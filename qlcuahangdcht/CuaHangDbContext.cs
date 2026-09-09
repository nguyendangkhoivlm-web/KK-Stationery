using qlcuahangdcht.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlcuahangdcht
{
    internal class CuaHangDbContext : DbContext
    {
        // Nhắc Entity Framework đọc chuỗi kết nối tên "ChuoiKetNoiSQL" trong file App.config
        public CuaHangDbContext() : base("name=ChuoiKetNoiSQL")
        {
        }

        // Khai báo danh sách các bảng sẽ xuất hiện trong SQL Server
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }


        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
