using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace appquanlynhanviencuahang
{
    public partial class frmMain : Form
    {
        // Biến lưu trữ form con đang hiển thị
        Form activeForm = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Mở form Bán hàng khi vừa khởi động ứng dụng
            OpenChildForm(new frmBanHang(), btnBanHang);
        }

        // Hàm nạp các Form con vào khu vực panel1
        public void OpenChildForm(Form childForm, Button btnActive = null)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            if (btnActive != null)
            {
                DoiMauNutMenu(btnActive);
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panel1.Controls.Clear();
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Đổi màu làm nổi bật nút menu đang được chọn
        private void DoiMauNutMenu(Button activeButton)
        {
            // Đặt màu nền mặc định cho tất cả các nút menu
            Color defaultColor = Color.FromArgb(44, 90, 160);

            if (btnBanHang != null) btnBanHang.BackColor = defaultColor;
            if (btnKhachHang != null) btnKhachHang.BackColor = defaultColor;
            if (btnLichSuDaBan != null) btnLichSuDaBan.BackColor = defaultColor;
            if (btnCaiDatCaNhan != null) btnCaiDatCaNhan.BackColor = defaultColor;
            if (btnLienHe != null) btnLienHe.BackColor = defaultColor;

            // Đổi màu nút đang được click cho đậm hơn
            activeButton.BackColor = Color.FromArgb(30, 70, 130);
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmBanHang(), btnBanHang);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang(), btnKhachHang);
        }

        private void btnLichSuDaBan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLichSuBanHang(), btnLichSuDaBan);
        }

        private void btnCaiDatCaNhan_Click(object sender, EventArgs e)
        {
            // Gọi form Cài đặt cá nhân nhúng vào panel chính của frmMain
            OpenChildForm(new frmCaiDatCaNhan(), btnCaiDatCaNhan);
        }

        private void btnLienHe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLienHe(), btnLienHe);
        }
    }
}