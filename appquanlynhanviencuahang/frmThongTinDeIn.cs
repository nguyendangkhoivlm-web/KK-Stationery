using appquanlynhanviencuahang;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace qlnhanvien
{
    public partial class frmThongTinDeIn : Form
    {
        DataTable dtSanPham = new DataTable();
        double tongTien = 0;
        double tamTinh = 0;
        double thueVAT = 0;

        // 1. Constructor mặc định
        public frmThongTinDeIn()
        {
            InitializeComponent();
        }

        // 2. Constructor nhận dữ liệu từ form trước
        public frmThongTinDeIn(DataTable dt, double tamTinh, double thue, double tong)
        {
            InitializeComponent();
            if (dt != null)
            {
                this.dtSanPham = dt.Copy();
            }
            this.tamTinh = tamTinh;
            this.thueVAT = thue;
            this.tongTien = tong;
        }

        private void frmThongTinDeIn_Load(object sender, EventArgs e)
        {
            lblTongTienHoaDon.Text = "Tổng tiền thanh toán: " + tongTien.ToString("N0") + " VNĐ";

            // Cài đặt bẫy lỗi cơ bản cho ô Số điện thoại
            txtSoDienThoai.MaxLength = 10; // Cấm gõ quá 10 số
            txtSoDienThoai.TextChanged += TxtSoDienThoai_TextChanged;
            txtSoDienThoai.KeyPress += TxtSoDienThoai_KeyPress; // Bật bẫy chặn chữ cái

            txtSoDienThoai.Focus(); // Tự động nháy chuột vào ô SĐT
        }

        // BẪY LỖI 1: Chỉ cho phép nhập số, chặn hoàn toàn chữ cái và ký tự đặc biệt
        private void TxtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Hủy lệnh gõ nếu không phải là số
            }
        }

        // Sự kiện khi khách hàng gõ số điện thoại
        private void TxtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSoDienThoai.Text.Trim();

            if (sdt == "0901234567" || sdt == "0912345678")
            {
                lblTrangThaiTimKiem.Text = "✓ Đã tìm thấy khách hàng thân thiết!";
                lblTrangThaiTimKiem.ForeColor = Color.FromArgb(16, 185, 129); // Màu Xanh
            }
            else if (sdt.Length == 10)
            {
                lblTrangThaiTimKiem.Text = "ℹ Khách hàng mới (chưa có trong hệ thống).";
                lblTrangThaiTimKiem.ForeColor = Color.FromArgb(234, 88, 12); // Màu Cam
            }
            else
            {
                lblTrangThaiTimKiem.Text = ""; // Xóa chữ nếu chưa gõ xong
            }
        }

        private void btnKhachLe_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Text = "Khách vãng lai";
            txtSoDienThoai.Text = "Không có";
            txtDiaChi.Text = "Mua trực tiếp tại quầy";
            ThucHienInHoaDon();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Tên khách hàng hoặc chọn 'Khách Lẻ'!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhachHang.Focus();
                return;
            }

            // BẪY LỖI 2: Nếu có nhập SĐT thì bắt buộc phải nhập đủ 10 số
            string sdt = txtSoDienThoai.Text.Trim();
            if (sdt != "" && sdt != "Không có" && sdt.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập đủ 10 chữ số.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            ThucHienInHoaDon();
        }

        private void btnDangKyMoi_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang.Text.Trim() == "" || txtSoDienThoai.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Số điện thoại!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // BẪY LỖI 3: Bấm đăng ký thì SĐT phải đúng 10 số
            if (txtSoDienThoai.Text.Trim().Length != 10)
            {
                MessageBox.Show("Số điện thoại phải bao gồm đúng 10 chữ số!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            MessageBox.Show("Đã lưu thông tin khách hàng [" + txtTenKhachHang.Text + "] vào hệ thống!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblTrangThaiTimKiem.Text = "✓ Đã lưu thông tin khách hàng mới!";
            lblTrangThaiTimKiem.ForeColor = Color.FromArgb(16, 185, 129);
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Hàm xử lý logic in hóa đơn chi tiết
        private void ThucHienInHoaDon()
        {
            string tenKH = txtTenKhachHang.Text != "" ? txtTenKhachHang.Text : "Khách vãng lai";
            string sdt = txtSoDienThoai.Text != "" ? txtSoDienThoai.Text : "Không có";
            string diaChi = txtDiaChi.Text != "" ? txtDiaChi.Text : "Mua trực tiếp tại quầy";

            string maDonHang = "HD_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string thoiGian = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            StringBuilder bill = new StringBuilder();
            bill.AppendLine("ĐANG GỬI LỆNH IN HÓA ĐƠN...\n");
            bill.AppendLine("Mã Đơn Hàng: " + maDonHang);
            bill.AppendLine("Thời gian: " + thoiGian);
            bill.AppendLine("Khách hàng: " + tenKH);
            bill.AppendLine("SĐT: " + sdt);
            bill.AppendLine("Địa chỉ: " + diaChi);
            bill.AppendLine("--------------------------------------------------------------");

            if (dtSanPham != null)
            {
                foreach (DataRow row in dtSanPham.Rows)
                {
                    string tenSP = row["Tên Sản Phẩm"].ToString();
                    string sl = row["Số Lượng"].ToString();
                    string tien = Convert.ToDouble(row["Thành Tiền"]).ToString("N0");
                    bill.AppendLine("- " + tenSP + " (x" + sl + "): " + tien + " đ");
                }
            }

            bill.AppendLine("--------------------------------------------------------------");
            bill.AppendLine("Tạm tính:     " + tamTinh.ToString("N0") + " đ");
            bill.AppendLine("Thuế VAT:     " + thueVAT.ToString("N0") + " đ");
            bill.AppendLine("TỔNG TIỀN:   " + tongTien.ToString("N0") + " VNĐ");
            bill.AppendLine("\nĐã in thành công hóa đơn tại quầy!");

            MessageBox.Show(bill.ToString(), "In Hóa Đơn Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // =======================================================
            // BẬT CỜ HIỆU BÁO GIAO DỊCH XONG ĐỂ TRANG BÁN HÀNG TỰ XÓA GIỎ
            // =======================================================
            KhoLichSu.VuaThanhToanXong = true;

            // Nhảy về trang Bán Hàng sau khi in
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmBanHang(), null);
            }
            else
            {
                this.Close();
            }
        }

        private void tblCanGiua_Paint(object sender, PaintEventArgs e)
        {
            // Để trống để tránh lỗi designer
        }

        private void btnHuyBo_Click_1(object sender, EventArgs e)
        {
            // Tìm Form Main (khung bọc ngoài cùng)
            frmMain mainForm = this.TopLevelControl as frmMain;

            if (mainForm != null)
            {
                // Mở lại form Thanh Toán và bưng theo dữ liệu giỏ hàng, tiền bạc về lại bên đó
                mainForm.OpenChildForm(new frmThanhToan(dtSanPham, tamTinh, thueVAT, tongTien), null);
            }
            else
            {
                // Phòng hờ nếu bạn đang chạy riêng lẻ form này để test thì chỉ cần đóng nó lại
                this.Close();
            }
        }
    }
}