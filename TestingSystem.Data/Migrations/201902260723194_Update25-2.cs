namespace TestingSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update252 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Phone", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Address", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "Avatar", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Avatar", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Address", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
