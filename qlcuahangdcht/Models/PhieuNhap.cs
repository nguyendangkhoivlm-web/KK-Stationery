using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlcuahangdcht.Models
{

    [Table("PhieuNhap")]
    internal class PhieuNhap
    {
        [Key]
        [StringLength(50)]
        public string MaPhieuNhap { get; set; }

        public DateTime? NgayNhap { get; set; }

        public string MaNCC { get; set; }
        [ForeignKey("MaNCC")]
        public virtual NhaCungCap NhaCungCap { get; set; }

        public string MaNhanVien { get; set; }
        [ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
