using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appquanlynhanviencuahang
{
    public partial class frmLichSuBanHang : Form
    {
        string placeholderText = "Tìm theo Mã HĐ hoặc SĐT...";

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
            TaiDuLieuLichSu(KhoLichSu.DanhSachDonHang);
        }

        // Hàm đổ dữ liệu vào DataGridView và tính toán tổng số đơn, tổng doanh thu
        private void TaiDuLieuLichSu(DataTable dt)
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

        // 1. Tự động lọc khi người dùng gõ chữ vào ô tìm kiếm
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = (txtTimKiem.Text != placeholderText) ? txtTimKiem.Text.Trim().ToLower() : "";

            if (string.IsNullOrEmpty(tuKhoa))
            {
                TaiDuLieuLichSu(KhoLichSu.DanhSachDonHang);
                return;
            }

            DataTable dtFiltered = KhoLichSu.DanhSachDonHang.Clone();
            foreach (DataRow row in KhoLichSu.DanhSachDonHang.Rows)
            {
                string maHD = row["Mã HĐ"].ToString().ToLower();
                string nhanVien = row["Nhân Viên"].ToString().ToLower();
                string phuongThuc = row["Phương Thức"].ToString().ToLower();

                if (maHD.Contains(tuKhoa) || nhanVien.Contains(tuKhoa) || phuongThuc.Contains(tuKhoa))
                {
                    dtFiltered.ImportRow(row);
                }
            }

            TaiDuLieuLichSu(dtFiltered);
        }

        // 2. Nút Lọc theo khoảng thời gian (Từ ngày - Đến ngày) kết hợp từ khóa
        private void btnLocNgay_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1); // Lấy hết cuối ngày đến ngày kết thúc
            string tuKhoa = (txtTimKiem.Text != placeholderText) ? txtTimKiem.Text.Trim().ToLower() : "";

            DataTable dtFiltered = KhoLichSu.DanhSachDonHang.Clone();

            foreach (DataRow row in KhoLichSu.DanhSachDonHang.Rows)
            {
                // Giả sử cột "Thời Gian" lưu dạng chuỗi "dd/MM/yyyy HH:mm:ss" hoặc tương tự
                if (DateTime.TryParse(row["Thời Gian"].ToString(), out DateTime ngayDonHang))
                {
                    bool thoảManNgay = (ngayDonHang >= tuNgay && ngayDonHang <= denNgay);

                    string maHD = row["Mã HĐ"].ToString().ToLower();
                    string nhanVien = row["Nhân Viên"].ToString().ToLower();
                    bool thoảManTuKhoa = string.IsNullOrEmpty(tuKhoa) || maHD.Contains(tuKhoa) || nhanVien.Contains(tuKhoa);

                    if (thoảManNgay && thoảManTuKhoa)
                    {
                        dtFiltered.ImportRow(row);
                    }
                }
            }

            TaiDuLieuLichSu(dtFiltered);
            MessageBox.Show(string.Format("Đã lọc được {0} hóa đơn trong khoảng thời gian đã chọn!", dtFiltered.Rows.Count), "Kết Quả Lọc", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 3. Nút In Lại Hóa Đơn đã chọn trên lưới
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