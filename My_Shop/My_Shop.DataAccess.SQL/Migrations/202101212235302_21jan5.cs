namespace My_Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21jan5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.WishLists", new[] { "WishListId" });
            CreateTable(
                "dbo.WishListItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        WishListId = c.String(maxLength: 128),
                        ProductId = c.String(maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.WishListId)
                .Index(t => t.ProductId);
            
            DropColumn("dbo.WishLists", "WishListId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WishLists", "WishListId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.WishListItems", "ProductId", "dbo.Products");
            DropIndex("dbo.WishListItems", new[] { "ProductId" });
            DropIndex("dbo.WishListItems", new[] { "WishListId" });
            DropTable("dbo.WishListItems");
            CreateIndex("dbo.WishLists", "WishListId");
        }
    }
}
