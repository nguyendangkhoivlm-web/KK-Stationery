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
            // Khởi tạo form Đăng ký mới
            frmDangKy frm = new frmDangKy();

            // Giấu form Đăng nhập hiện tại đi cho gọn màn hình
            this.Hide();

            // Mở form Đăng ký lên và khóa màn hình dưới (bắt buộc thao tác xong mới được quay lại)
            frm.ShowDialog();

            // Sau khi người dùng tắt form Đăng ký, form Đăng nhập tự động hiện lên lại
            this.Show();
        }
    }
}
