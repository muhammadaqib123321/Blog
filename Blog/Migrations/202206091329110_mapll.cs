namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Creates", "bFileNames", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Creates", "bFileNames");
        }
    }
}
