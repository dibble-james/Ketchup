namespace EntityFrameworkInit.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkInit.SampleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EntityFrameworkInit.SampleContext context)
        {
            foreach (var seedMethod in new Seeder().SeedMethods)
            {
                seedMethod.Invoke(context);
            }
        }
    }
}
