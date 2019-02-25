using TestingSystem.Data.Infrastructure;
using TestingSystem.Data.Repositories;

namespace TestingSystem.Sevice
{
    public interface IQuestionService
    {
        //
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

    }
}
