using qlcuahangdcht.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qlcuahangdcht
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
        // NÚT GIẢ LẬP ĐÃ NHẬN TIỀN (LƯU CSDL BẰNG ENTITY FRAMEWORK VÀ IN BIÊN LAI)
        // =========================================================================
        private void btnGiaLapThanhCong_Click(object sender, EventArgs e)
        {
            timerDemNguoc.Stop();

            try
            {
                using (var db = new CuaHangDbContext())
                {
                    // 1. Đảm bảo nhân viên NV01 luôn tồn tại
                    var nv = db.NhanViens.Find("NV01");
                    if (nv == null)
                    {
                        db.NhanViens.Add(new NhanVien { MaNhanVien = "NV01", HoTen = "Nhân Viên" });
                    }

                    // 2. Đảm bảo khách vãng lai KH01 luôn tồn tại (Chống lỗi khóa ngoại)
                    var kh = db.KhachHangs.Find("KH01");
                    if (kh == null)
                    {
                        db.KhachHangs.Add(new KhachHang { MaKhachHang = "KH01", HoTen = "Khách vãng lai", SDT = "Không có", DiaChi = "Tại quầy", Email = "Không có" });
                    }

                    // 3. Tạo và lưu Hóa Đơn mới
                    var hoaDonMoi = new HoaDon
                    {
                        MaHoaDon = maDonHang,
                        MaKhachHang = "KH01",
                        MaNhanVien = "NV01",
                        NgayLap = DateTime.Now,
                        TongTien = (decimal)tongTien
                    };
                    db.HoaDons.Add(hoaDonMoi);

                    // 4. Lưu Chi Tiết Hóa Đơn & Trừ Tồn Kho Sản Phẩm
                    if (dtSanPham != null)
                    {
                        foreach (DataRow row in dtSanPham.Rows)
                        {
                            string maSP = row["Mã Sản Phẩm"].ToString();
                            int soLuong = Convert.ToInt32(row["Số Lượng"]);
                            decimal gia = Convert.ToDecimal(row["Đơn Giá"]);
                            decimal tien = Convert.ToDecimal(row["Thành Tiền"]);

                            // Thêm chi tiết hóa đơn
                            var chiTiet = new ChiTietHoaDon
                            {
                                MaHoaDon = maDonHang,
                                MaSanPham = maSP,
                                SoLuong = soLuong,
                                DonGia = gia,
                                ThanhTien = tien
                            };
                            db.ChiTietHoaDons.Add(chiTiet);

                            // Trừ tồn kho sản phẩm tương ứng
                            var sanPham = db.SanPhams.Find(maSP);
                            if (sanPham != null)
                            {
                                sanPham.SoLuongTon -= soLuong;
                            }
                        }
                    }

                    // Lưu toàn bộ giao dịch xuống CSDL qua Entity Framework
                    db.SaveChanges();
                    KhoLichSu.VuaThanhToanXong = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu hóa đơn QR bằng Entity Framework: " + ex.Message, "Lỗi EF", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bill.AppendLine($"Tạm tính:      {tamTinh.ToString("N0")} đ");
            bill.AppendLine($"Thuế VAT:      {thueVAT.ToString("N0")} đ");
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