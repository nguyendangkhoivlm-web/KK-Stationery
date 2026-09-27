using qlcuahangdcht.Models;
using System;
using System.Data.Entity.Validation; // Thêm thư viện để dò lỗi EF
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace qlcuahangdcht
{
    public partial class frmThongTinDeIn1 : Form
    {
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
        // NÚT LƯU KHÁCH HÀNG (SỬ DỤNG ENTITY FRAMEWORK)
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

            // Tiến hành lưu xuống CSDL bằng Entity Framework
            try
            {
                using (var db = new CuaHangDbContext())
                {
                    // Tự động sinh mã khách hàng (ví dụ: KH_3520)
                    string maKHMoi = "KH_" + DateTime.Now.ToString("mmss");

                    var khMoi = new KhachHang
                    {
                        MaKhachHang = maKHMoi,
                        HoTen = tenKH,
                        SDT = sdt,
                        DiaChi = string.IsNullOrEmpty(diaChi) ? "Đồng Tháp" : diaChi,
                        Email = "khachhang@gmail.com" // Gán Email mặc định
                    };

                    db.KhachHangs.Add(khMoi);
                    db.SaveChanges(); // Lưu thay đổi xuống CSDL
                }

                MessageBox.Show("Đã thêm khách hàng [" + tenKH + "] thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lưu xong thì quay lại bảng Khách Hàng
                QuayVeTrangKhachHang();
            }
            catch (DbEntityValidationException ex) // <-- Bẫy lỗi chi tiết EF
            {
                string errorDetails = "";
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        errorDetails += $"Cột bị lỗi: {validationError.PropertyName}\nNguyên nhân: {validationError.ErrorMessage}\n\n";
                    }
                }
                MessageBox.Show("Chi tiết lỗi từ CSDL:\n\n" + errorDetails, "Bắt Được Lỗi EF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khách hàng bằng Entity Framework: " + ex.Message, "Lỗi EF", MessageBoxButtons.OK, MessageBoxIcon.Error);
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