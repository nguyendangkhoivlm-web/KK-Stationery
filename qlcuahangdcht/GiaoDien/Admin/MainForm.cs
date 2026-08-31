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

        private void HighlightButton(Button activeBtn)
        {
            // Bước 1: Trả TẤT CẢ các nút về màu gốc của Panel Sidebar (màu xanh mặc định)
            Color normalColor = pnlSidebar.BackColor;

            btnTongQuan.BackColor = normalColor;
            btnTongQuan.ForeColor = Color.White;

            btnBanHang.BackColor = normalColor;
            btnBanHang.ForeColor = Color.White;

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

        private void btnTongQuan_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTongQuan);
            // Sau này code load giao diện trang Tổng quan
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            HighlightButton(btnBanHang);
            // Code load trang Bán hàng
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            HighlightButton(btnSanPham);


        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            HighlightButton(btnNhanVien);

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            HighlightButton(btnBaoCao);

        }
    }
}
