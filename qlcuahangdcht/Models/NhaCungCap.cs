using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlcuahangdcht.Models
{

    [Table("NhaCungCap")]
    internal class NhaCungCap
    {
        [Key]
        [StringLength(50)]
        public string MaNCC { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNCC { get; set; }

        [StringLength(20)]
        public string SDT { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }
    }
}
