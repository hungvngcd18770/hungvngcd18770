namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.TraineeProfiles", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.TrainerProfiles", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.TraineeProfiles", "UserId");
            CreateIndex("dbo.TrainerProfiles", "UserId");
            AddForeignKey("dbo.TraineeProfiles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TrainerProfiles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrainerProfiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TraineeProfiles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserInfoes", new[] { "UserId" });
            DropIndex("dbo.TrainerProfiles", new[] { "UserId" });
            DropIndex("dbo.TraineeProfiles", new[] { "UserId" });
            DropColumn("dbo.TrainerProfiles", "UserId");
            DropColumn("dbo.TraineeProfiles", "UserId");
            DropTable("dbo.UserInfoes");
        }
    }
}
