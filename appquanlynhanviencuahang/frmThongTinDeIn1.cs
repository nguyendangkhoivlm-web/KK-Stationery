using System;
using System.Data.SqlClient; // Bắt buộc để lưu CSDL
using System.Drawing;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmThongTinDeIn1 : Form
    {
        // Chuỗi kết nối CSDL
        string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";

        public frmThongTinDeIn1()
        {
            InitializeComponent();

            // Gắn sự kiện (Event) cho form và các nút bấm
            this.Load += FrmThongTinDeIn1_Load;

            // Nút bấm
            this.nutDangKyMoi_Test.Click += NutDangKyMoi_Test_Click;
            this.nutHuyBo_Test.Click += NutHuyBo_Test_Click;
            this.nutQuayLai_Test.Click += NutQuayLai_Test_Click;

            // Ô nhập Số điện thoại
            this.hopNhapSoDienThoai_Test.KeyPress += HopNhapSoDienThoai_Test_KeyPress;
            this.hopNhapSoDienThoai_Test.TextChanged += HopNhapSoDienThoai_Test_TextChanged;
        }

        private void FrmThongTinDeIn1_Load(object sender, EventArgs e)
        {
            // 1. Đổi lại chữ trên giao diện cho phù hợp với chức năng Thêm Khách Hàng
            nhanTieuDeTren_Test.Text = "Thêm Khách Hàng Mới";
            nhanTieuDeThe_Test.Text = "Thông Tin Khách Hàng";
            nhanGhiChuPhu_Test.Text = "Vui lòng nhập đầy đủ thông tin để lưu vào danh bạ cửa hàng.";

            // 2. Ẩn các chức năng của form In Hóa Đơn đi (Vì form này chỉ để thêm khách)
            nhanTongTien_Test.Visible = false;

            // 3. Rút gọn giao diện: Cho nút Đăng Ký và Hủy Bỏ to ra lấp chỗ trống
            nutDangKyMoi_Test.Text = "💾 Lưu Khách Hàng";
            bangLuoiNutBam_Test.ColumnStyles[0].Width = 50; // Chỉnh tỷ lệ 50-50
            bangLuoiNutBam_Test.ColumnStyles[1].Width = 50;

            // 4. Giới hạn ô SĐT và đưa con trỏ chuột vào ô Tên
            hopNhapSoDienThoai_Test.MaxLength = 10;
            hopNhapTenKhachHang_Test.Focus();
        }

        // ==========================================================
        // BẪY LỖI Ô NHẬP SỐ ĐIỆN THOẠI
        // ==========================================================
        private void HopNhapSoDienThoai_Test_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Khóa gõ chữ cái
            }
        }

        private void HopNhapSoDienThoai_Test_TextChanged(object sender, EventArgs e)
        {
            if (hopNhapSoDienThoai_Test.Text.Trim().Length == 10)
            {
                nhanTrangThaiTimKiem_Test.Text = "✓ Số điện thoại hợp lệ.";
                nhanTrangThaiTimKiem_Test.ForeColor = Color.FromArgb(16, 185, 129); // Màu Xanh
            }
            else
            {
                nhanTrangThaiTimKiem_Test.Text = "";
            }
        }

        // ==========================================================
        // NÚT LƯU KHÁCH HÀNG (KẾT NỐI SQL SERVER - ĐÃ THÊM CỘT EMAIL)
        // ==========================================================
        private void NutDangKyMoi_Test_Click(object sender, EventArgs e)
        {
            string tenKH = hopNhapTenKhachHang_Test.Text.Trim();
            string sdt = hopNhapSoDienThoai_Test.Text.Trim();
            string diaChi = hopNhapDiaChi_Test.Text.Trim();

            if (tenKH == "" || sdt == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Số điện thoại!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hopNhapTenKhachHang_Test.Focus();
                return;
            }

            if (sdt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải bao gồm đúng 10 chữ số!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hopNhapSoDienThoai_Test.Focus();
                return;
            }

            // Tiến hành lưu xuống CSDL
            try
            {
                using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                {
                    conn.Open();

                    // Tự động sinh mã khách hàng (ví dụ: KH_3520)
                    string maKHMoi = "KH_" + DateTime.Now.ToString("mmss");

                    // ĐÃ THÊM EMAIL VÀO ĐÂY
                    string sqlThem = "INSERT INTO KhachHang (MaKhachHang, HoTen, SDT, DiaChi, Email) VALUES (@MaKH, @HoTen, @SDT, @DiaChi, @Email)";
                    using (SqlCommand cmd = new SqlCommand(sqlThem, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", maKHMoi);
                        cmd.Parameters.AddWithValue("@HoTen", tenKH);
                        cmd.Parameters.AddWithValue("@SDT", sdt);
                        cmd.Parameters.AddWithValue("@DiaChi", string.IsNullOrEmpty(diaChi) ? "Đồng Tháp" : diaChi);
                        cmd.Parameters.AddWithValue("@Email", "khachhang@gmail.com"); // Gán Email mặc định
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã thêm khách hàng [" + tenKH + "] thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lưu xong thì quay lại bảng Khách Hàng
                QuayVeTrangKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // CÁC NÚT ĐÓNG, HỦY VÀ QUAY VỀ
        // ==========================================================
        private void NutHuyBo_Test_Click(object sender, EventArgs e)
        {
            QuayVeTrangKhachHang();
        }

        private void NutQuayLai_Test_Click(object sender, EventArgs e)
        {
            QuayVeTrangKhachHang();
        }

        private void QuayVeTrangKhachHang()
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                // Gọi lại chính xác trang Khách Hàng
                mainForm.OpenChildForm(new frmKhachHang(), null);
            }
            else
            {
                this.Close();
            }
        }
    }
}