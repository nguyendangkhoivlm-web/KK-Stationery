using qlnhanvien;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmThanhToanQuaQR : Form
    {
        DataTable dtSanPham;
        double tamTinh, thueVAT, tongTien;
        string maDonHang;
        int thoiGianConLai = 300; // Đếm ngược 5 phút (300 giây)

        // Chuỗi kết nối chuẩn
        string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";

        // 1. Constructor mặc định
        public frmThanhToanQuaQR()
        {
            InitializeComponent();
        }

        // 2. Constructor nhận dữ liệu từ form Thanh Toán truyền sang
        public frmThanhToanQuaQR(DataTable dt, double sub, double tax, double total, string maDon)
        {
            InitializeComponent();
            this.dtSanPham = dt;
            this.tamTinh = sub;
            this.thueVAT = tax;
            this.tongTien = total;
            this.maDonHang = maDon;

            // Nối dây sự kiện bằng code cho chắc chắn 
            this.Load -= frmThanhToanQuaQR_Load;
            this.Load += frmThanhToanQuaQR_Load;

            btnGiaLapThanhCong.Click -= btnGiaLapThanhCong_Click;
            btnGiaLapThanhCong.Click += btnGiaLapThanhCong_Click;

            btnHuyThanhToan.Click -= btnHuyThanhToan_Click;
            btnHuyThanhToan.Click += btnHuyThanhToan_Click;

            btnQuayLai.Click -= btnQuayLai_Click;
            btnQuayLai.Click += btnQuayLai_Click;

            timerDemNguoc.Tick -= TimerDemNguoc_Tick;
            timerDemNguoc.Tick += TimerDemNguoc_Tick;
        }

        private void frmThanhToanQuaQR_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDonHang))
            {
                maDonHang = "HD" + DateTime.Now.ToString("ddHHmmss");
            }

            lblSoTien.Text = tongTien.ToString("N0") + " VNĐ";
            lblNoiDungChuyenKhoan.Text = "Nội dung CK: " + maDonHang;

            string urlQR = $"https://img.vietqr.io/image/MB-0987654321-compact2.png?amount={tongTien}&addInfo={maDonHang}&accountName=TRAN VU TUAN KIET";
            picMaQR.LoadAsync(urlQR);

            timerDemNguoc.Start();
        }

        private void TimerDemNguoc_Tick(object sender, EventArgs e)
        {
            thoiGianConLai--;

            int phut = thoiGianConLai / 60;
            int giay = thoiGianConLai % 60;

            lblThoiGianConLai.Text = string.Format("⏳ Mã QR có hiệu lực trong: {0:D2}:{1:D2}", phut, giay);

            if (thoiGianConLai <= 0)
            {
                timerDemNguoc.Stop();
                MessageBox.Show("Mã QR đã hết hạn! Vui lòng tạo lại đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnGiaLapThanhCong.Enabled = false;
            }
        }

        // =========================================================================
        // NÚT GIẢ LẬP ĐÃ NHẬN TIỀN (LƯU CSDL VÀ IN BIÊN LAI)
        // =========================================================================
        private void btnGiaLapThanhCong_Click(object sender, EventArgs e)
        {
            timerDemNguoc.Stop();

            try
            {
                using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. BẢO VỆ NHÂN VIÊN
                        string maNhanVienChuan = "NV01";
                        using (SqlCommand cmdNV = new SqlCommand("IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNhanVien = 'NV01') INSERT INTO NhanVien (MaNhanVien, HoTen) VALUES ('NV01', N'Admin')", conn, transaction))
                        {
                            cmdNV.ExecuteNonQuery();
                        }

                        using (SqlCommand cmdGetNV = new SqlCommand("SELECT TOP 1 MaNhanVien FROM NhanVien", conn, transaction))
                        {
                            object resNV = cmdGetNV.ExecuteScalar();
                            if (resNV != null) maNhanVienChuan = resNV.ToString();
                        }

                        // 2. BẢO VỆ KHÁCH HÀNG
                        string maKhachHangChuan = "KH01";
                        using (SqlCommand cmdKH = new SqlCommand("IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKhachHang = 'KH01') INSERT INTO KhachHang (MaKhachHang, HoTen, SDT, DiaChi, Email) VALUES ('KH01', N'Khách vãng lai', N'Không có', N'Tại quầy', N'Không có')", conn, transaction))
                        {
                            cmdKH.ExecuteNonQuery();
                        }

                        // 3. LƯU VÀO BẢNG HÓA ĐƠN
                        string sqlInsertHoaDon = "INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayLap, TongTien) VALUES (@MaHD, @MaKH, @MaNV, @NgayLap, @TongTien)";
                        using (SqlCommand cmd = new SqlCommand(sqlInsertHoaDon, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", maDonHang);
                            cmd.Parameters.AddWithValue("@MaKH", maKhachHangChuan);
                            cmd.Parameters.AddWithValue("@MaNV", maNhanVienChuan);
                            cmd.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                            cmd.Parameters.AddWithValue("@TongTien", (decimal)tongTien);
                            cmd.ExecuteNonQuery();
                        }

                        // 4. LƯU CHI TIẾT & TRỪ TỒN KHO
                        if (dtSanPham != null)
                        {
                            foreach (DataRow row in dtSanPham.Rows)
                            {
                                string maSP = row["Mã Sản Phẩm"].ToString();
                                int soLuong = Convert.ToInt32(row["Số Lượng"]);
                                double gia = Convert.ToDouble(row["Đơn Giá"]);
                                double tien = Convert.ToDouble(row["Thành Tiền"]);

                                string sqlInsertCTHD = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien) VALUES (@MaHD, @MaSP, @SL, @Gia, @Tien)";
                                using (SqlCommand cmdCTHD = new SqlCommand(sqlInsertCTHD, conn, transaction))
                                {
                                    cmdCTHD.Parameters.AddWithValue("@MaHD", maDonHang);
                                    cmdCTHD.Parameters.AddWithValue("@MaSP", maSP);
                                    cmdCTHD.Parameters.AddWithValue("@SL", soLuong);
                                    cmdCTHD.Parameters.AddWithValue("@Gia", gia);
                                    cmdCTHD.Parameters.AddWithValue("@Tien", tien);
                                    cmdCTHD.ExecuteNonQuery();
                                }

                                string sqlUpdateTonKho = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL WHERE MaSanPham = @MaSP";
                                using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateTonKho, conn, transaction))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@SL", soLuong);
                                    cmdUpdate.Parameters.AddWithValue("@MaSP", maSP);
                                    cmdUpdate.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        KhoLichSu.VuaThanhToanXong = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi lưu hóa đơn QR vào CSDL: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // =========================================================
            // 5. TẠO VÀ HIỂN THỊ HÓA ĐƠN CHI TIẾT LÊN MÀN HÌNH
            // =========================================================
            StringBuilder bill = new StringBuilder();
            bill.AppendLine("===== THANH TOÁN QR THÀNH CÔNG =====\n");
            bill.AppendLine("Mã Đơn Hàng: " + maDonHang);
            bill.AppendLine("Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            bill.AppendLine("Khách hàng: Khách vãng lai");
            bill.AppendLine("Phương thức: Chuyển khoản VietQR");
            bill.AppendLine("--------------------------------------------------------------");

            if (dtSanPham != null)
            {
                foreach (DataRow row in dtSanPham.Rows)
                {
                    string tenSP = row["Tên Sản Phẩm"].ToString();
                    string sl = row["Số Lượng"].ToString();
                    string tien = Convert.ToDouble(row["Thành Tiền"]).ToString("N0");
                    bill.AppendLine($"- {tenSP} (x{sl}): {tien} đ");
                }
            }

            bill.AppendLine("--------------------------------------------------------------");
            bill.AppendLine($"Tạm tính:     {tamTinh.ToString("N0")} đ");
            bill.AppendLine($"Thuế VAT:     {thueVAT.ToString("N0")} đ");
            bill.AppendLine($"TỔNG TIỀN:    {tongTien.ToString("N0")} VNĐ");
            bill.AppendLine("\nĐã nhận tiền. Cảm ơn quý khách!");

            MessageBox.Show(bill.ToString(), "Biên Lai Giao Dịch", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Nhảy sang Lịch Sử Bán Hàng sau khi xem xong hóa đơn
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmLichSuBanHang(), null);
            }
        }

        private void btnHuyThanhToan_Click(object sender, EventArgs e)
        {
            timerDemNguoc.Stop();

            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmThanhToan(dtSanPham, tamTinh, thueVAT, (double)tongTien), null);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            btnHuyThanhToan_Click(sender, e);
        }
    }
}