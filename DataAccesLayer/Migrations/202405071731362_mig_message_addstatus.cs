namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_addstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "TaskStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "TaskStatus");
            DropColumn("dbo.Messages", "Status");
        }
    }
}
