using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appquanlynhanviencuahang.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
    }
}