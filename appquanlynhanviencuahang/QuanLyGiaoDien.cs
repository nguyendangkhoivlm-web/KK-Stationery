using System;
using System.Drawing;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public static class QuanLyGiaoDien
    {
        public static void ApDungGiaoDien(Form targetForm, bool laCheDoToi)
        {
            if (laCheDoToi)
            {
                // Màu nền form chính sang tối
                targetForm.BackColor = Color.FromArgb(30, 35, 45);

                foreach (Control ctrl in targetForm.Controls)
                {
                    DoiMauControl(ctrl, Color.FromArgb(40, 45, 55), Color.White, true);
                }
            }
            else
            {
                // Màu nền form chính sang sáng dịu nhẹ (Màu gốc ban đầu)
                targetForm.BackColor = Color.FromArgb(240, 243, 246);

                foreach (Control ctrl in targetForm.Controls)
                {
                    DoiMauControl(ctrl, Color.White, Color.Black, false);
                }
            }
        }

        private static void DoiMauControl(Control ctrl, Color panelBg, Color textColor, bool laToi)
        {
            // [BẢO VỆ MENU TRÁI]: Nếu là Panel chứa menu bên trái, bỏ qua tuyệt đối không đổi màu nền của nó!
            if (ctrl is Panel && (ctrl.Dock == DockStyle.Left || ctrl.Name.Contains("Menu") || ctrl.Name.Contains("Sidebar")))
            {
                return; // Giữ nguyên màu nền xanh gốc của menu!
            }

            // CHỈ đổi màu nền cho Panel thông thường, GIỮ LẠI GroupBox để giữ nguyên khung trắng nội dung đẹp mắt
            if (ctrl is Panel && !(ctrl is GroupBox))
            {
                ctrl.BackColor = panelBg;
                ctrl.ForeColor = textColor;
            }
            // Riêng GroupBox giữ nguyên màu sắc giao diện thiết kế để khung trắng luôn nổi bật
            else if (ctrl is GroupBox)
            {
                ctrl.ForeColor = textColor;
            }
            // Chỉ đổi màu chữ cho Label, KHÔNG đụng tới Button menu
            else if (ctrl is Label)
            {
                ctrl.ForeColor = textColor;
            }
            else if (ctrl is DataGridView dgv)
            {
                dgv.BackgroundColor = panelBg;
                dgv.ForeColor = textColor;
            }

            // Quét sâu vào các control con bên trong
            foreach (Control subCtrl in ctrl.Controls)
            {
                DoiMauControl(subCtrl, panelBg, textColor, laToi);
            }
        }
    }
}