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
            // Thiết lập màu nền mặc định sáng dịu nhẹ, chuyên nghiệp cho form chính
            this.BackColor = Color.FromArgb(240, 243, 246);

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
            childForm.Dock = DockStyle.Fill; // Phủ kín toàn bộ panel chứa form con

            // --- XỬ LÝ GIAO DIỆN SÁNG / TỐI ---
            // Kiểm tra xem form chính (frmMain) hiện tại có đang ở chế độ tối hay không
            bool laDangToi = (this.BackColor == Color.FromArgb(30, 35, 45));

            // Gọi class QuanLyGiaoDien có sẵn của nhóm để áp dụng màu sắc cho form con
            QuanLyGiaoDien.ApDungGiaoDien(childForm, laDangToi);
            // ------------------------------------

            panel1.Controls.Clear();
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // Hàm phụ trợ quét toàn bộ khung chứa giữ nền trắng cho các trang khác (như Cài đặt)
        private void DatMauTrangChoControls(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is Panel || ctrl is GroupBox || ctrl is TableLayoutPanel || ctrl is FlowLayoutPanel)
                {
                    ctrl.BackColor = Color.White;
                }

                if (ctrl.HasChildren)
                {
                    DatMauTrangChoControls(ctrl);
                }
            }
        }

        // Đổi màu làm nổi bật nút menu đang được chọn
        private void DoiMauNutMenu(Button activeButton)
        {
            Color defaultColor = Color.FromArgb(44, 90, 160);

            if (btnBanHang != null) btnBanHang.BackColor = defaultColor;
            if (btnKhachHang != null) btnKhachHang.BackColor = defaultColor;
            if (btnLichSuDaBan != null) btnLichSuDaBan.BackColor = defaultColor;
            if (btnCaiDatCaNhan != null) btnCaiDatCaNhan.BackColor = defaultColor;
            if (btnLienHe != null) btnLienHe.BackColor = defaultColor;

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
            OpenChildForm(new frmCaiDatCaNhan(), btnCaiDatCaNhan);
        }

        private void btnLienHe_Click(object sender, EventArgs e)
        {
            // Mở đúng trang Liên hệ
            OpenChildForm(new frmLienHe(), btnLienHe);
        }
    }
}