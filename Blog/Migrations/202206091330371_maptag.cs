namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maptag : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Creates", "bFileNames");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Creates", "bFileNames", c => c.String());
        }
    }
}
