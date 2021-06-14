namespace ASPDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String());
            AddColumn("dbo.Courses", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Courses", "CategoryId");
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Courses", "CourseName");
            DropColumn("dbo.Courses", "CategoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CategoryName", c => c.String());
            AddColumn("dbo.Courses", "CourseName", c => c.String());
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Courses", "CategoryId");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
