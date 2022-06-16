namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdbyUpDatedBy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Creates", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Creates", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Creates", "CreatedBy", c => c.String());
            AddColumn("dbo.Creates", "UpdatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Creates", "UpdatedBy");
            DropColumn("dbo.Creates", "CreatedBy");
            DropColumn("dbo.Creates", "UpdatedDate");
            DropColumn("dbo.Creates", "CreatedDate");
        }
    }
}
