namespace ProjectData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "ReplyId", "dbo.Reply");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "UserId", "dbo.User");
            DropForeignKey("dbo.Post", "UserId", "dbo.User");
            DropForeignKey("dbo.Reply", "UserId", "dbo.User");
            DropIndex("dbo.Post", new[] { "ReplyId" });
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "PostId");
            AddForeignKey("dbo.Comment", "UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Post", "UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Reply", "UserId", "dbo.User", "UserId");
            DropColumn("dbo.Post", "ReplyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "ReplyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reply", "UserId", "dbo.User");
            DropForeignKey("dbo.Post", "UserId", "dbo.User");
            DropForeignKey("dbo.Comment", "UserId", "dbo.User");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            CreateIndex("dbo.Post", "ReplyId");
            AddForeignKey("dbo.Reply", "UserId", "dbo.User", "UserId", cascadeDelete: false);
            AddForeignKey("dbo.Post", "UserId", "dbo.User", "UserId", cascadeDelete: false);
            AddForeignKey("dbo.Comment", "UserId", "dbo.User", "UserId", cascadeDelete: false);
            AddForeignKey("dbo.Comment", "PostId", "dbo.Post", "PostId", cascadeDelete: false);
            AddForeignKey("dbo.Post", "ReplyId", "dbo.Reply", "ReplyId", cascadeDelete: false);
        }
    }
}
