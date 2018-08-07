namespace AtmoreChamberPinnacle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class devmigration2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductType = c.String(nullable: false),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        imgSource = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
    }
}
