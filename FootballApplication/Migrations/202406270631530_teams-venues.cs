namespace FootballApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamsvenues : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        VenueName = c.String(),
                        VenueLocation = c.String(),
                    })
                .PrimaryKey(t => t.VenueID);
            
            CreateTable(
                "dbo.VenuesTeams",
                c => new
                    {
                        Venues_VenueID = c.Int(nullable: false),
                        Teams_TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Venues_VenueID, t.Teams_TeamID })
                .ForeignKey("dbo.Venues", t => t.Venues_VenueID, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Teams_TeamID, cascadeDelete: true)
                .Index(t => t.Venues_VenueID)
                .Index(t => t.Teams_TeamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VenuesTeams", "Teams_TeamID", "dbo.Teams");
            DropForeignKey("dbo.VenuesTeams", "Venues_VenueID", "dbo.Venues");
            DropIndex("dbo.VenuesTeams", new[] { "Teams_TeamID" });
            DropIndex("dbo.VenuesTeams", new[] { "Venues_VenueID" });
            DropTable("dbo.VenuesTeams");
            DropTable("dbo.Venues");
        }
    }
}
