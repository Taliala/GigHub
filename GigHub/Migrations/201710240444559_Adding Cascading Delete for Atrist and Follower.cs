namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCascadingDeleteforAtristandFollower : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "FollowerId" });
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        ArtistId = c.Int(nullable: false),
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        Artist_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ArtistId, t.FollowerId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id)
                .Index(t => t.FollowerId)
                .Index(t => t.Artist_Id);
            
            DropTable("dbo.Follows");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        AtristId = c.Int(nullable: false),
                        FollowerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AtristId, t.FollowerId });
            
            DropForeignKey("dbo.Followings", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "Artist_Id" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropTable("dbo.Followings");
            CreateIndex("dbo.Follows", "FollowerId");
            AddForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
