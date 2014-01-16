// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KetchupContextConfiguration.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Persistence.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// The Entity Framework Migrations configuration.
    /// </summary>
    public class KetchupContextConfiguration<TSeeder> : DbMigrationsConfiguration<KetchupContext> where TSeeder : IKetchupSeeder, new()
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="KetchupContextConfiguration"/> class.
        /// </summary>
        public KetchupContextConfiguration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data. </param>
        protected override void Seed(KetchupContext context)
        {
            if (!this.ShouldSeed())
            {
                return;
            }

            var seeder = new TSeeder();

            foreach (var seedMethod in seeder.SeedMethods)
            {
                seedMethod.Invoke(context);
            }
        }

        protected bool ShouldSeed()
        {
            var migrator = new DbMigrator(this);

            return !migrator.GetPendingMigrations().Any();
        }
    }
}
