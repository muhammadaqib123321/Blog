namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maptag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maptags",
                c => new
                    {
                        maptagid = c.Int(nullable: false, identity: true),
                        tagid = c.Int(nullable: false),
                        blogid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.maptagid)
                .ForeignKey("dbo.Addtags", t => t.tagid, cascadeDelete: true)
                .ForeignKey("dbo.Blogs", t => t.blogid, cascadeDelete: true)
                .Index(t => t.tagid)
                .Index(t => t.blogid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Maptags", "blogid", "dbo.Blogs");
            DropForeignKey("dbo.Maptags", "tagid", "dbo.Addtags");
            DropIndex("dbo.Maptags", new[] { "blogid" });
            DropIndex("dbo.Maptags", new[] { "tagid" });
            DropTable("dbo.Maptags");
        }
    }
}
