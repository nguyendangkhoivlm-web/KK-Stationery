using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmLichSuBanHang : Form
    {
        string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";
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

        private void TaiDuLieuTuCSDL()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            hd.MaHoaDon AS [Mã HĐ], 
                            hd.NgayLap AS [Thời Gian], 
                            ISNULL(nv.HoTen, hd.MaNhanVien) AS [Nhân Viên], 
                            ISNULL(kh.HoTen, hd.MaKhachHang) AS [Khách Hàng],
                            hd.TongTien AS [Tổng Tiền]
                        FROM HoaDon hd
                        LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
                        LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                        ORDER BY hd.NgayLap DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                    {
                        dtLichSu = new DataTable();
                        da.Fill(dtLichSu);
                    }
                }
                HienThiVaTinhTong(dtLichSu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // HÀM CHUI VÀO CSDL LẤY CHI TIẾT SẢN PHẨM VÀ VẼ LẠI HÓA ĐƠN
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
                    using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                    {
                        conn.Open();

                        // 1. Kéo thông tin tổng quan của hóa đơn
                        string sqlHD = @"
                            SELECT hd.NgayLap, hd.TongTien, 
                                   ISNULL(nv.HoTen, hd.MaNhanVien) AS NhanVien,
                                   ISNULL(kh.HoTen, 'Khách vãng lai') AS KhachHang,
                                   ISNULL(kh.SDT, 'Không có') AS SDT,
                                   ISNULL(kh.DiaChi, 'Mua trực tiếp') AS DiaChi
                            FROM HoaDon hd
                            LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
                            LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                            WHERE hd.MaHoaDon = @MaHD";

                        string thoiGian = "", nhanVien = "", khachHang = "", sdt = "", diaChi = "";
                        double tongTien = 0;

                        using (SqlCommand cmdHD = new SqlCommand(sqlHD, conn))
                        {
                            cmdHD.Parameters.AddWithValue("@MaHD", maHD);
                            using (SqlDataReader reader = cmdHD.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    thoiGian = Convert.ToDateTime(reader["NgayLap"]).ToString("dd/MM/yyyy HH:mm:ss");
                                    nhanVien = reader["NhanVien"].ToString();
                                    khachHang = reader["KhachHang"].ToString();
                                    sdt = reader["SDT"].ToString();
                                    diaChi = reader["DiaChi"].ToString();
                                    tongTien = Convert.ToDouble(reader["TongTien"]);
                                }
                                else
                                {
                                    MessageBox.Show("Không tìm thấy dữ liệu hóa đơn này trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                        // 2. Bắt đầu vẽ tờ bill
                        StringBuilder bill = new StringBuilder();
                        bill.AppendLine("===== IN LẠI HÓA ĐƠN =====");
                        bill.AppendLine("Mã Đơn Hàng: " + maHD);
                        bill.AppendLine("Thời gian: " + thoiGian);
                        bill.AppendLine("Nhân viên: " + nhanVien);
                        bill.AppendLine("Khách hàng: " + khachHang);
                        bill.AppendLine("SĐT: " + sdt);
                        bill.AppendLine("Địa chỉ: " + diaChi);
                        bill.AppendLine("--------------------------------------------------------------");

                        // 3. Kéo chi tiết các mặt hàng đã mua
                        string sqlCT = @"
                            SELECT sp.TenSanPham, ct.SoLuong, ct.DonGia, ct.ThanhTien
                            FROM ChiTietHoaDon ct
                            INNER JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham
                            WHERE ct.MaHoaDon = @MaHD";

                        using (SqlCommand cmdCT = new SqlCommand(sqlCT, conn))
                        {
                            cmdCT.Parameters.AddWithValue("@MaHD", maHD);
                            using (SqlDataReader readerCT = cmdCT.ExecuteReader())
                            {
                                while (readerCT.Read())
                                {
                                    string tenSP = readerCT["TenSanPham"].ToString();
                                    int sl = Convert.ToInt32(readerCT["SoLuong"]);
                                    double tien = Convert.ToDouble(readerCT["ThanhTien"]);
                                    bill.AppendLine("- " + tenSP + " (x" + sl + "): " + tien.ToString("N0") + " đ");
                                }
                            }
                        }

                        bill.AppendLine("--------------------------------------------------------------");
                        bill.AppendLine("TỔNG TIỀN:    " + tongTien.ToString("N0") + " VNĐ");
                        bill.AppendLine("\nBản sao lưu từ Lịch sử bán hàng.");

                        MessageBox.Show(bill.ToString(), "Chi Tiết Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi lôi chi tiết hóa đơn từ SQL: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng click chọn một dòng đơn hàng trên bảng để xem!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}