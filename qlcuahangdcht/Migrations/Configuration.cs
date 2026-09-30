namespace qlcuahangdcht.Migrations
{
    using qlcuahangdcht.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<qlcuahangdcht.CuaHangDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(qlcuahangdcht.CuaHangDbContext context)
        {
            // Lệnh AddOrUpdate sẽ kiểm tra: Nếu chưa có thì Thêm mới, nếu có rồi thì Cập nhật
            // Tham số đầu tiên (vd: d => d.MaDanhMuc) là chỉ định Khóa chính để nó so sánh

            // 1. Gieo dữ liệu BẢNG DANH MỤC
            context.DanhMucs.AddOrUpdate(
                d => d.MaDanhMuc,
                new DanhMuc { MaDanhMuc = "DM01", TenDanhMuc = "Bút các loại" },
                new DanhMuc { MaDanhMuc = "DM02", TenDanhMuc = "Sổ tay - Giấy in" },
                new DanhMuc { MaDanhMuc = "DM03", TenDanhMuc = "Dụng cụ vẽ & Mỹ thuật" },
                new DanhMuc { MaDanhMuc = "DM04", TenDanhMuc = "Balo - Cặp xách" }
            );

            // 2. Gieo dữ liệu BẢNG SẢN PHẨM (Nhớ dùng đúng MaDanhMuc ở trên)
            context.SanPhams.AddOrUpdate(
                s => s.MaSanPham,
                new SanPham { MaSanPham = "SP001", TenSanPham = "Bút bi xanh Thiên Long", MaDanhMuc = "DM01", DonGia = 5000, SoLuongTon = 100 },
                new SanPham { MaSanPham = "SP002", TenSanPham = "Sổ còng caro A5", MaDanhMuc = "DM02", DonGia = 25000, SoLuongTon = 50 },
                new SanPham { MaSanPham = "SP003", TenSanPham = "Tẩy Pentel siêu sạch", MaDanhMuc = "DM03", DonGia = 12000, SoLuongTon = 200 }
            );

            // 3. Gieo dữ liệu BẢNG NHÂN VIÊN
            context.NhanViens.AddOrUpdate(
                n => n.MaNhanVien,
                new NhanVien { MaNhanVien = "NV01", HoTen = "Nguyễn Đăng Khôi" }, // Dành cho Admin
                new NhanVien { MaNhanVien = "NV02", HoTen = "Nguyễn Văn Lộc" }     // Dành cho Nhân viên bán hàng
            );

            // 4. Gieo dữ liệu BẢNG TÀI KHOẢN (Liên kết với Mã nhân viên ở trên)
            context.TaiKhoans.AddOrUpdate(
                t => t.TenDangNhap,
                new TaiKhoan { TenDangNhap = "khoi", MatKhau = "123456", VaiTro = "Admin", MaNhanVien = "NV01" },
                new TaiKhoan { TenDangNhap = "loc", MatKhau = "12345", VaiTro = "NhanVien", MaNhanVien = "NV02" }
            );

            // 5. Gieo dữ liệu BẢNG KHÁCH HÀNG (Tạo sẵn 1 khách mặc định để bán lẻ)
            context.KhachHangs.AddOrUpdate(
                k => k.MaKhachHang,
                new KhachHang { MaKhachHang = "KH00", HoTen = "Khách vãng lai", SDT = "0000000000" }
            );
        }
    }
}

