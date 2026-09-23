using qlnhanvien;
using System;
using System.Data;
using System.Data.SqlClient; // BẮT BUỘC THÊM THƯ VIỆN NÀY ĐỂ KẾT NỐI SQL
using System.Drawing;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmThanhToanQuaQR : Form
    {
        DataTable dtSanPham;
        double tamTinh, thueVAT, tongTien;
        string maDonHang;
        int thoiGianConLai = 300; // Đếm ngược 5 phút (300 giây)

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

            // =========================================================
            // Nối dây sự kiện bằng code cho chắc chắn (Chuẩn cơ bản)
            // =========================================================
            this.Load += frmThanhToanQuaQR_Load;
            btnGiaLapThanhCong.Click += btnGiaLapThanhCong_Click;
            btnHuyThanhToan.Click += btnHuyThanhToan_Click;
            btnQuayLai.Click += btnQuayLai_Click;

            timerDemNguoc.Tick += TimerDemNguoc_Tick;
        }

        private void frmThanhToanQuaQR_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDonHang))
            {
                maDonHang = "HD_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            }

            // Hiển thị số tiền và mã đơn lên giao diện
            lblSoTien.Text = tongTien.ToString("N0") + " VNĐ";
            lblNoiDungChuyenKhoan.Text = "Nội dung CK: " + maDonHang;

            // Gọi API sinh mã QR tự động điền số tiền và nội dung
            string urlQR = $"https://img.vietqr.io/image/MB-0987654321-compact2.png?amount={tongTien}&addInfo={maDonHang}&accountName=TRAN VU TUAN KIET";
            picMaQR.LoadAsync(urlQR);

            // Bắt đầu chạy đồng hồ đếm ngược
            timerDemNguoc.Start();
        }

        private void TimerDemNguoc_Tick(object sender, EventArgs e)
        {
            thoiGianConLai--; // Trừ đi 1 giây

            // Tính ra phút và giây
            int phut = thoiGianConLai / 60;
            int giay = thoiGianConLai % 60;

            // Cập nhật lên Label
            lblThoiGianConLai.Text = string.Format("⏳ Mã QR có hiệu lực trong: {0:D2}:{1:D2}", phut, giay);

            // Hết giờ thì dừng đồng hồ và khóa nút bấm
            if (thoiGianConLai <= 0)
            {
                timerDemNguoc.Stop();
                MessageBox.Show("Mã QR đã hết hạn! Vui lòng tạo lại đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnGiaLapThanhCong.Enabled = false;
            }
        }

        // =========================================================================
        // NÚT GIẢ LẬP ĐÃ NHẬN TIỀN (LƯU VÀO CSDL SQL SERVER)
        // =========================================================================
        private void btnGiaLapThanhCong_Click(object sender, EventArgs e)
        {
            timerDemNguoc.Stop(); // Nhận được tiền thì dừng đếm ngược

            string maNhanVien = !string.IsNullOrEmpty(PhienDangNhap.MaNhanVien) ? PhienDangNhap.MaNhanVien : "NV01";
            string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";

            try
            {
                using (SqlConnection con = new SqlConnection(chuoiKetNoi))
                {
                    con.Open();

                    // 1. Lưu vào bảng HoaDon
                    string sqlInsertHoaDon = "INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayLap, TongTien) VALUES (@MaHD, 'KH03', @MaNV, @NgayLap, @TongTien)";
                    using (SqlCommand cmd = new SqlCommand(sqlInsertHoaDon, con))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", maDonHang);
                        cmd.Parameters.AddWithValue("@MaNV", maNhanVien);
                        cmd.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TongTien", (decimal)tongTien);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Lưu chi tiết và trừ tồn kho
                    if (dtSanPham != null)
                    {
                        foreach (DataRow row in dtSanPham.Rows)
                        {
                            string maSP = row["Mã Sản Phẩm"].ToString();
                            int soLuong = Convert.ToInt32(row["Số Lượng"]);
                            double gia = Convert.ToDouble(row["Đơn Giá"]);
                            double tien = Convert.ToDouble(row["Thành Tiền"]);

                            // Lưu ChiTietHoaDon
                            string sqlInsertCTHD = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien) VALUES (@MaHD, @MaSP, @SL, @Gia, @Tien)";
                            using (SqlCommand cmdCTHD = new SqlCommand(sqlInsertCTHD, con))
                            {
                                cmdCTHD.Parameters.AddWithValue("@MaHD", maDonHang);
                                cmdCTHD.Parameters.AddWithValue("@MaSP", maSP);
                                cmdCTHD.Parameters.AddWithValue("@SL", soLuong);
                                cmdCTHD.Parameters.AddWithValue("@Gia", gia);
                                cmdCTHD.Parameters.AddWithValue("@Tien", tien);
                                cmdCTHD.ExecuteNonQuery();
                            }

                            // Trừ tồn kho
                            string sqlUpdateTonKho = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL WHERE MaSanPham = @MaSP";
                            using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateTonKho, con))
                            {
                                cmdUpdate.Parameters.AddWithValue("@SL", soLuong);
                                cmdUpdate.Parameters.AddWithValue("@MaSP", maSP);
                                cmdUpdate.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // Bật cờ hiệu để trang Bán Hàng tự dọn giỏ hàng
                KhoLichSu.VuaThanhToanXong = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu hóa đơn QR vào CSDL: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đã nhận được tiền qua mã QR thành công!\nHệ thống vừa lưu hóa đơn vào cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Nhảy sang form In Hóa Đơn
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmThongTinDeIn(dtSanPham, tamTinh, thueVAT, (double)tongTien), null);
            }
        }

        // Nút Hủy Bỏ (Nhảy về trang Tổng kết thanh toán)
        private void btnHuyThanhToan_Click(object sender, EventArgs e)
        {
            timerDemNguoc.Stop();

            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmThanhToan(dtSanPham, tamTinh, thueVAT, (double)tongTien), null);
            }
        }

        // Nút Quay Lại ở thanh tiêu đề (Dùng chung lệnh với nút Hủy)
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            btnHuyThanhToan_Click(sender, e);
        }
    }
}