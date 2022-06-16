namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Creates", "imgname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Creates", "imgname");
        }
    }
}
