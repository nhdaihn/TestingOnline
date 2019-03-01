using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data.Infrastructure;
using TestingSystem.Models;

namespace TestingSystem.Data.Repositories
{
    public interface IExamPaperQuestionRepository : IRepository<ExamPaperQuesion>
    {
 
        IEnumerable<ExamPaperQuesion> GetExamPaperQuesionsByExamPaperId(int examPaperId);
    }
    public class ExamPaperQuestionRepository : RepositoryBase<ExamPaperQuesion>, IExamPaperQuestionRepository
    {
        public ExamPaperQuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<ExamPaperQuesion> GetExamPaperQuesionsByExamPaperId(int examPaperId)
        {
            var examPaperQuestions = DbContext.ExamPaperQuesions.Where(e => e.ExamPaperID == examPaperId);
            return examPaperQuestions;
        }

    }
}
