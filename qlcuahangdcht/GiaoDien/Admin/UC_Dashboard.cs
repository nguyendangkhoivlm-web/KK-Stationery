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
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {

            // Gọi hàm tính số liệu cho 4 thẻ KPI
            LoadKpiData();

            // Gọi hàm kéo dữ liệu vẽ biểu đồ 7 ngày
            LoadChartData();

            LoadTopProductsData();

            using (var db = new CuaHangDbContext())
            {
                // 1. Cập nhật Số lượng tồn kho (Lấy tổng cột SoLuongTon trong bảng SanPhams)
                int tongTonKho = db.SanPhams.Sum(sp => (int?)sp.SoLuongTon) ?? 0;
                lblTonKho.Text = tongTonKho.ToString(); // Đổi lblTonKho thành tên cái nhãn đang hiện số 36 của ông

                // 2. Cập nhật Tổng đơn hàng
                DateTime homNay = DateTime.Today;
                int tongDon = db.HoaDons.Count(hd => hd.NgayLap.HasValue
                                                  && hd.NgayLap.Value.Year == homNay.Year
                                                  && hd.NgayLap.Value.Month == homNay.Month
                                                  && hd.NgayLap.Value.Day == homNay.Day);
                // Nhớ sửa lblTongDonHang thành tên thực tế của cái Label đang hiện số 100 
                lblTongDonHang.Text = tongDon.ToString();

                // 3. Cập nhật Tổng doanh thu hôm nay
                decimal doanhThu = db.HoaDons
                                     .Where(hd => hd.NgayLap.HasValue
                                               && hd.NgayLap.Value.Year == homNay.Year
                                               && hd.NgayLap.Value.Month == homNay.Month
                                               && hd.NgayLap.Value.Day == homNay.Day)
                                     .Sum(hd => (decimal?)hd.TongTien) ?? 0;

                lblDoanhThu.Text = doanhThu.ToString("N0") + " đ";

                // 4. Sản phẩm bán chạy nhất
                // (Phần này phức tạp hơn vì phải group by trong bảng ChiTietHoaDon, ông cứ test 3 ô trên cho nó tự nhảy số đi đã!)
            }
        }


        #region 1. Đổ dữ liệu 4 thẻ KPI trên cùng
        private void LoadKpiData()
        {
            // TODO: Dùng LINQ truy vấn db.HoaDons trong ngày hôm nay
            // Ví dụ: lblTongDoanhThu.Text = db.HoaDons.Where(...).Sum(x => x.TongTien).ToString("#,##0 đ");

            // Data giả lập giữ form không bị trống
            lblDoanhThu.Text = "4.500.000.000 đ";
            lblTongDonHang.Text = "100";
            lblSanPhamBanChay.Text = "Bút bi Thiên Long";
            lblTonKho.Text = "36";
        }
        #endregion

        #region 2. Đổ dữ liệu Biểu đồ biến động 7 ngày
        private void LoadChartData()
        {
            // Quét sạch dữ liệu rác mặc định của Designer
            chart1.Series["Doanh thu"].Points.Clear();
            chart1.Series["Lợi nhuận"].Points.Clear();

            // Format trục Y hiển thị tiền tệ
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0";

            // Khai báo kết nối Database ở đây để kéo dữ liệu thật
            using (var db = new CuaHangDbContext())
            {
                // 1. Xác định mốc thời gian: Từ 6 ngày trước đến hôm nay
                DateTime homNay = DateTime.Today;
                DateTime bayNgayTruoc = homNay.AddDays(-6);

                // 2. Kéo dữ liệu hóa đơn trong 7 ngày qua
                var hoaDon7Ngay = db.HoaDons
                    .Where(hd => hd.NgayLap.HasValue
                              && hd.NgayLap.Value >= bayNgayTruoc
                              && hd.NgayLap.Value <= homNay)
                    .ToList();

                // 3. Gom nhóm doanh thu theo từng ngày
                var duLieuThongKe = hoaDon7Ngay
                    .GroupBy(hd => hd.NgayLap.Value.Date)
                    .Select(g => new {
                        Ngay = g.Key.ToString("dd/MM"),
                        DoanhThu = g.Sum(hd => (decimal?)hd.TongTien) ?? 0
                    })
                    .ToList();

                // 4. Lấp đầy dữ liệu vào danh sách (đảm bảo ngày không bán được gì vẫn hiện số 0)
                var danhSachNgay = new List<string>();
                var danhSachDoanhThu = new List<decimal>();

                for (int i = 6; i >= 0; i--)
                {
                    string chuoiNgay = homNay.AddDays(-i).ToString("dd/MM");
                    danhSachNgay.Add(chuoiNgay);

                    var dt = duLieuThongKe.FirstOrDefault(x => x.Ngay == chuoiNgay);
                    danhSachDoanhThu.Add(dt != null ? dt.DoanhThu : 0);
                }

                // 5. Đổ dữ liệu vào biểu đồ
                chart1.Series["Doanh thu"].Points.DataBindXY(danhSachNgay, danhSachDoanhThu);
            }
        }
        #endregion

        #region 3. Đổ dữ liệu Top Sản phẩm bán chạy (Bên phải)
        private void LoadTopProductsData()
        {
            using (var db = new CuaHangDbContext())
            {
                // 1. Gom nhóm chi tiết hóa đơn để tìm ra 3 sản phẩm bán chạy nhất
                var top3SanPham = (from ct in db.ChiTietHoaDons
                                   group ct by ct.MaSanPham into g
                                   select new
                                   {
                                       MaSP = g.Key,
                                       TongSoLuongBan = g.Sum(x => x.SoLuong)
                                   })
                                  .OrderByDescending(x => x.TongSoLuongBan)
                                  .Take(3)
                                  .Join(db.SanPhams,
                                        top => top.MaSP,
                                        sp => sp.MaSanPham,
                                        (top, sp) => new
                                        {
                                            TenSP = sp.TenSanPham,
                                            GiaBan = sp.DonGia,
                                            SoLuong = top.TongSoLuongBan
                                        }).ToList();

                // 2. Xóa chữ mặc định ban đầu để lỡ không có đủ 3 SP thì nó trắng chứ không hiện data giả
                lblTenTop1.Text = ""; lblGiaTop1.Text = "";
                lblTenTop2.Text = ""; lblGiaTop2.Text = "";
                lblTenTop3.Text = ""; lblGiaTop3.Text = "";

                // 3. Đổ dữ liệu thật lên giao diện (CÁCH B)
                if (top3SanPham.Count > 0)
                {
                    lblTenTop1.Text = top3SanPham[0].TenSP;
                    lblGiaTop1.Text = top3SanPham[0].GiaBan.ToString("N0") + " đ";
                }

                if (top3SanPham.Count > 1)
                {
                    lblTenTop2.Text = top3SanPham[1].TenSP;
                    lblGiaTop2.Text = top3SanPham[1].GiaBan.ToString("N0") + " đ";
                }

                if (top3SanPham.Count > 2)
                {
                    lblTenTop3.Text = top3SanPham[2].TenSP;
                    lblGiaTop3.Text = top3SanPham[2].GiaBan.ToString("N0") + " đ";
                }
            }
        }
        #endregion

    }
}
