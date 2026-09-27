using qlcuahangdcht.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qlcuahangdcht
{
    public partial class frmLichSuBanHang : Form
    {
        DataTable dtLichSu = new DataTable();
        string placeholderText = "Tìm theo Mã HĐ hoặc Tên NV...";

        public frmLichSuBanHang()
        {
            InitializeComponent();
            this.Load += frmLichSuBanHang_Load;

            if (btnLocNgay != null) { btnLocNgay.Click -= btnLocNgay_Click; btnLocNgay.Click += btnLocNgay_Click; }
            if (btnInLaiHoaDon != null) { btnInLaiHoaDon.Click -= btnInLaiHoaDon_Click; btnInLaiHoaDon.Click += btnInLaiHoaDon_Click; }

            if (txtTimKiem != null)
            {
                txtTimKiem.Enter -= txtTimKiem_Enter; txtTimKiem.Enter += txtTimKiem_Enter;
                txtTimKiem.Leave -= txtTimKiem_Leave; txtTimKiem.Leave += txtTimKiem_Leave;
                txtTimKiem.TextChanged -= txtTimKiem_TextChanged; txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            }

            // GẮN SỰ KIỆN CLICK ĐÚP CHUỘT VÀO DÒNG ĐỂ XEM HÓA ĐƠN NHANH
            if (dgvLichSu != null)
            {
                dgvLichSu.CellDoubleClick -= dgvLichSu_CellDoubleClick;
                dgvLichSu.CellDoubleClick += dgvLichSu_CellDoubleClick;
            }
        }

        private void frmLichSuBanHang_Load(object sender, EventArgs e)
        {
            if (txtTimKiem != null && (string.IsNullOrWhiteSpace(txtTimKiem.Text) || txtTimKiem.Text == placeholderText))
            {
                txtTimKiem.Text = placeholderText;
                txtTimKiem.ForeColor = Color.Gray;
            }
            TaiDuLieuTuCSDL();
        }

        // =========================================================================
        // TẢI DỮ LIỆU TỪ CSDL BẰNG ENTITY FRAMEWORK
        // =========================================================================
        private void TaiDuLieuTuCSDL()
        {
            try
            {
                using (var db = new CuaHangDbContext())
                {
                    // Dùng LINQ kết hợp các bảng HoaDon, NhanVien, KhachHang
                    var query = from hd in db.HoaDons
                                join nv in db.NhanViens on hd.MaNhanVien equals nv.MaNhanVien into nvGroup
                                from nv in nvGroup.DefaultIfEmpty()
                                join kh in db.KhachHangs on hd.MaKhachHang equals kh.MaKhachHang into khGroup
                                from kh in khGroup.DefaultIfEmpty()
                                orderby hd.NgayLap descending
                                select new
                                {
                                    MaHD = hd.MaHoaDon,
                                    ThoiGian = hd.NgayLap,
                                    NhanVien = nv != null ? nv.HoTen : hd.MaNhanVien,
                                    KhachHang = kh != null ? kh.HoTen : hd.MaKhachHang,
                                    TongTien = hd.TongTien
                                };

                    // Đổ dữ liệu vào DataTable để tận dụng lại logic lọc ngày/tìm kiếm mượt mà của bạn
                    dtLichSu = new DataTable();
                    dtLichSu.Columns.Add("Mã HĐ", typeof(string));
                    dtLichSu.Columns.Add("Thời Gian", typeof(DateTime));
                    dtLichSu.Columns.Add("Nhân Viên", typeof(string));
                    dtLichSu.Columns.Add("Khách Hàng", typeof(string));
                    dtLichSu.Columns.Add("Tổng Tiền", typeof(decimal));

                    foreach (var item in query)
                    {
                        dtLichSu.Rows.Add(item.MaHD, item.ThoiGian, item.NhanVien, item.KhachHang, item.TongTien);
                    }
                }
                HienThiVaTinhTong(dtLichSu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử bằng Entity Framework: " + ex.Message, "Lỗi EF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiVaTinhTong(DataTable dt)
        {
            if (dgvLichSu != null)
            {
                dgvLichSu.AutoGenerateColumns = true;
                dgvLichSu.DataSource = null;
                dgvLichSu.DataSource = dt;
                dgvLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLichSu.AllowUserToAddRows = false;
                dgvLichSu.ReadOnly = true;
                dgvLichSu.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Đảm bảo chọn được nguyên dòng

                if (dgvLichSu.Columns.Contains("Tổng Tiền"))
                    dgvLichSu.Columns["Tổng Tiền"].DefaultCellStyle.Format = "N0";
            }

            int tongSoDon = dt.Rows.Count;
            decimal tongDoanhThu = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["Tổng Tiền"] != DBNull.Value) tongDoanhThu += Convert.ToDecimal(row["Tổng Tiền"]);
            }

            if (lblTongSoHoaDon != null) lblTongSoHoaDon.Text = "Tổng số: " + tongSoDon + " đơn hàng";
            if (lblTongDoanhThu != null) lblTongDoanhThu.Text = "Tổng Doanh Thu: " + tongDoanhThu.ToString("N0") + " VNĐ";
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == placeholderText) { txtTimKiem.Text = ""; txtTimKiem.ForeColor = Color.Black; }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text)) { txtTimKiem.Text = placeholderText; txtTimKiem.ForeColor = Color.Gray; }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dtLichSu == null || dtLichSu.Rows.Count == 0) return;
            string tuKhoa = (txtTimKiem.Text != placeholderText) ? txtTimKiem.Text.Trim().ToLower() : "";
            if (string.IsNullOrEmpty(tuKhoa)) { HienThiVaTinhTong(dtLichSu); return; }

            DataTable dtFiltered = dtLichSu.Clone();
            foreach (DataRow row in dtLichSu.Rows)
            {
                if (row["Mã HĐ"].ToString().ToLower().Contains(tuKhoa) || row["Nhân Viên"].ToString().ToLower().Contains(tuKhoa) || row["Khách Hàng"].ToString().ToLower().Contains(tuKhoa))
                    dtFiltered.ImportRow(row);
            }
            HienThiVaTinhTong(dtFiltered);
        }

        private void btnLocNgay_Click(object sender, EventArgs e)
        {
            if (dtLichSu == null || dtLichSu.Rows.Count == 0) return;
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
            string tuKhoa = (txtTimKiem.Text != placeholderText) ? txtTimKiem.Text.Trim().ToLower() : "";

            DataTable dtFiltered = dtLichSu.Clone();
            foreach (DataRow row in dtLichSu.Rows)
            {
                if (DateTime.TryParse(row["Thời Gian"].ToString(), out DateTime ngayDonHang))
                {
                    bool thoaManNgay = (ngayDonHang >= tuNgay && ngayDonHang <= denNgay);
                    bool thoaManTuKhoa = string.IsNullOrEmpty(tuKhoa) || row["Mã HĐ"].ToString().ToLower().Contains(tuKhoa) || row["Nhân Viên"].ToString().ToLower().Contains(tuKhoa);
                    if (thoaManNgay && thoaManTuKhoa) dtFiltered.ImportRow(row);
                }
            }
            HienThiVaTinhTong(dtFiltered);
        }

        // Sự kiện gọi nút In khi click đúp chuột
        private void dgvLichSu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnInLaiHoaDon_Click(sender, e);
            }
        }

        // =========================================================================
        // HÀM LẤY CHI TIẾT SẢN PHẨM VÀ VẼ LẠI HÓA ĐƠN BẰNG ENTITY FRAMEWORK
        // =========================================================================
        private void btnInLaiHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.SelectedRows.Count > 0 || dgvLichSu.CurrentRow != null)
            {
                DataGridViewRow row = dgvLichSu.CurrentRow;
                if (row.IsNewRow) return;

                string maHD = row.Cells["Mã HĐ"].Value.ToString();

                try
                {
                    using (var db = new CuaHangDbContext())
                    {
                        // 1. Kéo thông tin tổng quan của hóa đơn bằng LINQ
                        var hdInfo = (from hd in db.HoaDons
                                      join nv in db.NhanViens on hd.MaNhanVien equals nv.MaNhanVien into nvGroup
                                      from nv in nvGroup.DefaultIfEmpty()
                                      join kh in db.KhachHangs on hd.MaKhachHang equals kh.MaKhachHang into khGroup
                                      from kh in khGroup.DefaultIfEmpty()
                                      where hd.MaHoaDon == maHD
                                      select new
                                      {
                                          hd.NgayLap,
                                          hd.TongTien,
                                          NhanVien = nv != null ? nv.HoTen : hd.MaNhanVien,
                                          KhachHang = kh != null ? kh.HoTen : "Khách vãng lai",
                                          SDT = kh != null ? kh.SDT : "Không có",
                                          DiaChi = kh != null ? kh.DiaChi : "Mua trực tiếp"
                                      }).FirstOrDefault();

                        if (hdInfo == null)
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu hóa đơn này trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string thoiGian = hdInfo.NgayLap != null ? Convert.ToDateTime(hdInfo.NgayLap).ToString("dd/MM/yyyy HH:mm:ss") : "";

                        // 2. Bắt đầu vẽ tờ bill
                        StringBuilder bill = new StringBuilder();
                        bill.AppendLine("===== IN LẠI HÓA ĐƠN =====");
                        bill.AppendLine("Mã Đơn Hàng: " + maHD);
                        bill.AppendLine("Thời gian: " + thoiGian);
                        bill.AppendLine("Nhân viên: " + hdInfo.NhanVien);
                        bill.AppendLine("Khách hàng: " + hdInfo.KhachHang);
                        bill.AppendLine("SĐT: " + hdInfo.SDT);
                        bill.AppendLine("Địa chỉ: " + hdInfo.DiaChi);
                        bill.AppendLine("--------------------------------------------------------------");

                        // 3. Kéo chi tiết các mặt hàng đã mua
                        var chiTietList = (from ct in db.ChiTietHoaDons
                                           join sp in db.SanPhams on ct.MaSanPham equals sp.MaSanPham
                                           where ct.MaHoaDon == maHD
                                           select new
                                           {
                                               sp.TenSanPham,
                                               ct.SoLuong,
                                               ct.ThanhTien
                                           }).ToList();

                        foreach (var item in chiTietList)
                        {
                            string tenSP = item.TenSanPham;
                            int sl = Convert.ToInt32(item.SoLuong);
                            double tien = Convert.ToDouble(item.ThanhTien);
                            bill.AppendLine("- " + tenSP + " (x" + sl + "): " + tien.ToString("N0") + " đ");
                        }

                        bill.AppendLine("--------------------------------------------------------------");
                        bill.AppendLine("TỔNG TIỀN:    " + Convert.ToDouble(hdInfo.TongTien).ToString("N0") + " VNĐ");
                        bill.AppendLine("\nBản sao lưu từ Lịch sử bán hàng.");

                        MessageBox.Show(bill.ToString(), "Chi Tiết Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi lôi chi tiết hóa đơn bằng Entity Framework: " + ex.Message, "Lỗi EF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng click chọn một dòng đơn hàng trên bảng để xem!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}