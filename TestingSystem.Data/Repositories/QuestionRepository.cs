using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data.Infrastructure;
using TestingSystem.Models;

namespace TestingSystem.Data.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        //
    }
    public class QuestionRepository:RepositoryBase<Question>,IQuestionRepository
    {
        public QuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
