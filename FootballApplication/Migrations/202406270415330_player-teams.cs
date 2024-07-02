namespace FootballApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerteams : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "TeamID", c => c.Int(nullable: false));
            CreateIndex("dbo.Players", "TeamID");
            AddForeignKey("dbo.Players", "TeamID", "dbo.Teams", "TeamID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamID", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamID" });
            DropColumn("dbo.Players", "TeamID");
        }
    }
}
