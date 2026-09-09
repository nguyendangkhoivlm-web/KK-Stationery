using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlcuahangdcht.Models
{

    [Table("ChiTietHoaDon")]
    internal class ChiTietHoaDon
    {
        [Key]
        [StringLength(50)]
        public string MaCTHD { get; set; }

        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        public string MaHoaDon { get; set; }
        [ForeignKey("MaHoaDon")]
        public virtual HoaDon HoaDon { get; set; }

        public string MaSanPham { get; set; }
        [ForeignKey("MaSanPham")]
        public virtual SanPham SanPham { get; set; }
    }
}
