namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddnewww : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TrainerProfiles", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainerProfiles", "Id", c => c.Int(nullable: false));
        }
    }
}
