namespace My_Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21jan3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Image", c => c.String());
            AddColumn("dbo.OrderItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrderItems", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItems", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItems", "ProductName");
            DropColumn("dbo.OrderItems", "Quantity");
            DropColumn("dbo.OrderItems", "Price");
            DropColumn("dbo.OrderItems", "Image");
        }
    }
}
