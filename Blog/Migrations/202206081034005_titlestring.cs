namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class titlestring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "title", c => c.Int(nullable: false));
        }
    }
}
