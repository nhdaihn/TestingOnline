using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data.Infrastructure;
using TestingSystem.Data.Repositories;
using TestingSystem.DataTranferObject.Question;
using TestingSystem.Models;

namespace TestingSystem.Sevice
{
    public interface IQuestionService
    {
        void AddQuestion(Question question);
        void UpdateQuestion(Question question);
        void DeleteQuestion(Question question);
        Question GetById(int id);
        IEnumerable<Question> SearchByContent(string input);
        IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel);
        IEnumerable<Question> GetAllQuestion();

    }
    public class QuestionService:IQuestionService
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IUnitOfWork unitOfWork;

        public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            this.questionRepository = questionRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddQuestion(Question question)
        {
             questionRepository.Add(question);
        }

        public void DeleteQuestion(Question question)
        {
            questionRepository.Delete(question);
        }

        public IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel)
        {
            return questionRepository.FilterQuestions(searchModel);
        }

        public IEnumerable<Question> GetAllQuestion()
        {
            return questionRepository.GetAll();
        }

        public Question GetById(int id)
        {
            return questionRepository.GetById(id);
        }

        public IEnumerable<Question> SearchByContent(string input)
        {
            return questionRepository.SearchByContent(input);
        }

        public void UpdateQuestion(Question question)
        {
            questionRepository.Update(question);
        }
    }
}
