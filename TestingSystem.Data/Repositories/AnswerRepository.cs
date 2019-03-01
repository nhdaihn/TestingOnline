using TestingSystem.Data.Infrastructure;
using TestingSystem.Models;

namespace TestingSystem.Data.Repositories
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        int AddAnswer(Answer answer);
    }

    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public int AddAnswer(Answer answer)
        {
            {
                DbContext.Answers.Add(answer);
                this.DbContext.SaveChanges();
                return 1;
            }
        }
    }
}
