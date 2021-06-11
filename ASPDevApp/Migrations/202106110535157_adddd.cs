namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TraineeProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FristName = c.String(),
                        LastName = c.String(),
                        WorkPlace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TraineeProfiles");
        }
    }
}
