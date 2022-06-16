namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddCategories",
                c => new
                    {
                        catid = c.Int(nullable: false, identity: true),
                        catname = c.String(),
                    })
                .PrimaryKey(t => t.catid);
            
            CreateTable(
                "dbo.Addtags",
                c => new
                    {
                        tagid = c.Int(nullable: false, identity: true),
                        tagname = c.String(),
                    })
                .PrimaryKey(t => t.tagid);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        blogid = c.Int(nullable: false, identity: true),
                        author = c.String(),
                        metadescription = c.String(),
                        metatitle = c.String(),
                        imagealt = c.String(),
                        blogdescription = c.String(),
                        imgpath = c.String(),
                        catid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.blogid)
                .ForeignKey("dbo.AddCategories", t => t.catid, cascadeDelete: true)
                .Index(t => t.catid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "catid", "dbo.AddCategories");
            DropIndex("dbo.Blogs", new[] { "catid" });
            DropTable("dbo.Blogs");
            DropTable("dbo.Addtags");
            DropTable("dbo.AddCategories");
        }
    }
}
