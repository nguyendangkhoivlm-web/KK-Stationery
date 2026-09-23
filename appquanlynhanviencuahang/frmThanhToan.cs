using qlnhanvien;
using System;
using System.Data;
using System.Data.SqlClient; // BẮT BUỘC THÊM ĐỂ KẾT NỐI SQL
using System.Drawing;
using System.Text;
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

        public frmThanhToan()
        {
            InitializeComponent();
            ThietLapGiaoDien();
        }

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

            if (btnquaylaitrangtruoc != null)
            {
                btnquaylaitrangtruoc.Click -= btnquaylaitrangtruoc_Click;
                btnquaylaitrangtruoc.Click += btnquaylaitrangtruoc_Click;
                btnquaylaitrangtruoc.BackColor = Color.DimGray;
                btnquaylaitrangtruoc.ForeColor = Color.White;
                btnquaylaitrangtruoc.FlatStyle = FlatStyle.Flat;
            }

            ThietLapPlaceholder(txtTienKhachDua, phTienKhachDua);
            ThietLapPlaceholder(txtSoThe, phSoThe);
            ThietLapPlaceholder(txtNgayHetHan, phMMYY);
            ThietLapPlaceholder(txtMaCVV, phCVV);
            ThietLapPlaceholder(txtTenChuThe, phTenChuThe);

            if (cardTienMat != null) cardTienMat.Click += (s, e) => ChonPhuongThucThanhToan(cardTienMat, "Tiền mặt");
            if (cardTheNganHang != null) cardTheNganHang.Click += (s, e) => ChonPhuongThucThanhToan(cardTheNganHang, "Thẻ ngân hàng");

            if (cardQuetQR != null)
            {
                cardQuetQR.Click += (s, e) =>
                {
                    ChonPhuongThucThanhToan(cardQuetQR, "Quét mã QR");
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
                txt.Enter += (s, e) => { if (txt.Text == placeholder) { txt.Text = ""; txt.ForeColor = Color.Black; } };
                txt.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txt.Text)) { txt.Text = placeholder; txt.ForeColor = Color.Gray; } };
            }
        }

        private void ChonPhuongThucThanhToan(Panel selectedCard, string tenPhuongThuc)
        {
            phuongThucThanhToan = tenPhuongThuc;
            Color normalBackColor = Color.White;

            if (cardTienMat != null) cardTienMat.BackColor = normalBackColor;
            if (cardTheNganHang != null) cardTheNganHang.BackColor = normalBackColor;
            if (cardQuetQR != null) cardQuetQR.BackColor = normalBackColor;

            if (selectedCard != null) selectedCard.BackColor = Color.FromArgb(230, 242, 255);
        }

        // ======================================================================
        // NÚT HOÀN TẤT THANH TOÁN SẼ LƯU VÀO CSDL VÀ IN BILL
        // ======================================================================
        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            string maDonHang = "HD_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            if (phuongThucThanhToan == "Quét mã QR")
            {
                frmMain mainForm = this.TopLevelControl as frmMain;
                if (mainForm != null) mainForm.OpenChildForm(new frmThanhToanQuaQR(dtSanPham, tamTinh, thueVAT, (double)tongTien, maDonHang), null);
                return;
            }

            string maNhanVien = !string.IsNullOrEmpty(PhienDangNhap.MaNhanVien) ? PhienDangNhap.MaNhanVien : "NV01";
            string thoiGian = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // 1. TIẾN HÀNH LƯU DỮ LIỆU XUỐNG SQL SERVER
            string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";
            try
            {
                using (SqlConnection con = new SqlConnection(chuoiKetNoi))
                {
                    con.Open();

                    // Lưu vào bảng HoaDon (Tạm gán 'KH03' là Khách vãng lai, sửa lại mã KH nếu cần)
                    string sqlInsertHoaDon = "INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayLap, TongTien) VALUES (@MaHD, 'KH03', @MaNV, @NgayLap, @TongTien)";
                    using (SqlCommand cmd = new SqlCommand(sqlInsertHoaDon, con))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", maDonHang);
                        cmd.Parameters.AddWithValue("@MaNV", maNhanVien);
                        cmd.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TongTien", tongTien);
                        cmd.ExecuteNonQuery();
                    }

                    // Lưu từng sản phẩm vào bảng ChiTietHoaDon và Trừ Tồn Kho
                    if (dtSanPham != null)
                    {
                        foreach (DataRow row in dtSanPham.Rows)
                        {
                            string maSP = row["Mã Sản Phẩm"].ToString();
                            int soLuong = Convert.ToInt32(row["Số Lượng"]);
                            double gia = Convert.ToDouble(row["Đơn Giá"]);
                            double tien = Convert.ToDouble(row["Thành Tiền"]);

                            // Lưu chi tiết
                            string sqlInsertCTHD = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien) VALUES (@MaHD, @MaSP, @SL, @Gia, @Tien)";
                            using (SqlCommand cmdCTHD = new SqlCommand(sqlInsertCTHD, con))
                            {
                                cmdCTHD.Parameters.AddWithValue("@MaHD", maDonHang);
                                cmdCTHD.Parameters.AddWithValue("@MaSP", maSP);
                                cmdCTHD.Parameters.AddWithValue("@SL", soLuong);
                                cmdCTHD.Parameters.AddWithValue("@Gia", gia);
                                cmdCTHD.Parameters.AddWithValue("@Tien", tien);
                                cmdCTHD.ExecuteNonQuery();
                            }

                            // Trừ tồn kho
                            string sqlUpdateTonKho = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL WHERE MaSanPham = @MaSP";
                            using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateTonKho, con))
                            {
                                cmdUpdate.Parameters.AddWithValue("@SL", soLuong);
                                cmdUpdate.Parameters.AddWithValue("@MaSP", maSP);
                                cmdUpdate.ExecuteNonQuery();
                            }
                        }
                    }
                }
                // Bật cờ hiệu để trang Bán Hàng tự xóa giỏ hàng
                KhoLichSu.VuaThanhToanXong = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu hóa đơn vào CSDL: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Có lỗi thì dừng, không in bill
            }

            // 2. TẠO HÓA ĐƠN CHI TIẾT CHO KHÁCH HÀNG SAU KHI LƯU CSDL THÀNH CÔNG
            StringBuilder bill = new StringBuilder();
            bill.AppendLine("THANH TOÁN THÀNH CÔNG!\n");
            bill.AppendLine("Mã Đơn Hàng: " + maDonHang);
            bill.AppendLine("Thời gian: " + thoiGian);
            bill.AppendLine("Khách hàng: Khách vãng lai");
            bill.AppendLine("--------------------------------------------------------------");

            if (dtSanPham != null)
            {
                foreach (DataRow row in dtSanPham.Rows)
                {
                    string tenSP = row["Tên Sản Phẩm"].ToString();
                    string sl = row["Số Lượng"].ToString();
                    string tien = Convert.ToDouble(row["Thành Tiền"]).ToString("N0");
                    bill.AppendLine($"- {tenSP} (x{sl}): {tien} đ");
                }
            }

            bill.AppendLine("--------------------------------------------------------------");
            bill.AppendLine($"Tạm tính:     {tamTinh.ToString("N0")} đ");
            bill.AppendLine($"Thuế VAT:     {thueVAT.ToString("N0")} đ");
            bill.AppendLine($"TỔNG TIỀN:   {tongTien.ToString("N0")} VNĐ");
            bill.AppendLine("\nCảm ơn quý khách đã mua sắm!");

            MessageBox.Show(bill.ToString(), "Biên Lai Giao Dịch", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmMain main = this.TopLevelControl as frmMain;
            if (main != null) main.OpenChildForm(new frmLichSuBanHang(), null);
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null) mainForm.OpenChildForm(new frmThongTinDeIn(dtSanPham, tamTinh, thueVAT, (double)tongTien), null);
        }

        private void btnquaylaitrangtruoc_Click(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null) mainForm.OpenChildForm(new frmLapHoaDon(dtSanPham), null);
        }

        private void btnDong_Click(object sender, EventArgs e) { this.Close(); }
        private void cardTienMat_Paint(object sender, PaintEventArgs e) { }
        private void cardTheNganHang_Paint(object sender, PaintEventArgs e) { }
        private void cardQuetQR_Paint(object sender, PaintEventArgs e) { }
        private void dgvDanhSachSP_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtNgayHetHan_TextChanged(object sender, EventArgs e) { }
        private void txtMaCVV_TextChanged(object sender, EventArgs e) { }
    }
}