using qlcuahangdcht.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlcuahangdcht.GiaoDien.Admin
{
    public partial class UC_PhieuNhap : UserControl
    {
        public UC_PhieuNhap()
        {
            InitializeComponent();
        }

        // Biến toàn cục đóng vai trò như một "giỏ hàng" tạm chứa các sản phẩm trước khi ông bấm nút Lưu
        BindingList<ChiTietPhieuNhap> lstChiTiet = new BindingList<ChiTietPhieuNhap>();

        private void UC_PhieuNhap_Load(object sender, EventArgs e)
        {
            // 1. Tắt tính năng tự sinh cột để ép DataGridView hiển thị đúng các cột tiếng Việt ông đã vẽ
            dgvChiTietPhieu.AutoGenerateColumns = false;
            dgvDanhSachPhieu.AutoGenerateColumns = false;

            // 2. Gắn cái "giỏ hàng" vào bảng phía trên. Từ giờ add gì vào list, bảng tự động hiện ra.
            dgvChiTietPhieu.DataSource = lstChiTiet;

            // 3. Khóa ô Người lập phiếu và điền sẵn mã (sau này gỡ chữ AD001 ra, truyền mã từ form Login vào)
            txtNguoiLapPhieu.ReadOnly = true;
            txtNguoiLapPhieu.Text = "AD001";

            // 4. Gọi hàm tải dữ liệu nền
            LoadDuLieuBanDau();
        }

        private void LoadDuLieuBanDau()
        {
            using (var db = new CuaHangDbContext())
            {
                // Kéo danh sách Nhà cung cấp từ DB ném vào ComboBox
                cboNhaCungCap.DataSource = db.NhaCungCaps.ToList();

                // DisplayMember: Chữ hiển thị ra ngoài cho Admin thấy (Tên NCC)
                cboNhaCungCap.DisplayMember = "TenNCC";

                // ValueMember: Giá trị ngầm giấu bên dưới để lấy ra lưu vào DB (Mã NCC)
                cboNhaCungCap.ValueMember = "MaNCC";

                // Tải lịch sử phiếu nhập vào bảng dưới cùng, dùng OrderByDescending để đẩy phiếu mới nhất lên trên cùng
                dgvDanhSachPhieu.DataSource = db.PhieuNhaps.OrderByDescending(p => p.NgayNhap).ToList();
            }

        }


        // Hàm dùng chung để tính toán
        private void TinhThanhTien()
        {
            decimal giaNhap = 0;

            // Dùng if...else để thể hiện tư duy bắt lỗi đầu vào cực kỳ chặt chẽ
            // Nếu hàm TryParse thành công (tức là người dùng gõ đúng số)
            if (decimal.TryParse(txtGiaNhap.Text.Trim(), out giaNhap))
            {
                // Thực hiện phép nhân và format có dấu phẩy
                txtThanhTien.Text = (giaNhap * nudSoLuong.Value).ToString("N0");
            }
            else // Nếu người dùng nhập sai (gõ chữ) hoặc để trống
            {
                // Gán thẳng bằng 0, khỏi mắc công làm toán dư thừa
                txtThanhTien.Text = "0";
            }
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            // Bắt lỗi nhập liệu cơ bản
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || nudSoLuong.Value <= 0 || string.IsNullOrWhiteSpace(txtGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin Mã SP, Số lượng và Giá nhập hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đẩy dữ liệu vào List tạm
            ChiTietPhieuNhap ct = new ChiTietPhieuNhap();
            ct.MaSanPham = txtMaSP.Text.Trim();
            ct.SoLuong = (int)nudSoLuong.Value;
            ct.GiaNhap = decimal.Parse(txtGiaNhap.Text.Trim());

            lstChiTiet.Add(ct);

            CapNhatTongTienPhieu();

            // Làm trắng vùng nhập để gõ SP tiếp theo
            txtMaSP.Text = "";
            nudSoLuong.Value = 0;
            txtGiaNhap.Text = "";
            txtMaSP.Focus();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieu.CurrentRow != null && dgvChiTietPhieu.CurrentRow.Index >= 0)
            {
                lstChiTiet.RemoveAt(dgvChiTietPhieu.CurrentRow.Index);
                CapNhatTongTienPhieu();
            }
        }

        private void CapNhatTongTienPhieu()
        {
            // Tính tổng tiền toàn bộ phiếu từ List tạm
            decimal tong = lstChiTiet.Sum(x => x.SoLuong * x.GiaNhap);
            txtTongTienPhieu.Text = tong.ToString("N0");
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text) || lstChiTiet.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập Mã phiếu và thêm ít nhất 1 sản phẩm vào danh sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new CuaHangDbContext())
                {
                    // 1. Chống trùng khóa chính
                    if (db.PhieuNhaps.Any(p => p.MaPhieuNhap == txtMaPhieu.Text.Trim()))
                    {
                        MessageBox.Show("Mã phiếu này đã tồn tại trong hệ thống!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Tạo Master (Bảng cha)
                    PhieuNhap pn = new PhieuNhap();
                    pn.MaPhieuNhap = txtMaPhieu.Text.Trim();
                    pn.NgayNhap = dtpNgayNhap.Value;
                    pn.MaNCC = cboNhaCungCap.SelectedValue.ToString();
                    pn.MaNhanVien = txtNguoiLapPhieu.Text;
                    pn.TongTien = lstChiTiet.Sum(x => x.SoLuong * x.GiaNhap);

                    db.PhieuNhaps.Add(pn);

                    // 3. Tạo Detail (Bảng con) & Cập nhật kho
                    foreach (var item in lstChiTiet)
                    {
                        item.MaPhieuNhap = pn.MaPhieuNhap; // Móc khóa phụ vào khóa chính
                        db.ChiTietPhieuNhaps.Add(item);

                        // Tìm sản phẩm tương ứng để cộng dồn số lượng tồn
                        var sp = db.SanPhams.Find(item.MaSanPham);
                        if (sp != null)
                        {
                            sp.SoLuongTon += item.SoLuong;
                        }
                        else
                        {
                            MessageBox.Show($"Cảnh báo: Không tìm thấy Mã SP '{item.MaSanPham}' trong hệ thống để cộng tồn kho!", "Sai Mã SP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // 4. Lưu một phát ăn ngay toàn bộ cục dữ liệu
                    db.SaveChanges();

                    MessageBox.Show("Lưu phiếu nhập và cập nhật kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Reset giao diện chuẩn bị cho phiếu mới
                    lstChiTiet.Clear();
                    txtMaPhieu.Text = "";
                    CapNhatTongTienPhieu();
                    LoadDuLieuBanDau(); // Refresh lại bảng danh sách ở dưới
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Database: \n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimPhieu_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiemPhieu.Text.Trim().ToLower();

            using (var db = new CuaHangDbContext())
            {
                // Lọc ra các phiếu có mã phiếu hoặc mã NCC chứa từ khóa tìm kiếm
                var ketQua = db.PhieuNhaps
                               .Where(p => p.MaPhieuNhap.ToLower().Contains(tuKhoa) ||
                                           p.MaNCC.ToLower().Contains(tuKhoa))
                               .OrderByDescending(p => p.NgayNhap)
                               .ToList();

                // Đẩy kết quả đã lọc vào bảng
                dgvDanhSachPhieu.DataSource = ketQua;

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập nào khớp với từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn phiếu nào dưới bảng danh sách chưa
            if (dgvDanhSachPhieu.CurrentRow != null && dgvDanhSachPhieu.CurrentRow.Index >= 0)
            {
                // Lấy mã phiếu của dòng đang chọn
                // Lưu ý: Cột "MaPhieu" phải khớp với tên thuộc tính DataPropertyName của cột đó
                string maPhieu = dgvDanhSachPhieu.CurrentRow.Cells["MaPhieu"].Value.ToString();

                // Hiển thị thông báo hoặc gọi form In/Xuất Excel tại đây
                MessageBox.Show($"Đang tiến hành trích xuất và in dữ liệu cho phiếu: {maPhieu}\n\n(Tích hợp thư viện in ấn hoặc xuất Excel vào khối lệnh này sau)",
                                "In Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập từ danh sách bên dưới để in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
