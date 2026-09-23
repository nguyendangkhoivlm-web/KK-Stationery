using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmLapHoaDon : Form
    {
        DataTable dtSanPham = new DataTable();
        double tamTinh = 0;
        double thueVAT = 0;
        double tongCong = 0;

        // 1. Constructor mặc định
        public frmLapHoaDon()
        {
            InitializeComponent();
        }

        // 2. Constructor nhận dữ liệu từ Form Bán Hàng truyền sang
        public frmLapHoaDon(DataTable dtTruyenSang)
        {
            InitializeComponent();
            if (dtTruyenSang != null)
            {
                dtSanPham = dtTruyenSang.Copy(); // Copy dữ liệu sang bảng hóa đơn
            }
        }

        // 3. Sự kiện Load Form
        private void frmLapHoaDon_Load(object sender, EventArgs e)
        {
            dgvDanhSachSanPham.AutoGenerateColumns = true;

            // Nếu chưa có dữ liệu truyền qua thì tạo bảng mẫu để test
            if (dtSanPham.Rows.Count == 0)
            {
                KhoiTaoBangSanPhamMau();
            }

            // Đổ dữ liệu lên bảng
            dgvDanhSachSanPham.DataSource = dtSanPham;
            if (dgvDanhSachSanPham.Columns.Contains("Đơn Giá")) dgvDanhSachSanPham.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
            if (dgvDanhSachSanPham.Columns.Contains("Thành Tiền")) dgvDanhSachSanPham.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";

            // Tính tiền và hiển thị thông tin
            TinhTongTien();

            // Lấy tên nhân viên đang đăng nhập (hoặc tên mặc định)
            string tenNV = !string.IsNullOrEmpty(PhienDangNhap.HoVaTen) ? PhienDangNhap.HoVaTen : "Trần Vũ Tuấn Kiệt";
            lblNhanVien.Text = "Nhân viên: " + tenNV;
            lblNgayLap.Text = "Ngày Lập: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        // 4. Khởi tạo bảng mẫu (Dùng khi chạy thẳng form này mà không qua form Bán Hàng)
        private void KhoiTaoBangSanPhamMau()
        {
            dtSanPham = new DataTable();
            dtSanPham.Columns.Add("Mã Sản Phẩm", typeof(string));
            dtSanPham.Columns.Add("Tên Sản Phẩm", typeof(string));
            dtSanPham.Columns.Add("Số Lượng", typeof(int));
            dtSanPham.Columns.Add("Đơn Giá", typeof(double));
            dtSanPham.Columns.Add("Thành Tiền", typeof(double));

            dtSanPham.Rows.Add("SP01", "Bút bi Thiên Long 0.5", 5, 5000, 25000);
            dtSanPham.Rows.Add("SP02", "Tập học sinh 96 trang", 10, 12000, 120000);
            dtSanPham.Rows.Add("SP03", "Bộ Compa học sinh Deli", 1, 35000, 35000);
        }

        // 5. Hàm tính toán tiền
        private void TinhTongTien()
        {
            tamTinh = 0;

            // Vòng lặp cơ bản tính tổng cột Thành Tiền
            for (int i = 0; i < dtSanPham.Rows.Count; i++)
            {
                tamTinh += Convert.ToDouble(dtSanPham.Rows[i]["Thành Tiền"]);
            }

            thueVAT = tamTinh * 0.08; // VAT 8%
            tongCong = tamTinh + thueVAT;

            lblTamTinh.Text = "Tạm tính: " + tamTinh.ToString("N0") + " VNĐ";
            lblThueVAT.Text = "Thuế VAT (8%): " + thueVAT.ToString("N0") + " VNĐ";
            lblTongCong.Text = "Tổng cộng: " + tongCong.ToString("N0") + " VNĐ";
        }

        // 6. Các nút chức năng
        private void btnCapNhatHoaDon_Click(object sender, EventArgs e)
        {
            TinhTongTien();
            lblKhachHang.Text = "Khách Hàng: Khách vãng lai";
            MessageBox.Show("Đã làm mới lại thông tin hóa đơn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            // Tìm Form Main (form cha) đang bọc cái form hiện tại
            frmMain mainForm = this.TopLevelControl as frmMain;

            if (mainForm != null)
            {
                // Mở form Chọn Sản Phẩm ngay BÊN TRONG form cha
                // Đồng thời quăng cái giỏ hàng (dtSanPham) sang form đó để nó thêm đồ vào
                mainForm.OpenChildForm(new frmChonSanPham(dtSanPham), null);
            }
        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSanPham.CurrentRow != null)
            {
                int viTri = dgvDanhSachSanPham.CurrentRow.Index;
                string tenSP = dtSanPham.Rows[viTri]["Tên Sản Phẩm"].ToString();

                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa '" + tenSP + "' khỏi hóa đơn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    dtSanPham.Rows.RemoveAt(viTri);
                    dgvDanhSachSanPham.DataSource = null;
                    dgvDanhSachSanPham.DataSource = dtSanPham;
                    TinhTongTien();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuuNhap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã lưu nháp hóa đơn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTroLaiTrangTruoc_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmBanHang(), null);
            }
        }

        private void btnThanhToan1_Click(object sender, EventArgs e)
        {
            if (dtSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong hóa đơn để thanh toán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmThanhToan(dtSanPham, tamTinh, thueVAT, tongCong), null);
            }
        }

        // 7. Xử lý ô tìm kiếm (hiệu ứng mờ)
        private void txtTimKiemSanPham_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemSanPham.Text == "Tìm kiếm sản phẩm theo tên hoặc mã...")
            {
                txtTimKiemSanPham.Text = "";
                txtTimKiemSanPham.ForeColor = Color.Black;
            }
        }

        private void txtTimKiemSanPham_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemSanPham.Text.Trim() == "")
            {
                txtTimKiemSanPham.Text = "Tìm kiếm sản phẩm theo tên hoặc mã...";
                txtTimKiemSanPham.ForeColor = Color.Gray;
            }
        }

        private void txtTimKiemSanPham_TextChanged(object sender, EventArgs e)
        {
            // Để trống, sau này có thể thêm code lọc sản phẩm giống bên Form Khách Hàng
        }
    }
}