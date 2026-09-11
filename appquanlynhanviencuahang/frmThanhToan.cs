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
        decimal tongTien = 0; // Biến của bạn
        double tamTinh = 0;
        double thueVAT = 0;
        DataTable dtSanPham = new DataTable();

        string phTienKhachDua = "Tiền khách đưa";
        string phSoThe = "Số thẻ";
        string phMMYY = "MM/YY";
        string phCVV = "CVV";
        string phTenChuThe = "Tên chủ thẻ";

        // 1. Constructor mặc định (Giữ nguyên của bạn)
        public frmThanhToan()
        {
            InitializeComponent();
            ThietLapGiaoDien();
        }

        // 2. CONSTRUCTOR 4 THAM SỐ: Đón dữ liệu từ form Lập Hóa Đơn truyền sang
        public frmThanhToan(DataTable dt, double sub, double tax, double total)
        {
            InitializeComponent();

            // Hứng dữ liệu
            this.dtSanPham = dt;
            this.tamTinh = sub;
            this.thueVAT = tax;
            this.tongTien = (decimal)total; // Ép kiểu double sang decimal cho khớp biến của bạn

            ThietLapGiaoDien();
            HienThiDuLieuTruyenSang();
        }

        // Hàm gom các thiết lập giao diện gốc của bạn lại cho gọn
        private void ThietLapGiaoDien()
        {
            // Gán sự kiện Click trực tiếp bằng code cho các nút bấm chính để tránh bị mất kết nối
            if (btnHoanTat != null)
            {
                btnHoanTat.Click -= btnHoanTat_Click;
                btnHoanTat.Click += btnHoanTat_Click;
            }

            if (btnInHoaDon != null)
            {
                btnInHoaDon.Click -= btnInHoaDon_Click;
                btnInHoaDon.Click += btnInHoaDon_Click;
            }

            // Gán sự kiện ẩn/hiện chữ mờ cho các ô TextBox
            ThietLapPlaceholder(txtTienKhachDua, phTienKhachDua);
            ThietLapPlaceholder(txtSoThe, phSoThe);
            ThietLapPlaceholder(txtNgayHetHan, phMMYY);
            ThietLapPlaceholder(txtMaCVV, phCVV);
            ThietLapPlaceholder(txtTenChuThe, phTenChuThe);

            // Gán sự kiện chọn phương thức thanh toán
            if (cardTienMat != null) cardTienMat.Click += (s, e) => ChonPhuongThucThanhToan(cardTienMat, "Tiền mặt");
            if (cardTheNganHang != null) cardTheNganHang.Click += (s, e) => ChonPhuongThucThanhToan(cardTheNganHang, "Thẻ ngân hàng");
            if (cardQuetQR != null) cardQuetQR.Click += (s, e) => ChonPhuongThucThanhToan(cardQuetQR, "Quét mã QR");

            ChonPhuongThucThanhToan(cardTienMat, "Tiền mặt");
        }

        // Hàm đưa dữ liệu truyền sang lên các nhãn trên form (nếu có)
        private void HienThiDuLieuTruyenSang()
        {
            // Gắn tên nhân viên
            if (lblNhanVien != null) lblNhanVien.Text = "Nhân viên: Trần Vũ Tuấn Kiệt";

            // Đổ bảng sản phẩm ra Grid (ép tự sinh cột)
            if (dtSanPham != null && dtSanPham.Rows.Count > 0 && dgvDanhSachSP != null)
            {
                dgvDanhSachSP.AutoGenerateColumns = true;
                dgvDanhSachSP.DataSource = dtSanPham;

                if (dgvDanhSachSP.Columns.Contains("Đơn Giá")) dgvDanhSachSP.Columns["Đơn Giá"].DefaultCellStyle.Format = "N0";
                if (dgvDanhSachSP.Columns.Contains("Thành Tiền")) dgvDanhSachSP.Columns["Thành Tiền"].DefaultCellStyle.Format = "N0";
            }

            // Gắn số tiền
            if (lblTamTinh != null) lblTamTinh.Text = "Tạm tính: " + tamTinh.ToString("N0") + " VNĐ";
            if (lblThueVAT != null) lblThueVAT.Text = "Thuế VAT (8%): " + thueVAT.ToString("N0") + " VNĐ";
            if (lblTongTien != null) lblTongTien.Text = "Tổng Tiền: " + tongTien.ToString("N0") + " VNĐ";
        }

        // --- CÁC HÀM XỬ LÝ GIAO DIỆN (GIỮ NGUYÊN CỦA BẠN) ---
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

        // Nút Hoàn Tất Giao Dịch
        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            string thongBao = string.Format("Thanh toán thành công!\nPhương thức: {0}\nTổng thanh toán: {1:N0} VNĐ", phuongThucThanhToan, tongTien);
            MessageBox.Show(thongBao, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                // Gọi form lịch sử bán hàng theo code của bạn
                mainForm.OpenChildForm(new frmLichSuBanHang(), null);
            }
        }

        // Nút In Hóa Đơn -> Chuyển sang form frmThongTinDeIn
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                // Ở đây mình truyền cả dtSanPham sang frmThongTinDeIn để sau này in hóa đơn có chi tiết luôn
                mainForm.OpenChildForm(new frmThongTinDeIn(dtSanPham, tamTinh, thueVAT, (double)tongTien), null);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Các sự kiện trống giữ nguyên
        private void cardTienMat_Paint(object sender, PaintEventArgs e) { }
        private void cardTheNganHang_Paint(object sender, PaintEventArgs e) { }
        private void cardQuetQR_Paint(object sender, PaintEventArgs e) { }
        private void dgvDanhSachSP_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtNgayHetHan_TextChanged(object sender, EventArgs e) { }
        private void txtMaCVV_TextChanged(object sender, EventArgs e) { }
    }
}