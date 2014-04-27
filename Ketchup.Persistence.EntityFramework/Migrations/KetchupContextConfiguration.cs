// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KetchupContextConfiguration.cs" company="James Dibble">
//    Copyright 2012 James Dibble
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Ketchup.Persistence.EntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// The Entity Framework Migrations configuration.
    /// </summary>
    public class KetchupContextConfiguration : DbMigrationsConfiguration<KetchupContext>
    {
        private readonly bool _shouldSeed;

        /// <summary>
        /// Initialises a new instance of the <see cref="KetchupContextConfiguration"/> class.
        /// </summary>
        public KetchupContextConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;

            var migrator = new DbMigrator(this);

            this._shouldSeed = migrator.GetPendingMigrations().Any();
        }

        /// <summary>
        /// Gets a value indicating whether any migrations were present.
        /// </summary>
        protected bool ShouldSeed
        {
            get
            {
                return this._shouldSeed;
            }
        }
    }

    /// <summary>
    /// The Entity Framework Migrations configuration.
    /// </summary>
    /// <typeparam name="TSeeder">
    /// The class to create to invoke seed methods from.
    /// </typeparam>
    public class KetchupContextConfiguration<TSeeder> : KetchupContextConfiguration where TSeeder : IKetchupSeeder, new()
    {
        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data. </param>
        protected override void Seed(KetchupContext context)
        {
            if (!this.ShouldSeed)
            {
                return;
            }

            var seeder = new TSeeder();

            foreach (var seedMethod in seeder.SeedMethods)
            {
                seedMethod.Invoke(context);
            }
        }
    }
}
