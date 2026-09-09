using qlcuahangdcht.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlcuahangdcht.GiaoDien.HeThong
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra người dùng đã nhập đủ thông tin chưa
            if (string.IsNullOrWhiteSpace(txtHoTenDangKy.Text) ||
                string.IsNullOrWhiteSpace(txtTaiKhoanDangKy.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhauDangKy.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại, không chạy code bên dưới nữa
            }

            // 2. Kiểm tra mật khẩu nhập lại có khớp không
            if (txtMatKhauDangKy.Text != txtXacNhanMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Bắt đầu gọi Entity Framework để làm việc với Database
            using (var context = new CuaHangDbContext())
            {
                // Kiểm tra xem Tên đăng nhập này đã có ai xài chưa
                var taiKhoanCu = context.TaiKhoans.FirstOrDefault(t => t.TenDangNhap == txtTaiKhoanDangKy.Text);
                if (taiKhoanCu != null)
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại. Vui lòng chọn tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tên đăng nhập hợp lệ, tiến hành tạo dữ liệu
                // A. Tạo một mã nhân viên ngẫu nhiên (Ví dụ: NV + Năm tháng ngày giờ phút giây)
                string maNVMoi = "NV" + DateTime.Now.ToString("yyMMddHHmmss");

                // B. Lưu thông tin vào bảng NhanVien trước
                NhanVien nv = new NhanVien()
                {
                    MaNhanVien = maNVMoi,
                    HoTen = txtHoTenDangKy.Text
                };
                context.NhanViens.Add(nv); // Thêm vào bộ nhớ đệm

                // C. Lưu thông tin vào bảng TaiKhoan và móc nối với Nhân viên vừa tạo
                TaiKhoan tk = new TaiKhoan()
                {
                    TenDangNhap = txtTaiKhoanDangKy.Text,
                    MatKhau = txtMatKhauDangKy.Text,
                    VaiTro = "Nhân viên", // Mặc định người mới đăng ký là Nhân viên
                    MaNhanVien = maNVMoi
                };
                context.TaiKhoans.Add(tk); // Thêm vào bộ nhớ đệm

                // D. Gọi lệnh thần thánh lưu toàn bộ xuống SQL Server
                context.SaveChanges();

                MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đóng form đăng ký lại để người dùng quay về màn hình Đăng nhập
                this.Close();
            }
        }
    }
}
