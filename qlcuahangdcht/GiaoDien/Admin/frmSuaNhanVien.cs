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
    public partial class frmSuaNhanVien : Form
    {

        // Khai báo biến để nhận Mã NV truyền từ form Danh Sách sang
        private string maNhanVienCanSua = "";
        public frmSuaNhanVien()
        {
            InitializeComponent();
        }

        // Constructor dùng để nhận mã nhân viên
        public frmSuaNhanVien(string maNV)
        {
            InitializeComponent();
            maNhanVienCanSua = maNV;
        }

        private void frmSuaNhanVien_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu cũ của nhân viên lên giao diện
            using (var db = new CuaHangDbContext())
            {
                var nv = db.NhanViens.Find(maNhanVienCanSua);
                if (nv != null)
                {
                    txtMaNV.Text = nv.MaNhanVien;
                    txtMaNV.ReadOnly = true; // Khóa lại không cho đổi mã

                    txtHoTen.Text = nv.HoTen;

                    if (nv.GioiTinh == "Nam") radNam.Checked = true;
                    else if (nv.GioiTinh == "Nữ") radNu.Checked = true;

                    if (nv.NgaySinh.HasValue) dtpNgaySinh.Value = nv.NgaySinh.Value;

                    // Xử lý Placeholder cho SĐT
                    if (string.IsNullOrWhiteSpace(nv.SDT))
                    {
                        txtSDT.Text = "SĐT";
                        txtSDT.ForeColor = Color.Gray;
                    }
                    else
                    {
                        txtSDT.Text = nv.SDT;
                        txtSDT.ForeColor = Color.Black;
                    }

                    // Xử lý Placeholder cho Email
                    if (string.IsNullOrWhiteSpace(nv.Email))
                    {
                        txtEmail.Text = "Email";
                        txtEmail.ForeColor = Color.Gray;
                    }
                    else
                    {
                        txtEmail.Text = nv.Email;
                        txtEmail.ForeColor = Color.Black;
                    }

                    // Xử lý Placeholder cho Địa chỉ
                    if (string.IsNullOrWhiteSpace(nv.DiaChi))
                    {
                        txtDiaChi.Text = "Địa chỉ..";
                        txtDiaChi.ForeColor = Color.Gray;
                    }
                    else
                    {
                        txtDiaChi.Text = nv.DiaChi;
                        txtDiaChi.ForeColor = Color.Black;
                    }
                }
            }
        }


        // ================= CÁC SỰ KIỆN ẨN/HIỆN CHỮ MỜ =================
        private void txtSDT_Enter(object sender, EventArgs e)
        {
            if (txtSDT.Text == "SĐT") { txtSDT.Text = ""; txtSDT.ForeColor = Color.Black; }
        }
        private void txtSDT_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSDT.Text)) { txtSDT.Text = "SĐT"; txtSDT.ForeColor = Color.Gray; }
        }


        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email") { txtEmail.Text = ""; txtEmail.ForeColor = Color.Black; }
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { txtEmail.Text = "Email"; txtEmail.ForeColor = Color.Gray; }
        }


        private void txtDiaChi_Enter(object sender, EventArgs e)
        {
            if (txtDiaChi.Text == "Địa chỉ..") { txtDiaChi.Text = ""; txtDiaChi.ForeColor = Color.Black; }
        }
        private void txtDiaChi_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text)) { txtDiaChi.Text = "Địa chỉ.."; txtDiaChi.ForeColor = Color.Gray; }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra bắt buộc nhập
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            // 2. Dọn dẹp chữ mờ trước khi lưu để tránh rác vào Database
            string sdt = txtSDT.Text.Trim();
            if (sdt == "SĐT") sdt = "";

            string email = txtEmail.Text.Trim();
            if (email == "Email") email = "";

            string diaChi = txtDiaChi.Text.Trim();
            if (diaChi == "Địa chỉ..") diaChi = "";

            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            // 3. Thực hiện CẬP NHẬT xuống DB (Update)
            try
            {
                using (var db = new CuaHangDbContext())
                {
                    // Lấy đối tượng cũ lên để sửa
                    var nvSua = db.NhanViens.Find(maNhanVienCanSua);

                    if (nvSua != null)
                    {
                        nvSua.HoTen = txtHoTen.Text.Trim();
                        nvSua.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
                        nvSua.NgaySinh = dtpNgaySinh.Value;
                        nvSua.SDT = sdt;
                        nvSua.Email = email;
                        nvSua.DiaChi = diaChi;

                        // Lưu thay đổi
                        db.SaveChanges();

                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật: \n" + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Ông có chắc chắn muốn hủy bỏ thao tác này không? Các thay đổi sẽ không được lưu.", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
