namespace My_Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20jun2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAddresses", "CustomerId", c => c.String());
            AlterColumn("dbo.Orders", "ShippingCost", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerAddresses", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerAddresses", "UserId", c => c.String());
            AlterColumn("dbo.Orders", "ShippingCost", c => c.String());
            DropColumn("dbo.CustomerAddresses", "CustomerId");
        }
    }
}
