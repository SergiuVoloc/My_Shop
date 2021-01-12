namespace My_Shop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _100121 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BasketId = c.String(maxLength: 128),
                        ProductId = c.String(maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.BasketId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.BasketId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Showroom = c.String(),
                        CompanyId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        IBAN = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Couriers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CompanyId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Status = c.String(),
                        CompanyId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        CustomerAddressId = c.String(maxLength: 128),
                        BasketId = c.String(maxLength: 128),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Baskets", t => t.BasketId)
                .ForeignKey("dbo.CustomerAddresses", t => t.CustomerAddressId)
                .Index(t => t.CustomerAddressId)
                .Index(t => t.BasketId);
            
            CreateTable(
                "dbo.CustomerAddresses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderId = c.String(maxLength: 128),
                        ProductId = c.String(maxLength: 128),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        OrderStatus = c.String(),
                        ShippingCost = c.String(),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Quantity = c.String(),
                        ProductId = c.String(maxLength: 128),
                        CustomerId = c.String(maxLength: 128),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId);
            
            AddColumn("dbo.Products", "Specifications", c => c.String());
            AddColumn("dbo.Products", "Stock", c => c.String());
            AddColumn("dbo.Products", "CategoryId", c => c.String());
            AddColumn("dbo.Products", "SupplierId", c => c.String(maxLength: 128));
            AddColumn("dbo.Products", "StoreId", c => c.String(maxLength: 128));
            AddColumn("dbo.Products", "ProductCategory_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Products", "SupplierId");
            CreateIndex("dbo.Products", "StoreId");
            CreateIndex("dbo.Products", "ProductCategory_Id");
            AddForeignKey("dbo.Products", "ProductCategory_Id", "dbo.ProductCategories", "Id");
            AddForeignKey("dbo.Products", "StoreId", "dbo.Stores", "Id");
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "ProductId", "dbo.Products");
            DropForeignKey("dbo.WishLists", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Customers", "CustomerAddressId", "dbo.CustomerAddresses");
            DropForeignKey("dbo.Customers", "BasketId", "dbo.Baskets");
            DropForeignKey("dbo.BasketItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Suppliers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Stores", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Couriers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Products", "ProductCategory_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.WishLists", new[] { "CustomerId" });
            DropIndex("dbo.WishLists", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Customers", new[] { "BasketId" });
            DropIndex("dbo.Customers", new[] { "CustomerAddressId" });
            DropIndex("dbo.Suppliers", new[] { "CompanyId" });
            DropIndex("dbo.Couriers", new[] { "CompanyId" });
            DropIndex("dbo.Stores", new[] { "CompanyId" });
            DropIndex("dbo.Products", new[] { "ProductCategory_Id" });
            DropIndex("dbo.Products", new[] { "StoreId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.BasketItems", new[] { "ProductId" });
            DropIndex("dbo.BasketItems", new[] { "BasketId" });
            DropColumn("dbo.Products", "ProductCategory_Id");
            DropColumn("dbo.Products", "StoreId");
            DropColumn("dbo.Products", "SupplierId");
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "Stock");
            DropColumn("dbo.Products", "Specifications");
            DropTable("dbo.WishLists");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.CustomerAddresses");
            DropTable("dbo.Customers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Couriers");
            DropTable("dbo.Companies");
            DropTable("dbo.Stores");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketItems");
        }
    }
}
