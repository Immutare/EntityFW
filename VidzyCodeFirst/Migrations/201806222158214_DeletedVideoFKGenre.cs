namespace VidzyCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedVideoFKGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VideoGenres", "Video_Id", "dbo.Videos");
            DropForeignKey("dbo.VideoGenres", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.VideoGenres", new[] { "Video_Id" });
            DropIndex("dbo.VideoGenres", new[] { "Genre_Id" });
            AddColumn("dbo.Genres", "Video_Id", c => c.Int());
            CreateIndex("dbo.Genres", "Vi" +
                "deo_Id");
            AddForeignKey("dbo.Genres", "Video_Id", "dbo.Videos", "Id");
            DropTable("dbo.VideoGenres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VideoGenres",
                c => new
                    {
                        Video_Id = c.Int(nullable: false),
                        Genre_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Video_Id, t.Genre_Id });
            
            DropForeignKey("dbo.Genres", "Video_Id", "dbo.Videos");
            DropIndex("dbo.Genres", new[] { "Video_Id" });
            DropColumn("dbo.Genres", "Video_Id");
            CreateIndex("dbo.VideoGenres", "Genre_Id");
            CreateIndex("dbo.VideoGenres", "Video_Id");
            AddForeignKey("dbo.VideoGenres", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VideoGenres", "Video_Id", "dbo.Videos", "Id", cascadeDelete: true);
        }
    }
}
