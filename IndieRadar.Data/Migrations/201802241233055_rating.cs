namespace IndieRadar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRatings",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.UserId })
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.UserId);
            
            DropColumn("dbo.Games", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Rating", c => c.Double());
            DropForeignKey("dbo.UserRatings", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserRatings", "GameId", "dbo.Games");
            DropIndex("dbo.UserRatings", new[] { "UserId" });
            DropIndex("dbo.UserRatings", new[] { "GameId" });
            DropTable("dbo.UserRatings");
        }
    }
}
