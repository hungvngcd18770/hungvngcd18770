namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnew : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TraineeProfiles");
            AddColumn("dbo.TraineeProfiles", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TraineeProfiles", "Education", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TraineeProfiles", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.TraineeProfiles", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.TraineeProfiles", "ProgramingLanguage", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TraineeProfiles", "Toeic", c => c.Int(nullable: false));
            AddColumn("dbo.TrainerProfiles", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.TraineeProfiles", "TraineeId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.TraineeProfiles", "TraineeId");
            CreateIndex("dbo.TrainerProfiles", "TrainerId");
            AddForeignKey("dbo.TrainerProfiles", "TrainerId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.TraineeProfiles", "FristName");
            DropColumn("dbo.TraineeProfiles", "LastName");
            DropColumn("dbo.TraineeProfiles", "PhoneNumber");
            DropColumn("dbo.TraineeProfiles", "DateOfBirth");
            DropColumn("dbo.TraineeProfiles", "Gmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TraineeProfiles", "Gmail", c => c.String());
            AddColumn("dbo.TraineeProfiles", "DateOfBirth", c => c.Int(nullable: false));
            AddColumn("dbo.TraineeProfiles", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.TraineeProfiles", "LastName", c => c.String());
            AddColumn("dbo.TraineeProfiles", "FristName", c => c.String());
            DropForeignKey("dbo.TrainerProfiles", "TrainerId", "dbo.AspNetUsers");
            DropIndex("dbo.TrainerProfiles", new[] { "TrainerId" });
            DropPrimaryKey("dbo.TraineeProfiles");
            AlterColumn("dbo.TraineeProfiles", "TraineeId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.TrainerProfiles", "Id");
            DropColumn("dbo.TraineeProfiles", "Toeic");
            DropColumn("dbo.TraineeProfiles", "ProgramingLanguage");
            DropColumn("dbo.TraineeProfiles", "Birthday");
            DropColumn("dbo.TraineeProfiles", "Age");
            DropColumn("dbo.TraineeProfiles", "Education");
            DropColumn("dbo.TraineeProfiles", "Name");
            AddPrimaryKey("dbo.TraineeProfiles", "TraineeId");
        }
    }
}
