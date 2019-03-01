namespace TestingSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modified13team1v10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "AnswerContent", c => c.String(nullable: false));
            DropColumn("dbo.Answers", "Content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Content", c => c.String(nullable: false));
            DropColumn("dbo.Answers", "AnswerContent");
        }
    }
}
