using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlcuahangdcht.Models
{

    [Table("SanPham")]
    internal class SanPham
    {
        [Key]
        [StringLength(50)]
        public string MaSanPham { get; set; }

        [Required]
        [StringLength(200)]
        public string TenSanPham { get; set; }

        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }

        [StringLength(50)]
        public string DonViTinh { get; set; }

        // Khóa ngoại liên kết tới bảng DanhMuc
        public string MaDanhMuc { get; set; }
        [ForeignKey("MaDanhMuc")]
        public virtual DanhMuc DanhMuc { get; set; }

        // Liên kết 1-N tới Chi tiết hóa đơn và Chi tiết phiếu nhập
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
