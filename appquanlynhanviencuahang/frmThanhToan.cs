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

        string phTienKhachDua = "Tiền khách đưa";
        string phSoThe = "Số thẻ";
        string phMMYY = "MM/YY";
        string phCVV = "CVV";
        string phTenChuThe = "Tên chủ thẻ";

        public frmThanhToan()
        {
            InitializeComponent();

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
                mainForm.OpenChildForm(new frmLichSuBanHang(), null);
            }
        }

        // Nút In Hóa Đơn -> Chuyển sang form frmThongTinDeIn trong panel1 của frmMain
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmThongTinDeIn(), null);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cardTienMat_Paint(object sender, PaintEventArgs e) { }
        private void cardTheNganHang_Paint(object sender, PaintEventArgs e) { }
        private void cardQuetQR_Paint(object sender, PaintEventArgs e) { }
        private void dgvDanhSachSP_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtNgayHetHan_TextChanged(object sender, EventArgs e) { }
        private void txtMaCVV_TextChanged(object sender, EventArgs e) { }
    }
}