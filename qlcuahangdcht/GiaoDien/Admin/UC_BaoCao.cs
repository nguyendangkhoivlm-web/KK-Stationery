using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace qlcuahangdcht
{
    public partial class UC_BaoCao : UserControl
    {
        public UC_BaoCao()
        {
            InitializeComponent();

            // Nối dây sự kiện ngay từ lúc khởi tạo
            this.Load += UC_BaoCao_Load;
            btnLocDuLieu.Click += btnLocDuLieu_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;
        }

        private void UC_BaoCao_Load(object sender, EventArgs e)
        {
            // Set ngày mặc định: Từ đầu tháng đến ngày hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            // Nạp giá trị mặc định cho ComboBox Loại báo cáo nếu chưa có
            if (cboLoaiBaoCao.Items.Count == 0)
            {
                cboLoaiBaoCao.Items.Add("Tất cả doanh thu");
                cboLoaiBaoCao.SelectedIndex = 0;
            }

            LoadDuLieuBaoCao();
        }

        private void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            LoadDuLieuBaoCao();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dữ liệu để xuất không
            if (dgvChiTietKPI.Rows.Count == 0 || dgvChiTietKPI.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Mở hộp thoại cho phép người dùng chọn nơi lưu file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            sfd.Title = "Lưu báo cáo Excel";
            // Đặt tên file mặc định có kèm ngày giờ để không bị trùng
            sfd.FileName = "BaoCaoDoanhThu_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Sử dụng ClosedXML để tạo file Excel
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Báo Cáo KPI");

                        // 4. In dòng Tiêu đề (Header) từ DataGridView
                        for (int i = 0; i < dgvChiTietKPI.Columns.Count; i++)
                        {
                            var cell = worksheet.Cell(1, i + 1);
                            cell.Value = dgvChiTietKPI.Columns[i].HeaderText;

                            // Format cho Header đẹp mắt: In đậm, nền xanh dương nhạt
                            cell.Style.Font.Bold = true;
                            cell.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        }

                        // 5. Đổ dữ liệu các dòng từ DataGridView vào Excel
                        for (int i = 0; i < dgvChiTietKPI.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvChiTietKPI.Columns.Count; j++)
                            {
                                var cellValue = dgvChiTietKPI.Rows[i].Cells[j].Value;
                                worksheet.Cell(i + 2, j + 1).Value = cellValue != null ? cellValue.ToString() : "";
                            }
                        }

                        // Tự động căn chỉnh độ rộng các cột cho vừa vặn nội dung
                        worksheet.Columns().AdjustToContents();

                        // 6. Lưu file xuống ổ cứng
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi xuất file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // =========================================================================
        // HÀM LỌC VÀ TÍNH TOÁN BÁO CÁO BẰNG ENTITY FRAMEWORK
        // =========================================================================
        private void LoadDuLieuBaoCao()
        {
            try
            {
                using (var db = new CuaHangDbContext())
                {
                    // 1. Lấy khoảng thời gian từ DateTimePicker
                    DateTime tuNgay = dtpTuNgay.Value.Date;
                    DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

                    // 2. Kéo dữ liệu hóa đơn và chi tiết trong khoảng thời gian
                    var query = from hd in db.HoaDons
                                join ct in db.ChiTietHoaDons on hd.MaHoaDon equals ct.MaHoaDon
                                join sp in db.SanPhams on ct.MaSanPham equals sp.MaSanPham
                                join dm in db.DanhMucs on sp.MaDanhMuc equals dm.MaDanhMuc into dmGroup
                                from dm in dmGroup.DefaultIfEmpty()
                                where hd.NgayLap >= tuNgay && hd.NgayLap <= denNgay
                                select new
                                {
                                    hd.MaHoaDon,
                                    hd.NgayLap,
                                    hd.TongTien,
                                    ct.SoLuong,
                                    ThanhTienCT = ct.ThanhTien,
                                    TenDanhMuc = dm != null ? dm.TenDanhMuc : "Khác"
                                };

                    var data = query.ToList();

                    if (data.Count == 0)
                    {
                        // Nếu khoảng thời gian này không bán được gì thì reset các con số về 0
                        ResetBaoCao();
                        return;
                    }

                    // 3. TÍNH CÁC CHỈ SỐ TỔNG QUAN (KPI) TRÊN BỐN Ô TRẮNG
                    int soHoaDon = data.Select(x => x.MaHoaDon).Distinct().Count();
                    int soLuongBan = data.Sum(x => (int)x.SoLuong);
                    decimal tongDoanhThu = data.GroupBy(x => x.MaHoaDon).Sum(g => (decimal)g.First().TongTien);
                    decimal tongTienLoi = tongDoanhThu * 0.3m; // Lợi nhuận tạm tính 30% doanh thu

                    // Đổ dữ liệu lên giao diện
                    lblSoDoanhThuBC.Text = tongDoanhThu.ToString("N0") + " đ";
                    lblSoTienLoi.Text = tongTienLoi.ToString("N0") + " đ";
                    lblSoHoaDon.Text = soHoaDon.ToString();
                    lblSoLuongBan.Text = soLuongBan.ToString();

                    // 4. ĐỔ DỮ LIỆU VÀO BẢNG CHI TIẾT KPI (dgvChiTietKPI)
                    var dataBang = data.GroupBy(x => x.NgayLap.Value.Date).Select(g => new
                    {
                        Ngày_Bán = g.Key.ToString("dd/MM/yyyy"),
                        Số_Lượng_Bán = g.Sum(x => x.SoLuong),
                        Tổng_Thu = g.GroupBy(h => h.MaHoaDon).Sum(h => h.First().TongTien),
                        Tiền_Lời = g.GroupBy(h => h.MaHoaDon).Sum(h => h.First().TongTien) * 0.3m
                    }).ToList();

                    dgvChiTietKPI.DataSource = null;
                    dgvChiTietKPI.DataSource = dataBang;

                    // Định dạng hiển thị tiền tệ trên bảng
                    if (dgvChiTietKPI.Columns.Contains("Tổng_Thu"))
                        dgvChiTietKPI.Columns["Tổng_Thu"].DefaultCellStyle.Format = "N0";
                    if (dgvChiTietKPI.Columns.Contains("Tiền_Lời"))
                        dgvChiTietKPI.Columns["Tiền_Lời"].DefaultCellStyle.Format = "N0";
                    dgvChiTietKPI.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // 5. VẼ BIỂU ĐỒ TRÒN THEO DANH MỤC SẢN PHẨM (chartDanhMuc)
                    var dataBieuDo = data.GroupBy(x => x.TenDanhMuc).Select(g => new
                    {
                        DanhMuc = g.Key,
                        SoLuong = g.Sum(x => x.SoLuong)
                    }).ToList();

                    chartDanhMuc.Series.Clear();
                    Series series = new Series("TyTrong");
                    series.ChartType = SeriesChartType.Pie;
                    series.IsValueShownAsLabel = true; // Hiện số liệu trực tiếp trên múi biểu đồ

                    foreach (var item in dataBieuDo)
                    {
                        series.Points.AddXY(item.DanhMuc, item.SoLuong);
                    }
                    chartDanhMuc.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo bằng EF: " + ex.Message, "Lỗi EF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetBaoCao()
        {
            lblSoDoanhThuBC.Text = "0 đ";
            lblSoTienLoi.Text = "0 đ";
            lblSoHoaDon.Text = "0";
            lblSoLuongBan.Text = "0";
            dgvChiTietKPI.DataSource = null;
            chartDanhMuc.Series.Clear();
        }
    }
}