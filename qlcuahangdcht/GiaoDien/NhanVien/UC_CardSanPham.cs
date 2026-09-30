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

            btnThem.Click += (s, e) =>
            {
                if (ThemClick != null)
                {
                    ThemClick(this, EventArgs.Empty);
                }
            };
        }

        public void HienThi(string ma, string ten, decimal gia, int ton, string duongDanAnh)
        {
            // 1. Gán dữ liệu vào Properties
            MaSP = ma;
            TenSP = ten;
            DonGia = gia;
            SoLuongTon = ton;

            // 2. Hiển thị lên Label
            lblTenSanPham.Text = ten;
            lblGiaTien.Text = gia.ToString("N0") + " đ";
            lblTonKho.Text = "Kho: " + ton;

            // 3. Xử lý hiển thị trạng thái nút Thêm và Tồn kho
            if (ton <= 0)
            {
                lblTonKho.Text = "Hết hàng";
                lblTonKho.ForeColor = Color.Red;
                btnThem.Enabled = false;
            }
            else
            {
                lblTonKho.ForeColor = Color.FromArgb(100, 116, 139); // Màu xám nhẹ
                btnThem.Enabled = true;
            }

            // ==============================================================
            // 4. LOGIC LOAD HÌNH ẢNH "BẤT TỬ" (Quét đa luồng)
            // ==============================================================
            try
            {
                string thuMucDebug = Path.Combine(Application.StartupPath, "Resources");
                string thuMucGoc = Path.Combine(Application.StartupPath, @"..\..\Resources");

                string fileAnh = "";
                string tenFilePng = ma + ".png"; // VD: SP001.png
                string tenFileJpg = ma + ".jpg"; // VD: SP001.jpg

                // Ưu tiên 1: Tên file lấy từ cơ sở dữ liệu (nếu có)
                string tenFileTuDB = "";
                if (!string.IsNullOrWhiteSpace(duongDanAnh))
                {
                    tenFileTuDB = Path.GetFileName(duongDanAnh.Trim());
                }

                // HÀM CỤC BỘ: Giúp kiểm tra nhanh đường dẫn tồn tại
                string KiemTraTonTai(string thuMuc, string tenFile)
                {
                    string duongDanFull = Path.Combine(thuMuc, tenFile);
                    return File.Exists(duongDanFull) ? duongDanFull : "";
                }

                // Bắt đầu quét tìm ảnh
                if (!string.IsNullOrEmpty(tenFileTuDB))
                {
                    // Quét tên file từ DB trong cả 2 thư mục
                    fileAnh = KiemTraTonTai(thuMucDebug, tenFileTuDB);
                    if (string.IsNullOrEmpty(fileAnh)) fileAnh = KiemTraTonTai(thuMucGoc, tenFileTuDB);
                }

                // Nếu vẫn chưa tìm thấy, quét theo mã sản phẩm (Dự phòng)
                if (string.IsNullOrEmpty(fileAnh))
                {
                    fileAnh = KiemTraTonTai(thuMucDebug, tenFilePng);
                    if (string.IsNullOrEmpty(fileAnh)) fileAnh = KiemTraTonTai(thuMucDebug, tenFileJpg);
                    if (string.IsNullOrEmpty(fileAnh)) fileAnh = KiemTraTonTai(thuMucGoc, tenFilePng);
                    if (string.IsNullOrEmpty(fileAnh)) fileAnh = KiemTraTonTai(thuMucGoc, tenFileJpg);
                }

                // 5. Gắn ảnh lên PictureBox nếu tìm thấy
                if (!string.IsNullOrEmpty(fileAnh))
                {
                    using (FileStream fs = new FileStream(fileAnh, FileMode.Open, FileAccess.Read))
                    {
                        picHinhAnh.Image = Image.FromStream(fs);
                    }
                    picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    picHinhAnh.Image = null; // Trống nếu không có ảnh
                }
            }
            catch
            {
                // Bắt lỗi âm thầm để không crash ứng dụng nếu file bị lỗi
                picHinhAnh.Image = null;
            }
        }
    }
}