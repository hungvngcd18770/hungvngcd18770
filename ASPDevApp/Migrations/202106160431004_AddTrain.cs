namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TraineeProfiles", "Gmail", c => c.String());
            AlterColumn("dbo.TraineeProfiles", "PhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.TraineeProfiles", "DateOfBirth", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TraineeProfiles", "DateOfBirth", c => c.String());
            AlterColumn("dbo.TraineeProfiles", "PhoneNumber", c => c.String());
            DropColumn("dbo.TraineeProfiles", "Gmail");
        }
    }
}
