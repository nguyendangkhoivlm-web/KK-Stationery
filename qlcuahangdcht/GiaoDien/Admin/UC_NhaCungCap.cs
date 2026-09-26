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
    public partial class UC_NhaCungCap : UserControl
    {
        public UC_NhaCungCap()
        {
            InitializeComponent();
            LoadData();
        }


        private void LoadData()
        {
            using (var db = new CuaHangDbContext())
            {
                dgvNhaCungCap.DataSource = db.NhaCungCaps.ToList();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click trúng dòng trống hoặc chưa có dữ liệu thì bỏ qua
            if (dgvNhaCungCap.CurrentRow == null || dgvNhaCungCap.CurrentRow.IsNewRow) return;

            // Bắn dữ liệu lên các ô TextBox (Nhớ sửa tên cột trong ngoặc vuông cho đúng DataPropertyName của ông)
            txtMaNCC.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["MaNCC"].Value);
            txtTenNCC.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["TenNCC"].Value);
            txtDiaChi.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["DiaChi"].Value);
            txtSDT.Text = Convert.ToString(dgvNhaCungCap.CurrentRow.Cells["SDT"].Value);

            // QUAN TRỌNG: Khóa ô Mã nhà cung cấp lại, vì Khóa chính (Primary Key) thì không được phép sửa!
            txtMaNCC.ReadOnly = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNCC.Text.Trim();

            // 1. Kiểm tra xem người ta đã chọn ai để sửa chưa
            if (string.IsNullOrWhiteSpace(maNCC))
            {
                MessageBox.Show("Vui lòng click chọn một nhà cung cấp dưới bảng trước khi sửa!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // (Tùy chọn) Bắt lỗi để trống Tên, Địa chỉ... tương tự như lúc làm form Thêm

            // 2. Tìm và Cập nhật xuống Database
            try
            {
                using (var db = new CuaHangDbContext())
                {
                    // Dùng Find để móc chính xác ông nhà cung cấp này lên từ CSDL
                    var ncc = db.NhaCungCaps.Find(maNCC);

                    if (ncc != null)
                    {
                        // Ghi đè dữ liệu mới từ TextBox vào
                        ncc.TenNCC = txtTenNCC.Text.Trim();
                        ncc.DiaChi = txtDiaChi.Text.Trim();
                        ncc.SDT = txtSDT.Text.Trim();

                        // Chốt hạ lưu xuống DB
                        db.SaveChanges();

                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh lại bảng và reset lại các ô TextBox cho sạch sẽ
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã nhà cung cấp này trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: \n" + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Cơ chế Refresh trực tiếp: Bấm lúc đang chọn dòng sẽ làm trống để nhập mới
            if (txtMaNCC.ReadOnly == true)
            {
                txtMaNCC.Text = "";
                txtTenNCC.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtMaNCC.ReadOnly = false; // Mở khóa ô Mã
                txtMaNCC.Focus(); // Nhảy chuột vào ô Mã
                return;
            }

            // Kiểm tra cơ bản
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text) || string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã và Tên NCC!");
                return;
            }

            // Lưu vào DB 
            using (var db = new CuaHangDbContext())
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNCC = txtMaNCC.Text.Trim();
                ncc.TenNCC = txtTenNCC.Text.Trim();
                ncc.DiaChi = txtDiaChi.Text.Trim();
                ncc.SDT = txtSDT.Text.Trim();

                db.NhaCungCaps.Add(ncc);
                db.SaveChanges();

                MessageBox.Show("Thêm thành công!");
                LoadData();

                // Làm trống các ô sau khi lưu thành công
                txtMaNCC.Text = "";
                txtTenNCC.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
                txtMaNCC.Focus();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNCC = txtMaNCC.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNCC) || txtMaNCC.ReadOnly == false)
            {
                MessageBox.Show("Vui lòng chọn 1 nhà cung cấp từ bảng!");
                return;
            }

            // Hỏi xác nhận nhanh gọn
            if (MessageBox.Show("Xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (var db = new CuaHangDbContext())
                {
                    var ncc = db.NhaCungCaps.Find(maNCC);
                    if (ncc != null)
                    {
                        db.NhaCungCaps.Remove(ncc);
                        db.SaveChanges();

                        MessageBox.Show("Xóa thành công!");
                        LoadData();

                        // Làm trống các ô và mở khóa sau khi xóa xong
                        txtMaNCC.Text = "";
                        txtTenNCC.Text = "";
                        txtDiaChi.Text = "";
                        txtSDT.Text = "";
                        txtMaNCC.ReadOnly = false;
                    }
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            // 1. Nếu ô tìm kiếm trống thì tự động tải lại toàn bộ danh sách
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                LoadData();
                return;
            }

            // 2. Nếu có chữ thì tiến hành lọc dưới Database
            using (var db = new CuaHangDbContext())
            {
                // Lọc những nhà cung cấp mà Tên hoặc Mã có chứa từ khóa (chữ hoa/thường đều được)
                var ketQua = db.NhaCungCaps
                               .Where(ncc => ncc.TenNCC.Contains(tuKhoa) || ncc.MaNCC.Contains(tuKhoa))
                               .ToList();

                // Đổ kết quả tìm được lên bảng
                dgvNhaCungCap.DataSource = ketQua;
            }
        }
    }
}
