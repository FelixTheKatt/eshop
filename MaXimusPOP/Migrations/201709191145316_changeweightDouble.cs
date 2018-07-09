namespace MaXimusPOP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeweightDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Weight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Weight", c => c.Int(nullable: false));
        }
    }
}
