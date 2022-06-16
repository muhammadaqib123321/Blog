namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdbsa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Creates", "bFilePath", c => c.String());
            AddColumn("dbo.Creates", "bFileName", c => c.String());
            DropColumn("dbo.Creates", "imgpath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Creates", "imgpath", c => c.String());
            DropColumn("dbo.Creates", "bFileName");
            DropColumn("dbo.Creates", "bFilePath");
        }
    }
}
