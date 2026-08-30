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


    }
}
