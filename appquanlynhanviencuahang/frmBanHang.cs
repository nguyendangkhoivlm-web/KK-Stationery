using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmBanHang : Form
    {
        static DataTable dtGioHang = null;
        DataTable dtSanPham = new DataTable();

        // Chuỗi kết nối chuẩn đến CSDL của bạn
        string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";

        public frmBanHang()
        {
            InitializeComponent();

            // Kích hoạt nối dây tự động cho TẤT CẢ các nút bấm trên form
            NoiDaySuKienToanBo();

            this.Load += FrmBanHang_Load;
            this.VisibleChanged += FrmBanHang_VisibleChanged;
        }

        // =========================================================================
        // HÀM ÉP NỐI DÂY SỰ KIỆN: ĐẢM BẢO 100% CÁC NÚT ĐỀU HOẠT ĐỘNG
        // =========================================================================
        private void NoiDaySuKienToanBo()
        {
            // 1. Nối dây ô tìm kiếm
            if (this.txtTimKiem != null)
            {
                this.txtTimKiem.TextChanged += txtTimKiem_TextChanged;
                this.txtTimKiem.Enter += txtTimKiem_Enter;
                this.txtTimKiem.Leave += txtTimKiem_Leave;
            }

            // 2. Nối dây các nút thao tác đơn hàng
            if (this.btnHuyDon != null) this.btnHuyDon.Click += btnHuyDon_Click;
            if (this.btnThanhToan != null) this.btnThanhToan.Click += btnThanhToan_Click;

            // 3. Nối dây các nút lọc Danh Mục (Lúc trước bị thiếu chỗ này nên bấm không ăn)
            if (this.btnDanhMucTatCa != null) this.btnDanhMucTatCa.Click += btnDanhMucTatCa_Click;
            if (this.btnDanhMucBanChay != null) this.btnDanhMucBanChay.Click += btnDanhMucBanChay_Click;
            if (this.btnDanhMucButChi != null) this.btnDanhMucButChi.Click += btnDanhMucButChi_Click;
            if (this.btnDanhMucThuocTay != null) this.btnDanhMucThuocTay.Click += btnDanhMucThuocTay_Click;
            if (this.btnDanhMucCompaMau != null) this.btnDanhMucCompaMau.Click += btnDanhMucCompaMau_Click;
            if (this.btnDanhMucTapHocSinh != null) this.btnDanhMucTapHocSinh.Click += btnDanhMucTapHocSinh_Click;
        }

        private void FrmBanHang_Load(object sender, EventArgs e)
        {
            DoiMauNutDanhMuc(btnDanhMucTatCa);
            KhoiTaoBangGioHang();

            // Lấy dữ liệu sản phẩm từ SQL
            TaoDanhSachSanPhamTuCSDL();
            LoadDanhSachSanPham("Tất cả sản phẩm", "");

            // Cài đặt chữ mờ (placeholder) cho ô tìm kiếm
            if (txtTimKiem != null)
            {
                txtTimKiem.Text = "Tìm kiếm sản phẩm theo tên hoặc mã...";
                txtTimKiem.ForeColor = Color.Gray;
            }

            KiemTraVaXoaGioHang();
            CapNhatTongTien();
        }

        private void FrmBanHang_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                KiemTraVaXoaGioHang();

                if (dgvGioHang != null)
                {
                    dgvGioHang.DataSource = null;
                    dgvGioHang.DataSource = dtGioHang;
                }
                CapNhatTongTien();
            }
        }

        // =========================================================================
        // LẤY DỮ LIỆU TỪ SQL SERVER
        // =========================================================================
        private void TaoDanhSachSanPhamTuCSDL()
        {
            dtSanPham = new DataTable();

            string query = @"
                SELECT 
                    sp.MaSanPham AS MaSP, 
                    sp.TenSanPham AS TenSP, 
                    sp.DonGia AS Gia, 
                    dm.TenDanhMuc AS DanhMuc, 
                    sp.SoLuongTon AS TonKho 
                FROM SanPham sp
                INNER JOIN DanhMuc dm ON sp.MaDanhMuc = dm.MaDanhMuc";

            try
            {
                using (SqlConnection con = new SqlConnection(chuoiKetNoi))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.Fill(dtSanPham);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TaoDuLieuMauDePhongHo();
            }
        }

        private void TaoDuLieuMauDePhongHo()
        {
            dtSanPham.Columns.Add("MaSP", typeof(string));
            dtSanPham.Columns.Add("TenSP", typeof(string));
            dtSanPham.Columns.Add("Gia", typeof(double));
            dtSanPham.Columns.Add("DanhMuc", typeof(string));
            dtSanPham.Columns.Add("TonKho", typeof(int));

            dtSanPham.Rows.Add("SP01", "Bút bi Thiên Long 0.5", 5000, "Bút bi/ Chì", 50);
            dtSanPham.Rows.Add("SP07", "Tập học sinh 96T", 12000, "Tập học sinh", 100);
            dtSanPham.Rows.Add("SP14", "Gôm tẩy 4B Pentel", 10000, "Thước/ Tẩy", 30);
        }

        // =========================================================================
        // HIỂN THỊ SẢN PHẨM LÊN GIAO DIỆN
        // =========================================================================
        private void LoadDanhSachSanPham(string danhMuc, string tuKhoa = "")
        {
            if (flpDanhSachSP == null) return;
            flpDanhSachSP.Controls.Clear();

            foreach (DataRow row in dtSanPham.Rows)
            {
                string ma = row["MaSP"].ToString();
                string ten = row["TenSP"].ToString();
                decimal gia = Convert.ToDecimal(row["Gia"]);
                string loai = row["DanhMuc"].ToString();

                int ton = (dtSanPham.Columns.Contains("TonKho") && row["TonKho"] != DBNull.Value)
                          ? Convert.ToInt32(row["TonKho"]) : 20;

                if (danhMuc != "Tất cả sản phẩm" && loai != danhMuc) continue;
                if (!string.IsNullOrEmpty(tuKhoa) && !ten.ToLower().Contains(tuKhoa.ToLower()) && !ma.ToLower().Contains(tuKhoa.ToLower())) continue;

                UC_CardSanPham card = new UC_CardSanPham();
                card.HienThi(ma, ten, gia, ton, "");

                card.ThemClick += (s, e) => {
                    if (card.SoLuongTon <= 0)
                    {
                        MessageBox.Show("Sản phẩm này đã hết hàng trong kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    card.SoLuongTon -= 1;
                    card.HienThi(card.MaSP, card.TenSP, card.DonGia, card.SoLuongTon, "");
                    ThemVaoGioHang(card.MaSP, card.TenSP, card.DonGia);
                };
                flpDanhSachSP.Controls.Add(card);
            }
        }

        // =========================================================================
        // XỬ LÝ GIỎ HÀNG VÀ THANH TOÁN
        // =========================================================================
        private void KhoiTaoBangGioHang()
        {
            if (dtGioHang == null)
            {
                dtGioHang = new DataTable();
                dtGioHang.Columns.Add("Mã Sản Phẩm", typeof(string));
                dtGioHang.Columns.Add("Tên Sản Phẩm", typeof(string));
                dtGioHang.Columns.Add("Số Lượng", typeof(int));
                dtGioHang.Columns.Add("Đơn Giá", typeof(double));
                dtGioHang.Columns.Add("Thành Tiền", typeof(double));
            }

            dgvGioHang.DataSource = dtGioHang;

            if (dgvGioHang.Columns.Contains("Đơn Giá")) dgvGioHang.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
            if (dgvGioHang.Columns.Contains("Thành Tiền")) dgvGioHang.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";

            if (!dgvGioHang.Columns.Contains("colXoa"))
            {
                DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();
                btnXoa.Name = "colXoa";
                btnXoa.HeaderText = "Hành động";
                btnXoa.Text = "Xóa";
                btnXoa.UseColumnTextForButtonValue = true;
                dgvGioHang.Columns.Add(btnXoa);
            }

            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.CellContentClick -= DgvGioHang_CellContentClick;
            dgvGioHang.CellContentClick += DgvGioHang_CellContentClick;
        }

        private void KiemTraVaXoaGioHang()
        {
            if (KhoLichSu.VuaThanhToanXong)
            {
                if (dtGioHang != null) dtGioHang.Rows.Clear();
                if (dgvGioHang != null)
                {
                    dgvGioHang.DataSource = null;
                    dgvGioHang.DataSource = dtGioHang;
                }

                LoadDanhSachSanPham("Tất cả sản phẩm");
                DoiMauNutDanhMuc(btnDanhMucTatCa);
                KhoLichSu.VuaThanhToanXong = false;
            }
        }

        private void ThemVaoGioHang(string maSP, string tenSP, decimal donGia)
        {
            bool daCo = false;
            foreach (DataRow row in dtGioHang.Rows)
            {
                if (row["Mã Sản Phẩm"].ToString() == maSP)
                {
                    int soLuongCu = Convert.ToInt32(row["Số Lượng"]);
                    row["Số Lượng"] = soLuongCu + 1;
                    row["Thành Tiền"] = (soLuongCu + 1) * (double)donGia;
                    daCo = true;
                    break;
                }
            }

            if (!daCo)
            {
                dtGioHang.Rows.Add(maSP, tenSP, 1, (double)donGia, (double)donGia);
            }

            if (dgvGioHang != null)
            {
                dgvGioHang.DataSource = null;
                dgvGioHang.DataSource = dtGioHang;
                if (dgvGioHang.Columns.Contains("Đơn Giá")) dgvGioHang.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
                if (dgvGioHang.Columns.Contains("Thành Tiền")) dgvGioHang.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";
            }
            CapNhatTongTien();
        }

        private void DgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGioHang.Columns[e.ColumnIndex].Name == "colXoa" && e.RowIndex >= 0)
            {
                string maSP = dtGioHang.Rows[e.RowIndex]["Mã Sản Phẩm"].ToString();
                int soLuongMua = Convert.ToInt32(dtGioHang.Rows[e.RowIndex]["Số Lượng"]);

                dtGioHang.Rows.RemoveAt(e.RowIndex);

                foreach (Control ctrl in flpDanhSachSP.Controls)
                {
                    if (ctrl is UC_CardSanPham card && card.MaSP == maSP)
                    {
                        card.SoLuongTon += soLuongMua;
                        card.HienThi(card.MaSP, card.TenSP, card.DonGia, card.SoLuongTon, "");
                        break;
                    }
                }

                if (dgvGioHang != null)
                {
                    dgvGioHang.DataSource = null;
                    dgvGioHang.DataSource = dtGioHang;
                    if (dgvGioHang.Columns.Contains("Đơn Giá")) dgvGioHang.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
                    if (dgvGioHang.Columns.Contains("Thành Tiền")) dgvGioHang.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";
                }
                CapNhatTongTien();
            }
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            if (dtGioHang != null)
            {
                foreach (DataRow row in dtGioHang.Rows)
                {
                    if (row["Thành Tiền"] != DBNull.Value)
                    {
                        tongTien += Convert.ToDecimal(row["Thành Tiền"]);
                    }
                }
            }

            string chuoiTien = tongTien.ToString("N0") + " đ";
            if (lblTongCongGiaTri != null) lblTongCongGiaTri.Text = chuoiTien;
            if (lblTongTien != null) lblTongTien.Text = chuoiTien;
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang == null || dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm vào giỏ trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmLapHoaDon(dtGioHang), null);
            }
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            if (dtGioHang == null || dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn hủy đơn hàng này không?", "Xác nhận hủy đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                dtGioHang.Rows.Clear();

                if (dgvGioHang != null)
                {
                    dgvGioHang.DataSource = null;
                    dgvGioHang.DataSource = dtGioHang;
                }

                CapNhatTongTien();
                LoadDanhSachSanPham("Tất cả sản phẩm");
                DoiMauNutDanhMuc(btnDanhMucTatCa);
                MessageBox.Show("Đã hủy đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // =========================================================================
        // XỬ LÝ TÌM KIẾM CHUẨN XÁC TRÊN Ô TXTTIMKIEM
        // =========================================================================
        string placeholderText = "Tìm kiếm sản phẩm theo tên hoặc mã...";

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == placeholderText)
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = placeholderText;
                txtTimKiem.ForeColor = Color.Gray;
                LoadDanhSachSanPham("Tất cả sản phẩm", "");
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != placeholderText)
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                LoadDanhSachSanPham("Tất cả sản phẩm", tuKhoa);
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        // =========================================================================
        // HIỆU ỨNG ĐỔI MÀU NÚT DANH MỤC
        // =========================================================================
        private void DoiMauNutDanhMuc(Button activeButton)
        {
            Color defaultBackColor = Color.White;
            Color defaultForeColor = Color.Black;

            if (btnDanhMucTatCa != null) { btnDanhMucTatCa.BackColor = defaultBackColor; btnDanhMucTatCa.ForeColor = defaultForeColor; }
            if (btnDanhMucBanChay != null) { btnDanhMucBanChay.BackColor = defaultBackColor; btnDanhMucBanChay.ForeColor = defaultForeColor; }
            if (btnDanhMucButChi != null) { btnDanhMucButChi.BackColor = defaultBackColor; btnDanhMucButChi.ForeColor = defaultForeColor; }
            if (btnDanhMucThuocTay != null) { btnDanhMucThuocTay.BackColor = defaultBackColor; btnDanhMucThuocTay.ForeColor = defaultForeColor; }
            if (btnDanhMucCompaMau != null) { btnDanhMucCompaMau.BackColor = defaultBackColor; btnDanhMucCompaMau.ForeColor = defaultForeColor; }
            if (btnDanhMucTapHocSinh != null) { btnDanhMucTapHocSinh.BackColor = defaultBackColor; btnDanhMucTapHocSinh.ForeColor = defaultForeColor; }

            if (activeButton != null)
            {
                activeButton.BackColor = Color.RoyalBlue;
                activeButton.ForeColor = Color.White;
            }
        }

        private void btnDanhMucTatCa_Click(object sender, EventArgs e) { DoiMauNutDanhMuc(btnDanhMucTatCa); LoadDanhSachSanPham("Tất cả sản phẩm"); }
        private void btnDanhMucBanChay_Click(object sender, EventArgs e) { DoiMauNutDanhMuc(btnDanhMucBanChay); LoadDanhSachSanPham("Bán chạy"); }
        private void btnDanhMucButChi_Click(object sender, EventArgs e) { DoiMauNutDanhMuc(btnDanhMucButChi); LoadDanhSachSanPham("Bút bi/ Chì"); }
        private void btnDanhMucThuocTay_Click(object sender, EventArgs e) { DoiMauNutDanhMuc(btnDanhMucThuocTay); LoadDanhSachSanPham("Thước/ Tẩy"); }
        private void btnDanhMucCompaMau_Click(object sender, EventArgs e) { DoiMauNutDanhMuc(btnDanhMucCompaMau); LoadDanhSachSanPham("Compa/ Màu"); }
        private void btnDanhMucTapHocSinh_Click(object sender, EventArgs e) { DoiMauNutDanhMuc(btnDanhMucTapHocSinh); LoadDanhSachSanPham("Tập học sinh"); }
    }
}