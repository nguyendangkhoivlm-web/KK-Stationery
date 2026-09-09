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
    public partial class frmCaiDatCaNhan : Form
    {
        // Biến trạng thái: ẩn/hiện mật khẩu và bật/tắt chế độ tối
        private bool đangHienMatKhau = false;
        private static bool đangBatCheDoToi = false; // Dùng static để lưu trạng thái xuyên suốt các tab

        public frmCaiDatCaNhan()
        {
            InitializeComponent();
        }

        private void frmCaiDatCaNhan_Load(object sender, EventArgs e)
        {
            // 1. Tự động đổ thông tin nhân viên đăng nhập lên form
            HienThiThongTinNhanVienDangNhap();

            // 2. Phân quyền: Kiểm tra tài khoản đăng nhập
            string quyenTruyCap = "NhanVien"; // Mặc định nhân viên thường

            if (quyenTruyCap != "Admin")
            {
                // Nhân viên thường: Khóa cứng hoàn toàn thông tin
                txtHoTen.ReadOnly = true;
                txtMaNV.ReadOnly = true;
                txtChucVu.ReadOnly = true;
                txtBoPhan.ReadOnly = true;

                // Đổi màu nền xám nhẹ nhận diện vùng chỉ đọc
                txtHoTen.BackColor = Color.FromArgb(240, 240, 240);
                txtMaNV.BackColor = Color.FromArgb(240, 240, 240);
                txtChucVu.BackColor = Color.FromArgb(240, 240, 240);
                txtBoPhan.BackColor = Color.FromArgb(240, 240, 240);
            }
            else
            {
                // Admin: Cho phép chỉnh sửa thông tin
                txtHoTen.ReadOnly = false;
                txtChucVu.ReadOnly = false;
                txtBoPhan.ReadOnly = false;
                txtMaNV.ReadOnly = true;

                txtHoTen.BackColor = Color.White;
                txtChucVu.BackColor = Color.White;
                txtBoPhan.BackColor = Color.White;
            }
        }

        // Hàm gán thông tin nhân viên lên giao diện
        private void HienThiThongTinNhanVienDangNhap()
        {
            txtHoTen.Text = "Trần Vũ Tuấn Kiệt";
            txtMaNV.Text = "NV01";
            txtChucVu.Text = "Nhân viên Bán hàng / Thu ngân";
            txtBoPhan.Text = "Cửa Hàng Bán Lẻ & Dụng Cụ Học Tập";
        }

        // 3. Chức năng ẩn / hiện mật khẩu mới
        private void btnHienMatKhauMoi_Click(object sender, EventArgs e)
        {
            đangHienMatKhau = !đangHienMatKhau;
            if (đangHienMatKhau)
            {
                txtMatKhauMoi.UseSystemPasswordChar = false;
                txtXacNhanMatKhau.UseSystemPasswordChar = false;
                btnHienMatKhauMoi.Text = "🙈 Ẩn";
            }
            else
            {
                txtMatKhauMoi.UseSystemPasswordChar = true;
                txtXacNhanMatKhau.UseSystemPasswordChar = true;
                btnHienMatKhauMoi.Text = "👁 Hiện";
            }
        }

        // 4. Chức năng chuyển đổi qua lại chế độ Sáng / Tối linh hoạt
        private void btnChuyenCheDo_Click(object sender, EventArgs e)
        {
            // Đảo ngược trạng thái mỗi lần bấm nút
            đangBatCheDoToi = !đangBatCheDoToi;

            foreach (Form frm in Application.OpenForms)
            {
                QuanLyGiaoDien.ApDungGiaoDien(frm, đangBatCheDoToi);
            }

            frmMain mainForm = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            if (mainForm != null)
            {
                QuanLyGiaoDien.ApDungGiaoDien(mainForm, đangBatCheDoToi);
            }

            if (đangBatCheDoToi)
            {
                MessageBox.Show("Đã chuyển sang chế độ tối bảo vệ mắt!", "Giao diện", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đã chuyển về chế độ sáng dịu nhẹ!", "Giao diện", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // 5. Chức năng xác nhận đổi mật khẩu cá nhân
        private void btnDoiMatKhau_Click_1(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string xacNhanMK = txtXacNhanMatKhau.Text.Trim();

            // Kiểm tra bỏ trống
            if (matKhauCu == "" || matKhauMoi == "" || xacNhanMK == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra quy tắc độ dài mật khẩu mới (tối thiểu 8 ký tự)
            if (matKhauMoi.Length < 8)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất từ 8 ký tự trở lên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            // Kiểm tra mật khẩu xác nhận có khớp không
            if (matKhauMoi != xacNhanMK)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Xóa sạch các ô nhập sau khi đổi thành công
            txtMatKhauCu.Clear();
            txtMatKhauMoi.Clear();
            txtXacNhanMatKhau.Clear();
        }

        // 6. Chức năng đăng xuất toàn bộ thiết bị
        private void btnDangXuatTatCa_Click(object sender, EventArgs e)
        {
            DialogResult ketQua = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi tất cả các thiết bị khác không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketQua == DialogResult.Yes)
            {
                MessageBox.Show("Đã đăng xuất thành công khỏi các thiết bị khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}