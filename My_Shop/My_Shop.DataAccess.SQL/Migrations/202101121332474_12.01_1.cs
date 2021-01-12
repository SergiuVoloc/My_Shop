namespace My_Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1201_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WishLists", "WishListId", c => c.String(maxLength: 128));
            AlterColumn("dbo.WishLists", "Quantity", c => c.Int(nullable: false));
            CreateIndex("dbo.WishLists", "WishListId");
            AddForeignKey("dbo.WishLists", "WishListId", "dbo.WishLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "WishListId", "dbo.WishLists");
            DropIndex("dbo.WishLists", new[] { "WishListId" });
            AlterColumn("dbo.WishLists", "Quantity", c => c.String());
            DropColumn("dbo.WishLists", "WishListId");
        }
    }
}
