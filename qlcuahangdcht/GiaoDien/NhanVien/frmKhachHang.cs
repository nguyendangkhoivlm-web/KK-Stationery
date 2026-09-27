using qlcuahangdcht.Models;
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
    public partial class frmKhachHang : Form
    {
        // Khai báo bảng chứa dữ liệu tạm thời để phục vụ tìm kiếm nhanh trên UI
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
        // HÀM TẢI DỮ LIỆU TỪ CSDL BẰNG ENTITY FRAMEWORK
        // =========================================================================
        private void TaiDuLieuKhachHang()
        {
            try
            {
                using (var db = new CuaHangDbContext())
                {
                    // Truy vấn dữ liệu từ bảng KhachHang bằng LINQ
                    var query = db.KhachHangs
                                  .Select(k => new
                                  {
                                      MaKH = k.MaKhachHang,
                                      TenKhachHang = k.HoTen,
                                      SoDienThoai = k.SDT,
                                      DiaChi = k.DiaChi,
                                      Email = k.Email
                                  })
                                  .ToList();

                    // Đổ dữ liệu vào DataTable để tương thích với cơ chế tìm kiếm sẵn có
                    dtKhachHang = new DataTable();
                    dtKhachHang.Columns.Add("Mã KH", typeof(string));
                    dtKhachHang.Columns.Add("Tên Khách Hàng", typeof(string));
                    dtKhachHang.Columns.Add("Số Điện Thoại", typeof(string));
                    dtKhachHang.Columns.Add("Địa Chỉ", typeof(string));
                    dtKhachHang.Columns.Add("Email", typeof(string));

                    foreach (var item in query)
                    {
                        dtKhachHang.Rows.Add(item.MaKH, item.TenKhachHang, item.SoDienThoai, item.DiaChi, item.Email);
                    }
                }

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
                MessageBox.Show("Lỗi tải dữ liệu Khách hàng bằng Entity Framework: " + ex.Message, "Lỗi EF", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        // NÚT XÓA KHÁCH HÀNG (SỬ DỤNG ENTITY FRAMEWORK)
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
                        using (var db = new CuaHangDbContext())
                        {
                            // Tìm khách hàng trong cơ sở dữ liệu bằng Entity Framework
                            var kh = db.KhachHangs.Find(maKHXoa);
                            if (kh != null)
                            {
                                db.KhachHangs.Remove(kh); // Xóa khỏi DbSet
                                db.SaveChanges();         // Lưu thay đổi xuống CSDL
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy khách hàng này trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
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

        private void btnXoaKhachHang_Click_1(object sender, EventArgs e)
        {

        }
    }
}