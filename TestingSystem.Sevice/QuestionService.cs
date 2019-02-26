using System.Collections.Generic;
using System.Linq;
using TestingSystem.Data.Infrastructure;
using TestingSystem.Data.Repositories;
using TestingSystem.DataTranferObject.Question;
using TestingSystem.Models;

namespace TestingSystem.Sevice
{
    public interface IQuestionService
    {
        Question FindID(int? id);
        void AddQuestion(Question question);
        void UpdateQuestion(Question question);
        bool DeleteQuestion(int id);
        Question GetQuetionById(int id);
        IEnumerable<Question> SearchByContent(string input);
        IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel);
        IEnumerable<Question> GetAllQuestion();

    }
    public class QuestionService : IQuestionService
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

        public bool DeleteQuestion(int id)
        {
            return questionRepository.DeleteQuestion(id);
        }

        public IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel)
        {
            return questionRepository.FilterQuestions(searchModel);
        }

        public Question FindID(int? id)
        {
            return questionRepository.FindID(id);
        }

        public IEnumerable<Question> GetAllQuestion()
        {
            return questionRepository.GetAll();
        }

        public Question GetQuetionById(int id)
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
