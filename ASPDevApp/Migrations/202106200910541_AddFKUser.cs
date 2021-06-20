namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKUser : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TraineeProfiles", "TraineeId");
            CreateIndex("dbo.TrainerProfiles", "TrainerId");
            AddForeignKey("dbo.TraineeProfiles", "TraineeId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TrainerProfiles", "TrainerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerProfiles", "TrainerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TraineeProfiles", "TraineeId", "dbo.AspNetUsers");
            DropIndex("dbo.TrainerProfiles", new[] { "TrainerId" });
            DropIndex("dbo.TraineeProfiles", new[] { "TraineeId" });
        }
    }
}
