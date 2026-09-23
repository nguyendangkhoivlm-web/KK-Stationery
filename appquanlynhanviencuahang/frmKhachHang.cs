using qlnhanvien;
using System;
using System.Data;
using System.Data.SqlClient;
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

            // 1. Kích hoạt Load
            this.Load += frmKhachHang_Load;

            // 2. Nối dây TẤT CẢ các hành động cho ô tìm kiếm
            this.txtTimKiem.Enter += txtTimKiem_Enter;
            this.txtTimKiem.Leave += txtTimKiem_Leave;
            this.txtTimKiem.Click += txtTimKiem_Click;
            this.txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // 3. NỐI DÂY CHO NÚT XÓA BẰNG CODE ĐỂ ĐẢM BẢO HOẠT ĐỘNG 100%
            // (Nếu nút xóa của bạn có tên khác ở giao diện, hãy đổi chữ btnXoaKhachHang thành tên đó)
            this.btnXoaKhachHang.Click += btnXoaKhachHang_Click;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            TaiDuLieuKhachHang();

            // Ép hệ thống chọn Focus vào bảng thay vì ô Textbox
            this.ActiveControl = dgvDanhSachKhachHang;

            // Cài đặt chữ mờ ban đầu cho ô tìm kiếm
            txtTimKiem.Text = placeholderText;
            txtTimKiem.ForeColor = Color.Gray;
        }

        // =========================================================================
        // HÀM TẢI DỮ LIỆU TỪ SQL
        // =========================================================================
        private void TaiDuLieuKhachHang()
        {
            try
            {
                SqlConnection conn = new SqlConnection(chuoiKetNoi);
                conn.Open();

                string sql = "SELECT MaKhachHang AS [Mã KH], HoTen AS [Tên Khách Hàng], SDT AS [Số Điện Thoại], DiaChi AS [Địa Chỉ], Email FROM KhachHang";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                dtKhachHang = new DataTable();
                da.Fill(dtKhachHang);
                conn.Close();

                dgvDanhSachKhachHang.DataSource = null;
                dgvDanhSachKhachHang.Columns.Clear();
                dgvDanhSachKhachHang.AutoGenerateColumns = true;

                dgvDanhSachKhachHang.DataSource = dtKhachHang;

                dgvDanhSachKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDanhSachKhachHang.AllowUserToAddRows = false;
                dgvDanhSachKhachHang.BackgroundColor = Color.White;
                dgvDanhSachKhachHang.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Khách hàng: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // CHỨC NĂNG XÓA/HIỆN CHỮ MỜ CHO Ô TÌM KIẾM 
        // =========================================================================
        private void XoaChuMo()
        {
            if (txtTimKiem.Text == placeholderText)
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            XoaChuMo();
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            XoaChuMo();
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = placeholderText;
                txtTimKiem.ForeColor = Color.Gray;

                dgvDanhSachKhachHang.DataSource = dtKhachHang;
            }
        }

        // =========================================================================
        // CHỨC NĂNG TÌM KIẾM
        // =========================================================================
        private void ThucHienTimKiem()
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            if (tuKhoa == "" || tuKhoa == placeholderText.ToLower())
            {
                dgvDanhSachKhachHang.DataSource = dtKhachHang;
                return;
            }

            DataTable dtTimKiem = dtKhachHang.Clone();

            for (int i = 0; i < dtKhachHang.Rows.Count; i++)
            {
                string maKH = dtKhachHang.Rows[i]["Mã KH"].ToString().ToLower();
                string sdt = dtKhachHang.Rows[i]["Số Điện Thoại"].ToString().ToLower();
                string tenKH = dtKhachHang.Rows[i]["Tên Khách Hàng"].ToString().ToLower();

                if (maKH.Contains(tuKhoa) || sdt.Contains(tuKhoa) || tenKH.Contains(tuKhoa))
                {
                    dtTimKiem.ImportRow(dtKhachHang.Rows[i]);
                }
            }

            dgvDanhSachKhachHang.DataSource = dtTimKiem;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != placeholderText)
            {
                ThucHienTimKiem();
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        // =========================================================================
        // NÚT THÊM KHÁCH HÀNG 
        // =========================================================================
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            btnThemKhachHang_Click_1(sender, e);
        }

        private void btnThemKhachHang_Click_1(object sender, EventArgs e)
        {
            frmMain mainForm = this.TopLevelControl as frmMain;

            if (mainForm != null)
            {
                mainForm.OpenChildForm(new frmThongTinDeIn1(), null);
            }
            else
            {
                frmThongTinDeIn1 frm = new frmThongTinDeIn1();
                frm.ShowDialog();
                TaiDuLieuKhachHang();
            }
        }

        // =========================================================================
        // NÚT XÓA KHÁCH HÀNG (ĐÃ BẬT TÍNH NĂNG VÀ HIỂN THỊ THÔNG BÁO)
        // =========================================================================
        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã click chọn 1 dòng trên bảng chưa
            if (dgvDanhSachKhachHang.CurrentRow != null && !dgvDanhSachKhachHang.CurrentRow.IsNewRow)
            {
                // Lấy Mã KH từ cột đầu tiên của dòng đang chọn
                string maKHXoa = dgvDanhSachKhachHang.CurrentRow.Cells[0].Value.ToString();

                // Hiện hộp thoại hỏi xác nhận trước khi xóa
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng mã [" + maKHXoa + "] không?", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(chuoiKetNoi))
                        {
                            conn.Open();

                            // Dùng Parameter để bảo mật và tránh lỗi cú pháp SQL
                            string sqlXoa = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKH";
                            using (SqlCommand cmd = new SqlCommand(sqlXoa, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaKH", maKHXoa);
                                cmd.ExecuteNonQuery(); // Chạy lệnh xóa
                            }
                        }

                        // Tải lại bảng ngay lập tức để cập nhật giao diện
                        TaiDuLieuKhachHang();
                        MessageBox.Show("Đã xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xóa khách hàng này!\n(Nguyên nhân: Khách hàng này đã từng mua hàng, dữ liệu đang bị ràng buộc với bảng Hóa Đơn)\n\nChi tiết lỗi: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhấp chuột chọn một dòng khách hàng hợp lệ trên bảng trước khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Đoạn thừa nếu lỡ tạo bên giao diện, cứ để trống không sao cả
        private void btnXoaKhachHang_Click_1(object sender, EventArgs e)
        {

        }
    }
}