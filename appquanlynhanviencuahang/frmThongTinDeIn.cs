using appquanlynhanviencuahang;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace qlnhanvien
{
    public partial class frmThongTinDeIn : Form
    {
        DataTable dtSanPham = new DataTable();
        double tongTien = 0;
        double tamTinh = 0;
        double thueVAT = 0;

        // Cờ lưu mã khách hàng (Mặc định KH01 là khách vãng lai)
        string maKhachHangHienTai = "KH01";

        // Chuỗi kết nối CSDL của bạn
        string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";

        public frmThongTinDeIn()
        {
            InitializeComponent();
            NoiDaySuKienChoNutBam();
        }

        public frmThongTinDeIn(DataTable dt, double tamTinh, double thue, double tong)
        {
            InitializeComponent();
            NoiDaySuKienChoNutBam();

            if (dt != null) this.dtSanPham = dt.Copy();
            this.tamTinh = tamTinh;
            this.thueVAT = thue;
            this.tongTien = tong;
        }

        private void NoiDaySuKienChoNutBam()
        {
            if (btnKhachLe != null) { btnKhachLe.Click -= btnKhachLe_Click; btnKhachLe.Click += btnKhachLe_Click; }
            if (btnInHoaDon != null) { btnInHoaDon.Click -= btnInHoaDon_Click; btnInHoaDon.Click += btnInHoaDon_Click; }
            if (btnDangKyMoi != null) { btnDangKyMoi.Click -= btnDangKyMoi_Click; btnDangKyMoi.Click += btnDangKyMoi_Click; }
            if (btnHuyBo != null) { btnHuyBo.Click -= btnHuyBo_Click; btnHuyBo.Click += btnHuyBo_Click; }
            if (btnQuayLai != null) { btnQuayLai.Click -= btnQuayLai_Click; btnQuayLai.Click += btnQuayLai_Click; }
        }

        private void frmThongTinDeIn_Load(object sender, EventArgs e)
        {
            lblTongTienHoaDon.Text = "Tổng tiền thanh toán: " + tongTien.ToString("N0") + " VNĐ";
            txtSoDienThoai.MaxLength = 10;
            txtSoDienThoai.TextChanged -= TxtSoDienThoai_TextChanged;
            txtSoDienThoai.TextChanged += TxtSoDienThoai_TextChanged;
            txtSoDienThoai.KeyPress -= TxtSoDienThoai_KeyPress;
            txtSoDienThoai.KeyPress += TxtSoDienThoai_KeyPress;
            txtSoDienThoai.Focus();
        }

        private void TxtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void TxtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSoDienThoai.Text.Trim();
            if (sdt == "0901234567" || sdt == "0912345678") { lblTrangThaiTimKiem.Text = "✓ Đã tìm thấy KH!"; lblTrangThaiTimKiem.ForeColor = Color.LimeGreen; }
            else if (sdt.Length == 10) { lblTrangThaiTimKiem.Text = "ℹ Khách hàng mới."; lblTrangThaiTimKiem.ForeColor = Color.OrangeRed; }
            else { lblTrangThaiTimKiem.Text = ""; }
        }

        private void btnKhachLe_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = "Khách vãng lai"; txtSoDienThoai.Text = "Không có";
            txtDiaChi.Text = "Mua trực tiếp"; txtEmail.Text = "Không có";
            maKhachHangHienTai = "KH01";
            MessageBox.Show("Đã điền tự động thông tin Khách Lẻ!\nVui lòng bấm 'In Hóa Đơn' để hoàn tất.", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang.Text.Trim() == "") { MessageBox.Show("Vui lòng nhập Tên!"); return; }
            string sdt = txtSoDienThoai.Text.Trim();
            if (sdt != "" && sdt != "Không có" && sdt.Length != 10) { MessageBox.Show("SĐT không hợp lệ!"); return; }
            if (sdt.Length == 10 && maKhachHangHienTai == "KH01") { maKhachHangHienTai = "KH" + DateTime.Now.ToString("mmss"); }
            ThucHienInHoaDon();
        }

        private void btnDangKyMoi_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang.Text.Trim() == "" || txtSoDienThoai.Text.Trim() == "") { MessageBox.Show("Nhập đủ Họ Tên và SĐT!"); return; }
            try
            {
                using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                {
                    conn.Open();
                    string maKHMoi = "KH" + DateTime.Now.ToString("mmss");
                    string sqlThem = "INSERT INTO KhachHang (MaKhachHang, HoTen, SDT, DiaChi, Email) VALUES (@MaKH, @HoTen, @SDT, @DiaChi, @Email)";
                    using (SqlCommand cmd = new SqlCommand(sqlThem, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", maKHMoi);
                        cmd.Parameters.AddWithValue("@HoTen", txtTenKhachHang.Text.Trim());
                        cmd.Parameters.AddWithValue("@SDT", txtSoDienThoai.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(txtDiaChi.Text.Trim()) ? "Đồng Tháp" : txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(txtEmail.Text.Trim()) ? "Không" : txtEmail.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                    maKhachHangHienTai = maKHMoi;
                }
                MessageBox.Show("Lưu Khách hàng thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTrangThaiTimKiem.Text = "✓ Đã lưu thông tin khách hàng mới!";
                lblTrangThaiTimKiem.ForeColor = Color.LimeGreen;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null) mainForm.OpenChildForm(new frmBanHang(), null);
            else this.Close();
        }

        // =========================================================================
        // PHỤC HỒI LẠI HÓA ĐƠN GIẤY CHI TIẾT + BẢO VỆ DỮ LIỆU SQL
        // =========================================================================
        private void ThucHienInHoaDon()
        {
            string maDonHang = "HD" + DateTime.Now.ToString("ddHHmmss");
            string thoiGian = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // 1. CHUẨN BỊ MẶT CHỮ CHO BẢN IN HÓA ĐƠN
            StringBuilder bill = new StringBuilder();
            bill.AppendLine("ĐANG GỬI LỆNH IN HÓA ĐƠN...\n");
            bill.AppendLine("Mã Đơn Hàng: " + maDonHang);
            bill.AppendLine("Thời gian: " + thoiGian);
            bill.AppendLine("Khách hàng: " + (txtTenKhachHang.Text != "" ? txtTenKhachHang.Text : "Khách vãng lai"));
            bill.AppendLine("SĐT: " + (txtSoDienThoai.Text != "" ? txtSoDienThoai.Text : "Không có"));
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text != "Không có")
            {
                bill.AppendLine("Email: " + txtEmail.Text.Trim());
            }
            bill.AppendLine("--------------------------------------------------------------");

            // 2. LƯU DỮ LIỆU VÀ GHI CHI TIẾT SẢN PHẨM VÀO HÓA ĐƠN
            if (dtSanPham != null && dtSanPham.Rows.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction(); // Bật chế độ giao dịch an toàn

                    try
                    {
                        string maNhanVienChuan = "NV01";
                        using (SqlCommand cmdNV = new SqlCommand("IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNhanVien = 'NV01') INSERT INTO NhanVien (MaNhanVien, HoTen) VALUES ('NV01', N'Admin')", conn, transaction))
                            cmdNV.ExecuteNonQuery();

                        using (SqlCommand cmdKH = new SqlCommand("IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKhachHang = @MaKH) INSERT INTO KhachHang (MaKhachHang, HoTen, SDT, DiaChi, Email) VALUES (@MaKH, @TenKH, @SDT, @DiaChi, @Email)", conn, transaction))
                        {
                            cmdKH.Parameters.AddWithValue("@MaKH", maKhachHangHienTai);
                            cmdKH.Parameters.AddWithValue("@TenKH", txtTenKhachHang.Text != "" ? txtTenKhachHang.Text : "Khách vãng lai");
                            cmdKH.Parameters.AddWithValue("@SDT", txtSoDienThoai.Text != "" ? txtSoDienThoai.Text : "Không có");
                            cmdKH.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(txtDiaChi.Text) ? "Tại quầy" : txtDiaChi.Text);
                            cmdKH.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(txtEmail.Text) ? "Không có" : txtEmail.Text);
                            cmdKH.ExecuteNonQuery();
                        }

                        using (SqlCommand cmdHD = new SqlCommand("INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayLap, TongTien) VALUES (@MaHD, @MaKH, @MaNV, @NgayLap, @TongTien)", conn, transaction))
                        {
                            cmdHD.Parameters.AddWithValue("@MaHD", maDonHang);
                            cmdHD.Parameters.AddWithValue("@MaKH", maKhachHangHienTai);
                            cmdHD.Parameters.AddWithValue("@MaNV", maNhanVienChuan);
                            cmdHD.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                            cmdHD.Parameters.AddWithValue("@TongTien", tongTien);
                            cmdHD.ExecuteNonQuery();
                        }

                        foreach (DataRow row in dtSanPham.Rows)
                        {
                            int sl = Convert.ToInt32(row["Số Lượng"]);
                            double gia = Convert.ToDouble(row["Đơn Giá"]);
                            double tien = Convert.ToDouble(row["Thành Tiền"]);
                            string maSP = row["Mã Sản Phẩm"].ToString();
                            string tenSP = row["Tên Sản Phẩm"].ToString();

                            // Đưa mặt hàng vào phiếu in
                            bill.AppendLine("- " + tenSP + " (x" + sl + "): " + tien.ToString("N0") + " đ");

                            using (SqlCommand cmdCT = new SqlCommand("INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien) VALUES (@MaHD, @MaSP, @SL, @Gia, @Tien)", conn, transaction))
                            {
                                cmdCT.Parameters.AddWithValue("@MaHD", maDonHang);
                                cmdCT.Parameters.AddWithValue("@MaSP", maSP);
                                cmdCT.Parameters.AddWithValue("@SL", sl);
                                cmdCT.Parameters.AddWithValue("@Gia", gia);
                                cmdCT.Parameters.AddWithValue("@Tien", tien);
                                cmdCT.ExecuteNonQuery();
                            }

                            using (SqlCommand cmdKho = new SqlCommand("UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL WHERE MaSanPham = @MaSP", conn, transaction))
                            {
                                cmdKho.Parameters.AddWithValue("@SL", sl);
                                cmdKho.Parameters.AddWithValue("@MaSP", maSP);
                                cmdKho.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi lưu hóa đơn vào cơ sở dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // 3. TỔNG KẾT VÀ IN HÓA ĐƠN LÊN MÀN HÌNH
            bill.AppendLine("--------------------------------------------------------------");
            bill.AppendLine("Tạm tính:     " + tamTinh.ToString("N0") + " đ");
            bill.AppendLine("Thuế VAT:     " + thueVAT.ToString("N0") + " đ");
            bill.AppendLine("TỔNG TIỀN:    " + tongTien.ToString("N0") + " VNĐ");
            bill.AppendLine("\nĐã in thành công hóa đơn và lưu Lịch sử bán hàng!");

            // Bật bảng in hóa đơn như cũ
            MessageBox.Show(bill.ToString(), "Biên Lai Giao Dịch", MessageBoxButtons.OK, MessageBoxIcon.Information);

            KhoLichSu.VuaThanhToanXong = true;

            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null) mainForm.OpenChildForm(new frmBanHang(), null);
            else this.Close();
        }

        private void tblCanGiua_Paint(object sender, PaintEventArgs e) { }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null) mainForm.OpenChildForm(new frmThanhToan(dtSanPham, tamTinh, thueVAT, tongTien), null);
            else this.Close();
        }
    }
}