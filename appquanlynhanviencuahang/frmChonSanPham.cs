using System;
using System.Data;
using System.Data.SqlClient; // Thư viện kết nối CSDL
using System.Drawing;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmChonSanPham : Form
    {
        // Khai báo chuỗi kết nối chuẩn đến CSDL của bạn
        string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";

        DataTable dtKhoSanPham = new DataTable();
        string placeholderText = "Tìm kiếm sản phẩm theo tên hoặc mã...";

        // Biến lưu trữ giỏ hàng hiện tại do form Lập Hóa Đơn truyền qua
        DataTable dtGioHangDangMua = new DataTable();

        public frmChonSanPham()
        {
            InitializeComponent();
        }

        public frmChonSanPham(DataTable dtTruyenSang)
        {
            InitializeComponent();
            if (dtTruyenSang != null)
            {
                dtGioHangDangMua = dtTruyenSang;
            }
        }

        private void frmChonSanPham_Load(object sender, EventArgs e)
        {
            // Gọi hàm tải dữ liệu từ CSDL SQL Server thay vì gán cứng
            TaiDuLieuSanPhamTuCSDL();

            // Đổ danh mục lên ComboBox
            cboDanhMuc.Items.Add("Tất cả");
            cboDanhMuc.Items.Add("Bút bi/ Chì");
            cboDanhMuc.Items.Add("Tập học sinh");
            cboDanhMuc.Items.Add("Thước/ Tẩy");
            cboDanhMuc.Items.Add("Bán chạy");
            cboDanhMuc.SelectedIndex = 0;

            dgvDanhSachSanPham.AutoGenerateColumns = false;
            dgvDanhSachSanPham.DataSource = dtKhoSanPham;
            if (dgvDanhSachSanPham.Columns.Contains("colDonGia"))
            {
                dgvDanhSachSanPham.Columns["colDonGia"].DefaultCellStyle.Format = "N0";
            }

            txtTimKiem.Text = placeholderText;
            txtTimKiem.ForeColor = Color.Gray;

            // KHÓA Ô SỐ LƯỢNG KHI MỚI MỞ FORM (Chưa chọn món nào thì không cho tăng giảm)
            numSoLuongChon.Enabled = false;
        }

        // =========================================================================
        // HÀM KÉO DỮ LIỆU TỪ SQL SERVER (Dùng JOIN để lấy tên danh mục)
        // =========================================================================
        private void TaiDuLieuSanPhamTuCSDL()
        {
            dtKhoSanPham = new DataTable();

            string query = @"
                SELECT 
                    sp.MaSanPham AS MaSP, 
                    sp.TenSanPham AS TenSP, 
                    dm.TenDanhMuc AS DanhMuc, 
                    sp.DonGia AS DonGia, 
                    sp.SoLuongTon AS TonKho, 
                    sp.DonViTinh AS DonViTinh 
                FROM SanPham sp
                INNER JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc";

            try
            {
                using (SqlConnection con = new SqlConnection(chuoiKetNoi))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.Fill(dtKhoSanPham);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL khi tải danh sách chọn sản phẩm: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================================
        // SỰ KIỆN KHI BẤM CHỌN 1 DÒNG TRÊN BẢNG (Xử lý Tồn Kho tại đây)
        // ==========================================================
        private void dgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDanhSachSanPham.CurrentRow != null && e.RowIndex >= 0)
            {
                string tenSP = dgvDanhSachSanPham.CurrentRow.Cells["colTenSP"].Value.ToString();
                string giaSP = Convert.ToDouble(dgvDanhSachSanPham.CurrentRow.Cells["colDonGia"].Value).ToString("N0");
                int tonKho = Convert.ToInt32(dgvDanhSachSanPham.CurrentRow.Cells["colTonKho"].Value);

                lblSanPhamDangChon.Text = tenSP + " - " + giaSP + " VNĐ (Tồn: " + tonKho + ")";
                lblSanPhamDangChon.ForeColor = Color.RoyalBlue;

                // Kiểm tra tồn kho để mở khóa hoặc khóa ô chọn số lượng
                if (tonKho > 0)
                {
                    numSoLuongChon.Enabled = true; // Mở khóa cho phép bấm
                    numSoLuongChon.Maximum = tonKho; // Ép giới hạn tối đa bằng đúng số tồn kho
                    numSoLuongChon.Minimum = 1;
                    numSoLuongChon.Value = 1; // Mặc định mua 1 món
                }
                else
                {
                    numSoLuongChon.Enabled = false; // Hết hàng thì khóa lại
                    MessageBox.Show("Sản phẩm này hiện đã hết hàng trong kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // ==========================================================
        // XÁC NHẬN THÊM VÀO GIỎ & QUAY VỀ TRANG HÓA ĐƠN
        // ==========================================================
        private void btnXacNhanThem_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachSanPham.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn 1 sản phẩm từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numSoLuongChon.Enabled == false)
            {
                MessageBox.Show("Sản phẩm này đã hết hàng, không thể thêm vào hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSP = dgvDanhSachSanPham.CurrentRow.Cells["colMaSP"].Value.ToString();
            string tenSP = dgvDanhSachSanPham.CurrentRow.Cells["colTenSP"].Value.ToString();
            double donGia = Convert.ToDouble(dgvDanhSachSanPham.CurrentRow.Cells["colDonGia"].Value);
            int soLuongMua = (int)numSoLuongChon.Value;

            bool daCoTrongHoaDon = false;

            for (int i = 0; i < dtGioHangDangMua.Rows.Count; i++)
            {
                if (dtGioHangDangMua.Rows[i]["Mã Sản Phẩm"].ToString() == maSP)
                {
                    int soLuongCu = Convert.ToInt32(dtGioHangDangMua.Rows[i]["Số Lượng"]);
                    dtGioHangDangMua.Rows[i]["Số Lượng"] = soLuongCu + soLuongMua;
                    dtGioHangDangMua.Rows[i]["Thành Tiền"] = (soLuongCu + soLuongMua) * donGia;
                    daCoTrongHoaDon = true;
                    break;
                }
            }

            if (daCoTrongHoaDon == false)
            {
                double thanhTien = soLuongMua * donGia;
                dtGioHangDangMua.Rows.Add(maSP, tenSP, soLuongMua, donGia, thanhTien);
            }

            MessageBox.Show("Đã thêm thành công vào hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            QuayVeTrangHoaDon();
        }

        // ==========================================================
        // CÁC NÚT ĐÓNG, HỦY VÀ HÀM QUAY VỀ
        // ==========================================================
        private void QuayVeTrangHoaDon()
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmLapHoaDon(dtGioHangDangMua), null);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e) { QuayVeTrangHoaDon(); }
        private void btnDong_Click(object sender, EventArgs e) { QuayVeTrangHoaDon(); }
        private void btnHuyBo_Click_1(object sender, EventArgs e) { QuayVeTrangHoaDon(); }

        // ==========================================================
        // TÌM KIẾM, LỌC & LÀM MỚI
        // ==========================================================
        private void LocDuLieu()
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            if (tuKhoa == placeholderText.ToLower()) tuKhoa = "";
            string danhMucChon = cboDanhMuc.Text;

            DataTable dtLoc = dtKhoSanPham.Clone();

            for (int i = 0; i < dtKhoSanPham.Rows.Count; i++)
            {
                string ma = dtKhoSanPham.Rows[i]["MaSP"].ToString().ToLower();
                string ten = dtKhoSanPham.Rows[i]["TenSP"].ToString().ToLower();
                string dm = dtKhoSanPham.Rows[i]["DanhMuc"].ToString();

                bool dungTuKhoa = (tuKhoa == "" || ma.Contains(tuKhoa) || ten.Contains(tuKhoa));
                bool dungDanhMuc = (danhMucChon == "Tất cả" || dm == danhMucChon);

                if (dungTuKhoa == true && dungDanhMuc == true)
                {
                    dtLoc.ImportRow(dtKhoSanPham.Rows[i]);
                }
            }

            dgvDanhSachSanPham.DataSource = dtLoc;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e) { LocDuLieu(); }
        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e) { LocDuLieu(); }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = placeholderText;
            txtTimKiem.ForeColor = Color.Gray;
            cboDanhMuc.SelectedIndex = 0;

            // Đưa mọi thứ về trạng thái ban đầu
            numSoLuongChon.Value = 1;
            numSoLuongChon.Enabled = false;
            lblSanPhamDangChon.Text = "Chưa chọn sản phẩm nào...";
            lblSanPhamDangChon.ForeColor = Color.Gray;

            dgvDanhSachSanPham.DataSource = dtKhoSanPham;
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == placeholderText) { txtTimKiem.Text = ""; txtTimKiem.ForeColor = Color.Black; }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "") { txtTimKiem.Text = placeholderText; txtTimKiem.ForeColor = Color.Gray; }
        }
    }
}