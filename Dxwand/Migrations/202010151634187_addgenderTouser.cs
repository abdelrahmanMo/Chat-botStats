namespace Dxwand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgenderTouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "GenderId");
            AddForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "GenderId", "dbo.Genders");
            DropIndex("dbo.AspNetUsers", new[] { "GenderId" });
            DropColumn("dbo.AspNetUsers", "GenderId");
        }
    }
}
