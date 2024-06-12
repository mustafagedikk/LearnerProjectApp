namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_course_view_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Viewing", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Viewing");
        }
    }
}
