namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKTrainerAndTrainee : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TraineeProfiles", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.TrainerProfiles", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.TraineeProfiles", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.TrainerProfiles", name: "IX_UserId", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TrainerProfiles", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.TraineeProfiles", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.TrainerProfiles", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.TraineeProfiles", name: "User_Id", newName: "UserId");
        }
    }
}
