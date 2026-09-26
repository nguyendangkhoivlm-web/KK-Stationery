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

namespace qlcuahangdcht.GiaoDien.Admin
{
    public partial class UC_CaiDat : UserControl
    {
        // 1. Khai báo biến rỗng, không gán cứng nữa
        private string maAdminDangNhap;
        public UC_CaiDat()
        {
            InitializeComponent();
        }

        private void btnCapNhatHoSo_Click(object sender, EventArgs e)
        {
            using (var db = new CuaHangDbContext())
            {
                // Tìm tài khoản đang đăng nhập dưới DB
                var taiKhoan = db.NhanViens.Find(maAdminDangNhap);
                if (taiKhoan != null)
                {
                    // Gán dữ liệu từ TextBox vào đối tượng
                    taiKhoan.HoTen = txtHoTen.Text.Trim();
                    taiKhoan.SDT = txtSDT.Text.Trim();
                    taiKhoan.Email = txtEmail.Text.Trim();
                    taiKhoan.DiaChi = txtDiaChi.Text.Trim();

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin hồ sơ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatKhauCu.Text) || string.IsNullOrWhiteSpace(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMatKhauMoi.Text != txtNhapLaiMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new CuaHangDbContext())
            {
                // Phải tìm trong bảng TaiKhoan dựa vào mã nhân viên
                var tk = db.TaiKhoans.FirstOrDefault(t => t.MaNhanVien == maAdminDangNhap);

                if (tk != null)
                {
                    if (tk.MatKhau != txtMatKhauCu.Text)
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    tk.MatKhau = txtMatKhauMoi.Text;
                    db.SaveChanges();

                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMatKhauCu.Clear(); txtMatKhauMoi.Clear(); txtNhapLaiMatKhau.Clear();
                }
            }
        }


        // Hàm sinh mã AD ngẫu nhiên ông đã yêu cầu từ trước
        private string TaoMaAdminNgauNhien(CuaHangDbContext db)
        {
            Random rnd = new Random();
            string maMoi;
            bool biTrung;
            do
            {
                maMoi = "AD" + rnd.Next(1000, 10000).ToString();
                // Kiểm tra xem bảng NhanVien đã có mã này chưa
                biTrung = db.NhanViens.Any(nv => nv.MaNhanVien == maMoi);
            } while (biTrung);

            return maMoi;
        }

        private void btnLuuAdmin_Click(object sender, EventArgs e)
        {
            // Kiểm tra các ô nhập liệu 
            if (string.IsNullOrWhiteSpace(txtHoTenAdmin.Text) ||
                string.IsNullOrWhiteSpace(txtUserAdmin.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhauAdmin.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Họ tên, Tên đăng nhập và Mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new CuaHangDbContext())
            {
                // 1. Kiểm tra trùng tên đăng nhập trong bảng TaiKhoan
                string userMoi = txtUserAdmin.Text.Trim();
                if (db.TaiKhoans.Any(t => t.TenDangNhap == userMoi))
                {
                    MessageBox.Show("Tên đăng nhập này đã tồn tại, vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Tạo hồ sơ nhân sự mới (lưu vào bảng NhanVien)
                NhanVien adminMoi = new NhanVien();
                adminMoi.MaNhanVien = TaoMaAdminNgauNhien(db); // Hàm sinh mã tự động
                adminMoi.HoTen = txtHoTenAdmin.Text.Trim();
                adminMoi.SDT = txtSDTAdmin.Text.Trim();
                db.NhanViens.Add(adminMoi);

                // 3. Tạo tài khoản đăng nhập (lưu vào bảng TaiKhoan)
                TaiKhoan tkMoi = new TaiKhoan();
                tkMoi.MaNhanVien = adminMoi.MaNhanVien;
                tkMoi.TenDangNhap = userMoi;
                tkMoi.MatKhau = txtMatKhauAdmin.Text;

                // VỊ TRÍ CHÈN CODE NẰM Ở ĐÂY: Gán cứng quyền Admin cho tài khoản mới
                tkMoi.VaiTro = "Admin";

                db.TaiKhoans.Add(tkMoi);

                // 4. Lưu toàn bộ xuống DB
                db.SaveChanges();

                MessageBox.Show($"Khởi tạo thành công Quản trị viên mã: {adminMoi.MaNhanVien}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Dọn dẹp các ô text sau khi lưu thành công
                btnHuyAdmin_Click(sender, e);
            }
        }

        private void btnHuyAdmin_Click(object sender, EventArgs e)
        {
            txtHoTenAdmin.Clear();
            txtSDTAdmin.Clear();
            txtHoTenAdmin.Clear();
            txtMatKhauAdmin.Clear();
        }
    }
}
