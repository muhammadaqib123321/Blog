namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdbs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Creates", "imgname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Creates", "imgname", c => c.String());
        }
    }
}
