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
        public frmLapHoaDon(DataTable dtTruyenSang) : this()
        {
            if (dtTruyenSang != null)
            {
                dtSanPham = dtTruyenSang.Copy(); // Copy dữ liệu sang bảng hóa đơn
            }
        }

        // 3. Sự kiện Load Form
        private void frmLapHoaDon_Load(object sender, EventArgs e)
        {
            // Ép lưới tự động sinh cột để đảm bảo 100% hiển thị
            if (dgvDanhSachSanPham != null)
            {
                dgvDanhSachSanPham.AutoGenerateColumns = true;
            }

            // Nếu chưa có dữ liệu truyền qua thì tạo bảng mẫu
            if (dtSanPham == null || dtSanPham.Rows.Count == 0 || dtSanPham.Columns.Count == 0)
            {
                KhoiTaoBangSanPhamMau();
            }
            else
            {
                // CÓ DỮ LIỆU TỪ TRANG BÁN HÀNG: Ép lưới cập nhật lại dữ liệu mới
                if (dgvDanhSachSanPham != null)
                {
                    dgvDanhSachSanPham.DataSource = null; // Gỡ dữ liệu cũ để ép lưới tải lại
                    dgvDanhSachSanPham.DataSource = dtSanPham; // Gán dữ liệu giỏ hàng vào

                    if (dgvDanhSachSanPham.Columns.Contains("Đơn Giá"))
                        dgvDanhSachSanPham.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
                    if (dgvDanhSachSanPham.Columns.Contains("Thành Tiền"))
                        dgvDanhSachSanPham.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";
                }
            }

            TinhTongTien();

            // Hiển thị thông tin người lập và ngày hiện tại
            if (lblNhanVien != null)
                lblNhanVien.Text = "Nhân viên: Trần Vũ Tuấn Kiệt";
            if (lblNgayLap != null)
                lblNgayLap.Text = "Ngày Lập: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        // 4. Khởi tạo bảng mẫu
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

            if (dgvDanhSachSanPham != null)
            {
                dgvDanhSachSanPham.DataSource = dtSanPham;
                if (dgvDanhSachSanPham.Columns.Contains("Đơn Giá"))
                    dgvDanhSachSanPham.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
                if (dgvDanhSachSanPham.Columns.Contains("Thành Tiền"))
                    dgvDanhSachSanPham.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";
            }
        }

        // 5. Tính tổng tiền tạm tính, VAT và tổng cộng
        private void TinhTongTien()
        {
            tamTinh = 0;

            for (int i = 0; i < dtSanPham.Rows.Count; i++)
            {
                if (dtSanPham.Rows[i]["Thành Tiền"] != DBNull.Value)
                {
                    tamTinh += Convert.ToDouble(dtSanPham.Rows[i]["Thành Tiền"]);
                }
            }

            thueVAT = tamTinh * 0.08; // VAT 8%
            tongCong = tamTinh + thueVAT;

            if (lblTamTinh != null) lblTamTinh.Text = "Tạm tính: " + tamTinh.ToString("N0") + " VNĐ";
            if (lblThueVAT != null) lblThueVAT.Text = "Thuế VAT (8%): " + thueVAT.ToString("N0") + " VNĐ";
            if (lblTongCong != null) lblTongCong.Text = "Tổng cộng: " + tongCong.ToString("N0") + " VNĐ";
        }

        // 6. Nút Cập nhật hóa đơn
        private void btnCapNhatHoaDon_Click(object sender, EventArgs e)
        {
            TinhTongTien();
            if (lblKhachHang != null) lblKhachHang.Text = "Khách Hàng: Khách vãng lai";
            MessageBox.Show("Đã làm mới lại thông tin hóa đơn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 7. Nút Thêm sản phẩm
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            string maMoi = "SP0" + (dtSanPham.Rows.Count + 1);
            dtSanPham.Rows.Add(maMoi, "Gôm tẩy 4B Pentel", 2, 10000, 20000);

            if (dgvDanhSachSanPham != null)
            {
                dgvDanhSachSanPham.DataSource = null;
                dgvDanhSachSanPham.DataSource = dtSanPham;
            }

            TinhTongTien();
        }

        // 8. Nút Xóa sản phẩm
        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSanPham != null && dgvDanhSachSanPham.CurrentRow != null && dgvDanhSachSanPham.CurrentRow.Index >= 0)
            {
                int viTri = dgvDanhSachSanPham.CurrentRow.Index;
                string tenSP = dtSanPham.Rows[viTri]["Tên Sản Phẩm"].ToString();

                DialogResult dr = MessageBox.Show(
                    "Bạn có chắc muốn xóa '" + tenSP + "' khỏi hóa đơn không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    dtSanPham.Rows.RemoveAt(viTri);

                    if (dgvDanhSachSanPham != null)
                    {
                        dgvDanhSachSanPham.DataSource = null;
                        dgvDanhSachSanPham.DataSource = dtSanPham;
                    }

                    TinhTongTien();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 9. Nút Lưu nháp
        private void btnLuuNhap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã lưu nháp hóa đơn thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 10. Nút Quay Lại Trang Trước
        private void btnTroLaiTrangTruoc_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmBanHang(), null);
            }
        }

        // 11. Nút Thanh toán
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
            else
            {
                frmThanhToan f = new frmThanhToan(dtSanPham, tamTinh, thueVAT, tongCong);
                f.ShowDialog();
            }
        }

        // 12. Xử lý ô tìm kiếm (hiệu ứng mờ)
        private void txtTimKiemSanPham_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemSanPham != null && txtTimKiemSanPham.Text == "Tìm kiếm sản phẩm theo tên hoặc mã...")
            {
                txtTimKiemSanPham.Text = "";
                txtTimKiemSanPham.ForeColor = Color.Black;
            }
        }

        private void txtTimKiemSanPham_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemSanPham != null && string.IsNullOrWhiteSpace(txtTimKiemSanPham.Text))
            {
                txtTimKiemSanPham.Text = "Tìm kiếm sản phẩm theo tên hoặc mã...";
                txtTimKiemSanPham.ForeColor = Color.Gray;
            }
        }

        // Sự kiện gõ text tìm kiếm
        private void txtTimKiemSanPham_TextChanged(object sender, EventArgs e)
        {
        }

        
    }
}