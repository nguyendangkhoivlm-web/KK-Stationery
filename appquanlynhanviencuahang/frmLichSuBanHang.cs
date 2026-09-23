using System;
using System.Data;
using System.Data.SqlClient; // Bắt buộc để kết nối SQL
using System.Drawing;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmLichSuBanHang : Form
    {
        // 1. Khai báo chuỗi kết nối và bảng chứa dữ liệu thật
        string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";
        DataTable dtLichSu = new DataTable();

        string placeholderText = "Tìm theo Mã HĐ hoặc Tên NV...";

        public frmLichSuBanHang()
        {
            InitializeComponent();

            this.Load += frmLichSuBanHang_Load;

            // Gán sự kiện cho các nút bấm và ô tìm kiếm
            if (btnLocNgay != null) btnLocNgay.Click += btnLocNgay_Click;
            if (btnInLaiHoaDon != null) btnInLaiHoaDon.Click += btnInLaiHoaDon_Click;

            if (txtTimKiem != null)
            {
                txtTimKiem.Enter += txtTimKiem_Enter;
                txtTimKiem.Leave += txtTimKiem_Leave;
                txtTimKiem.TextChanged += txtTimKiem_TextChanged; // Tự động lọc khi gõ chữ

                if (string.IsNullOrWhiteSpace(txtTimKiem.Text) || txtTimKiem.Text == placeholderText)
                {
                    txtTimKiem.Text = placeholderText;
                    txtTimKiem.ForeColor = Color.Gray;
                }
            }
        }

        private void frmLichSuBanHang_Load(object sender, EventArgs e)
        {
            // Vừa mở form lên là gọi hàm kéo dữ liệu từ SQL ngay
            TaiDuLieuTuCSDL();
        }

        // =========================================================================
        // HÀM KÉO DỮ LIỆU TỪ SQL SERVER BẰNG LỆNH JOIN
        // =========================================================================
        private void TaiDuLieuTuCSDL()
        {
            try
            {
                SqlConnection conn = new SqlConnection(chuoiKetNoi);
                conn.Open();

                // Lệnh SQL kết nối bảng HoaDon với bảng NhanVien và KhachHang để lấy tên thật thay vì lấy Mã
                string sql = @"
                    SELECT 
                        hd.MaHoaDon AS [Mã HĐ], 
                        hd.NgayLap AS [Thời Gian], 
                        nv.HoTen AS [Nhân Viên], 
                        kh.HoTen AS [Khách Hàng],
                        hd.TongTien AS [Tổng Tiền]
                    FROM HoaDon hd
                    LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNhanVien
                    LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                dtLichSu = new DataTable();
                da.Fill(dtLichSu); // Đổ dữ liệu thật vào biến dtLichSu

                conn.Close();

                // Đẩy dữ liệu lên DataGridView và tính tổng tiền
                HienThiVaTinhTong(dtLichSu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu lịch sử: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm đổ dữ liệu vào DataGridView và tính toán tổng số đơn, tổng doanh thu
        private void HienThiVaTinhTong(DataTable dt)
        {
            if (dgvLichSu != null)
            {
                dgvLichSu.DataSource = null;
                dgvLichSu.DataSource = dt;

                if (dgvLichSu.Columns.Contains("Tổng Tiền"))
                {
                    dgvLichSu.Columns["Tổng Tiền"].DefaultCellStyle.Format = "N0";
                }
            }

            int tongSoDon = dt.Rows.Count;
            decimal tongDoanhThu = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Tổng Tiền"] != DBNull.Value)
                {
                    tongDoanhThu += Convert.ToDecimal(row["Tổng Tiền"]);
                }
            }

            if (lblTongSoHoaDon != null)
            {
                lblTongSoHoaDon.Text = "Tổng số: " + tongSoDon + " đơn hàng";
            }

            if (lblTongDoanhThu != null)
            {
                lblTongDoanhThu.Text = "Tổng Doanh Thu: " + tongDoanhThu.ToString("N0") + " VNĐ";
            }
        }

        // =========================================================================
        // XỬ LÝ CHỮ MỜ TÌM KIẾM
        // =========================================================================
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == placeholderText)
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = placeholderText;
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        // =========================================================================
        // 1. TÌM KIẾM TỰ ĐỘNG KHI GÕ
        // =========================================================================
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = (txtTimKiem.Text != placeholderText) ? txtTimKiem.Text.Trim().ToLower() : "";

            if (string.IsNullOrEmpty(tuKhoa))
            {
                HienThiVaTinhTong(dtLichSu); // Nếu không gõ gì thì hiện toàn bộ
                return;
            }

            DataTable dtFiltered = dtLichSu.Clone();

            foreach (DataRow row in dtLichSu.Rows)
            {
                string maHD = row["Mã HĐ"].ToString().ToLower();
                string nhanVien = row["Nhân Viên"].ToString().ToLower();
                string khachHang = row["Khách Hàng"].ToString().ToLower();

                // Tìm theo mã HĐ, tên NV hoặc tên KH
                if (maHD.Contains(tuKhoa) || nhanVien.Contains(tuKhoa) || khachHang.Contains(tuKhoa))
                {
                    dtFiltered.ImportRow(row);
                }
            }

            HienThiVaTinhTong(dtFiltered);
        }

        // =========================================================================
        // 2. LỌC THEO KHOẢNG THỜI GIAN
        // =========================================================================
        private void btnLocNgay_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1); // Lấy hết cuối ngày
            string tuKhoa = (txtTimKiem.Text != placeholderText) ? txtTimKiem.Text.Trim().ToLower() : "";

            DataTable dtFiltered = dtLichSu.Clone();

            foreach (DataRow row in dtLichSu.Rows)
            {
                if (DateTime.TryParse(row["Thời Gian"].ToString(), out DateTime ngayDonHang))
                {
                    bool thoaManNgay = (ngayDonHang >= tuNgay && ngayDonHang <= denNgay);

                    string maHD = row["Mã HĐ"].ToString().ToLower();
                    string nhanVien = row["Nhân Viên"].ToString().ToLower();
                    bool thoaManTuKhoa = string.IsNullOrEmpty(tuKhoa) || maHD.Contains(tuKhoa) || nhanVien.Contains(tuKhoa);

                    if (thoaManNgay && thoaManTuKhoa)
                    {
                        dtFiltered.ImportRow(row);
                    }
                }
            }

            HienThiVaTinhTong(dtFiltered);
            MessageBox.Show(string.Format("Đã lọc được {0} hóa đơn trong khoảng thời gian đã chọn!", dtFiltered.Rows.Count), "Kết Quả Lọc", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =========================================================================
        // 3. IN LẠI HÓA ĐƠN
        // =========================================================================
        private void btnInLaiHoaDon_Click(object sender, EventArgs e)
        {
            if (dgvLichSu.SelectedRows.Count > 0 || dgvLichSu.CurrentRow != null)
            {
                DataGridViewRow row = dgvLichSu.CurrentRow;
                string maHD = row.Cells["Mã HĐ"].Value.ToString();
                string tongTienHD = Convert.ToDecimal(row.Cells["Tổng Tiền"].Value).ToString("N0");

                MessageBox.Show(string.Format("Đang gửi lệnh in lại hóa đơn [{0}] - Tổng tiền: {1} VNĐ", maHD, tongTienHD), "In Lại Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng đơn hàng cần in lại trên bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}