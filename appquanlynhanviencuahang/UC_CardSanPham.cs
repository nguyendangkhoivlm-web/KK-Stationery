using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class UC_CardSanPham : UserControl
    {
        // Các thuộc tính cơ bản của sản phẩm
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }

        // Khai báo sự kiện đơn giản khi khách bấm nút Thêm
        public event EventHandler ThemClick;

        public UC_CardSanPham()
        {
            InitializeComponent();

            // Gắn sự kiện click cho nút Thêm
            btnThem.Click += (s, e) => {
                if (ThemClick != null)
                {
                    ThemClick(this, EventArgs.Empty);
                }
            };
        }

        // Hàm gán dữ liệu đơn giản, dễ hiểu
        public void HienThi(string ma, string ten, decimal gia, int ton, string duongDanAnh)
        {
            MaSP = ma;
            TenSP = ten;
            DonGia = gia;
            SoLuongTon = ton;

            // Đưa dữ liệu lên các Label
            lblTenSanPham.Text = ten;
            lblGiaTien.Text = gia.ToString("N0") + " đ";
            lblTonKho.Text = "Kho: " + ton;

            // Kiểm tra hàng trong kho
            if (ton <= 0)
            {
                lblTonKho.Text = "Hết hàng";
                lblTonKho.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
            else
            {
                btnThem.Enabled = true;
            }

            // Load hình ảnh cơ bản
            try
            {
                if (!string.IsNullOrEmpty(duongDanAnh) && File.Exists(duongDanAnh))
                {
                    picHinhAnh.Image = Image.FromFile(duongDanAnh);
                    picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch
            {
                picHinhAnh.Image = null;
            }
        }
    }
}