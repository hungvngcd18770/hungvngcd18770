namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adđhh : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TraineeProfiles", name: "User_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.TraineeProfiles", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            DropPrimaryKey("dbo.TraineeProfiles");
            AddColumn("dbo.TraineeProfiles", "FristName", c => c.String());
            AddColumn("dbo.TraineeProfiles", "LastName", c => c.String());
            AddColumn("dbo.TraineeProfiles", "PhoneNumber", c => c.String());
            AddColumn("dbo.TraineeProfiles", "DateOfBirth", c => c.String());
            AddColumn("dbo.TrainerProfiles", "CourseId", c => c.Int());
            AddColumn("dbo.TrainerProfiles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.TraineeProfiles", "TraineeId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TraineeProfiles", "CourseId", c => c.Int());
            AddPrimaryKey("dbo.TraineeProfiles", "TraineeId");
            CreateIndex("dbo.TraineeProfiles", "CourseId");
            CreateIndex("dbo.TrainerProfiles", "CourseId");
            CreateIndex("dbo.TrainerProfiles", "ApplicationUser_Id");
            AddForeignKey("dbo.TraineeProfiles", "CourseId", "dbo.Courses", "Id");
            AddForeignKey("dbo.TrainerProfiles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TrainerProfiles", "CourseId", "dbo.Courses", "Id");
            DropColumn("dbo.TraineeProfiles", "Name");
            DropColumn("dbo.TraineeProfiles", "Education");
            DropColumn("dbo.TraineeProfiles", "Age");
            DropColumn("dbo.TraineeProfiles", "Birthday");
            DropColumn("dbo.TraineeProfiles", "ProgramingLanguage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TraineeProfiles", "ProgramingLanguage", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TraineeProfiles", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.TraineeProfiles", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.TraineeProfiles", "Education", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TraineeProfiles", "Name", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.TrainerProfiles", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.TrainerProfiles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TraineeProfiles", "CourseId", "dbo.Courses");
            DropIndex("dbo.TrainerProfiles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TrainerProfiles", new[] { "CourseId" });
            DropIndex("dbo.TraineeProfiles", new[] { "CourseId" });
            DropPrimaryKey("dbo.TraineeProfiles");
            AlterColumn("dbo.TraineeProfiles", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.TraineeProfiles", "TraineeId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.TrainerProfiles", "ApplicationUser_Id");
            DropColumn("dbo.TrainerProfiles", "CourseId");
            DropColumn("dbo.TraineeProfiles", "DateOfBirth");
            DropColumn("dbo.TraineeProfiles", "PhoneNumber");
            DropColumn("dbo.TraineeProfiles", "LastName");
            DropColumn("dbo.TraineeProfiles", "FristName");
            AddPrimaryKey("dbo.TraineeProfiles", "TraineeId");
            RenameIndex(table: "dbo.TraineeProfiles", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.TraineeProfiles", name: "ApplicationUser_Id", newName: "User_Id");
        }
    }
}
