using qlcuahangdcht.GiaoDien.HeThong;
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

        private void txtLoginUser_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                // Đổi màu nền nhẹ đi (ví dụ: vàng nhạt hoặc xanh nhạt) để báo hiệu đang chọn
                txt.BackColor = Color.FromArgb(240, 248, 255); // Xanh Alice Blue rất dịu mắt

                // Nếu ông có dùng Panel bọc bên ngoài TextBox, có thể đổi màu viền Panel ở đây
            }
        }

        private void txtLoginUser_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                // Trả lại màu nền trắng bình thường
                txt.BackColor = Color.White;
            }
        }

        private void lnkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Khởi tạo form Đăng ký
            frmDangKy frm = new frmDangKy();

            // Giấu form Đăng nhập hiện tại đi cho đỡ vướng víu
            this.Hide();

            // Mở form Đăng ký lên và khóa màn hình chờ người dùng nhập
            frm.ShowDialog();

            // Sau khi người dùng tắt form Đăng ký (đăng ký xong hoặc bấm hủy), form Đăng nhập tự động hiện lên lại
            this.Show();
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
    }
}
