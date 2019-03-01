using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Data.Infrastructure;
using TestingSystem.DataTranferObject.Question;
using TestingSystem.Models;

namespace TestingSystem.Data.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        bool UpdateQuestion(Question question);
        int AddQuestion(Question question);
        bool DeleteQuestion(int id);
        Question FindID(int? id);
        IEnumerable<Question> SearchByContent(string input);
        IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel);

        IEnumerable<QuestionDto> GetQuestionsByExamPaperId(int examPaperId);

        IEnumerable<QuestionDto> GetQuestionsByQuestionCategoryId(int categoryId);

    }
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public Question FindID(int? id)
        {
            var question = this.DbContext.Questions.FirstOrDefault(x => x.QuestionID == id);
            return question;
        }
        public bool DeleteQuestion(int id)
        {
            var question = this.DbContext.Questions.Find(id);
            if (question != null)
            {
                this.DbContext.Questions.Remove(question);
                return this.DbContext.SaveChanges() > 0;
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

        public int AddQuestion(Question question)
        {
            question.CreatedDate = DateTime.Now;
            this.DbContext.Questions.Add(question);
            this.DbContext.SaveChanges();
            return question.QuestionID;
        }

        public bool UpdateQuestion(Question question)
        {
            var objQuestion = this.DbContext.Questions.Find(question.QuestionID);
            if (objQuestion != null)
            {
                objQuestion.Content = question.Content;
                objQuestion.Image = question.Image;
                objQuestion.Level = question.Level;
                objQuestion.CategoryID = question.CategoryID;
                objQuestion.IsActive = question.IsActive;
                objQuestion.CreatedBy = question.CreatedBy;
                objQuestion.CreatedDate = question.CreatedDate;
                objQuestion.ModifiedBy = question.ModifiedBy;
                objQuestion.ModifiedDate = DateTime.Now;
                this.DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<QuestionDto> GetQuestionsByExamPaperId(int examPaperId)
        {
            DbContext.Configuration.ProxyCreationEnabled = false;
            var examPaperQuestions = DbContext.ExamPaperQuesions.Where(e => e.ExamPaperID == examPaperId).ToList();
            List<QuestionDto> questionsDto = new List<QuestionDto>();
            foreach (var item in examPaperQuestions)
            {
                var question = new Question();
                var questionDto = new QuestionDto();
                question = DbContext.Questions.SingleOrDefault(e => e.QuestionID == item.QuestionID);
                questionDto.IsActive = question.IsActive;
                questionDto.Content = question.Content;
                questionDto.Image = question.Image;
                questionDto.CreatedBy = question.CreatedBy;
                questionDto.CreatedDate = question.CreatedDate;
                questionDto.ModifiedBy = question.ModifiedBy;
                questionDto.ModifiedDate = question.ModifiedDate;
                questionDto.CategoryID = question.CategoryID;
                questionDto.CategoryName = DbContext.QuestionCategories.SingleOrDefault(q => q.CategoryID == question.CategoryID).Name;
                questionDto.ExamPaperQuestionID = item.ExamPaperQuesionID;
                questionsDto.Add(questionDto);
            }
            return questionsDto;
        }

        public IEnumerable<QuestionDto> GetQuestionsByQuestionCategoryId(int categoryId)
        {
            DbContext.Configuration.ProxyCreationEnabled = false;
            var questions = DbContext.Questions.Where(e => e.CategoryID == categoryId).ToList();
            List<QuestionDto> questionsDto = new List<QuestionDto>();
            foreach (var item in questions)
            {
                var questionDto = new QuestionDto();
                questionDto.IsActive = item.IsActive;
                questionDto.Content = item.Content;
                questionDto.Image = item.Image;
                questionDto.CreatedBy = item.CreatedBy;
                questionDto.CreatedDate = item.CreatedDate;
                questionDto.ModifiedBy = item.ModifiedBy;
                questionDto.ModifiedDate = item.ModifiedDate;
                questionDto.CategoryID = item.CategoryID;
                questionDto.CategoryName = DbContext.QuestionCategories.SingleOrDefault(q => q.CategoryID == item.CategoryID).Name;
                questionDto.QuestionID = item.QuestionID;
                questionsDto.Add(questionDto);
            }
            return questionsDto;
        }
    }
}
