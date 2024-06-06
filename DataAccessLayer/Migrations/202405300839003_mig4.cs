namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educators",
                c => new
                    {
                        EducatorId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.EducatorId);
            
            AddColumn("dbo.Courses", "EducatorId", c => c.Int());
            CreateIndex("dbo.Courses", "EducatorId");
            AddForeignKey("dbo.Courses", "EducatorId", "dbo.Educators", "EducatorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "EducatorId", "dbo.Educators");
            DropIndex("dbo.Courses", new[] { "EducatorId" });
            DropColumn("dbo.Courses", "EducatorId");
            DropTable("dbo.Educators");
        }
    }
}
