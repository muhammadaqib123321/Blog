namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initaialbdupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "title", c => c.String());
            AlterColumn("dbo.Blogs", "author", c => c.String());
            AlterColumn("dbo.Blogs", "metadescription", c => c.String());
            AlterColumn("dbo.Blogs", "metatitle", c => c.String());
            AlterColumn("dbo.Blogs", "imagealt", c => c.String());
            AlterColumn("dbo.Blogs", "blogdescription", c => c.String());
            AlterColumn("dbo.Blogs", "imgpath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "imgpath", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "blogdescription", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "imagealt", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "metatitle", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "metadescription", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "author", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "title", c => c.String(nullable: false));
        }
    }
}
