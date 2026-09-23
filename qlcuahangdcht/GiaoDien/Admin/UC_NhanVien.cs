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


        private void LoadData()
        {
            using (var db = new CuaHangDbContext())
            {
                dgvDanhSachNv.AutoGenerateColumns = false;

                // Dùng Select để lấy cả thông tin Nhân viên và Vai trò (từ bảng TaiKhoan nếu có)
                var danhSach = db.NhanViens.Select(nv => new
                {
                    MaNhanVien = nv.MaNhanVien, // Đã đổi MaNV thành MaNhanVien cho khớp với DataPropertyName
                    HoTen = nv.HoTen,
                    GioiTinh = nv.GioiTinh,
                    NgaySinh = nv.NgaySinh,
                    SDT = nv.SDT,               // Đã đổi SoDienThoai thành SDT cho khớp
                    Email = nv.Email,
                    DiaChi = nv.DiaChi,
                    VaiTro = "Chưa cấp"
                }).ToList();

                dgvDanhSachNv.DataSource = danhSach;
            }
        }

        private void btnThemNv_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo và mở form Thêm nhân viên
            frmThemNhanVien frm = new frmThemNhanVien();

            // Lệnh ShowDialog() sẽ chặn màn hình lại. 
            // Mọi code bên dưới dòng này sẽ phải ĐỨNG ĐỢI cho đến khi form Thêm bị tắt đi.
            frm.ShowDialog();

            // 2. MA THUẬT NẰM Ở ĐÂY: 
            // Ngay khi form Thêm vừa đóng lại (tức là đã lưu DB xong), lệnh này sẽ chạy để quét lại Database và làm mới bảng.
            LoadData();
        }

        private void btnCapTaiKhoan_Click(object sender, EventArgs e)
        {
            // 1. Chặn luôn nếu chưa chọn dòng nào, HOẶC lỡ bấm trúng dòng trống dưới cùng
            if (dgvDanhSachNv.CurrentRow == null || dgvDanhSachNv.CurrentRow.IsNewRow)
            {
                return;
            }

            // 2. Tuyệt chiêu: Dùng Convert.ToString() thay vì .Value.ToString().
            // Nếu Value bị null, Convert.ToString() sẽ biến nó thành chuỗi rỗng ("") chứ không văng lỗi sập phần mềm.
            string ma = Convert.ToString(dgvDanhSachNv.CurrentRow.Cells["MaNhanVien"].Value);
            string ten = Convert.ToString(dgvDanhSachNv.CurrentRow.Cells["HoTen"].Value);

            // 3. Kiểm tra an toàn: Nhỡ cột Mã bị trống thật thì báo cho người dùng biết
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Ô này chưa có dữ liệu Mã Nhân Viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Truyền Mã và Tên qua form Cấp tài khoản
            frmCapTaiKhoan frm = new frmCapTaiKhoan(ma, ten);
            frm.ShowDialog();

            LoadData();
        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            // Nạp dữ liệu giả cho ComboBox Chức vụ lọc bảng
            cboLocChucVu.Items.Add("Tất cả");
            cboLocChucVu.Items.Add("Quản lý");
            cboLocChucVu.Items.Add("Nhân viên bán hàng");
            cboLocChucVu.SelectedIndex = 0;
        }

        private void btnXoaNv_Click(object sender, EventArgs e)
        {
            // Lớp 1: Chặn lỗi văng game khi bấm trúng dòng trống hoặc chưa chọn dòng nào
            if (dgvDanhSachNv.CurrentRow == null || dgvDanhSachNv.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên hợp lệ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lớp 2: Lấy mã an toàn bằng Convert.ToString (Chống lỗi Null) và đổi thành đúng cột "MaNhanVien"
            string maNV = Convert.ToString(dgvDanhSachNv.CurrentRow.Cells["MaNhanVien"].Value);

            // Lớp 3: Kiểm tra nhỡ đâu cái ô đó bị rỗng dữ liệu thật
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Dòng này bị trống Mã nhân viên, không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tiến hành xác nhận và Xóa
            DialogResult rs = MessageBox.Show($"Ông có chắc chắn muốn xóa nhân viên mã '{maNV}' không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    using (var db = new CuaHangDbContext())
                    {
                        var nv = db.NhanViens.Find(maNV);
                        if (nv != null)
                        {
                            db.NhanViens.Remove(nv);
                            db.SaveChanges(); // Chốt hạ xuống DB
                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadData(); // Load lại bảng
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên này trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Bẫy lỗi database (VD: Nhân viên này đang dính khóa ngoại tới bảng Hóa đơn, không thể xóa)
                    MessageBox.Show("Không thể xóa do lỗi cơ sở dữ liệu: \n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimKiemNV_Enter(object sender, EventArgs e)
        {
            // LƯU Ý: Chữ trong ngoặc kép phải giống Y HỆT chữ ông gõ sẵn trên giao diện
            if (txtTimKiemNV.Text == "Tìm kiếm nhân viên...")
            {
                txtTimKiemNV.Text = "";
                txtTimKiemNV.ForeColor = Color.Black;

                // TUYỆT CHIÊU: Dựng đứng chữ lên (Regular)
                txtTimKiemNV.Font = new Font(txtTimKiemNV.Font, FontStyle.Regular);
            }
        }

        private void txtTimKiemNV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiemNV.Text))
            {
                txtTimKiemNV.Text = "Tìm kiếm nhân viên...";
                txtTimKiemNV.ForeColor = Color.Gray;

                // Ép nó nằm nghiêng lại (Italic) làm chữ mờ
                txtTimKiemNV.Font = new Font(txtTimKiemNV.Font, FontStyle.Italic);
            }
        }
    }
}
