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
            // 1. Chặn người dùng chưa nhập gì mà đã bấm
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Chui vào Database kiểm tra
            using (var context = new CuaHangDbContext())
            {
                // Lục tìm tài khoản khớp cả tên lẫn mật khẩu
                var tk = context.TaiKhoans.FirstOrDefault(t =>
                    t.TenDangNhap == txtTenDangNhap.Text &&
                    t.MatKhau == txtMatKhau.Text);

                if (tk != null) // Nếu tìm thấy tài khoản hợp lệ
                {
                    MessageBox.Show("Đăng nhập thành công! Chào mừng " + tk.TenDangNhap, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Khởi tạo Form chính (MainForm)
                    MainForm frmMain = new MainForm();

                    this.Hide(); // Giấu form đăng nhập đi
                    frmMain.ShowDialog(); // Hiển thị form chính lên

                    // Sau khi người dùng tắt form chính (nghỉ xài phần mềm) thì tắt luôn form đăng nhập ngầm để giải phóng bộ nhớ
                    this.Close();
                }
                else // Nếu không tìm thấy (nhập sai)
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
