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
            // Gọi 3 hàm xử lý riêng biệt khi màn hình vừa hiện lên
            LoadKpiData();
            LoadChartData();
            LoadTopProducts();
        }


        #region 1. Đổ dữ liệu 4 thẻ KPI trên cùng
        private void LoadKpiData()
        {
            // TODO: Dùng LINQ truy vấn db.HoaDons trong ngày hôm nay
            // Ví dụ: lblTongDoanhThu.Text = db.HoaDons.Where(...).Sum(x => x.TongTien).ToString("#,##0 đ");

            // Data giả lập giữ form không bị trống
            lblTongDoanhThu.Text = "4.500.000.000 đ";
            lblTongDonHang.Text = "100";
            lblSanPhamBanChay.Text = "Bút bi Thiên Long";
            lblSoLuongTon.Text = "36";
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

            // TODO: Vòng lặp lấy data 7 ngày từ Database đắp vào đây
            // Khởi tạo điểm bắt đầu sát lề (như đã fix hôm trước)
            for (int i = 1; i <= 7; i++)
            {
                // Thay số 0 bằng giá trị thực tế sau
                chart1.Series["Doanh thu"].Points.AddXY(i, 0);
                chart1.Series["Lợi nhuận"].Points.AddXY(i, 0);
            }
        }
        #endregion

        #region 3. Đổ dữ liệu Top Sản phẩm bán chạy (Bên phải)
        private void LoadTopProducts()
        {
            // TODO: Đổ danh sách sản phẩm. 
            // Nếu ông đang dùng FlowLayoutPanel, chỗ này sẽ dùng vòng lặp foreach để sinh ra các UserControl sản phẩm con.
        }
        #endregion

    }
}
