using qlcuahangdcht.GiaoDien.Admin;
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
    public partial class UC_NhanVien : UserControl
    {
        public UC_NhanVien()
        {
            InitializeComponent();
        }

        private void btnThemNv_Click(object sender, EventArgs e)
        {
            // Khởi tạo form Thêm nhân viên
            frmThemNhanVien frm = new frmThemNhanVien();

            // Hiển thị form lên và chờ người dùng xử lý xong
            frm.ShowDialog();

            // (Mẹo) Chỗ này sau này ông gọi thêm hàm Load lại DataGridView 
            // để khi form thêm đóng lại, bảng nhân viên tự động cập nhật dữ liệu mới luôn.
            // Ví dụ: LoadDuLieuNhanVien();
        }

        private void btnCapTaiKhoan_Click(object sender, EventArgs e)
        {
            // Khởi tạo form Cấp tài khoản
            frmCapTaiKhoan frm = new frmCapTaiKhoan();

            // Hiển thị form lên và khóa màn hình dưới
            frm.ShowDialog();
        }
    }
}
