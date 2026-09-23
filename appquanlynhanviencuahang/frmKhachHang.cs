using System;
using System.Data;
using System.Data.SqlClient; // Thư viện kết nối CSDL
using System.Drawing;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmKhachHang : Form
    {
        // 1. Khai báo chuỗi kết nối toàn cục
        string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlycuahangdungcuhoctap;Integrated Security=True";

        // Khai báo bảng chứa dữ liệu
        DataTable dtKhachHang = new DataTable();
        string placeholderText = "Tìm kiếm theo Mã hoặc Số điện thoại...";

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            // Gọi hàm tải dữ liệu
            TaiDuLieuKhachHang();

            // Làm chữ mờ ô tìm kiếm
            if (txtTimKiem.Text == "" || txtTimKiem.Text == "Tìm kiếm theo Mã hoặc Số điện thoại...")
            {
                txtTimKiem.Text = placeholderText;
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        // =========================================================================
        // HÀM TẢI DỮ LIỆU TỪ SQL (Viết theo chuẩn cơ bản cô dạy)
        // =========================================================================
        private void TaiDuLieuKhachHang()
        {
            try
            {
                // Bước 1: Tạo kết nối
                SqlConnection conn = new SqlConnection(chuoiKetNoi);

                // Bước 2: Mở kết nối
                conn.Open();

                // Bước 3: Viết câu lệnh SQL
                string sql = "SELECT MaKhachHang AS [Mã KH], HoTen AS [Tên Khách Hàng], SDT AS [Số Điện Thoại], DiaChi AS [Địa Chỉ], Email FROM KhachHang";

                // Bước 4: Dùng DataAdapter lấy dữ liệu
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                // Bước 5: Đổ vào DataTable và đẩy lên DataGridView
                dtKhachHang = new DataTable();
                da.Fill(dtKhachHang);
                dgvDanhSachKhachHang.DataSource = dtKhachHang;

                // Bước 6: Đóng kết nối
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // =========================================================================
        // XỬ LÝ HIỆU ỨNG CHỮ MỜ CHO Ô TÌM KIẾM
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
            if (txtTimKiem.Text == "")
            {
                txtTimKiem.Text = placeholderText;
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        // =========================================================================
        // CHỨC NĂNG TÌM KIẾM (Giữ nguyên thuật toán vòng lặp FOR của bạn)
        // =========================================================================
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            if (tuKhoa == "" || tuKhoa == placeholderText.ToLower())
            {
                TaiDuLieuKhachHang();
                return;
            }

            DataTable dtTimKiem = dtKhachHang.Clone();

            for (int i = 0; i < dtKhachHang.Rows.Count; i++)
            {
                string maKH = dtKhachHang.Rows[i]["Mã KH"].ToString().ToLower();
                string sdt = dtKhachHang.Rows[i]["Số Điện Thoại"].ToString().ToLower();

                if (maKH.Contains(tuKhoa) || sdt.Contains(tuKhoa))
                {
                    dtTimKiem.ImportRow(dtKhachHang.Rows[i]);
                }
            }

            dgvDanhSachKhachHang.DataSource = dtTimKiem;
        }

        // =========================================================================
        // NÚT THÊM KHÁCH HÀNG
        // =========================================================================
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            // Tự tạo mã KH004, KH005...
            int soLuong = dtKhachHang.Rows.Count + 1;
            string maKHMoi = "KH" + soLuong.ToString("D3");

            try
            {
                SqlConnection conn = new SqlConnection(chuoiKetNoi);
                conn.Open();

                // Dùng chuỗi cộng chuỗi cơ bản
                string sqlThem = "INSERT INTO KhachHang (MaKhachHang, HoTen, SDT, DiaChi, Email) VALUES ('" + maKHMoi + "', N'Khách Hàng Mới', '0987654321', N'Đồng Tháp', 'khachhang@gmail.com')";

                SqlCommand cmd = new SqlCommand(sqlThem, conn);
                cmd.ExecuteNonQuery(); // Chạy lệnh Thêm

                conn.Close();

                // Tải lại bảng để xem dòng mới thêm
                TaiDuLieuKhachHang();
                MessageBox.Show("Thêm khách hàng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        // =========================================================================
        // NÚT XÓA KHÁCH HÀNG
        // =========================================================================
        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachKhachHang.CurrentRow != null)
            {
                string maKHXoa = dgvDanhSachKhachHang.CurrentRow.Cells["Mã KH"].Value.ToString();

                DialogResult dr = MessageBox.Show("Bạn có muốn xóa mã " + maKHXoa + " không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection conn = new SqlConnection(chuoiKetNoi);
                        conn.Open();

                        string sqlXoa = "DELETE FROM KhachHang WHERE MaKhachHang = '" + maKHXoa + "'";

                        SqlCommand cmd = new SqlCommand(sqlXoa, conn);
                        cmd.ExecuteNonQuery(); // Chạy lệnh Xóa

                        conn.Close();

                        TaiDuLieuKhachHang();
                        MessageBox.Show("Đã xóa thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa (Có thể khách này đã mua hàng): " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng để xóa!");
            }
        }
    }
}