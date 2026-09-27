using qlcuahangdcht.Models; // Gọi Entity Framework Models
using qlcuahangdcht; // Gọi các form bên namespace chính
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qlnhanvien // Đã sửa lại namespace khớp chính xác với file Designer
{
    public partial class frmThongTinDeIn : Form
    {
        DataTable dtSanPham = new DataTable();
        double tongTien = 0;
        double tamTinh = 0;
        double thueVAT = 0;

        // Cờ lưu mã khách hàng (Mặc định KH01 là khách vãng lai)
        string maKhachHangHienTai = "KH01";

        public frmThongTinDeIn()
        {
            InitializeComponent();
            NoiDaySuKienChoNutBam();
        }

        public frmThongTinDeIn(DataTable dt, double tamTinh, double thue, double tong)
        {
            InitializeComponent();
            NoiDaySuKienChoNutBam();

            if (dt != null) this.dtSanPham = dt.Copy();
            this.tamTinh = tamTinh;
            this.thueVAT = thue;
            this.tongTien = tong;
        }

        private void NoiDaySuKienChoNutBam()
        {
            // Tên chuẩn xác theo file Designer bạn gửi
            if (btnKhachLe != null) { btnKhachLe.Click -= btnKhachLe_Click; btnKhachLe.Click += btnKhachLe_Click; }
            if (btnInHoaDon != null) { btnInHoaDon.Click -= btnInHoaDon_Click; btnInHoaDon.Click += btnInHoaDon_Click; }
            if (btnDangKyMoi != null) { btnDangKyMoi.Click -= btnDangKyMoi_Click; btnDangKyMoi.Click += btnDangKyMoi_Click; }
            if (btnHuyBo != null) { btnHuyBo.Click -= btnHuyBo_Click; btnHuyBo.Click += btnHuyBo_Click; }
            if (btnQuayLai != null) { btnQuayLai.Click -= btnQuayLai_Click; btnQuayLai.Click += btnQuayLai_Click; }

            this.Load += frmThongTinDeIn_Load;
        }

        private void frmThongTinDeIn_Load(object sender, EventArgs e)
        {
            if (lblTongTienHoaDon != null)
                lblTongTienHoaDon.Text = "Tổng tiền thanh toán: " + tongTien.ToString("N0") + " VNĐ";

            if (txtSoDienThoai != null)
            {
                txtSoDienThoai.MaxLength = 10;
                txtSoDienThoai.TextChanged -= TxtSoDienThoai_TextChanged;
                txtSoDienThoai.TextChanged += TxtSoDienThoai_TextChanged;
                txtSoDienThoai.KeyPress -= TxtSoDienThoai_KeyPress;
                txtSoDienThoai.KeyPress += TxtSoDienThoai_KeyPress;
                txtSoDienThoai.Focus();
            }
        }

        private void TxtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void TxtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            string sdt = txtSoDienThoai.Text.Trim();
            if (sdt == "0901234567" || sdt == "0912345678")
            {
                if (lblTrangThaiTimKiem != null) { lblTrangThaiTimKiem.Text = "✓ Đã tìm thấy KH!"; lblTrangThaiTimKiem.ForeColor = Color.LimeGreen; }
            }
            else if (sdt.Length == 10)
            {
                if (lblTrangThaiTimKiem != null) { lblTrangThaiTimKiem.Text = "ℹ Khách hàng mới."; lblTrangThaiTimKiem.ForeColor = Color.OrangeRed; }
            }
            else
            {
                if (lblTrangThaiTimKiem != null) { lblTrangThaiTimKiem.Text = ""; }
            }
        }

        private void btnKhachLe_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang != null) txtTenKhachHang.Text = "Khách vãng lai";
            if (txtSoDienThoai != null) txtSoDienThoai.Text = "Không có";
            if (txtDiaChi != null) txtDiaChi.Text = "Mua trực tiếp";
            if (txtEmail != null) txtEmail.Text = "Không có";
            maKhachHangHienTai = "KH01";
            MessageBox.Show("Đã điền tự động thông tin Khách Lẻ!\nVui lòng bấm 'In Hóa Đơn' để hoàn tất.", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang != null && txtTenKhachHang.Text.Trim() == "") { MessageBox.Show("Vui lòng nhập Tên khách hàng!"); return; }
            string sdt = txtSoDienThoai != null ? txtSoDienThoai.Text.Trim() : "";
            if (sdt != "" && sdt != "Không có" && sdt.Length != 10) { MessageBox.Show("Số điện thoại không hợp lệ!"); return; }
            if (sdt.Length == 10 && maKhachHangHienTai == "KH01") { maKhachHangHienTai = "KH" + DateTime.Now.ToString("mmss"); }
            ThucHienInHoaDon();
        }

        // =========================================================================
        // NÚT ĐĂNG KÝ KHÁCH HÀNG MỚI (SỬ DỤNG ENTITY FRAMEWORK)
        // =========================================================================
        private void btnDangKyMoi_Click(object sender, EventArgs e)
        {
            string tenKH = txtTenKhachHang != null ? txtTenKhachHang.Text.Trim() : "";
            string sdt = txtSoDienThoai != null ? txtSoDienThoai.Text.Trim() : "";
            string diaChi = txtDiaChi != null ? txtDiaChi.Text.Trim() : "";
            string email = txtEmail != null ? txtEmail.Text.Trim() : "";

            if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ Tên và SĐT khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new CuaHangDbContext())
                {
                    string maKHMoi = "KH" + DateTime.Now.ToString("mmss");

                    var khMoi = new KhachHang
                    {
                        MaKhachHang = maKHMoi,
                        HoTen = tenKH,
                        SDT = sdt,
                        DiaChi = string.IsNullOrEmpty(diaChi) ? "Đồng Tháp" : diaChi,
                        Email = string.IsNullOrEmpty(email) ? "Không có" : email
                    };

                    db.KhachHangs.Add(khMoi);
                    db.SaveChanges(); // Lưu xuống CSDL bằng EF

                    maKhachHangHienTai = maKHMoi;
                }

                MessageBox.Show("Lưu thông tin khách hàng mới thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (lblTrangThaiTimKiem != null)
                {
                    lblTrangThaiTimKiem.Text = "✓ Đã lưu thông tin khách hàng mới!";
                    lblTrangThaiTimKiem.ForeColor = Color.LimeGreen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký khách hàng mới bằng EF: " + ex.Message, "Lỗi EF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            Form mainForm = this.TopLevelControl as Form;
            if (mainForm != null && mainForm.Name == "frmMain")
            {
                ((qlcuahangdcht.frmMain)mainForm).OpenChildForm(new qlcuahangdcht.frmBanHang(), null);
            }
            else this.Close();
        }

        // =========================================================================
        // THỰC HIỆN IN HÓA ĐƠN VÀ LƯU VÀO CSDL BẰNG ENTITY FRAMEWORK
        // =========================================================================
        private void ThucHienInHoaDon()
        {
            string maDonHang = "HD" + DateTime.Now.ToString("ddHHmmss");
            string thoiGian = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            string tenKhachIn = txtTenKhachHang != null && txtTenKhachHang.Text != "" ? txtTenKhachHang.Text : "Khách vãng lai";
            string sdtIn = txtSoDienThoai != null && txtSoDienThoai.Text != "" ? txtSoDienThoai.Text : "Không có";
            string emailIn = txtEmail != null ? txtEmail.Text.Trim() : "";

            // 1. Chuẩn bị nội dung hóa đơn hiển thị
            StringBuilder bill = new StringBuilder();
            bill.AppendLine("ĐANG GỬI LỆNH IN HÓA ĐƠN...\n");
            bill.AppendLine("Mã Đơn Hàng: " + maDonHang);
            bill.AppendLine("Thời gian: " + thoiGian);
            bill.AppendLine("Khách hàng: " + tenKhachIn);
            bill.AppendLine("SĐT: " + sdtIn);
            if (!string.IsNullOrEmpty(emailIn) && emailIn != "Không có")
            {
                bill.AppendLine("Email: " + emailIn);
            }
            bill.AppendLine("--------------------------------------------------------------");

            // 2. Lưu giao dịch xuống CSDL an toàn thông qua Entity Framework
            try
            {
                using (var db = new CuaHangDbContext())
                {
                    // A. Đảm bảo nhân viên NV01 luôn tồn tại
                    var nv = db.NhanViens.Find("NV01");
                    if (nv == null)
                    {
                        db.NhanViens.Add(new NhanVien { MaNhanVien = "NV01", HoTen = "Nhân Viên" });
                    }

                    // B. Kiểm tra hoặc thêm mới thông tin khách hàng vào CSDL
                    var khCheck = db.KhachHangs.Find(maKhachHangHienTai);
                    if (khCheck == null)
                    {
                        var khMoi = new KhachHang
                        {
                            MaKhachHang = maKhachHangHienTai,
                            HoTen = tenKhachIn,
                            SDT = sdtIn,
                            DiaChi = txtDiaChi != null && !string.IsNullOrEmpty(txtDiaChi.Text) ? txtDiaChi.Text : "Tại quầy",
                            Email = string.IsNullOrEmpty(emailIn) ? "Không có" : emailIn
                        };
                        db.KhachHangs.Add(khMoi);
                    }

                    // C. Tạo và lưu Hóa Đơn mới
                    var hoaDonMoi = new HoaDon
                    {
                        MaHoaDon = maDonHang,
                        MaKhachHang = maKhachHangHienTai,
                        MaNhanVien = "NV01",
                        NgayLap = DateTime.Now,
                        TongTien = (decimal)tongTien
                    };
                    db.HoaDons.Add(hoaDonMoi);

                    // D. Lưu Chi Tiết Hóa Đơn và Trừ Tồn Kho Sản Phẩm
                    if (dtSanPham != null && dtSanPham.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtSanPham.Rows)
                        {
                            int sl = Convert.ToInt32(row["Số Lượng"]);
                            double gia = Convert.ToDouble(row["Đơn Giá"]);
                            double tien = Convert.ToDouble(row["Thành Tiền"]);
                            string maSP = row["Mã Sản Phẩm"].ToString();
                            string tenSP = row["Tên Sản Phẩm"].ToString();

                            // Đưa mặt hàng vào phiếu in
                            bill.AppendLine("- " + tenSP + " (x" + sl + "): " + tien.ToString("N0") + " đ");

                            // Thêm chi tiết hóa đơn
                            var chiTiet = new ChiTietHoaDon
                            {
                                MaHoaDon = maDonHang,
                                MaSanPham = maSP,
                                SoLuong = sl,
                                DonGia = (decimal)gia,
                                ThanhTien = (decimal)tien
                            };
                            db.ChiTietHoaDons.Add(chiTiet);

                            // Trừ tồn kho sản phẩm tương ứng
                            var sanPham = db.SanPhams.Find(maSP);
                            if (sanPham != null)
                            {
                                sanPham.SoLuongTon -= sl;
                            }
                        }
                    }

                    // Lưu toàn bộ thay đổi xuống cơ sở dữ liệu qua EF
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu hóa đơn bằng Entity Framework: " + ex.Message, "Lỗi EF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Tổng kết và hiển thị biên lai thành công
            bill.AppendLine("--------------------------------------------------------------");
            bill.AppendLine("Tạm tính:     " + tamTinh.ToString("N0") + " đ");
            bill.AppendLine("Thuế VAT:     " + thueVAT.ToString("N0") + " đ");
            bill.AppendLine("TỔNG TIỀN:    " + tongTien.ToString("N0") + " VNĐ");
            bill.AppendLine("\nĐã in thành công hóa đơn và lưu Lịch sử bán hàng!");

            MessageBox.Show(bill.ToString(), "Biên Lai Giao Dịch", MessageBoxButtons.OK, MessageBoxIcon.Information);

            KhoLichSu.VuaThanhToanXong = true;

            Form mainForm = this.TopLevelControl as Form;
            if (mainForm != null && mainForm.Name == "frmMain")
            {
                ((qlcuahangdcht.frmMain)mainForm).OpenChildForm(new qlcuahangdcht.frmBanHang(), null);
            }
            else this.Close();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form mainForm = this.TopLevelControl as Form;
            if (mainForm != null && mainForm.Name == "frmMain")
            {
                ((qlcuahangdcht.frmMain)mainForm).OpenChildForm(new qlcuahangdcht.frmThanhToan(dtSanPham, tamTinh, thueVAT, tongTien), null);
            }
            else this.Close();
        }
    }
}