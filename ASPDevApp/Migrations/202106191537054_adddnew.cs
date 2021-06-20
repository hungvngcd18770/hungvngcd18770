namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddnew : DbMigration
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
            AddColumn("dbo.TraineeProfiles", "Toeic", c => c.Int(nullable: false));
            AddColumn("dbo.TraineeProfiles", "CourseId", c => c.Int());
            AddColumn("dbo.TraineeProfiles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.TrainerProfiles", "TrainerId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.TrainerProfiles", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TrainerProfiles", "Education", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TrainerProfiles", "WorkingPlace", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TrainerProfiles", "Telephone", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TrainerProfiles", "Email", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TrainerProfiles", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.TrainerProfiles", "CourseId", c => c.Int());
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "CategoryId", c => c.Int());
            AddPrimaryKey("dbo.TraineeProfiles", "TraineeId");
            AddPrimaryKey("dbo.TrainerProfiles", "TrainerId");
            CreateIndex("dbo.Courses", "CategoryId");
            CreateIndex("dbo.TraineeProfiles", "CourseId");
            CreateIndex("dbo.TraineeProfiles", "ApplicationUser_Id");
            CreateIndex("dbo.TrainerProfiles", "TrainerId");
            CreateIndex("dbo.TrainerProfiles", "CourseId");
            AddForeignKey("dbo.TraineeProfiles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TraineeProfiles", "CourseId", "dbo.Courses", "Id");
            AddForeignKey("dbo.TrainerProfiles", "TrainerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TrainerProfiles", "CourseId", "dbo.Courses", "Id");
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id");
            DropColumn("dbo.TraineeProfiles", "Id");
            DropColumn("dbo.TraineeProfiles", "FristName");
            DropColumn("dbo.TraineeProfiles", "LastName");
            DropColumn("dbo.TraineeProfiles", "WorkPlace");
            DropColumn("dbo.TrainerProfiles", "Id");
            DropColumn("dbo.TrainerProfiles", "FirstName");
            DropColumn("dbo.TrainerProfiles", "LastName");
            DropColumn("dbo.TrainerProfiles", "DateOfBirth");
            DropColumn("dbo.TrainerProfiles", "Gmail");
            DropColumn("dbo.TrainerProfiles", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainerProfiles", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.TrainerProfiles", "Gmail", c => c.String());
            AddColumn("dbo.TrainerProfiles", "DateOfBirth", c => c.Int(nullable: false));
            AddColumn("dbo.TrainerProfiles", "LastName", c => c.String());
            AddColumn("dbo.TrainerProfiles", "FirstName", c => c.String());
            AddColumn("dbo.TrainerProfiles", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TraineeProfiles", "WorkPlace", c => c.String());
            AddColumn("dbo.TraineeProfiles", "LastName", c => c.String());
            AddColumn("dbo.TraineeProfiles", "FristName", c => c.String());
            AddColumn("dbo.TraineeProfiles", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.TrainerProfiles", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.TrainerProfiles", "TrainerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TraineeProfiles", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.TraineeProfiles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TrainerProfiles", new[] { "CourseId" });
            DropIndex("dbo.TrainerProfiles", new[] { "TrainerId" });
            DropIndex("dbo.TraineeProfiles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TraineeProfiles", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropPrimaryKey("dbo.TrainerProfiles");
            DropPrimaryKey("dbo.TraineeProfiles");
            AlterColumn("dbo.Courses", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            DropColumn("dbo.TrainerProfiles", "CourseId");
            DropColumn("dbo.TrainerProfiles", "Type");
            DropColumn("dbo.TrainerProfiles", "Email");
            DropColumn("dbo.TrainerProfiles", "Telephone");
            DropColumn("dbo.TrainerProfiles", "WorkingPlace");
            DropColumn("dbo.TrainerProfiles", "Education");
            DropColumn("dbo.TrainerProfiles", "Name");
            DropColumn("dbo.TrainerProfiles", "TrainerId");
            DropColumn("dbo.TraineeProfiles", "ApplicationUser_Id");
            DropColumn("dbo.TraineeProfiles", "CourseId");
            DropColumn("dbo.TraineeProfiles", "Toeic");
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
