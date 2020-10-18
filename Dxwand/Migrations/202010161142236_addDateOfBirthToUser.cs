﻿namespace Dxwand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateOfBirthToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
        }
    }
}
