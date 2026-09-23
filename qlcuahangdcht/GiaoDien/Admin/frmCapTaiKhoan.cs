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
    public partial class frmCapTaiKhoan : Form
    {
        private string _maNV;
        private string _tenNV;


        public frmCapTaiKhoan()
        {
            InitializeComponent();
        }

        // Nhận dữ liệu truyền từ ngoài vào
        public frmCapTaiKhoan(string maNV, string tenNV)
        {
            InitializeComponent();
            _maNV = maNV;
            _tenNV = tenNV;
        }


        private void frmCapTaiKhoan_Load(object sender, EventArgs e)
        {
            // Hiển thị mờ (Read-only) thông tin nhân viên
            txtMaNV_Display.Text = _maNV;
            txtHoTen_Display.Text = _tenNV;
            txtMaNV_Display.Enabled = false;
            txtHoTen_Display.Enabled = false;

            // Nạp tạm Vai trò
            cboVaiTro.Items.Add("Admin");
            cboVaiTro.Items.Add("Nhân viên");
            cboVaiTro.SelectedIndex = 1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Validate Mật khẩu
            if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                return;
            }

            using (var db = new CuaHangDbContext())
            {
                // Kiểm tra nhân viên này đã có tài khoản chưa (để Insert hoặc Update)
                var tkCu = db.TaiKhoans.FirstOrDefault(t => t.MaNhanVien == _maNV);

                if (tkCu == null)
                {
                    // Chưa có -> Tạo mới
                    TaiKhoan tkMoi = new TaiKhoan();
                    tkMoi.TenDangNhap = txtTenDangNhap.Text;
                    tkMoi.MatKhau = txtMatKhau.Text; // Thực tế nên mã hóa MD5/Hash chỗ này
                    tkMoi.VaiTro = cboVaiTro.SelectedItem.ToString();
                    tkMoi.MaNhanVien = _maNV;
                    db.TaiKhoans.Add(tkMoi);
                }
                else
                {
                    // Đã có -> Cập nhật
                    tkCu.MatKhau = txtMatKhau.Text;
                    tkCu.VaiTro = cboVaiTro.SelectedItem.ToString();
                }

                db.SaveChanges();
                MessageBox.Show("Cấp tài khoản thành công!");
                this.Close();
            }
        }
    }
    
}
