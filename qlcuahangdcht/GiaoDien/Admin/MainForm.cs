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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // --- HÀM 1: XỬ LÝ NHÚNG USER CONTROL VÀO CONTAINER ---
        // Hàm này tui viết sẵn dùng chung, nút nào gọi cũng được
        private void AddUserControl(UserControl uc)
        {
            // 1. Phủ kín form con vào khung
            uc.Dock = DockStyle.Fill;

            // 2. Xóa các form cũ đang hiển thị trong đó (nếu có) để tránh đè lên nhau
            pnlContainer.Controls.Clear();

            // 3. Nạp form mới vào
            pnlContainer.Controls.Add(uc);

            // 4. Đẩy nó lên mặt tiền
            uc.BringToFront();
        }

        private void HighlightButton(Button activeBtn)
        {
            // Bước 1: Trả TẤT CẢ các nút về màu gốc của Panel Sidebar (màu xanh mặc định)
            Color normalColor = pnlSidebar.BackColor;

            btnTongQuan.BackColor = normalColor;
            btnTongQuan.ForeColor = Color.White;

            btnSanPham.BackColor = normalColor;
            btnSanPham.ForeColor = Color.White;

            btnNhanVien.BackColor = normalColor;
            btnNhanVien.ForeColor = Color.White;

            btnBaoCao.BackColor = normalColor;
            btnBaoCao.ForeColor = Color.White;

            // Bước 2: Chỉ riêng cái nút được nhấn mới chuyển sang màu trắng, chữ xanh để làm điểm nhấn
            activeBtn.BackColor = Color.White;
            activeBtn.ForeColor = normalColor;
        }



        // --- HÀM 3: SỰ KIỆN KHI BẤM CÁC NÚT TRÊN MENU ---
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTongQuan);
            
            UC_Dashboard uc = new UC_Dashboard(); // Khởi tạo trang Dashboard
            AddUserControl(uc); // Nhúng vào lỗ Container
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            HighlightButton(btnSanPham);

            UC_SanPham uc = new UC_SanPham();
            AddUserControl(uc);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            HighlightButton(btnNhanVien);

            UC_NhanVien uc = new UC_NhanVien();
            AddUserControl(uc);
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            HighlightButton(btnBaoCao);

            UC_BaoCao uc = new UC_BaoCao();
            AddUserControl(uc);
        }



        // --- SỰ KIỆN FORM LOAD ---
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Vừa mở phần mềm lên là ép nó nhấp luôn vào nút Tổng quan để load trang chủ trước
            btnTongQuan.PerformClick();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            // 1. Làm sáng cái nút lên (nếu form ông có dùng hàm này)
            HighlightButton(btnNhaCungCap);

            // 2. Gọi giao diện ra và nhét vào cái hàm ông đã tạo sẵn
            UC_NhaCungCap uc = new UC_NhaCungCap();
            AddUserControl(uc);
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            HighlightButton(btnPhieuNhap);

            UC_PhieuNhap uc = new UC_PhieuNhap();
            AddUserControl(uc);
        }
    }
}
