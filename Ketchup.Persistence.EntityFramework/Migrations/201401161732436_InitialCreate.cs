// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201401161732436_InitialCreate.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Persistence.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// Model creation migration.
    /// </summary>
    public partial class InitialCreate : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
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
            
            this.CreateTable(
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
            
            this.CreateTable(
                "ketchup.Baskets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            this.CreateTable(
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
            
            this.CreateTable(
                "ketchup.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            this.CreateTable(
                "ketchup.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ketchup.ProductCategories", t => t.ProductCategory_Id)
                .Index(t => t.ProductCategory_Id);
            
            this.CreateTable(
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
            
            this.CreateTable(
                "ketchup.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        ParentCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ketchup.ProductCategories", t => t.ParentCategory_Id)
                .ForeignKey("ketchup.ProductCategorySpecifications", t => t.Id, cascadeDelete: true)
                .Index(t => t.ParentCategory_Id)
                .Index(t => t.Id);
            
            this.CreateTable(
                "ketchup.ProductCategorySpecifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            this.CreateTable(
                "ketchup.ProductCategorySpecificationAttributes",
                c => new
                    {
                        ProductAttributeTypeId = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        ProductCategorySpecification_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.ProductAttributeTypeId, t.ProductCategoryId })
                .ForeignKey("ketchup.ProductAttributeTypes", t => t.ProductAttributeTypeId, cascadeDelete: true)
                .ForeignKey("ketchup.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .ForeignKey("ketchup.ProductCategorySpecifications", t => t.ProductCategorySpecification_Id)
                .Index(t => t.ProductAttributeTypeId)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.ProductCategorySpecification_Id);
            
            this.CreateTable(
                "ketchup.ProductAttributeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayName = c.String(),
                        ValidationRegularExpression = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            this.CreateTable(
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
            
            this.CreateTable(
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

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("ketchup.BasketProducts", "ProductId", "ketchup.Products");
            this.DropForeignKey("ketchup.Images", new[] { "ProductSpecification_ProductId", "ProductSpecification_ActiveFrom", "ProductSpecification_ActiveUntil" }, "ketchup.ProductSpecifications");
            this.DropForeignKey("ketchup.ProductSpecifications", "ProductId", "ketchup.Products");
            this.DropForeignKey("ketchup.ProductSpecifications", "Category_Id", "ketchup.ProductCategories");
            this.DropForeignKey("ketchup.ProductCategories", "Id", "ketchup.ProductCategorySpecifications");
            this.DropForeignKey("ketchup.ProductCategorySpecificationAttributes", "ProductCategorySpecification_Id", "ketchup.ProductCategorySpecifications");
            this.DropForeignKey("ketchup.ProductCategorySpecificationAttributes", "ProductCategoryId", "ketchup.ProductCategories");
            this.DropForeignKey("ketchup.ProductCategorySpecificationAttributes", "ProductAttributeTypeId", "ketchup.ProductAttributeTypes");
            this.DropForeignKey("ketchup.ProductAttributes", new[] { "ProductId", "AttributeActiveFrom", "AttributeActiveUntil" }, "ketchup.ProductSpecifications");
            this.DropForeignKey("ketchup.ProductAttributes", "AttributeTypeId", "ketchup.ProductAttributeTypes");
            this.DropForeignKey("ketchup.Products", "ProductCategory_Id", "ketchup.ProductCategories");
            this.DropForeignKey("ketchup.ProductCategories", "ParentCategory_Id", "ketchup.ProductCategories");
            this.DropForeignKey("ketchup.BasketProducts", "BasketId", "ketchup.Baskets");
            this.DropForeignKey("ketchup.Orders", "ShippingAddress_Id", "ketchup.Addresses");
            this.DropForeignKey("ketchup.Orders", "CustomerId", "ketchup.Customers");
            this.DropForeignKey("ketchup.Addresses", "Customer_Id", "ketchup.Customers");
            this.DropForeignKey("ketchup.Orders", "BasketId", "ketchup.Baskets");
            this.DropIndex("ketchup.BasketProducts", new[] { "ProductId" });
            this.DropIndex("ketchup.Images", new[] { "ProductSpecification_ProductId", "ProductSpecification_ActiveFrom", "ProductSpecification_ActiveUntil" });
            this.DropIndex("ketchup.ProductSpecifications", new[] { "ProductId" });
            this.DropIndex("ketchup.ProductSpecifications", new[] { "Category_Id" });
            this.DropIndex("ketchup.ProductCategories", new[] { "Id" });
            this.DropIndex("ketchup.ProductCategorySpecificationAttributes", new[] { "ProductCategorySpecification_Id" });
            this.DropIndex("ketchup.ProductCategorySpecificationAttributes", new[] { "ProductCategoryId" });
            this.DropIndex("ketchup.ProductCategorySpecificationAttributes", new[] { "ProductAttributeTypeId" });
            this.DropIndex("ketchup.ProductAttributes", new[] { "ProductId", "AttributeActiveFrom", "AttributeActiveUntil" });
            this.DropIndex("ketchup.ProductAttributes", new[] { "AttributeTypeId" });
            this.DropIndex("ketchup.Products", new[] { "ProductCategory_Id" });
            this.DropIndex("ketchup.ProductCategories", new[] { "ParentCategory_Id" });
            this.DropIndex("ketchup.BasketProducts", new[] { "BasketId" });
            this.DropIndex("ketchup.Orders", new[] { "ShippingAddress_Id" });
            this.DropIndex("ketchup.Orders", new[] { "CustomerId" });
            this.DropIndex("ketchup.Addresses", new[] { "Customer_Id" });
            this.DropIndex("ketchup.Orders", new[] { "BasketId" });
            this.DropTable("ketchup.Images");
            this.DropTable("ketchup.ProductAttributes");
            this.DropTable("ketchup.ProductAttributeTypes");
            this.DropTable("ketchup.ProductCategorySpecificationAttributes");
            this.DropTable("ketchup.ProductCategorySpecifications");
            this.DropTable("ketchup.ProductCategories");
            this.DropTable("ketchup.ProductSpecifications");
            this.DropTable("ketchup.Products");
            this.DropTable("ketchup.Customers");
            this.DropTable("ketchup.Orders");
            this.DropTable("ketchup.Baskets");
            this.DropTable("ketchup.BasketProducts");
            this.DropTable("ketchup.Addresses");
        }
    }
}
