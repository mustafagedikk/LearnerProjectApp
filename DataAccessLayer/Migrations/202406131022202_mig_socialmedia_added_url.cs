﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_socialmedia_added_url : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SocialMedias", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SocialMedias", "Url");
        }
    }
}
