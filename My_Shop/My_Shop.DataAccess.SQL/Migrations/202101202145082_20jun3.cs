namespace My_Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20jun3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.OrderItems", "ProductName");
            DropColumn("dbo.OrderItems", "Price");
            DropColumn("dbo.OrderItems", "Image");
            DropColumn("dbo.OrderItems", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "Image", c => c.String());
            AddColumn("dbo.OrderItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderItems", "ProductName", c => c.String());
        }
    }
}
