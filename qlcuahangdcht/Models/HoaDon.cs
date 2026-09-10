using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlcuahangdcht.Models
{

    [Table("HoaDon")]
    internal class HoaDon
    {
        [Key]
        [StringLength(50)]
        public string MaHoaDon { get; set; }

        public DateTime? NgayLap { get; set; }
        public decimal TongTien { get; set; }

        // Khóa ngoại tới Khách Hàng
        public string MaKhachHang { get; set; }
        [ForeignKey("MaKhachHang")]
        public virtual KhachHang KhachHang { get; set; }

        // Khóa ngoại tới Nhân Viên
        public string MaNhanVien { get; set; }
        [ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
