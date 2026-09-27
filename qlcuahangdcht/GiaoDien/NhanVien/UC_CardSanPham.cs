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
            // LOGIC LOAD HÌNH ẢNH (Ưu tiên ảnh Admin đã cấu hình)
            // ==============================================================
            try
            {
                // Thư mục mặc định chứa ảnh của hệ thống
                string thuMucAnh = Path.Combine(Application.StartupPath, "Resources");
                if (!Directory.Exists(thuMucAnh)) Directory.CreateDirectory(thuMucAnh);

                // 1. Kiểm tra nếu Admin đã lưu đường dẫn ảnh hợp lệ (Biến duongDanAnh từ CSDL)
                if (!string.IsNullOrEmpty(duongDanAnh))
                {
                    // Trường hợp 1: Admin lưu đường dẫn tuyệt đối (VD: D:\HinhAnh\SP01.jpg)
                    if (File.Exists(duongDanAnh))
                    {
                        picHinhAnh.Image = Image.FromFile(duongDanAnh);
                        picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                        return; // Load thành công thì dừng luôn
                    }

                    // Trường hợp 2: Admin chỉ lưu tên file (VD: "butbi.jpg"), ta tìm nó trong thư mục Resources
                    string duongDanTuongDoi = Path.Combine(thuMucAnh, Path.GetFileName(duongDanAnh));
                    if (File.Exists(duongDanTuongDoi))
                    {
                        picHinhAnh.Image = Image.FromFile(duongDanTuongDoi);
                        picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                        return; // Load thành công thì dừng luôn
                    }
                }

                // 2. Dự phòng: Nếu Admin CHƯA lưu ảnh, tự động tìm ảnh có tên trùng với Mã SP (VD: SP01.jpg)
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
                    // 3. Nếu không tìm thấy bất kỳ ảnh nào, để trống hoặc bạn có thể gán ảnh mặc định ở đây
                    picHinhAnh.Image = null;
                }
            }
            catch
            {
                // Bẫy lỗi an toàn: Bị lỗi file ảnh (file hỏng, đang bị khóa...) thì bỏ qua, không làm văng app
                picHinhAnh.Image = null;
            }
        }
    }
}