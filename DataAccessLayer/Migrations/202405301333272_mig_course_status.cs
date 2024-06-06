namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_course_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Status");
        }
    }
}
