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
        private void AddUserControl(UserControl uc)
        {
            // Phủ kín UserControl vào khung container nhờ Dock = Fill (chuẩn cô dạy)
            uc.Dock = DockStyle.Fill;

            // Xóa các control cũ đang hiển thị để tránh đè lên nhau
            pnlContainer.Controls.Clear();

            // Nạp UserControl mới vào và đưa lên hiển thị
            pnlContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        // --- HÀM 2: ĐỔI MÀU NÚT MENU KHI ĐƯỢC CHỌN ---
        private void HighlightButton(Button activeBtn)
        {
            Color normalColor = pnlSidebar.BackColor;

            // Trả tất cả các nút về màu gốc
            btnTongQuan.BackColor = normalColor;
            btnTongQuan.ForeColor = Color.White;

            btnSanPham.BackColor = normalColor;
            btnSanPham.ForeColor = Color.White;

            btnNhanVien.BackColor = normalColor;
            btnNhanVien.ForeColor = Color.White;

            btnBaoCao.BackColor = normalColor;
            btnBaoCao.ForeColor = Color.White;

            // Nút đang được chọn chuyển sang nổi bật
            if (activeBtn != null)
            {
                activeBtn.BackColor = Color.White;
                activeBtn.ForeColor = normalColor;
            }
        }

        // --- HÀM 3: SỰ KIỆN KHI BẤM CÁC NÚT TRÊN MENU ---
        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTongQuan);
            UC_Dashboard uc = new UC_Dashboard();
            AddUserControl(uc);
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
            // Vừa mở phần mềm lên là tự động load trang Tổng quan đầu tiên
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