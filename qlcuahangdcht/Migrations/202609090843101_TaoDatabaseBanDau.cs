namespace qlcuahangdcht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaoDatabaseBanDau : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHoaDon",
                c => new
                    {
                        MaCTHD = c.String(nullable: false, maxLength: 50),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThanhTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaHoaDon = c.String(maxLength: 50),
                        MaSanPham = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaCTHD)
                .ForeignKey("dbo.HoaDon", t => t.MaHoaDon)
                .ForeignKey("dbo.SanPham", t => t.MaSanPham)
                .Index(t => t.MaHoaDon)
                .Index(t => t.MaSanPham);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHoaDon = c.String(nullable: false, maxLength: 50),
                        NgayLap = c.DateTime(),
                        TongTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaKhachHang = c.String(maxLength: 50),
                        MaNhanVien = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.KhachHang", t => t.MaKhachHang)
                .ForeignKey("dbo.NhanVien", t => t.MaNhanVien)
                .Index(t => t.MaKhachHang)
                .Index(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKhachHang = c.String(nullable: false, maxLength: 50),
                        HoTen = c.String(nullable: false, maxLength: 100),
                        SDT = c.String(maxLength: 20),
                        DiaChi = c.String(maxLength: 255),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNhanVien = c.String(nullable: false, maxLength: 50),
                        HoTen = c.String(nullable: false, maxLength: 100),
                        NgaySinh = c.DateTime(),
                        GioiTinh = c.String(maxLength: 10),
                        SDT = c.String(maxLength: 20),
                        DiaChi = c.String(maxLength: 255),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.PhieuNhap",
                c => new
                    {
                        MaPhieuNhap = c.String(nullable: false, maxLength: 50),
                        NgayNhap = c.DateTime(),
                        MaNCC = c.String(maxLength: 50),
                        MaNhanVien = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaPhieuNhap)
                .ForeignKey("dbo.NhaCungCap", t => t.MaNCC)
                .ForeignKey("dbo.NhanVien", t => t.MaNhanVien)
                .Index(t => t.MaNCC)
                .Index(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.ChiTietPhieuNhap",
                c => new
                    {
                        MaCTPN = c.String(nullable: false, maxLength: 50),
                        SoLuong = c.Int(nullable: false),
                        GiaNhap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaPhieuNhap = c.String(maxLength: 50),
                        MaSanPham = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaCTPN)
                .ForeignKey("dbo.PhieuNhap", t => t.MaPhieuNhap)
                .ForeignKey("dbo.SanPham", t => t.MaSanPham)
                .Index(t => t.MaPhieuNhap)
                .Index(t => t.MaSanPham);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSanPham = c.String(nullable: false, maxLength: 50),
                        TenSanPham = c.String(nullable: false, maxLength: 200),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SoLuongTon = c.Int(nullable: false),
                        DonViTinh = c.String(maxLength: 50),
                        MaDanhMuc = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaSanPham)
                .ForeignKey("dbo.DanhMuc", t => t.MaDanhMuc)
                .Index(t => t.MaDanhMuc);
            
            CreateTable(
                "dbo.DanhMuc",
                c => new
                    {
                        MaDanhMuc = c.String(nullable: false, maxLength: 50),
                        TenDanhMuc = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.MaDanhMuc);
            
            CreateTable(
                "dbo.NhaCungCap",
                c => new
                    {
                        MaNCC = c.String(nullable: false, maxLength: 50),
                        TenNCC = c.String(nullable: false, maxLength: 100),
                        SDT = c.String(maxLength: 20),
                        DiaChi = c.String(maxLength: 255),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaNCC);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        TenDangNhap = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(nullable: false, maxLength: 255),
                        VaiTro = c.String(maxLength: 50),
                        MaNhanVien = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.TenDangNhap)
                .ForeignKey("dbo.NhanVien", t => t.MaNhanVien)
                .Index(t => t.MaNhanVien);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaiKhoan", "MaNhanVien", "dbo.NhanVien");
            DropForeignKey("dbo.PhieuNhap", "MaNhanVien", "dbo.NhanVien");
            DropForeignKey("dbo.PhieuNhap", "MaNCC", "dbo.NhaCungCap");
            DropForeignKey("dbo.SanPham", "MaDanhMuc", "dbo.DanhMuc");
            DropForeignKey("dbo.ChiTietPhieuNhap", "MaSanPham", "dbo.SanPham");
            DropForeignKey("dbo.ChiTietHoaDon", "MaSanPham", "dbo.SanPham");
            DropForeignKey("dbo.ChiTietPhieuNhap", "MaPhieuNhap", "dbo.PhieuNhap");
            DropForeignKey("dbo.HoaDon", "MaNhanVien", "dbo.NhanVien");
            DropForeignKey("dbo.HoaDon", "MaKhachHang", "dbo.KhachHang");
            DropForeignKey("dbo.ChiTietHoaDon", "MaHoaDon", "dbo.HoaDon");
            DropIndex("dbo.TaiKhoan", new[] { "MaNhanVien" });
            DropIndex("dbo.SanPham", new[] { "MaDanhMuc" });
            DropIndex("dbo.ChiTietPhieuNhap", new[] { "MaSanPham" });
            DropIndex("dbo.ChiTietPhieuNhap", new[] { "MaPhieuNhap" });
            DropIndex("dbo.PhieuNhap", new[] { "MaNhanVien" });
            DropIndex("dbo.PhieuNhap", new[] { "MaNCC" });
            DropIndex("dbo.HoaDon", new[] { "MaNhanVien" });
            DropIndex("dbo.HoaDon", new[] { "MaKhachHang" });
            DropIndex("dbo.ChiTietHoaDon", new[] { "MaSanPham" });
            DropIndex("dbo.ChiTietHoaDon", new[] { "MaHoaDon" });
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.NhaCungCap");
            DropTable("dbo.DanhMuc");
            DropTable("dbo.SanPham");
            DropTable("dbo.ChiTietPhieuNhap");
            DropTable("dbo.PhieuNhap");
            DropTable("dbo.NhanVien");
            DropTable("dbo.KhachHang");
            DropTable("dbo.HoaDon");
            DropTable("dbo.ChiTietHoaDon");
        }
    }
}
