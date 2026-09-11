using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appquanlynhanviencuahang
{
    internal class PhienDangNhap
    {
        public static string HoVaTen { get; set; } = "";
        public static string MaNhanVien { get; set; } = "";
        public static string ChucVu { get; set; } = "";
        public static string BoPhan { get; set; } = "";
        public static string VaiTro { get; set; } = "NhanVien"; // Mặc định là Nhân viên, nếu là sếp/admin thì đổi thành "Admin"

    }
}
