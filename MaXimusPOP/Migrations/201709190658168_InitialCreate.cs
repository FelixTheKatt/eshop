namespace MaXimusPOP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategorieId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategorieId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Int(nullable: false),
                        type = c.String(),
                        Price = c.Int(nullable: false),
                        Alias = c.String(),
                        Statut = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Commands",
                c => new
                    {
                        CommandId = c.Int(nullable: false, identity: true),
                        CommandName = c.String(),
                        CommandDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Customer_CustomerId = c.Int(),
                        Payement_PayementId = c.Int(),
                    })
                .PrimaryKey(t => t.CommandId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.Payements", t => t.Payement_PayementId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Payement_PayementId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Ville = c.String(),
                        Rue = c.String(),
                        Pays = c.String(),
                        Province = c.String(),
                        NumeroRue = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Payements",
                c => new
                    {
                        PayementId = c.Int(nullable: false, identity: true),
                        Operation = c.String(),
                        ModeDepaiment_ModeDePaimentId = c.Int(),
                    })
                .PrimaryKey(t => t.PayementId)
                .ForeignKey("dbo.ModeDePaiments", t => t.ModeDepaiment_ModeDePaimentId)
                .Index(t => t.ModeDepaiment_ModeDePaimentId);
            
            CreateTable(
                "dbo.ModeDePaiments",
                c => new
                    {
                        ModeDePaimentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ModeDePaimentId);
            
            CreateTable(
                "dbo.Depots",
                c => new
                    {
                        DepotID = c.Int(nullable: false, identity: true),
                        Quantite = c.Int(nullable: false),
                        lieu = c.String(),
                    })
                .PrimaryKey(t => t.DepotID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Categorie_CategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Categorie_CategorieId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Categorie_CategorieId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Categorie_CategorieId);
            
            CreateTable(
                "dbo.CommandProducts",
                c => new
                    {
                        Command_CommandId = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Command_CommandId, t.Product_ProductId })
                .ForeignKey("dbo.Commands", t => t.Command_CommandId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Command_CommandId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.DepotProducts",
                c => new
                    {
                        Depot_DepotID = c.Int(nullable: false),
                        Product_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Depot_DepotID, t.Product_ProductId })
                .ForeignKey("dbo.Depots", t => t.Depot_DepotID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Depot_DepotID)
                .Index(t => t.Product_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepotProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.DepotProducts", "Depot_DepotID", "dbo.Depots");
            DropForeignKey("dbo.CommandProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.CommandProducts", "Command_CommandId", "dbo.Commands");
            DropForeignKey("dbo.Payements", "ModeDepaiment_ModeDePaimentId", "dbo.ModeDePaiments");
            DropForeignKey("dbo.Commands", "Payement_PayementId", "dbo.Payements");
            DropForeignKey("dbo.Customers", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Commands", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.ProductCategories", "Categorie_CategorieId", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.DepotProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.DepotProducts", new[] { "Depot_DepotID" });
            DropIndex("dbo.CommandProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.CommandProducts", new[] { "Command_CommandId" });
            DropIndex("dbo.ProductCategories", new[] { "Categorie_CategorieId" });
            DropIndex("dbo.ProductCategories", new[] { "Product_ProductId" });
            DropIndex("dbo.Payements", new[] { "ModeDepaiment_ModeDePaimentId" });
            DropIndex("dbo.Customers", new[] { "Role_RoleId" });
            DropIndex("dbo.Commands", new[] { "Payement_PayementId" });
            DropIndex("dbo.Commands", new[] { "Customer_CustomerId" });
            DropTable("dbo.DepotProducts");
            DropTable("dbo.CommandProducts");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Depots");
            DropTable("dbo.ModeDePaiments");
            DropTable("dbo.Payements");
            DropTable("dbo.Roles");
            DropTable("dbo.Customers");
            DropTable("dbo.Commands");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
