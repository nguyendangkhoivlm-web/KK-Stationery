namespace qlcuahangdcht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemCotTongTien : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhieuNhap", "TongTien", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhieuNhap", "TongTien");
        }
    }
}
