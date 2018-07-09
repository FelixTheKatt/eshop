namespace MaXimusPOP.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MaXimusPOP.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MaXimusPOP.Models.Capsule>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MaXimusPOP.Models.Capsule";
        }

        protected override void Seed(MaXimusPOP.Models.Capsule context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            Product p = new Product { ProductId = 1, Name = "TimesCaps", Price = 200000, Alias = "T-1", Weight = 50, Description = "Time is the cruelest cut.", Statut = "Prototype" };
            context.Products.Add(p);
            context.SaveChanges();
        }
    }
}
