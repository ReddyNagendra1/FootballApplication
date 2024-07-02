namespace FootballApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class players : DbMigration
    {
        public static object[] TeamID { get; internal set; }

        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                        PlayerPosition = c.String(),
                    })
                .PrimaryKey(t => t.PlayerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
        }
    }
}
