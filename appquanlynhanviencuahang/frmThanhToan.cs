using qlnhanvien;
using System;
using System.Data;
using System.Data.SqlClient;
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

        string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";

        // 1. Constructor mặc định
        public frmThanhToan()
        {
            InitializeComponent();
            ThietLapGiaoDien();
        }

        // 2. Constructor nhận 4 tham số từ trang Bán Hàng truyền sang
        public frmThanhToan(DataTable dt, double sub, double tax, double total)
        {
            InitializeComponent();
            if (dt != null) this.dtSanPham = dt.Copy();
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
                    string maDonHang = "HD" + DateTime.Now.ToString("ddHHmmss");
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
            if (lblNhanVien != null) lblNhanVien.Text = "Nhân viên: Nhân Viên";

            if (dgvDanhSachSP != null && dtSanPham != null)
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
            Color normalBackColor = Color.FromArgb(248, 250, 252);

            if (cardTienMat != null) cardTienMat.BackColor = normalBackColor;
            if (cardTheNganHang != null) cardTheNganHang.BackColor = normalBackColor;
            if (cardQuetQR != null) cardQuetQR.BackColor = normalBackColor;

            if (selectedCard != null) selectedCard.BackColor = Color.FromArgb(230, 242, 255);
        }

        // ======================================================================
        // NÚT HOÀN TẤT THANH TOÁN (LƯU CSDL AN TOÀN VỚI SQL TRANSACTION)
        // ======================================================================
        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            string maDonHang = "HD" + DateTime.Now.ToString("ddHHmmss");

            if (phuongThucThanhToan == "Quét mã QR")
            {
                frmMain mainForm = this.TopLevelControl as frmMain;
                if (mainForm != null) mainForm.OpenChildForm(new frmThanhToanQuaQR(dtSanPham, tamTinh, thueVAT, (double)tongTien, maDonHang), null);
                return;
            }

            string thoiGian = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            try
            {
                using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Đảm bảo nhân viên NV01 luôn tồn tại
                        using (SqlCommand cmdNV = new SqlCommand("IF NOT EXISTS (SELECT 1 FROM NhanVien WHERE MaNhanVien = 'NV01') INSERT INTO NhanVien (MaNhanVien, HoTen) VALUES ('NV01', N'Nhân Viên')", conn, transaction))
                        {
                            cmdNV.ExecuteNonQuery();
                        }

                        // 2. Đảm bảo khách vãng lai KH01 luôn tồn tại (Chống lỗi khóa ngoại)
                        using (SqlCommand cmdKH = new SqlCommand("IF NOT EXISTS (SELECT 1 FROM KhachHang WHERE MaKhachHang = 'KH01') INSERT INTO KhachHang (MaKhachHang, HoTen, SDT, DiaChi, Email) VALUES ('KH01', N'Khách vãng lai', N'Không có', N'Tại quầy', N'Không có')", conn, transaction))
                        {
                            cmdKH.ExecuteNonQuery();
                        }

                        // 3. Lưu vào bảng HoaDon (Dùng mã 'KH01')
                        string sqlInsertHoaDon = "INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayLap, TongTien) VALUES (@MaHD, 'KH01', 'NV01', @NgayLap, @TongTien)";
                        using (SqlCommand cmd = new SqlCommand(sqlInsertHoaDon, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MaHD", maDonHang);
                            cmd.Parameters.AddWithValue("@NgayLap", DateTime.Now);
                            cmd.Parameters.AddWithValue("@TongTien", tongTien);
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Lưu chi tiết hóa đơn & trừ tồn kho
                        if (dtSanPham != null)
                        {
                            foreach (DataRow row in dtSanPham.Rows)
                            {
                                string maSP = row["Mã Sản Phẩm"].ToString();
                                int soLuong = Convert.ToInt32(row["Số Lượng"]);
                                double gia = Convert.ToDouble(row["Đơn Giá"]);
                                double tien = Convert.ToDouble(row["Thành Tiền"]);

                                string sqlInsertCTHD = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien) VALUES (@MaHD, @MaSP, @SL, @Gia, @Tien)";
                                using (SqlCommand cmdCTHD = new SqlCommand(sqlInsertCTHD, conn, transaction))
                                {
                                    cmdCTHD.Parameters.AddWithValue("@MaHD", maDonHang);
                                    cmdCTHD.Parameters.AddWithValue("@MaSP", maSP);
                                    cmdCTHD.Parameters.AddWithValue("@SL", soLuong);
                                    cmdCTHD.Parameters.AddWithValue("@Gia", gia);
                                    cmdCTHD.Parameters.AddWithValue("@Tien", tien);
                                    cmdCTHD.ExecuteNonQuery();
                                }

                                string sqlUpdateTonKho = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SL WHERE MaSanPham = @MaSP";
                                using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateTonKho, conn, transaction))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@SL", soLuong);
                                    cmdUpdate.Parameters.AddWithValue("@MaSP", maSP);
                                    cmdUpdate.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        KhoLichSu.VuaThanhToanXong = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi lưu hóa đơn: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thông báo thành công và chuyển sang Lịch sử bán hàng
            StringBuilder bill = new StringBuilder();
            bill.AppendLine("THANH TOÁN THÀNH CÔNG!\n");
            bill.AppendLine("Mã Đơn Hàng: " + maDonHang);
            bill.AppendLine("Thời gian: " + thoiGian);
            bill.AppendLine("Khách hàng: Khách vãng lai");
            bill.AppendLine("Nhân viên: Nhân Viên");
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
            bill.AppendLine($"Tạm tính:      {tamTinh.ToString("N0")} đ");
            bill.AppendLine($"Thuế VAT:      {thueVAT.ToString("N0")} đ");
            bill.AppendLine($"TỔNG TIỀN:    {tongTien.ToString("N0")} VNĐ");
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
        private void txtNgayHetHan_TextChanged(object sender, EventArgs e) { }
        private void txtMaCVV_TextChanged(object sender, EventArgs e) { }
    }
}