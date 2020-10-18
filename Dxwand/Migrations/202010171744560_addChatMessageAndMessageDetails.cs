namespace Dxwand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addChatMessageAndMessageDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        RecivedDate = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.MessageDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChatMessages", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ChatMessages", new[] { "ApplicationUserId" });
            DropTable("dbo.MessageDetails");
            DropTable("dbo.ChatMessages");
        }
    }
}
