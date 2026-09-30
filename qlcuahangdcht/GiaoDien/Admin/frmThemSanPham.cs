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
    public partial class frmThemSanPham : Form
    {

        // Biến toàn cục để lưu lại mã SP nếu đang ở chế độ Sửa
        private string _maSPSua = null;

        public frmThemSanPham()
        {
            InitializeComponent();
        }


        // ÔNG VIẾT THÊM HÀM NÀY: Dành cho chức năng SỬA
        public frmThemSanPham(string maSP)
        {
            InitializeComponent();
            _maSPSua = maSP; // Lưu cái mã được truyền từ form Quản lý vào biến
        }


        private void LoadComboBox()
        {
            using (var db = new CuaHangDbContext())
            {
                // Lôi dữ liệu từ bảng DanhMucs
                var listDM = db.DanhMucs.ToList();

                cboDanhMuc.DataSource = listDM;
                cboDanhMuc.DisplayMember = "TenDanhMuc"; // Hiển thị tên (chữ) cho người dùng xem
                cboDanhMuc.ValueMember = "MaDanhMuc";    // Giữ cái mã (ẩn bên dưới) để dành lưu DB
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new CuaHangDbContext())
                {
                    if (string.IsNullOrEmpty(_maSPSua))
                    {
                        // === NGÃ RẼ 1: CHẾ ĐỘ THÊM MỚI (Code cũ ông đã có) ===
                        SanPham spMoi = new SanPham();
                        spMoi.MaSanPham = txtMaSP.Text.Trim();
                        spMoi.TenSanPham = txtTenSP.Text.Trim();
                        spMoi.DonGia = decimal.Parse(txtDonGia.Text);
                        spMoi.SoLuongTon = int.Parse(txtSoLuongTon.Text);
                        // Nhớ thêm dòng này vào chỗ gán dữ liệu (ngay dưới dòng gán SoLuongTon)
                        spMoi.MaDanhMuc = cboDanhMuc.SelectedValue.ToString();


                        db.SanPhams.Add(spMoi);
                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // === NGÃ RẼ 2: CHẾ ĐỘ CẬP NHẬT ===
                        var spCu = db.SanPhams.Find(_maSPSua); // Lấy hàng cũ từ DB lên

                        // Ghi đè thông tin mới
                        spCu.TenSanPham = txtTenSP.Text.Trim();
                        spCu.DonGia = decimal.Parse(txtDonGia.Text);
                        spCu.SoLuongTon = int.Parse(txtSoLuongTon.Text);
                        // Và làm tương tự cho cái biến spCu ở ngã rẽ Cập nhật:
                        spCu.MaDanhMuc = cboDanhMuc.SelectedValue.ToString();
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    db.SaveChanges(); // Lệnh này dùng chung cho cả Thêm và Sửa
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: \n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmThemSanPham_Load(object sender, EventArgs e)
        {
            // Phải nạp danh sách vào ComboBox trước tiên
            LoadComboBox();

            // Nếu có mã truyền vào => Chế độ Cập nhật
            if (!string.IsNullOrEmpty(_maSPSua))
            {
                this.Text = "Cập nhật sản phẩm"; // Đổi tiêu đề góc trên cùng form

                using (var db = new CuaHangDbContext())
                {
                    // Tìm sản phẩm trong DB theo mã
                    var sp = db.SanPhams.Find(_maSPSua);
                    if (sp != null)
                    {
                        // Đổ dữ liệu cũ lên các ô TextBox
                        txtMaSP.Text = sp.MaSanPham;
                        txtMaSP.Enabled = false; // QUAN TRỌNG: Khóa ô Mã SP lại, không cho người dùng sửa Khóa Chính

                        txtTenSP.Text = sp.TenSanPham;
                        txtDonGia.Text = Math.Round(sp.DonGia, 0).ToString(); // Xóa mấy số 0 thập phân cho đẹp
                        txtSoLuongTon.Text = sp.SoLuongTon.ToString();
                    }
                }
            }
        }


        // Ông khai báo thêm 1 biến toàn cục ở đầu Form để lưu đường dẫn ảnh
        // Lát nữa ở nút "Lưu", ông sẽ gọi biến này ra để lưu tên file ảnh xuống Database
        private string duongDanAnh = "";
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại chọn file
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Lọc ra, chỉ cho phép người dùng chọn các file hình ảnh
                ofd.Filter = "Hình ảnh (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Chọn hình ảnh cho sản phẩm";

                // Mở hộp thoại lên, nếu người dùng chọn file và bấm OK thì xử lý tiếp
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn file vừa chọn gán vào biến
                    duongDanAnh = ofd.FileName;

                    // Hiển thị hình ảnh lên PictureBox 
                    picHinhAnh.Image = Image.FromFile(duongDanAnh);

                    // Căn chỉnh cho hình ảnh thu/phóng tự động vừa khít cái khung vuông mà không bị méo
                    picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
    }
}
