namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTrain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropPrimaryKey("dbo.TraineeProfiles");
            DropPrimaryKey("dbo.TrainerProfiles");
            AddColumn("dbo.TraineeProfiles", "TraineeId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.TraineeProfiles", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TraineeProfiles", "Education", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TraineeProfiles", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.TraineeProfiles", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.TraineeProfiles", "ProgramingLanguage", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TraineeProfiles", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.TraineeProfiles", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.TrainerProfiles", "TrainerId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.TrainerProfiles", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "CategoryId", c => c.Int());
            AlterColumn("dbo.TrainerProfiles", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.TrainerProfiles", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.TrainerProfiles", "Gmail", c => c.String(nullable: false));
            AddPrimaryKey("dbo.TraineeProfiles", "TraineeId");
            AddPrimaryKey("dbo.TrainerProfiles", "TrainerId");
            CreateIndex("dbo.Courses", "CategoryId");
            CreateIndex("dbo.TraineeProfiles", "User_Id");
            CreateIndex("dbo.TrainerProfiles", "User_Id");
            AddForeignKey("dbo.TraineeProfiles", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TrainerProfiles", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id");
            DropColumn("dbo.TraineeProfiles", "Id");
            DropColumn("dbo.TraineeProfiles", "FristName");
            DropColumn("dbo.TraineeProfiles", "LastName");
            DropColumn("dbo.TraineeProfiles", "WorkPlace");
            DropColumn("dbo.TrainerProfiles", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainerProfiles", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TraineeProfiles", "WorkPlace", c => c.String());
            AddColumn("dbo.TraineeProfiles", "LastName", c => c.String());
            AddColumn("dbo.TraineeProfiles", "FristName", c => c.String());
            AddColumn("dbo.TraineeProfiles", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.TrainerProfiles", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TraineeProfiles", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TrainerProfiles", new[] { "User_Id" });
            DropIndex("dbo.TraineeProfiles", new[] { "User_Id" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropPrimaryKey("dbo.TrainerProfiles");
            DropPrimaryKey("dbo.TraineeProfiles");
            AlterColumn("dbo.TrainerProfiles", "Gmail", c => c.String());
            AlterColumn("dbo.TrainerProfiles", "LastName", c => c.String());
            AlterColumn("dbo.TrainerProfiles", "FirstName", c => c.String());
            AlterColumn("dbo.Courses", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            DropColumn("dbo.TrainerProfiles", "User_Id");
            DropColumn("dbo.TrainerProfiles", "TrainerId");
            DropColumn("dbo.TraineeProfiles", "User_Id");
            DropColumn("dbo.TraineeProfiles", "CourseId");
            DropColumn("dbo.TraineeProfiles", "ProgramingLanguage");
            DropColumn("dbo.TraineeProfiles", "Birthday");
            DropColumn("dbo.TraineeProfiles", "Age");
            DropColumn("dbo.TraineeProfiles", "Education");
            DropColumn("dbo.TraineeProfiles", "Name");
            DropColumn("dbo.TraineeProfiles", "TraineeId");
            AddPrimaryKey("dbo.TrainerProfiles", "Id");
            AddPrimaryKey("dbo.TraineeProfiles", "Id");
            CreateIndex("dbo.Courses", "CategoryId");
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
