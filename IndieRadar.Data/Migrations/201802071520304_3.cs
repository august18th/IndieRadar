namespace IndieRadar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameGenres", "GenreName", "dbo.Genres");
            DropIndex("dbo.GameGenres", new[] { "GenreName" });
            RenameColumn(table: "dbo.GameGenres", name: "GenreName", newName: "Genre_GenreName");
            DropPrimaryKey("dbo.GameGenres");
            AddColumn("dbo.GameGenres", "GenreId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.GameGenres", "Genre_GenreName", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.GameGenres", new[] { "GameId", "GenreId" });
            CreateIndex("dbo.GameGenres", "Genre_GenreName");
            AddForeignKey("dbo.GameGenres", "Genre_GenreName", "dbo.Genres", "GenreName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameGenres", "Genre_GenreName", "dbo.Genres");
            DropIndex("dbo.GameGenres", new[] { "Genre_GenreName" });
            DropPrimaryKey("dbo.GameGenres");
            AlterColumn("dbo.GameGenres", "Genre_GenreName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.GameGenres", "GenreId");
            AddPrimaryKey("dbo.GameGenres", new[] { "GameId", "GenreName" });
            RenameColumn(table: "dbo.GameGenres", name: "Genre_GenreName", newName: "GenreName");
            CreateIndex("dbo.GameGenres", "GenreName");
            AddForeignKey("dbo.GameGenres", "GenreName", "dbo.Genres", "GenreName", cascadeDelete: true);
        }
    }
}
