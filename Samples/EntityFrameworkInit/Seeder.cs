﻿namespace EntityFrameworkInit
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Ketchup.Model.Product;
    using Ketchup.Persistence.EntityFramework;

    class Seeder : IKetchupSeeder
    {
        /// <summary>
        /// Gets the methods to invoke to seed the <see cref="KetchupContext"/>.
        /// </summary>
        public IEnumerable<Action<KetchupContext>> SeedMethods
        {
            get
            {
                return new List<Action<KetchupContext>> { Seeder.AddProductAttributeTypes, Seeder.AddProductCategory };
            }
        }

        public static void AddProductAttributeTypes(KetchupContext context)
        {
            context.ProductAttributeTypes.AddOrUpdate(new ProductAttributeType
            {
                Name = "Price",
                DisplayName = "Product Price",
                ValidationRegularExpression = @"^\d+[.]{1}(\d){2}$"
            });

            context.ProductAttributeTypes.AddOrUpdate(new ProductAttributeType
            {
                Name = "Name",
                DisplayName = "Product Name",
                ValidationRegularExpression = @"^$"
            });

            context.SaveChanges();
        }

        public static void AddProductCategory(KetchupContext context)
        {
            var price = context.ProductAttributeTypes.First(pat => pat.Name == "Price");
            var name = context.ProductAttributeTypes.First(pat => pat.Name == "Name");

            var category = new ProductCategory 
            { 
                Name = "Default Product Category"
            };

            context.ProductCategorys.AddOrUpdate(pc => pc.Name, category);

            var specifications = new []
            {
                new ProductCategorySpecificationAttribute
                {
                    Attribute = price, 
                    ProductCategory = category,
                    ProductAttributeTypeId = price.Id,
                    ProductCategoryId = category.Id
                },
                new ProductCategorySpecificationAttribute
                {
                    Attribute = name, 
                    ProductCategory = category,
                    ProductAttributeTypeId = price.Id,
                    ProductCategoryId = category.Id
                },
            };

            context.ProductCategorySpecificationAttributes.AddOrUpdate(
                pcsa => new { pcsa.ProductAttributeTypeId, pcsa.ProductCategoryId }, 
                specifications);
        }
    }
}
