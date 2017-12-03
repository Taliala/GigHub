namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bugfixes : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Followings", name: "Artist_Id", newName: "FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_Artist_Id", newName: "IX_FolloweeId");
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FollowerId", "FolloweeId" });
            DropColumn("dbo.Followings", "ArtistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Followings", "ArtistId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "ArtistId", "FollowerId" });
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "Artist_Id");
        }
    }
}
