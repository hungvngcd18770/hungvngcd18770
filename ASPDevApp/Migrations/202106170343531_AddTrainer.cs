namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainerProfiles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrainerProfiles", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TrainerProfiles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TrainerProfiles", new[] { "User_Id" });
            AddColumn("dbo.TrainerProfiles", "Name", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TrainerProfiles", "Education", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TrainerProfiles", "WorkingPlace", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TrainerProfiles", "Telephone", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TrainerProfiles", "Email", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.TrainerProfiles", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.TrainerProfiles", "FirstName");
            DropColumn("dbo.TrainerProfiles", "LastName");
            DropColumn("dbo.TrainerProfiles", "DateOfBirth");
            DropColumn("dbo.TrainerProfiles", "Gmail");
            DropColumn("dbo.TrainerProfiles", "PhoneNumber");
            DropColumn("dbo.TrainerProfiles", "ApplicationUser_Id");
            DropColumn("dbo.TrainerProfiles", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainerProfiles", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.TrainerProfiles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.TrainerProfiles", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.TrainerProfiles", "Gmail", c => c.String(nullable: false));
            AddColumn("dbo.TrainerProfiles", "DateOfBirth", c => c.Int(nullable: false));
            AddColumn("dbo.TrainerProfiles", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.TrainerProfiles", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.TrainerProfiles", "Type");
            DropColumn("dbo.TrainerProfiles", "Email");
            DropColumn("dbo.TrainerProfiles", "Telephone");
            DropColumn("dbo.TrainerProfiles", "WorkingPlace");
            DropColumn("dbo.TrainerProfiles", "Education");
            DropColumn("dbo.TrainerProfiles", "Name");
            CreateIndex("dbo.TrainerProfiles", "User_Id");
            CreateIndex("dbo.TrainerProfiles", "ApplicationUser_Id");
            AddForeignKey("dbo.TrainerProfiles", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TrainerProfiles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
