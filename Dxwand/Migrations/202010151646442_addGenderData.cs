namespace Dxwand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenderData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genders (Name) VALUES ('Male')");
            Sql("INSERT INTO Genders (Name) VALUES ('Female')");
        }
        
        public override void Down()
        {
        }
    }
}
