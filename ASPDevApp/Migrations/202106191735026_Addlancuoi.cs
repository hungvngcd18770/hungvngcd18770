namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addlancuoi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TraineeProfiles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrainerProfiles", "TrainerId", "dbo.AspNetUsers");
            DropIndex("dbo.TraineeProfiles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TrainerProfiles", new[] { "TrainerId" });
            DropColumn("dbo.TraineeProfiles", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TraineeProfiles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.TrainerProfiles", "TrainerId");
            CreateIndex("dbo.TraineeProfiles", "ApplicationUser_Id");
            AddForeignKey("dbo.TrainerProfiles", "TrainerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TraineeProfiles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
