﻿using System;
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
        bool UpdateQuestion(Question question);
        int AddQuestion(Question question);
        bool DeleteQuestion(int id);
        Question FindID(int? id);
        IEnumerable<Question> SearchByContent(string input);
        IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel);
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
    }
}
