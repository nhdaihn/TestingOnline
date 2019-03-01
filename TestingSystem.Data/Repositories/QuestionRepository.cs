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
        IEnumerable<Level> GetAlLevels();
        IEnumerable<QuestionDto> GetAllQuestionDtos();
        bool UpdateQuestion(Question question);
        int AddQuestion(Question question);
        int DeleteQuestion(int id);
        Question FindID(int? id);
        IEnumerable<Question> SearchByContent(string input);
        IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel);

        IEnumerable<QuestionDto> GetQuestionsByExamPaperId(int examPaperId);
    }
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        private readonly IQuestionCategoryRepository questionCategory;
        public QuestionRepository(IDbFactory dbFactory, IQuestionCategoryRepository questionCategory) : base(dbFactory)
        {
            this.questionCategory = questionCategory;
        }
        public Question FindID(int? id)
        {
            var question = this.DbContext.Questions.SingleOrDefault(x => x.QuestionID == id);
            return question;
        }
        public int DeleteQuestion(int id)
        {
            var question = this.DbContext.Questions.Find(id);
            if (question != null)
            {
                this.DbContext.Questions.Remove(question);
                return DbContext.SaveChanges();
            }
            else
            {
                return 0;
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
            DbContext.Questions.Add(question);
            DbContext.SaveChanges();
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

        public IEnumerable<QuestionDto> GetAllQuestionDtos()
        {
            List<QuestionDto> listQuestionDTOs = new List<QuestionDto>();
            foreach (var item in GetAll())
            {
                listQuestionDTOs.Add(new QuestionDto
                {
                    QuestionID = item.QuestionID,
                    IsActive = item.IsActive,
                    Content = item.Content,
                    Image = item.Image,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate,
                    CategoryID = item.CategoryID,
                    // category name fix cung truoc
                    CategoryName = questionCategory.FindCategoryByID(item.CategoryID).Name
                });
            }

            return listQuestionDTOs;
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
                questionsDto.Add(questionDto);
            }
            return questionsDto;
        }

        public IEnumerable<Level> GetAlLevels()
        {
            List<Level> listLevels = new List<Level>();
            listLevels.Add(new Level { LevelId = 1, LevelStep = 1, Name = "Easy" });
            listLevels.Add(new Level { LevelId = 2, LevelStep = 2, Name = "Normal" });
            listLevels.Add(new Level { LevelId = 3, LevelStep = 3, Name = "Hard" });
            return listLevels;
        }
    }
}
