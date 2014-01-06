// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KetchupConfiguration.cs" company="James Dibble">
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
    public class KetchupConfiguration : DbMigrationsConfiguration<KetchupContext>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="KetchupConfiguration"/> class.
        /// </summary>
        public KetchupConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data. </param>
        protected override void Seed(KetchupContext context)
        {
            var migrator = new DbMigrator(this);

            if (migrator.GetPendingMigrations().Any())
            {
                return;
            }
        }
    }
}
