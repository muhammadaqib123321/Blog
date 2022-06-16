namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "title", c => c.Int(nullable: false));
            AlterColumn("dbo.Blogs", "author", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "metadescription", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "metatitle", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "imagealt", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "blogdescription", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "imgpath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "imgpath", c => c.String());
            AlterColumn("dbo.Blogs", "blogdescription", c => c.String());
            AlterColumn("dbo.Blogs", "imagealt", c => c.String());
            AlterColumn("dbo.Blogs", "metatitle", c => c.String());
            AlterColumn("dbo.Blogs", "metadescription", c => c.String());
            AlterColumn("dbo.Blogs", "author", c => c.String());
            DropColumn("dbo.Blogs", "title");
        }
    }
}
