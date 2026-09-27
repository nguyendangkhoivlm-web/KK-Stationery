using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appquanlynhanviencuahang.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public string MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
    }
}