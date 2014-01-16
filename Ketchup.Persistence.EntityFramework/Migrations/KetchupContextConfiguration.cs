// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KetchupContextConfiguration.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Persistence.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class KetchupContextConfiguration : DbMigrationsConfiguration<KetchupContext>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="KetchupContextConfiguration{TSeeder}"/> class.
        /// </summary>
        public KetchupContextConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected bool ShouldSeed()
        {
            var migrator = new DbMigrator(this);

            return migrator.GetPendingMigrations().Any();
        }
    }

    /// <summary>
    /// The Entity Framework Migrations configuration.
    /// </summary>
    public class KetchupContextConfiguration<TSeeder> : KetchupContextConfiguration where TSeeder : IKetchupSeeder, new()
    {
        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data. </param>
        protected override void Seed(KetchupContext context)
        {
            var seeder = new TSeeder();

            foreach (var seedMethod in seeder.SeedMethods)
            {
                seedMethod.Invoke(context);
            }
        }
    }
}
