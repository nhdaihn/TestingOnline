namespace TestingSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedTeam1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExamPapers", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Questions", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.QuestionCategories", "ModifiedDate", c => c.DateTime());
            DropColumn("dbo.ExamPapers", "ModifiebDate");
            DropColumn("dbo.Questions", "ModifiebDate");
            DropColumn("dbo.QuestionCategories", "ModifiebDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestionCategories", "ModifiebDate", c => c.DateTime());
            AddColumn("dbo.Questions", "ModifiebDate", c => c.DateTime());
            AddColumn("dbo.ExamPapers", "ModifiebDate", c => c.DateTime());
            DropColumn("dbo.QuestionCategories", "ModifiedDate");
            DropColumn("dbo.Questions", "ModifiedDate");
            DropColumn("dbo.ExamPapers", "ModifiedDate");
        }
    }
}
