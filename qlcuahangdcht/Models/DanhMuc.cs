using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlcuahangdcht.Models
{

    [Table("DanhMuc")]
    internal class DanhMuc
    {
        [Key]
        [StringLength(50)]
        public string MaDanhMuc { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDanhMuc { get; set; }

        // Mối quan hệ 1-N: 1 Danh mục có nhiều Sản phẩm
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}

