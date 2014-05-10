namespace Ketchup.Persistence.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ketchup.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        TownCity = c.String(),
                        CountyState = c.String(),
                        Country = c.String(),
                        PostalCode = c.String(),
                        Customer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ketchup.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "ketchup.BasketProducts",
                c => new
                    {
                        BasketId = c.Guid(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BasketId, t.ProductId })
                .ForeignKey("ketchup.Baskets", t => t.BasketId, cascadeDelete: true)
                .ForeignKey("ketchup.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.BasketId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "ketchup.Baskets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ketchup.Orders",
                c => new
                    {
                        OrderDate = c.DateTime(nullable: false),
                        BasketId = c.Guid(nullable: false),
                        CustomerId = c.Guid(nullable: false),
                        OrderNumber = c.String(nullable: false),
                        ShippingAddress_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderDate, t.BasketId, t.CustomerId })
                .ForeignKey("ketchup.Baskets", t => t.BasketId, cascadeDelete: true)
                .ForeignKey("ketchup.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("ketchup.Addresses", t => t.ShippingAddress_Id, cascadeDelete: true)
                .Index(t => t.BasketId)
                .Index(t => t.CustomerId)
                .Index(t => t.ShippingAddress_Id);
            
            CreateTable(
                "ketchup.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ketchup.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ketchup.ProductCategories", t => t.ProductCategory_Id)
                .Index(t => t.ProductCategory_Id);
            
            CreateTable(
                "ketchup.ProductSpecifications",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ActiveFrom = c.DateTime(nullable: false),
                        ActiveUntil = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ActiveFrom, t.ActiveUntil })
                .ForeignKey("ketchup.ProductCategories", t => t.Category_Id)
                .ForeignKey("ketchup.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.ProductId);
            
            CreateTable(
                "ketchup.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ketchup.ProductCategories", t => t.ParentCategory_Id)
                .Index(t => t.ParentCategory_Id);
            
            CreateTable(
                "ketchup.ProductCategorySpecificationAttributes",
                c => new
                    {
                        ProductAttributeTypeId = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductAttributeTypeId, t.ProductCategoryId })
                .ForeignKey("ketchup.ProductAttributeTypes", t => t.ProductAttributeTypeId, cascadeDelete: true)
                .ForeignKey("ketchup.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.ProductAttributeTypeId)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "ketchup.ProductAttributeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        ValidationRegularExpression = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ketchup.ProductAttributes",
                c => new
                    {
                        AttributeTypeId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        AttributeActiveFrom = c.DateTime(nullable: false),
                        AttributeActiveUntil = c.DateTime(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => new { t.AttributeTypeId, t.ProductId, t.AttributeActiveFrom, t.AttributeActiveUntil })
                .ForeignKey("ketchup.ProductAttributeTypes", t => t.AttributeTypeId, cascadeDelete: true)
                .ForeignKey("ketchup.ProductSpecifications", t => new { t.ProductId, t.AttributeActiveFrom, t.AttributeActiveUntil }, cascadeDelete: true)
                .Index(t => t.AttributeTypeId)
                .Index(t => new { t.ProductId, t.AttributeActiveFrom, t.AttributeActiveUntil });
            
            CreateTable(
                "ketchup.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        ProductSpecification_ProductId = c.Int(),
                        ProductSpecification_ActiveFrom = c.DateTime(),
                        ProductSpecification_ActiveUntil = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ketchup.ProductSpecifications", t => new { t.ProductSpecification_ProductId, t.ProductSpecification_ActiveFrom, t.ProductSpecification_ActiveUntil })
                .Index(t => new { t.ProductSpecification_ProductId, t.ProductSpecification_ActiveFrom, t.ProductSpecification_ActiveUntil });
            
        }
        
        public override void Down()
        {
            DropForeignKey("ketchup.BasketProducts", "ProductId", "ketchup.Products");
            DropForeignKey("ketchup.Images", new[] { "ProductSpecification_ProductId", "ProductSpecification_ActiveFrom", "ProductSpecification_ActiveUntil" }, "ketchup.ProductSpecifications");
            DropForeignKey("ketchup.ProductSpecifications", "ProductId", "ketchup.Products");
            DropForeignKey("ketchup.ProductSpecifications", "Category_Id", "ketchup.ProductCategories");
            DropForeignKey("ketchup.ProductCategorySpecificationAttributes", "ProductCategoryId", "ketchup.ProductCategories");
            DropForeignKey("ketchup.ProductCategorySpecificationAttributes", "ProductAttributeTypeId", "ketchup.ProductAttributeTypes");
            DropForeignKey("ketchup.ProductAttributes", new[] { "ProductId", "AttributeActiveFrom", "AttributeActiveUntil" }, "ketchup.ProductSpecifications");
            DropForeignKey("ketchup.ProductAttributes", "AttributeTypeId", "ketchup.ProductAttributeTypes");
            DropForeignKey("ketchup.Products", "ProductCategory_Id", "ketchup.ProductCategories");
            DropForeignKey("ketchup.ProductCategories", "ParentCategory_Id", "ketchup.ProductCategories");
            DropForeignKey("ketchup.BasketProducts", "BasketId", "ketchup.Baskets");
            DropForeignKey("ketchup.Orders", "ShippingAddress_Id", "ketchup.Addresses");
            DropForeignKey("ketchup.Orders", "CustomerId", "ketchup.Customers");
            DropForeignKey("ketchup.Addresses", "Customer_Id", "ketchup.Customers");
            DropForeignKey("ketchup.Orders", "BasketId", "ketchup.Baskets");
            DropIndex("ketchup.BasketProducts", new[] { "ProductId" });
            DropIndex("ketchup.Images", new[] { "ProductSpecification_ProductId", "ProductSpecification_ActiveFrom", "ProductSpecification_ActiveUntil" });
            DropIndex("ketchup.ProductSpecifications", new[] { "ProductId" });
            DropIndex("ketchup.ProductSpecifications", new[] { "Category_Id" });
            DropIndex("ketchup.ProductCategorySpecificationAttributes", new[] { "ProductCategoryId" });
            DropIndex("ketchup.ProductCategorySpecificationAttributes", new[] { "ProductAttributeTypeId" });
            DropIndex("ketchup.ProductAttributes", new[] { "ProductId", "AttributeActiveFrom", "AttributeActiveUntil" });
            DropIndex("ketchup.ProductAttributes", new[] { "AttributeTypeId" });
            DropIndex("ketchup.Products", new[] { "ProductCategory_Id" });
            DropIndex("ketchup.ProductCategories", new[] { "ParentCategory_Id" });
            DropIndex("ketchup.BasketProducts", new[] { "BasketId" });
            DropIndex("ketchup.Orders", new[] { "ShippingAddress_Id" });
            DropIndex("ketchup.Orders", new[] { "CustomerId" });
            DropIndex("ketchup.Addresses", new[] { "Customer_Id" });
            DropIndex("ketchup.Orders", new[] { "BasketId" });
            DropTable("ketchup.Images");
            DropTable("ketchup.ProductAttributes");
            DropTable("ketchup.ProductAttributeTypes");
            DropTable("ketchup.ProductCategorySpecificationAttributes");
            DropTable("ketchup.ProductCategories");
            DropTable("ketchup.ProductSpecifications");
            DropTable("ketchup.Products");
            DropTable("ketchup.Customers");
            DropTable("ketchup.Orders");
            DropTable("ketchup.Baskets");
            DropTable("ketchup.BasketProducts");
            DropTable("ketchup.Addresses");
        }
    }
}
