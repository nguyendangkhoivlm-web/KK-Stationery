using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmLapHoaDon : Form
    {
        string placeholderText = "Tìm kiếm sản phẩm theo tên hoặc mã...";

        public frmLapHoaDon()
        {
            InitializeComponent();

            // Đảm bảo nút btnThanhToan1 được gán sự kiện Click bằng code
            if (btnThanhToan1 != null)
            {
                btnThanhToan1.Click -= btnThanhToan1_Click;
                btnThanhToan1.Click += btnThanhToan1_Click;
            }

            // Gán sự kiện ẩn/hiện chữ mờ cho ô tìm kiếm
            if (txtTimKiemSanPham != null)
            {
                txtTimKiemSanPham.Enter += txtTimKiemSanPham_Enter;
                txtTimKiemSanPham.Leave += txtTimKiemSanPham_Leave;

                if (string.IsNullOrWhiteSpace(txtTimKiemSanPham.Text) || txtTimKiemSanPham.Text == placeholderText)
                {
                    txtTimKiemSanPham.Text = placeholderText;
                    txtTimKiemSanPham.ForeColor = Color.Gray;
                }
            }
        }

        // --- XỬ LÝ ẨN/HIỆN CHỮ MỜ Ô TÌM KIẾM ---
        private void txtTimKiemSanPham_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemSanPham.Text == placeholderText)
            {
                txtTimKiemSanPham.Text = "";
                txtTimKiemSanPham.ForeColor = Color.Black;
            }
        }

        private void txtTimKiemSanPham_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiemSanPham.Text))
            {
                txtTimKiemSanPham.Text = placeholderText;
                txtTimKiemSanPham.ForeColor = Color.Gray;
            }
        }

        // 1. Nút Thanh Toán 1 (chuyển sang form Tổng kết thanh toán nhúng trong panel1 của frmMain)
        private void btnThanhToan1_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmThanhToan(), null);
            }
        }

        // 2. Nút Thêm Sản Phẩm vào hóa đơn / giỏ hàng
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng chọn sản phẩm để thêm vào hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 3. Nút Xóa Sản Phẩm khỏi hóa đơn
        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xóa sản phẩm được chọn khỏi hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 4. Nút Cập Nhật Hóa Đơn
        private void btnCapNhatHoaDon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cập nhật lại thông tin hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 5. Ô tìm kiếm sản phẩm
        private void txtTimKiemSanPham_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiemSanPham.Text != placeholderText)
            {
                string keyword = txtTimKiemSanPham.Text.Trim();
                // Xử lý lọc dữ liệu theo từ khóa
            }
        }

        // 6. Nút Lưu Nháp hóa đơn
        private void btnLuuNhap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã lưu hóa đơn vào danh sách nháp thành công!", "Lưu nháp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmLapHoaDon_Load(object sender, EventArgs e)
        {

        }
    }
}