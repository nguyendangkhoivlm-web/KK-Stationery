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
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();

            // Cài đặt nút mặc định khi vừa mở form lên là nút "Tất cả"
            this.Load += (s, e) => DoiMauNutDanhMuc(btnDanhMucTatCa);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Lấy form chính (frmMain) hiện tại đang chứa form bán hàng này
            frmMain mainForm = this.TopLevelControl as frmMain;
            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmLapHoaDon(), null);
            }
        }

        private void btnHuyDon_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn hủy đơn hàng này không?", "Xác nhận hủy đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Đã hủy đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- HÀM ĐỔI MÀU NÚT DANH MỤC SẢN PHẨM ---
        private void DoiMauNutDanhMuc(Button activeButton)
        {
            // 1. Đặt lại màu nền trắng, chữ đen mặc định cho tất cả các nút
            Color defaultBackColor = Color.White;
            Color defaultForeColor = Color.Black;

            if (btnDanhMucTatCa != null) { btnDanhMucTatCa.BackColor = defaultBackColor; btnDanhMucTatCa.ForeColor = defaultForeColor; }
            if (btnDanhMucBanChay != null) { btnDanhMucBanChay.BackColor = defaultBackColor; btnDanhMucBanChay.ForeColor = defaultForeColor; }
            if (btnDanhMucButChi != null) { btnDanhMucButChi.BackColor = defaultBackColor; btnDanhMucButChi.ForeColor = defaultForeColor; }
            if (btnDanhMucThuocTay != null) { btnDanhMucThuocTay.BackColor = defaultBackColor; btnDanhMucThuocTay.ForeColor = defaultForeColor; }
            if (btnDanhMucCompaMau != null) { btnDanhMucCompaMau.BackColor = defaultBackColor; btnDanhMucCompaMau.ForeColor = defaultForeColor; }
            if (btnDanhMucTapHocSinh != null) { btnDanhMucTapHocSinh.BackColor = defaultBackColor; btnDanhMucTapHocSinh.ForeColor = defaultForeColor; }

            // 2. Đổi màu nền xanh (RoyalBlue), chữ trắng cho nút đang được chọn
            if (activeButton != null)
            {
                activeButton.BackColor = Color.RoyalBlue;
                activeButton.ForeColor = Color.White;
            }
        }

        // --- NHÓM SỰ KIỆN CLICK CÁC NÚT DANH MỤC ---

        private void btnDanhMucTatCa_Click(object sender, EventArgs e)
        {
            DoiMauNutDanhMuc(btnDanhMucTatCa);
            CapNhatDanhMuc("Tất cả sản phẩm");
        }

        private void btnDanhMucBanChay_Click(object sender, EventArgs e)
        {
            DoiMauNutDanhMuc(btnDanhMucBanChay);
            CapNhatDanhMuc("Sản phẩm bán chạy");
        }

        private void btnDanhMucButChi_Click(object sender, EventArgs e)
        {
            DoiMauNutDanhMuc(btnDanhMucButChi);
            CapNhatDanhMuc("Bút bi / Chì");
        }

        private void btnDanhMucThuocTay_Click(object sender, EventArgs e)
        {
            DoiMauNutDanhMuc(btnDanhMucThuocTay);
            CapNhatDanhMuc("Thước");
        }

        private void btnDanhMucCompaMau_Click(object sender, EventArgs e)
        {
            DoiMauNutDanhMuc(btnDanhMucCompaMau);
            CapNhatDanhMuc("Compa");
        }

        private void btnDanhMucTapHocSinh_Click(object sender, EventArgs e)
        {
            DoiMauNutDanhMuc(btnDanhMucTapHocSinh);
            CapNhatDanhMuc("Tập học sinh");
        }

        // Hàm phụ trợ để xử lý chung việc lọc danh mục
        private void CapNhatDanhMuc(string tenDanhMuc)
        {
            // Sau này khi kết nối cơ sở dữ liệu SQL, bạn dùng câu lệnh SELECT lọc theo biến tenDanhMuc tại đây
        }
    }
}