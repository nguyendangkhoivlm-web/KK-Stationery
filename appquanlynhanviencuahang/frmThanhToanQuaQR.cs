using qlnhanvien;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmThanhToanQuaQR : Form
    {
        // Các biến nhận dữ liệu từ form trước truyền sang
        DataTable dtSanPham;
        double tamTinh, thueVAT, tongTien;
        string maDonHang;
        int thoiGianConLai = 300; // Đếm ngược 5 phút

        // 1. Constructor mặc định (dùng cho Designer)
        public frmThanhToanQuaQR()
        {
            InitializeComponent();
        }

        // 2. Constructor chính nhận dữ liệu thanh toán
        public frmThanhToanQuaQR(DataTable dt, double sub, double tax, double total, string maDon)
        {
            InitializeComponent();

            this.dtSanPham = dt;
            this.tamTinh = sub;
            this.thueVAT = tax;
            this.tongTien = total;
            this.maDonHang = maDon;
        }

        private void frmThanhToanQuaQR_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maDonHang)) maDonHang = "HD_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // Hiển thị số tiền và mã đơn
            if (lblSoTien != null) lblSoTien.Text = tongTien.ToString("N0") + " VNĐ";
            if (lblNoiDungChuyenKhoan != null) lblNoiDungChuyenKhoan.Text = "Nội dung CK: " + maDonHang;

            // Gọi API sinh mã QR thật tự động điền tiền
            string urlQR = $"https://img.vietqr.io/image/MB-0987654321-compact2.png?amount={tongTien}&addInfo={maDonHang}&accountName=TRAN VU TUAN KIET";
            if (picMaQR != null) picMaQR.LoadAsync(urlQR);

            // Chạy đồng hồ đếm ngược
            if (timerDemNguoc != null) timerDemNguoc.Start();
        }

        private void TimerDemNguoc_Tick(object sender, EventArgs e)
        {
            thoiGianConLai--;
            int phut = thoiGianConLai / 60;
            int giay = thoiGianConLai % 60;

            if (lblThoiGianConLai != null)
            {
                lblThoiGianConLai.Text = string.Format("⏳ Mã QR có hiệu lực trong: {0:D2}:{1:D2}", phut, giay);
            }

            if (thoiGianConLai <= 0)
            {
                timerDemNguoc.Stop();
                MessageBox.Show("Mã QR đã hết hạn! Vui lòng tạo lại đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (btnGiaLapThanhCong != null) btnGiaLapThanhCong.Enabled = false;
            }
        }

        // =========================================================================
        // NÚT GIẢ LẬP ĐÃ NHẬN TIỀN (Lưu lịch sử, báo SMS giả lập, mở Bill)
        // =========================================================================
        private void btnGiaLapThanhCong_Click(object sender, EventArgs e)
        {

        }

        // =========================================================================
        // NÚT HỦY BỎ / QUAY LẠI (Nhảy về trang Tổng kết thanh toán)
        // =========================================================================
        private void btnHuyThanhToan_Click(object sender, EventArgs e)
        {

        }

        // Dùng chung một hàm hủy cho cả nút Quay Lại ở thanh tiêu đề
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            btnHuyThanhToan_Click(sender, e);
        }
    }
}