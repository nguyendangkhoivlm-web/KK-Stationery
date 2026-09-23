using qlcuahangdcht.GiaoDien.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlcuahangdcht
{
    public partial class UC_SanPham : UserControl
    {
        public UC_SanPham()
        {
            InitializeComponent();
        }

        // 1. Khai báo hàm LoadData dùng chung
        private void LoadData()
        {
            using (var db = new CuaHangDbContext())
            {
                // Khóa tính năng tự động sinh thêm cột rác
                dgvDanhSachSP.AutoGenerateColumns = false;

                var danhSach = db.SanPhams.Select(sp => new
                {
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    DonGia = sp.DonGia,
                    SoLuongTon = sp.SoLuongTon,
                    DanhMuc = sp.MaDanhMuc,
                    TrangThai = (sp.SoLuongTon > 0) ? "Đang kinh doanh" : "Hết hàng"
                }).ToList();

                // Đổ dữ liệu vào đúng các cột đã thiết lập DataPropertyName
                dgvDanhSachSP.DataSource = danhSach;
            }
        }


        private void LoadComboBox()
        {
            using (var db = new CuaHangDbContext())
            {
                // Kéo danh sách từ bảng DanhMucs
                // Giả định bảng của ông tên là DanhMucs, có cột MaDanhMuc và TenDanhMuc
                var listDM = db.DanhMucs.ToList();

                // Nạp vào ComboBox
                cboDanhMuc.DataSource = listDM;
                cboDanhMuc.DisplayMember = "TenDanhMuc"; // Cái chữ hiện lên cho người dùng xem
                cboDanhMuc.ValueMember = "MaDanhMuc";    // Cái mã ngầm giữ lại để lấy lúc lưu Database
            }
        }



        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có đang chọn dòng nào không
            if (dgvDanhSachSP.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm trong bảng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy Mã SP của dòng đang chọn 
            // LƯU Ý: Chữ "MaSanPham" ở dưới phải giống y hệt thuộc tính DataPropertyName của cột Mã SP
            string maSP = dgvDanhSachSP.CurrentRow.Cells["MaSanPham"].Value.ToString();

            // 3. Hỏi xác nhận
            DialogResult rs = MessageBox.Show($"Ông có chắc chắn muốn xóa sản phẩm mã '{maSP}' không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                using (var db = new CuaHangDbContext())
                {
                    // Dùng Find() để tìm đúng thằng cần xóa theo Khóa chính
                    var sp = db.SanPhams.Find(maSP);
                    if (sp != null)
                    {
                        db.SanPhams.Remove(sp);
                        db.SaveChanges(); // Chốt hạ xuống Database
                        MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData(); // Gọi lại hàm LoadData() hôm bữa để refresh bảng
                    }
                }
            }
        }

        private void btnCapNhatSP_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dòng chưa
            if (dgvDanhSachSP.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã SP đang chọn
            string maSP = dgvDanhSachSP.CurrentRow.Cells["MaSanPham"].Value.ToString();

            // Gọi form popup và TRUYỀN MÃ SP SANG (Báo hiệu đây là chế độ Sửa, không phải Thêm mới)
            // Lưu ý: Tạm thời dòng này sẽ bị gạch đỏ vì bên frmThemSanPham mình chưa cấu hình nhận mã.
            frmThemSanPham frm = new frmThemSanPham(maSP);
            frm.ShowDialog();

            LoadData(); // Cập nhật xong thì refresh bảng
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            frmThemSanPham frm = new frmThemSanPham();
            frm.ShowDialog(); // Lệnh này ép phần mềm đứng đợi người dùng tắt form Thêm rồi mới đi tiếp

            // Ngay khi form Thêm đóng lại (sau khi bấm Lưu), hàm này chạy để làm mới bảng
            LoadData();
        }



        private void txtTimKiemSp_Enter(object sender, EventArgs e)
        {
            // Khi click chuột vào, nếu đang là chữ mờ thì xóa đi để người dùng gõ
            if (txtTimKiemSp.Text == "Tìm kiếm sản phẩm...")
            {
                txtTimKiemSp.Text = "";
                txtTimKiemSp.ForeColor = Color.Black; // Trả lại màu chữ đen bình thường
            }
        }

        private void txtTimKiemSp_Leave(object sender, EventArgs e)
        {
            // Khi click ra ngoài, nếu người dùng chưa gõ gì thì hiện lại chữ mờ
            if (string.IsNullOrWhiteSpace(txtTimKiemSp.Text))
            {
                txtTimKiemSp.Text = "Tìm kiếm sản phẩm...";
                txtTimKiemSp.ForeColor = Color.Gray; // Đổi sang màu xám mờ
            }
        }

        private void UC_SanPham_Load(object sender, EventArgs e)
        {
            // BẮT BUỘC phải có dòng này để nó kéo dữ liệu từ bảng DanhMucs đổ vào ComboBox
            LoadComboBox();

            // Kéo dữ liệu từ bảng SanPhams đổ vào DataGridView
            LoadData();
        }

    }
}
