namespace EntityFrameworkInit
{
    using System;

    using JamesDibble.ApplicationFramework.Data.Persistence.EntityFrameworkCodeFirst;

    using Ketchup;
    using Ketchup.Persistence.EntityFramework;
    using Ketchup.Persistence.EntityFramework.Migrations;

    class Program
    {
        static void Main(string[] args)
        {
            var ketchupContext = KetchupInitialiser.Initialise<KetchupInitialiser, KetchupContextConfiguration<Seeder>, Seeder>();

            var ketchup =
                KetchupBuilder
                    .Configure(() => new EntityFrameworkPersistenceManager(ketchupContext))
                    .AsProductManager()
                    .Build();

            var categories = ketchup.Products.GetProductCategories();

            foreach (var productCategory in categories)
            {
                Console.WriteLine("Category: {0}", productCategory.Name);

                foreach (var attribute in productCategory.Specification)
                {
                    Console.WriteLine(attribute.Attribute.Name);
                }
            }

            Console.ReadLine();
        }
    }
}
