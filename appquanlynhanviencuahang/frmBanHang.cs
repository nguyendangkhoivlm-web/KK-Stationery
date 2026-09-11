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
    public partial class frmBanHang : Form
    {
        // 1. Khai báo 2 bảng dữ liệu dùng chung (Giỏ hàng và Kho sản phẩm)
        DataTable dtGioHang = new DataTable();
        DataTable dtSanPham = new DataTable();

        public frmBanHang()
        {
            InitializeComponent();

            this.Load += (s, e) =>
            {
                DoiMauNutDanhMuc(btnDanhMucTatCa);
                KhoiTaoBangGioHang();
                TaoDanhSachSanPham(); // Nạp kho dữ liệu
                LoadDanhSachSanPham("Tất cả sản phẩm", ""); // Hiển thị ra giao diện
            };
        }

        // --- BƯỚC 1: KHỞI TẠO BẢNG GIỎ HÀNG ---
        private void KhoiTaoBangGioHang()
        {
            dtGioHang = new DataTable();
            dtGioHang.Columns.Add("Mã Sản Phẩm", typeof(string));
            dtGioHang.Columns.Add("Tên Sản Phẩm", typeof(string));
            dtGioHang.Columns.Add("Số Lượng", typeof(int));
            dtGioHang.Columns.Add("Đơn Giá", typeof(double));
            dtGioHang.Columns.Add("Thành Tiền", typeof(double));

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

        // --- BƯỚC 2: TẠO DỮ LIỆU SẢN PHẨM MẪU (Phục hồi từ bài cũ) ---
        private void TaoDanhSachSanPham()
        {
            dtSanPham = new DataTable();
            dtSanPham.Columns.Add("MaSP", typeof(string));
            dtSanPham.Columns.Add("TenSP", typeof(string));
            dtSanPham.Columns.Add("Gia", typeof(double));
            dtSanPham.Columns.Add("DanhMuc", typeof(string));

            // Nhóm Bút bi / Chì
            dtSanPham.Rows.Add("SP01", "Bút bi Thiên Long 0.5", 5000, "Bút bi/ Chì");
            dtSanPham.Rows.Add("SP02", "Bút bi bấm FO-024", 6000, "Bút bi/ Chì");
            dtSanPham.Rows.Add("SP03", "Bút chì 2B Deli", 7000, "Bút bi/ Chì");

            // Nhóm Tập học sinh
            dtSanPham.Rows.Add("SP07", "Tập học sinh 96T", 12000, "Tập học sinh");
            dtSanPham.Rows.Add("SP08", "Tập học sinh 200T", 22000, "Tập học sinh");

            // Nhóm Thước / Tẩy
            dtSanPham.Rows.Add("SP12", "Thước kẻ 20cm dẻo", 8000, "Thước/ Tẩy");
            dtSanPham.Rows.Add("SP14", "Gôm tẩy 4B Pentel", 10000, "Thước/ Tẩy");

            // Nhóm Compa / Màu
            dtSanPham.Rows.Add("SP16", "Bộ Compa học sinh", 35000, "Compa/ Màu");
            dtSanPham.Rows.Add("SP17", "Hộp sáp màu 24 màu", 45000, "Compa/ Màu");

            // Nhóm Bán chạy
            dtSanPham.Rows.Add("SP20", "Bút dạ quang Pastel", 32000, "Bán chạy");
            dtSanPham.Rows.Add("SP21", "Máy tính FX-580VN", 650000, "Bán chạy");
        }

        // --- BƯỚC 3: HIỂN THỊ SẢN PHẨM & TÌM KIẾM ---
        private void LoadDanhSachSanPham(string danhMuc, string tuKhoa = "")
        {
            if (flpDanhSachSP == null) return;
            flpDanhSachSP.Controls.Clear();

            // Duyệt qua kho dữ liệu thật thay vì vòng lặp giả
            foreach (DataRow row in dtSanPham.Rows)
            {
                string ma = row["MaSP"].ToString();
                string ten = row["TenSP"].ToString();
                decimal gia = Convert.ToDecimal(row["Gia"]);
                string loai = row["DanhMuc"].ToString();

                // Bộ lọc danh mục và từ khóa tìm kiếm
                if (danhMuc != "Tất cả sản phẩm" && loai != danhMuc) continue;
                if (!string.IsNullOrEmpty(tuKhoa) && !ten.ToLower().Contains(tuKhoa.ToLower())) continue;

                UC_CardSanPham card = new UC_CardSanPham();
                int ton = 20; // Tồn kho mẫu

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

        // --- XỬ LÝ THANH TÌM KIẾM ---
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            // Lấy từ khóa và tìm kiếm ngay khi gõ
            string tuKhoa = txtTimKiem.Text.Trim();
            if (tuKhoa == "Tìm kiếm sản phẩm theo tên hoặc mã...") tuKhoa = "";

            LoadDanhSachSanPham("Tất cả sản phẩm", tuKhoa);
        }

        // --- CÁC HÀM XỬ LÝ GIỎ HÀNG VÀ THANH TOÁN (Giữ nguyên) ---
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
                CapNhatTongTien();
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn hủy đơn hàng này không?", "Xác nhận hủy đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                dtGioHang.Rows.Clear();
                CapNhatTongTien();
                LoadDanhSachSanPham("Tất cả sản phẩm");
                MessageBox.Show("Đã hủy đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            foreach (DataRow row in dtGioHang.Rows)
            {
                if (row["Thành Tiền"] != DBNull.Value)
                {
                    tongTien += Convert.ToDecimal(row["Thành Tiền"]);
                }
            }

            string chuoiTien = tongTien.ToString("N0") + " đ";
            if (lblTongCongGiaTri != null) lblTongCongGiaTri.Text = chuoiTien;
            if (lblTongTien != null) lblTongTien.Text = chuoiTien;
        }

        // --- CÁC NÚT BẤM DANH MỤC ---
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