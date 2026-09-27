using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlcuahangdcht
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // 1. Chặn người dùng chưa nhập gì mà đã bấm (Giữ nguyên của ông)
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Chui vào Database kiểm tra
            using (var context = new CuaHangDbContext())
            {
                // THAY ĐỔI 1: Dùng LINQ JOIN 2 bảng để lấy được Họ Tên thật của nhân viên
                var tk = (from t in context.TaiKhoans
                          join n in context.NhanViens on t.MaNhanVien equals n.MaNhanVien
                          where t.TenDangNhap == txtTenDangNhap.Text && t.MatKhau == txtMatKhau.Text
                          select new
                          {
                              t.TenDangNhap,
                              t.VaiTro,
                              t.MaNhanVien,
                              n.HoTen
                          }).FirstOrDefault();

                if (tk != null) // Nếu tìm thấy tài khoản hợp lệ
                {
                    // THAY ĐỔI 2: Cấp thẻ đeo ngực (Lưu phiên đăng nhập)
                    PhienDangNhap.MaNhanVien = tk.MaNhanVien;
                    PhienDangNhap.HoVaTen = tk.HoTen; // Dùng đúng biến HoVaTen của bạn ông
                    PhienDangNhap.VaiTro = tk.VaiTro;

                    MessageBox.Show($"Đăng nhập thành công! Chào mừng {tk.VaiTro}: {tk.HoTen}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide(); // Giấu form đăng nhập đi

                    // THAY ĐỔI 3: Điều hướng Form theo Vai trò
                    if (tk.VaiTro == "Admin")
                    {
                        // Nếu là Admin thì mở MainForm như cũ
                        MainForm frmAdmin = new MainForm();
                        frmAdmin.ShowDialog();
                    }
                    else
                    {
                        // Nếu là Nhân viên thì mở Form Bán Hàng (Tui thấy ông có sẵn frmBanHang.cs bên cây Solution Explorer)
                        frmMain frmNV = new frmMain();
                        frmNV.ShowDialog();
                    }

                    // Sau khi tắt form chính thì tắt luôn chương trình ngầm
                    this.Close();
                }
                else // Nếu không tìm thấy
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void lnkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Đổi màu link sau khi người dùng đã click vào (tùy chọn để tăng trải nghiệm UX)
            lnkQuenMK.LinkVisited = true;

            // Khởi tạo bảng thông báo chứa thông tin Admin
            string thongBao = "Vui lòng liên hệ Quản trị viên hệ thống để được cấp lại mật khẩu.\n\n" +
                              "📞 Hotline: 0909 123 456\n" +
                              "📧 Email: admin@kk-stationery.com\n" +
                              "🏢 Phòng IT: Tầng 2, Tòa nhà Điều hành";

            string tieuDe = "Hỗ trợ khôi phục mật khẩu";

            // Hiển thị bảng thông báo với nút OK và icon Chú ý (Information)
            MessageBox.Show(thongBao, tieuDe, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
