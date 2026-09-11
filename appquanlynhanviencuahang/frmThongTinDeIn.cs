using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmThongTinDeIn : Form
    {
        DataTable dtSanPham = new DataTable();
        double tamTinh = 0;
        double thueVAT = 0;
        double tongTien = 0;
        string phuongThucThanhToan = "Tiền mặt";

        // Bảng dữ liệu khách hàng mẫu để tìm kiếm nhanh theo SĐT
        DataTable dtKhachHangMau = new DataTable();

        public frmThongTinDeIn()
        {
            InitializeComponent();
        }

        public frmThongTinDeIn(DataTable dt, double sub, double tax, double total, string method = "Tiền mặt")
        {
            InitializeComponent();
            this.dtSanPham = dt;
            this.tamTinh = sub;
            this.thueVAT = tax;
            this.tongTien = total;
            this.phuongThucThanhToan = method;
        }

        private void frmThongTinDeIn_Load(object sender, EventArgs e)
        {
            // 1. Ép cứng các khung Panel/GroupBox chứa nội dung hiển thị màu trắng rõ ràng
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Panel || ctrl is GroupBox)
                {
                    ctrl.BackColor = Color.White;
                }
            }

            // 3. Hiển thị tổng tiền nhận từ trang bán hàng
            if (lblTongTienHoaDon != null)
            {
                lblTongTienHoaDon.Text = "Tổng tiền thanh toán: " + tongTien.ToString("N0") + " VNĐ";
            }
            KhoiTaoDanhSachKhachHang();
        }

        private void KhoiTaoDanhSachKhachHang()
        {
            dtKhachHangMau.Columns.Add("SDT", typeof(string));
            dtKhachHangMau.Columns.Add("Ten", typeof(string));
            dtKhachHangMau.Columns.Add("DiaChi", typeof(string));

            dtKhachHangMau.Rows.Add("0901234567", "Nguyễn Văn An", "123 Lê Lợi, P.1, TP. Cao Lãnh");
            dtKhachHangMau.Rows.Add("0912345678", "Trần Thị Mai", "456 Nguyễn Huệ, TP. Sa Đéc");
            dtKhachHangMau.Rows.Add("0987654321", "Lê Hoàng Nam", "789 Hùng Vương, TP. Cao Lãnh");
        }

        // Tự động tìm kiếm khách hàng khi nhập số điện thoại
        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSoDienThoai.Text.Trim();

            if (string.IsNullOrEmpty(sdt))
            {
                if (lblTrangThaiTimKiem != null) lblTrangThaiTimKiem.Text = "";
                return;
            }

            if (sdt.Length >= 4)
            {
                DataRow[] rows = dtKhachHangMau.Select(string.Format("SDT LIKE '%{0}%'", sdt));
                if (rows.Length > 0)
                {
                    // Trường hợp ĐÃ CÓ trên hệ thống (Khách hàng thành viên)
                    txtTenKhachHang.Text = rows[0]["Ten"].ToString();
                    txtDiaChi.Text = rows[0]["DiaChi"].ToString();

                    if (lblTrangThaiTimKiem != null)
                    {
                        lblTrangThaiTimKiem.Text = "✓ Đã tìm thấy khách hàng thành viên";
                        lblTrangThaiTimKiem.ForeColor = Color.FromArgb(16, 185, 129); // Xanh lá
                    }
                    return;
                }
            }

            // Trường hợp CHƯA CÓ trên hệ thống (Khách hàng mới)
            if (lblTrangThaiTimKiem != null)
            {
                lblTrangThaiTimKiem.Text = "ℹ Khách hàng mới (chưa có trên hệ thống)";
                lblTrangThaiTimKiem.ForeColor = Color.FromArgb(234, 88, 12); // Màu cam
            }
        }

        // 1. In ngay cho Khách Lẻ
        private void btnKhachLe_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = "Khách Lẻ";
            txtSoDienThoai.Text = "Không có";
            txtDiaChi.Text = "Tại quầy";

            InVaXuatHoaDon();
        }

        // 2. In hóa đơn theo thông tin nhập
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhachHang.Focus();
                return;
            }

            InVaXuatHoaDon();
        }

        // 3. Đăng ký khách hàng mới vào hệ thống
        private void btnDangKyMoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text) || string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Tên và Số điện thoại để đăng ký thành viên mới!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dtKhachHangMau.Rows.Add(txtSoDienThoai.Text.Trim(), txtTenKhachHang.Text.Trim(), txtDiaChi.Text.Trim());
            MessageBox.Show("Đã lưu thông tin khách hàng mới vào hệ thống!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            InVaXuatHoaDon();
        }

        // Hàm thực hiện tổng hợp thông tin và in hóa đơn
        private void InVaXuatHoaDon()
        {
            string thongTin = string.Format(
                "====================================\n" +
                "       HÓA ĐƠN DỤNG CỤ HỌC TẬP       \n" +
                "====================================\n" +
                "Khách Hàng: {0}\n" +
                "SĐT: {1}\n" +
                "Địa Chỉ: {2}\n" +
                "Phương Thức: {3}\n" +
                "------------------------------------\n" +
                "Tổng Tiền: {4:N0} VNĐ\n" +
                "====================================\n" +
                "Đang gửi lệnh in tới máy in...",
                txtTenKhachHang.Text.Trim(),
                txtSoDienThoai.Text.Trim(),
                txtDiaChi.Text.Trim(),
                phuongThucThanhToan,
                tongTien
            );

            MessageBox.Show(thongTin, "In Hóa Đơn Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // 4. Hủy bỏ / Quay lại trang bán hàng
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy thanh toán và quay lại không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Đóng form hóa đơn hiện tại lại, trả về màn hình bán hàng trước đó
                this.Close();
            }
        }

        private void lblSoDienThoai_Click(object sender, EventArgs e)
        {
            // Để trống nếu không dùng sự kiện click vào nhãn
        }
    }
}