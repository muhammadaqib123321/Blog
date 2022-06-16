namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Blogs", newName: "Creates");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Creates", newName: "Blogs");
        }
    }
}
