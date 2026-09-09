using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlcuahangdcht.Models
{

    [Table("ChiTietPhieuNhap")]
    internal class ChiTietPhieuNhap
    {
        [Key]
        [StringLength(50)]
        public string MaCTPN { get; set; }

        public int SoLuong { get; set; }
        public decimal GiaNhap { get; set; }

        public string MaPhieuNhap { get; set; }
        [ForeignKey("MaPhieuNhap")]
        public virtual PhieuNhap PhieuNhap { get; set; }

        public string MaSanPham { get; set; }
        [ForeignKey("MaSanPham")]
        public virtual SanPham SanPham { get; set; }
    }
}
