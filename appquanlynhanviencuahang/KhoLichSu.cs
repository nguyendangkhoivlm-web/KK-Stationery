using System;
using System.Data;

namespace appquanlynhanviencuahang
{
    public static class KhoLichSu
    {
        // 1. THÊM CỜ HIỆU VÀO ĐÂY ĐỂ BÁO TRẠNG THÁI THANH TOÁN
        public static bool VuaThanhToanXong = false;

        public static DataTable DanhSachDonHang = KhoiTaoBang();

        private static DataTable KhoiTaoBang()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã HĐ", typeof(string));
            dt.Columns.Add("Nhân Viên", typeof(string));
            dt.Columns.Add("Phương Thức", typeof(string));
            dt.Columns.Add("Tổng Tiền", typeof(decimal));
            dt.Columns.Add("Thời Gian", typeof(string));

            // Thêm sẵn dữ liệu mẫu để kiểm tra hiển thị giao diện ngay lập tức
            dt.Rows.Add("HD_20260910_183000", "Trần Vũ Tuấn Kiệt", "Tiền mặt", 898560, "10/09/2026 18:30:00");
            dt.Rows.Add("HD_20260910_183215", "Trần Vũ Tuấn Kiệt", "Thẻ ngân hàng", 806760, "10/09/2026 18:32:15");

            return dt;
        }
    }
}