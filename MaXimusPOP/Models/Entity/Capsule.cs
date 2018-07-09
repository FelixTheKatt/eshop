namespace MaXimusPOP.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using MaXimusPOP.Models;
    public class Capsule : DbContext
    {
        public Capsule() : base("name=Capsule")
        { }

        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Command> Commands { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Depot> Depots { get; set; }
        public virtual DbSet<ModeDePaiment> ModeDepaiments { get; set; }
        public virtual DbSet<Payement> Payements { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
    }

}