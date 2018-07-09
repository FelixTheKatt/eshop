namespace MaXimusPOP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Customers", new[] { "Role_RoleId" });
            RenameColumn(table: "dbo.Customers", name: "Role_RoleId", newName: "RoleId");
            AddColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "RoleId");
            AddForeignKey("dbo.Customers", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "RoleId", "dbo.Roles");
            DropIndex("dbo.Customers", new[] { "RoleId" });
            AlterColumn("dbo.Customers", "RoleId", c => c.Int());
            DropColumn("dbo.Customers", "Password");
            RenameColumn(table: "dbo.Customers", name: "RoleId", newName: "Role_RoleId");
            CreateIndex("dbo.Customers", "Role_RoleId");
            AddForeignKey("dbo.Customers", "Role_RoleId", "dbo.Roles", "RoleId");
        }
    }
}
