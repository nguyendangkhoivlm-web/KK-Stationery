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
    public partial class frmThemNhanVien : Form
    {
        public frmThemNhanVien()
        {
            InitializeComponent();
        }


        private void frmThemNhanVien_Load(object sender, EventArgs e)
        {
            // Sinh mã ngẫu nhiên dạng "NV" + 4 số (Ví dụ: NV4829)
            Random rnd = new Random();
            string maNgauNhien = "NV" + rnd.Next(1000, 9999).ToString();

            // Gán vào ô Mã nhân viên và khóa lại không cho người dùng sửa
            txtMaNV.Text = maNgauNhien;
            txtMaNV.ReadOnly = true;
        }

        private void txtSDT_Enter(object sender, EventArgs e)
        {
            // Nếu chữ trong ô đang là chữ mờ thì xóa đi để gõ
            if (txtSDT.Text == "SĐT")
            {
                txtSDT.Text = "";
                txtSDT.ForeColor = Color.Black;
            }
        }

        private void txtSDT_Leave(object sender, EventArgs e)
        {
            // Khi click ra ngoài, nếu người dùng chưa gõ gì thì hiện lại chữ mờ
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                txtSDT.Text = "SĐT";
                txtSDT.ForeColor = Color.Gray;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    txtEmail.Text = "Email";
                    txtEmail.ForeColor = Color.Gray;
                }
        }

        private void txtDiaChi_Enter(object sender, EventArgs e)
        {
            // Lưu ý: Chữ so sánh phải giống hệt chữ ông gõ sẵn trên giao diện
            if (txtDiaChi.Text == "Địa chỉ..")
            {
                txtDiaChi.Text = "";
                txtDiaChi.ForeColor = Color.Black;
            }
        }

        private void txtDiaChi_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                txtDiaChi.Text = "Địa chỉ..";
                txtDiaChi.ForeColor = Color.Gray;
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra bắt buộc nhập (Ví dụ: Họ Tên không được để trống)
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus(); // Nhảy con trỏ chuột về ô Họ tên
                return; // Dừng lại, không chạy code lưu xuống DB nữa
            }

            // 2. Dọn dẹp mấy cái chữ mờ (Placeholder) để không bị lưu bậy vào Database
            string sdt = txtSDT.Text.Trim();
            if (sdt == "SĐT") sdt = ""; // Nếu chưa gõ gì thì đưa về chuỗi rỗng

            string email = txtEmail.Text.Trim();
            if (email == "Email") email = "";

            string diaChi = txtDiaChi.Text.Trim();
            if (diaChi == "Địa chỉ..") diaChi = "";

            // (Tùy chọn) Bắt buộc nhập SĐT 
            if (string.IsNullOrWhiteSpace(sdt))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            // 3. Bắt đầu lưu xuống DB
            try
            {
                using (var db = new CuaHangDbContext())
                {
                    NhanVien nv = new NhanVien();
                    nv.MaNhanVien = txtMaNV.Text.Trim();
                    nv.HoTen = txtHoTen.Text.Trim();

                    // Xử lý Giới tính
                    nv.GioiTinh = radNam.Checked ? "Nam" : "Nữ";

                    // Xử lý Ngày sinh
                    nv.NgaySinh = dtpNgaySinh.Value;

                    // Truyền dữ liệu đã dọn dẹp sạch sẽ ở bước 2 vào
                    nv.SDT = sdt;
                    nv.Email = email;
                    nv.DiaChi = diaChi;

                    db.NhanViens.Add(nv);
                    db.SaveChanges(); // Giờ thì chạy mượt, không sợ văng lỗi nữa

                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form
                }
            }
            catch (Exception ex)
            {
                // Bẫy lỗi an toàn: Bất cứ lỗi DB nào cũng sẽ được túm lại ở đây
                MessageBox.Show("Có lỗi xảy ra khi lưu: \n" + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Bật hộp thoại hỏi xác nhận
            DialogResult rs = MessageBox.Show("Ông có chắc chắn muốn hủy bỏ thao tác này không? Các thông tin đang gõ sẽ không được lưu.", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng bấm Yes (Có) thì mới thực hiện đóng form
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
