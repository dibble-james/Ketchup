namespace EntityFrameworkInit
{
    using System;

    using JamesDibble.ApplicationFramework.Data.Persistence.EntityFrameworkCodeFirst;

    using Ketchup;
    using Ketchup.Persistence.EntityFramework;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new SampleContextFactory().Create();
            
            var ketchup =
                KetchupBuilder
                    .Configure(() => new EntityFrameworkPersistenceManager(context))
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
