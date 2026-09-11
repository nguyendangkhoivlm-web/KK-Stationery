using qlnhanvien;
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
    public partial class frmThanhToan : Form
    {
        string phuongThucThanhToan = "Tiền mặt";
        decimal tongTien = 0;
        double tamTinh = 0;
        double thueVAT = 0;
        DataTable dtSanPham = new DataTable();

        string phTienKhachDua = "Tiền khách đưa";
        string phSoThe = "Số thẻ";
        string phMMYY = "MM/YY";
        string phCVV = "CVV";
        string phTenChuThe = "Tên chủ thẻ";

        // 1. Constructor mặc định
        public frmThanhToan()
        {
            InitializeComponent();
            ThietLapGiaoDien();
        }

        // 2. CONSTRUCTOR đón dữ liệu
        public frmThanhToan(DataTable dt, double sub, double tax, double total)
        {
            InitializeComponent();

            this.dtSanPham = dt;
            this.tamTinh = sub;
            this.thueVAT = tax;
            this.tongTien = (decimal)total;

            ThietLapGiaoDien();
            HienThiDuLieuTruyenSang();
        }

        private void ThietLapGiaoDien()
        {
            // Đăng ký sự kiện cho nút Hoàn Tất
            if (btnHoanTat != null)
            {
                btnHoanTat.Click -= btnHoanTat_Click;
                btnHoanTat.Click += btnHoanTat_Click;
            }

            // Đăng ký sự kiện cho nút In Hóa Đơn
            if (btnInHoaDon != null)
            {
                btnInHoaDon.Click -= btnInHoaDon_Click;
                btnInHoaDon.Click += btnInHoaDon_Click;
            }

            // ĐĂNG KÝ SỰ KIỆN VÀ ÉP MÀU CHO NÚT QUAY LẠI (Chống tàng hình)
            if (btnquaylaitrangtruoc != null)
            {
                btnquaylaitrangtruoc.Click -= btnquaylaitrangtruoc_Click;
                btnquaylaitrangtruoc.Click += btnquaylaitrangtruoc_Click;

                // Ép màu để nút luôn hiện rõ trên nền trắng
                btnquaylaitrangtruoc.BackColor = Color.DimGray; // Nền xám đậm
                btnquaylaitrangtruoc.ForeColor = Color.White;   // Chữ màu trắng
                btnquaylaitrangtruoc.FlatStyle = FlatStyle.Flat; // Bỏ viền 3D cũ kỹ
            }

            ThietLapPlaceholder(txtTienKhachDua, phTienKhachDua);
            ThietLapPlaceholder(txtSoThe, phSoThe);
            ThietLapPlaceholder(txtNgayHetHan, phMMYY);
            ThietLapPlaceholder(txtMaCVV, phCVV);
            ThietLapPlaceholder(txtTenChuThe, phTenChuThe);

            if (cardTienMat != null) cardTienMat.Click += (s, e) => ChonPhuongThucThanhToan(cardTienMat, "Tiền mặt");
            if (cardTheNganHang != null) cardTheNganHang.Click += (s, e) => ChonPhuongThucThanhToan(cardTheNganHang, "Thẻ ngân hàng");

            // =========================================================================
            // BẤM VÀO KHUNG QR LÀ BAY QUA TRANG QUÉT MÃ LUÔN
            // =========================================================================
            if (cardQuetQR != null)
            {
                cardQuetQR.Click += (s, e) =>
                {
                    ChonPhuongThucThanhToan(cardQuetQR, "Quét mã QR");

                    // Tạo mã đơn và mở form Quét QR ngay lập tức
                    string maDonHang = "HD_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    frmMain mainForm = this.TopLevelControl as frmMain;
                    if (mainForm != null)
                    {
                        mainForm.OpenChildForm(new frmThanhToanQuaQR(dtSanPham, tamTinh, thueVAT, (double)tongTien, maDonHang), null);
                    }
                };
            }

            ChonPhuongThucThanhToan(cardTienMat, "Tiền mặt");
        }

        private void HienThiDuLieuTruyenSang()
        {
            if (lblNhanVien != null) lblNhanVien.Text = "Nhân viên: " + PhienDangNhap.HoVaTen;

            if (dtSanPham != null && dtSanPham.Rows.Count > 0 && dgvDanhSachSP != null)
            {
                dgvDanhSachSP.AutoGenerateColumns = true;
                dgvDanhSachSP.DataSource = dtSanPham;

                if (dgvDanhSachSP.Columns.Contains("Đơn Giá")) dgvDanhSachSP.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
                if (dgvDanhSachSP.Columns.Contains("Thành Tiền")) dgvDanhSachSP.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";
            }

            if (lblTamTinh != null) lblTamTinh.Text = "Tạm tính: " + tamTinh.ToString("N0") + " VNĐ";
            if (lblThueVAT != null) lblThueVAT.Text = "Thuế VAT (8%): " + thueVAT.ToString("N0") + " VNĐ";
            if (lblTongTien != null) lblTongTien.Text = "Tổng Tiền: " + tongTien.ToString("N0") + " VNĐ";
        }

        private void ThietLapPlaceholder(TextBox txt, string placeholder)
        {
            if (txt != null)
            {
                if (string.IsNullOrWhiteSpace(txt.Text) || txt.Text == placeholder)
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }

                txt.Enter += (s, e) => {
                    if (txt.Text == placeholder)
                    {
                        txt.Text = "";
                        txt.ForeColor = Color.Black;
                    }
                };

                txt.Leave += (s, e) => {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        txt.Text = placeholder;
                        txt.ForeColor = Color.Gray;
                    }
                };
            }
        }

        private void ChonPhuongThucThanhToan(Panel selectedCard, string tenPhuongThuc)
        {
            phuongThucThanhToan = tenPhuongThuc;
            Color normalBackColor = Color.White;

            if (cardTienMat != null) cardTienMat.BackColor = normalBackColor;
            if (cardTheNganHang != null) cardTheNganHang.BackColor = normalBackColor;
            if (cardQuetQR != null) cardQuetQR.BackColor = normalBackColor;

            if (selectedCard != null)
            {
                selectedCard.BackColor = Color.FromArgb(230, 242, 255);
            }
        }

        // ======================================================================
        // XỬ LÝ NÚT HOÀN TẤT THANH TOÁN (Dành cho Tiền mặt / Thẻ)
        // ======================================================================
        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            string maDonHang = "HD_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            // KIỂM TRA: Lỡ người dùng bấm nhầm nút Hoàn tất khi đang ở chế độ QR
            if (phuongThucThanhToan == "Quét mã QR")
            {
                frmMain mainForm = this.TopLevelControl as frmMain;
                if (mainForm != null)
                {
                    mainForm.OpenChildForm(new frmThanhToanQuaQR(dtSanPham, tamTinh, thueVAT, (double)tongTien, maDonHang), null);
                }
                return;
            }

            // ==========================================================
            // PHẦN BÊN DƯỚI DÀNH CHO TIỀN MẶT / THẺ NGÂN HÀNG
            // ==========================================================
            string tenNhanVien = !string.IsNullOrEmpty(PhienDangNhap.HoVaTen) ? PhienDangNhap.HoVaTen : "Trần Vũ Tuấn Kiệt";
            string thoiGian = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            KhoLichSu.DanhSachDonHang.Rows.Add(maDonHang, tenNhanVien, phuongThucThanhToan, tongTien, thoiGian);
            KhoLichSu.VuaThanhToanXong = true;

            MessageBox.Show("Thanh toán thành công!\nMã Đơn Hàng: " + maDonHang, "Hóa Đơn & Lịch Sử Giao Dịch", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmMain main = this.TopLevelControl as frmMain;
            if (main != null)
            {
                main.OpenChildForm(new frmLichSuBanHang(), null);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmThongTinDeIn(dtSanPham, tamTinh, thueVAT, (double)tongTien), null);
            }
        }

        // ======================================================================
        // XỬ LÝ NÚT QUAY LẠI TRANG TRƯỚC
        // ======================================================================
        private void btnquaylaitrangtruoc_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                // Gọi form Lập Hóa Đơn và truyền lại giỏ hàng hiện tại để không bị mất
                mainForm.OpenChildForm(new frmLapHoaDon(dtSanPham), null);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Các sự kiện mặc định để không bị lỗi giao diện Designer
        private void cardTienMat_Paint(object sender, PaintEventArgs e) { }
        private void cardTheNganHang_Paint(object sender, PaintEventArgs e) { }
        private void cardQuetQR_Paint(object sender, PaintEventArgs e) { }
        private void dgvDanhSachSP_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtNgayHetHan_TextChanged(object sender, EventArgs e) { }
        private void txtMaCVV_TextChanged(object sender, EventArgs e) { }
    }
}