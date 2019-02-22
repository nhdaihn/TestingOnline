using System.Data.Entity;
using TestingSystem.Data.Infrastructure;
using TestingSystem.Models;
using TestingSystem.Data.Configuration;

namespace TestingSystem.Data
{
    public class TestingSystemEntities : DbContext, IUnitOfWork
    {
        public TestingSystemEntities() : base("TestingSystem")
        {

        }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ExamPaper> ExamPapers { get; set; }
        public DbSet<ExamPaperQuesion> ExamPaperQuesions { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Action> Actions { get; set; }



        public DbSet<Exam> Exams { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<ManagerTest> ManagerTests{ get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configtion
            modelBuilder
                .Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
            modelBuilder
                .Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();










            // Dual foreign key QuestionCategory
            modelBuilder.Entity<QuestionCategory>()
                .HasRequired(q => q.CreatedBys)
                .WithMany(t => t.QuestionCategoriesCreateUser)
                .HasForeignKey(q => q.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionCategory>()
                .HasRequired(q => q.ModifiedBys)
                .WithMany(t => t.QuestionCategoriesModifiedUser)
                .HasForeignKey(q => q.ModifiedBy)
                .WillCascadeOnDelete(false);




            // Dual foreign key ExamPaper
            modelBuilder.Entity<ExamPaper>()
                .HasRequired(e=>e.ModifiedBys)
                .WithMany(t=>t.ExamPapersModifiedUser)
                .HasForeignKey(e=>e.ModifiedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExamPaper>()
                .HasRequired(e => e.CreatedBys)
                .WithMany(t => t.ExamPapersCreateUser)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);



            // Dual foreign key Question
            modelBuilder.Entity<Question>()
                .HasRequired(e => e.ModifiedUser)
                .WithMany(t => t.QuestionModifiedUser)
                .HasForeignKey(e => e.ModifiedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasRequired(e => e.CreaterUser)
                .WithMany(t => t.QuestionCreateUser)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);


        }


    }
}
