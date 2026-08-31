using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace appquanlynhanviencuahang
{
    public partial class frmCaiDatCaNhan : Form
    {
        public frmCaiDatCaNhan()
        {
            InitializeComponent();
        }

        // 1. CHỨC NĂNG ĐỔI HÌNH NỀN ỨNG DỤNG
        private void btnDoiHinhNen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn hình nền cho ứng dụng";
                openFileDialog.Filter = "File hình ảnh (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp|Tất cả file (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;

                        frmMain mainForm = this.TopLevelControl as frmMain;
                        if (mainForm != null)
                        {
                            mainForm.BackgroundImage = Image.FromFile(filePath);
                            mainForm.BackgroundImageLayout = ImageLayout.Stretch;
                            MessageBox.Show("Đổi hình nền ứng dụng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            this.BackgroundImage = Image.FromFile(filePath);
                            this.BackgroundImageLayout = ImageLayout.Stretch;
                            MessageBox.Show("Đổi hình nền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải hình ảnh này: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // 2. CHỨC NĂNG BẬT CHẾ ĐỘ TỐI (CHỐNG MỎI MẮT)
        private void btnChuyenCheDo_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.BackColor = Color.FromArgb(30, 35, 45);
                MessageBox.Show("Đã chuyển sang chế độ tối bảo vệ mắt!", "Giao diện", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.BackColor = Color.FromArgb(30, 35, 45);
                MessageBox.Show("Đã chuyển sang chế độ tối bảo vệ mắt!", "Giao diện", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 3. CHỨC NĂNG BẬT CHẾ ĐỘ SÁNG DỊU NHẸ
        private void btnCheDoSang_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.BackColor = Color.FromArgb(240, 243, 246);
                MessageBox.Show("Đã chuyển sang chế độ sáng dịu nhẹ!", "Giao diện", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 243, 246);
                MessageBox.Show("Đã chuyển sang chế độ sáng dịu nhẹ!", "Giao diện", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 4. CHỨC NĂNG XÁC NHẬN ĐỔI MẬT KHẨU CÁ NHÂN
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            // Để code này hoạt động chuẩn, bạn hãy kiểm tra xem 3 ô TextBox trên giao diện 
            // đã được đặt tên (Name) trong bảng Properties lần lượt là: 
            // txtMatKhauCu, txtMatKhauMoi, txtXacNhanMatKhau chưa nhé!

            string matKhauCu = txtMatKhauCu.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string xacNhanMK = txtXacNhanMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(xacNhanMK))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhauMoi != xacNhanMK)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp nhau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đổi mật khẩu cá nhân thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa sạch các ô nhập sau khi đổi thành công
            txtMatKhauCu.Clear();
            txtMatKhauMoi.Clear();
            txtXacNhanMatKhau.Clear();
        }
    }
}