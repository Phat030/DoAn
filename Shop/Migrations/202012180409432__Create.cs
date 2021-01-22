namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        IDCart = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IDCart);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IDCategory = c.Int(nullable: false, identity: true),
                        NameCate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDCategory);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IDProduct = c.Int(nullable: false, identity: true),
                        NameProduct = c.String(nullable: false),
                        IDCategory = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        Image = c.String(nullable: false),
                        Available = c.String(nullable: false),
                        ProductDate = c.DateTime(nullable: false),
                        Descriptions = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDProduct)
                .ForeignKey("dbo.Categories", t => t.IDCategory, cascadeDelete: true)
                .Index(t => t.IDCategory);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        IDOrderDetail = c.Int(nullable: false, identity: true),
                        QuantitySale = c.Int(nullable: false),
                        UnitPriceSale = c.Double(nullable: false),
                        IDOrder = c.Int(nullable: false),
                        IDProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDOrderDetail)
                .ForeignKey("dbo.Orders", t => t.IDOrder, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.IDProduct, cascadeDelete: true)
                .Index(t => t.IDOrder)
                .Index(t => t.IDProduct);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        IDOrder = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        AddressDelivery = c.String(nullable: false),
                        PhoneCus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDOrder);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IDUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        LoginErrorMessage = c.String(),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "IDProduct", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "IDOrder", "dbo.Orders");
            DropForeignKey("dbo.Products", "IDCategory", "dbo.Categories");
            DropIndex("dbo.OrderDetails", new[] { "IDProduct" });
            DropIndex("dbo.OrderDetails", new[] { "IDOrder" });
            DropIndex("dbo.Products", new[] { "IDCategory" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Carts");
        }
    }
}
