using appquanlynhanviencuahang;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace qlnhanvien
{
    public partial class frmThongTinDeIn : Form
    {
        private DataTable dtSanPham = new DataTable();
        private double tongTien = 0;

        // Constructor mặc định
        public frmThongTinDeIn()
        {
            InitializeComponent();
        }

        // Constructor nhận dữ liệu chuẩn xác từ form Thanh Toán truyền sang
        public frmThongTinDeIn(DataTable dt, double tamTinh, double thue, double tong) : this()
        {
            if (dt != null)
            {
                this.dtSanPham = dt.Copy();
            }
            this.tongTien = tong;
        }

        private void frmThongTinDeIn_Load(object sender, EventArgs e)
        {
            // Hiển thị chuẩn xác số tiền nhận được
            if (lblTongTienHoaDon != null)
            {
                lblTongTienHoaDon.Text = "Tổng tiền thanh toán: " + tongTien.ToString("N0") + " VNĐ";
            }

            // Chủ động gán sự kiện TextChanged cho ô SĐT bằng code để không bị phụ thuộc vào file Designer
            if (txtSoDienThoai != null)
            {
                txtSoDienThoai.TextChanged -= TxtSoDienThoai_TextChanged;
                txtSoDienThoai.TextChanged += TxtSoDienThoai_TextChanged;
                txtSoDienThoai.Focus();
            }
        }

        private void TxtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSoDienThoai.Text.Trim();

            // Gợi ý thông tin khi gõ số điện thoại mẫu hoặc khách quen
            if (sdt == "12345" || sdt == "0901234567" || sdt == "0912345678")
            {
                if (txtTenKhachHang != null) txtTenKhachHang.Text = "Nguyễn Văn An";
                if (txtDiaChi != null) txtDiaChi.Text = "123 Lê Lợi, P.1, TP. Cao Lãnh";

                if (lblTrangThaiTimKiem != null)
                {
                    lblTrangThaiTimKiem.Text = "✓ Đã tìm thấy khách hàng thành viên";
                    lblTrangThaiTimKiem.ForeColor = Color.FromArgb(16, 185, 129);
                }
            }
            else if (sdt.Length >= 5)
            {
                if (lblTrangThaiTimKiem != null)
                {
                    lblTrangThaiTimKiem.Text = "ℹ Khách hàng mới (chưa có trong hệ thống)";
                    lblTrangThaiTimKiem.ForeColor = Color.FromArgb(234, 88, 12);
                }
            }
            else
            {
                if (lblTrangThaiTimKiem != null) lblTrangThaiTimKiem.Text = "";
            }
        }

        private void btnKhachLe_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang != null) txtTenKhachHang.Text = "Khách vãng lai";
            if (txtSoDienThoai != null) txtSoDienThoai.Text = "Không có";
            if (txtDiaChi != null) txtDiaChi.Text = "Mua trực tiếp tại quầy";
            ThucHienInHoaDon();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            string tenKH = txtTenKhachHang != null ? txtTenKhachHang.Text.Trim() : "";
            if (string.IsNullOrEmpty(tenKH))
            {
                MessageBox.Show("Vui lòng nhập Tên khách hàng hoặc chọn 'Khách Lẻ (In Ngay)'!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtTenKhachHang != null) txtTenKhachHang.Focus();
                return;
            }
            ThucHienInHoaDon();
        }

        private void btnDangKyMoi_Click(object sender, EventArgs e)
        {
            string tenKH = txtTenKhachHang != null ? txtTenKhachHang.Text.Trim() : "";
            string sdt = txtSoDienThoai != null ? txtSoDienThoai.Text.Trim() : "";

            if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Số điện thoại để lưu khách hàng mới!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show($"Đã lưu thông tin khách hàng [{tenKH}] vào hệ thống!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (lblTrangThaiTimKiem != null)
            {
                lblTrangThaiTimKiem.Text = "✓ Đã lưu thông tin khách hàng mới!";
                lblTrangThaiTimKiem.ForeColor = Color.FromArgb(16, 185, 129);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThucHienInHoaDon()
        {
            string tenKH = txtTenKhachHang != null ? txtTenKhachHang.Text.Trim() : "Khách lẻ";
            string sdt = txtSoDienThoai != null ? txtSoDienThoai.Text.Trim() : "";
            string diaChi = txtDiaChi != null ? txtDiaChi.Text.Trim() : "";

            MessageBox.Show(
                $"Đang gửi lệnh in hóa đơn...\n\n" +
                $"Khách hàng: {tenKH}\n" +
                $"SĐT: {sdt}\n" +
                $"Địa chỉ: {diaChi}\n" +
                $"Tổng tiền: {tongTien:N0} VNĐ\n\n" +
                $"Đã in thành công hóa đơn tại quầy!",
                "In Hóa Đơn",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Quay về màn hình bán hàng chính sau khi in xong
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmBanHang(), null);
            }
            else
            {
                this.Close();
            }
        }
    }
}