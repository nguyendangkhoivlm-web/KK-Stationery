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
    public partial class frmLichSuBanHang : Form
    {
        string placeholderText = "Tìm theo Mã HĐ hoặc SĐT...";

        public frmLichSuBanHang()
        {
            InitializeComponent();

            // Gán sự kiện ẩn/hiện chữ mờ cho ô tìm kiếm lịch sử
            if (txtTimKiem != null)
            {
                txtTimKiem.Enter += txtTimKiem_Enter;
                txtTimKiem.Leave += txtTimKiem_Leave;

                if (string.IsNullOrWhiteSpace(txtTimKiem.Text) || txtTimKiem.Text == placeholderText)
                {
                    txtTimKiem.Text = placeholderText;
                    txtTimKiem.ForeColor = Color.Gray;
                }
            }
        }

        // --- XỬ LÝ ẨN/HIỆN CHỮ MỜ Ô TÌM KIẾM ---
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == placeholderText)
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = placeholderText;
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        // 1. Nút Lọc dữ liệu theo ngày hoặc từ khóa
        private void btnLoc_Click(object sender, EventArgs e)
        {
            string tuNgay = dtpTuNgay.Text; // Ngày bắt đầu
            string denNgay = dtpDenNgay.Text; // Ngày kết thúc
            string tuKhoa = txtTimKiem.Text != placeholderText ? txtTimKiem.Text.Trim() : "";

            // Gợi ý sau này: Viết câu lệnh SQL lọc dữ liệu theo khoảng thời gian và từ khóa để đổ vào DataGridView
            MessageBox.Show("Đang lọc lịch sử từ ngày " + tuNgay + " đến " + denNgay, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 2. Nút In Lại Hóa Đơn đã chọn
        private void btnInLaiHD_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang chuẩn bị in lại hóa đơn được chọn...", "In hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click vào chi tiết từng dòng đơn hàng trên bảng
        }
    }
}