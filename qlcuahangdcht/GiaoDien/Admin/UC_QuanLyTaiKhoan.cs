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
    public partial class UC_QuanLyTaiKhoan : UserControl
    {
        public UC_QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void UC_QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            // Không tự động tạo cột thừa
            dgvTaiKhoan.AutoGenerateColumns = false;

            cboVaiTro.Items.Clear();
            cboVaiTro.Items.Add("Admin");
            cboVaiTro.Items.Add("Nhân viên");

            LoadDuLieuTaiKhoan();
        }

        // HÀM TẢI DỮ LIỆU CÓ TÍCH HỢP TÌM KIẾM
        private void LoadDuLieuTaiKhoan(string tuKhoa = "")
        {
            using (var db = new CuaHangDbContext())
            {
                var query = db.TaiKhoans.AsQueryable();

                // Nếu có nhập từ khóa tìm kiếm (Lọc theo tên đăng nhập hoặc mã NV)
                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    query = query.Where(t => t.TenDangNhap.Contains(tuKhoa) || t.MaNhanVien.Contains(tuKhoa));
                }

                dgvTaiKhoan.DataSource = query.ToList();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDuLieuTaiKhoan(txtTimKiem.Text.Trim());
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                txtTenDangNhap.Text = row.Cells["colTenDangNhap"].Value?.ToString();
                txtMaNV.Text = row.Cells["colMaNV"].Value?.ToString();
                txtMatKhau.Text = row.Cells["colMatKhau"].Value?.ToString();

                string vaiTro = row.Cells["colVaiTro"].Value?.ToString();
                if (!string.IsNullOrEmpty(vaiTro))
                {
                    cboVaiTro.SelectedItem = vaiTro;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDangNhap.Text.Trim();
            if (string.IsNullOrEmpty(tenDN))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản trên lưới để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new CuaHangDbContext())
            {
                var tkSua = db.TaiKhoans.Find(tenDN);
                if (tkSua != null)
                {
                    tkSua.MatKhau = txtMatKhau.Text.Trim();
                    tkSua.VaiTro = cboVaiTro.SelectedItem?.ToString();

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Nạp lại lưới giữ nguyên kết quả tìm kiếm hiện tại
                    LoadDuLieuTaiKhoan(txtTimKiem.Text.Trim());
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null || dgvTaiKhoan.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDN = dgvTaiKhoan.CurrentRow.Cells["colTenDangNhap"].Value?.ToString();

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa vĩnh viễn quyền đăng nhập của tài khoản '{tenDN}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var db = new CuaHangDbContext())
                {
                    var tkXoa = db.TaiKhoans.Find(tenDN);
                    if (tkXoa != null)
                    {
                        db.TaiKhoans.Remove(tkXoa);
                        db.SaveChanges();

                        MessageBox.Show("Đã xóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Dọn dẹp form nhập liệu
                        txtTenDangNhap.Clear();
                        txtMaNV.Clear();
                        txtMatKhau.Clear();
                        cboVaiTro.SelectedIndex = -1;

                        LoadDuLieuTaiKhoan(txtTimKiem.Text.Trim());
                    }
                }
            }
        }
    }
}
