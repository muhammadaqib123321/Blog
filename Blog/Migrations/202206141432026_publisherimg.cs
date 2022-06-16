namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publisherimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Creates", "pFilePath", c => c.String());
            AddColumn("dbo.Creates", "pFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Creates", "pFileName");
            DropColumn("dbo.Creates", "pFilePath");
        }
    }
}
