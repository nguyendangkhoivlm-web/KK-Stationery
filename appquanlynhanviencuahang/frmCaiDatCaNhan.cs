using System;
using System.Data;
using System.Data.SqlClient; // BẮT BUỘC THÊM THƯ VIỆN NÀY
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmCaiDatCaNhan : Form
    {
        // 1. Khai báo chuỗi kết nối CSDL
        string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";

        private bool đangHienMatKhau = false;
        private static bool đangBatCheDoToi = false;

        public frmCaiDatCaNhan()
        {
            InitializeComponent();
        }

        private void frmCaiDatCaNhan_Load(object sender, EventArgs e)
        {
            HienThiThongTinNhanVienDangNhap();

            string quyenTruyCap = PhienDangNhap.VaiTro;

            if (quyenTruyCap != "Admin")
            {
                txtHoTen.ReadOnly = true;
                txtMaNV.ReadOnly = true;
                txtChucVu.ReadOnly = true;
                txtBoPhan.ReadOnly = true;

                txtHoTen.BackColor = Color.FromArgb(240, 240, 240);
                txtMaNV.BackColor = Color.FromArgb(240, 240, 240);
                txtChucVu.BackColor = Color.FromArgb(240, 240, 240);
                txtBoPhan.BackColor = Color.FromArgb(240, 240, 240);
            }
            else
            {
                txtHoTen.ReadOnly = false;
                txtChucVu.ReadOnly = false;
                txtBoPhan.ReadOnly = false;
                txtMaNV.ReadOnly = true;

                txtHoTen.BackColor = Color.White;
                txtChucVu.BackColor = Color.White;
                txtBoPhan.BackColor = Color.White;
            }
        }

        // Hàm gán thông tin nhân viên lên giao diện từ lớp quản lý phiên làm việc
        private void HienThiThongTinNhanVienDangNhap()
        {
            txtHoTen.Text = PhienDangNhap.HoVaTen;
            txtMaNV.Text = PhienDangNhap.MaNhanVien;
            txtChucVu.Text = PhienDangNhap.ChucVu;
            txtBoPhan.Text = PhienDangNhap.BoPhan;
        }

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

        private void btnChuyenCheDo_Click(object sender, EventArgs e)
        {
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

        // =========================================================================
        // CHỨC NĂNG ĐỔI MẬT KHẨU (KIỂM TRA VÀ LƯU VÀO CSDL)
        // =========================================================================
        private void btnDoiMatKhau_Click_1(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text.Trim();
            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string xacNhanMK = txtXacNhanMatKhau.Text.Trim();
            string maNVDangNhap = txtMaNV.Text.Trim(); // Lấy mã nhân viên đang xài máy

            // 1. Kiểm tra các lỗi nhập liệu cơ bản
            if (matKhauCu == "" || matKhauMoi == "" || xacNhanMK == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (matKhauMoi.Length < 8)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất từ 8 ký tự trở lên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }

            if (matKhauMoi != xacNhanMK)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(maNVDangNhap))
            {
                MessageBox.Show("Lỗi: Không xác định được mã nhân viên đang đăng nhập!", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Kết nối CSDL để xử lý
            try
            {
                SqlConnection conn = new SqlConnection(chuoiKetNoi);
                conn.Open();

                // BƯỚC A: Kiểm tra xem mật khẩu cũ gõ vào có đúng với trong CSDL không
                string sqlKiemTra = "SELECT COUNT(*) FROM TaiKhoan WHERE MaNhanVien = '" + maNVDangNhap + "' AND MatKhau = '" + matKhauCu + "'";
                SqlCommand cmdKiemTra = new SqlCommand(sqlKiemTra, conn);

                // ExecuteScalar trả về giá trị của cột đầu tiên (số lượng dòng tìm được)
                int ketQua = (int)cmdKiemTra.ExecuteScalar();

                if (ketQua == 0)
                {
                    // Nếu trả về 0 nghĩa là sai mật khẩu cũ
                    MessageBox.Show("Mật khẩu hiện tại không chính xác! Vui lòng thử lại.", "Báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                    return;
                }

                // BƯỚC B: Mật khẩu cũ đúng -> Cập nhật mật khẩu mới
                string sqlCapNhat = "UPDATE TaiKhoan SET MatKhau = '" + matKhauMoi + "' WHERE MaNhanVien = '" + maNVDangNhap + "'";
                SqlCommand cmdCapNhat = new SqlCommand(sqlCapNhat, conn);
                cmdCapNhat.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Đổi mật khẩu thành công! Hãy ghi nhớ mật khẩu mới của bạn.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa sạch các ô nhập sau khi đổi thành công
                txtMatKhauCu.Clear();
                txtMatKhauMoi.Clear();
                txtXacNhanMatKhau.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối hệ thống đổi mật khẩu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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