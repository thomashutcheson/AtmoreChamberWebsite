namespace AtmoreChamber.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class fullcalendarmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        ThemeColor = c.Int(nullable: false),
                        IsFullDay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);  
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
