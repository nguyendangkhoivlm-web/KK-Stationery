using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace qlcuahangdcht
{
    public partial class UC_CardSanPham : UserControl
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }

        public event EventHandler ThemClick;

        public UC_CardSanPham()
        {
            InitializeComponent();

            btnThem.Click += (s, e) => {
                if (ThemClick != null)
                {
                    ThemClick(this, EventArgs.Empty);
                }
            };
        }

        public void HienThi(string ma, string ten, decimal gia, int ton, string duongDanAnh)
        {
            MaSP = ma;
            TenSP = ten;
            DonGia = gia;
            SoLuongTon = ton;

            lblTenSanPham.Text = ten;
            lblGiaTien.Text = gia.ToString("N0") + " đ";
            lblTonKho.Text = "Kho: " + ton;

            if (ton <= 0)
            {
                lblTonKho.Text = "Hết hàng";
                lblTonKho.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
            else
            {
                lblTonKho.ForeColor = Color.FromArgb(100, 116, 139);
                btnThem.Enabled = true;
            }

            // ==============================================================
            // LOGIC LOAD HÌNH ẢNH TỪ THƯ MỤC "Resources" CỦA BẠN
            // ==============================================================
            try
            {
                if (!string.IsNullOrEmpty(duongDanAnh) && File.Exists(duongDanAnh))
                {
                    picHinhAnh.Image = Image.FromFile(duongDanAnh);
                    picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                    return;
                }

                // Chỏ đường dẫn vào thư mục Resources mà bạn đã tạo
                string thuMucAnh = Path.Combine(Application.StartupPath, "Resources");

                // Tự động tìm tên ảnh trùng với Mã Sản Phẩm
                string fileAnhJPG = Path.Combine(thuMucAnh, ma + ".jpg");
                string fileAnhPNG = Path.Combine(thuMucAnh, ma + ".png");

                if (File.Exists(fileAnhJPG))
                {
                    picHinhAnh.Image = Image.FromFile(fileAnhJPG);
                    picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (File.Exists(fileAnhPNG))
                {
                    picHinhAnh.Image = Image.FromFile(fileAnhPNG);
                    picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    picHinhAnh.Image = null;
                }
            }
            catch
            {
                picHinhAnh.Image = null;
            }
        }
    }
}