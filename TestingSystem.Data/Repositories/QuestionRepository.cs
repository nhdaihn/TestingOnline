using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data.Infrastructure;
using TestingSystem.DataTranferObject.Question;
using TestingSystem.Models;

namespace TestingSystem.Data.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
         bool DeleteQuestion(int id);
         Question FindID(int? id);
        IEnumerable<Question> SearchByContent(string input);
        IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel);
    }
    public class QuestionRepository:RepositoryBase<Question>,IQuestionRepository
    {
        public QuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
        public Question FindID(int? id)
        {
            var question = this.DbContext.Questions.FirstOrDefault(x => x.CategoryID == id);
            return question;
        }
        public bool DeleteQuestion(int id)
        {
            var question = FindID(id);
            if (question!= null)
            {
                this.DbContext.Questions.Remove(question);
                return true;
            }
            else
            {
                return false;
            }
        }
        public IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel)
        {
            var result = this.DbContext.Questions.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.QuestionID.HasValue)
                    result = result.Where(x => x.QuestionID == searchModel.QuestionID);

                if (!string.IsNullOrEmpty(searchModel.Content))
                    result = result.Where(x => x.Content.Contains(searchModel.Content));

                if (searchModel.Level.HasValue)
                    result = result.Where(x => x.Level == searchModel.Level);

                if (searchModel.CategoryID.HasValue)
                    result = result.Where(x => x.CategoryID == searchModel.CategoryID);

                if (searchModel.CreatedBy.HasValue)
                    result = result.Where(x => x.CreatedBy == searchModel.CreatedBy);

                if (searchModel.CreatedDate.HasValue)
                    result = result.Where(x => x.CreatedDate == searchModel.CreatedDate);
            }

            return result;
        }
        public IEnumerable<Question> SearchByContent(string input)
        {
            var search = this.DbContext.Questions.OrderByDescending(x => x.QuestionID)
                .Where(x => x.Content.Contains(input.ToLower().Trim())).ToList();
            return search;
        }
         
    }
}
