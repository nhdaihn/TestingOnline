using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data.Infrastructure;
using TestingSystem.Data.Repositories;
using TestingSystem.Models;

namespace TestingSystem.Sevice
{
    public interface IAnswerService
    {
        void AddAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
        void DeleteAnswer(Answer answer);
    }
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository answerRepository;
        private readonly IUnitOfWork unitOfWork;

        public AnswerService(IAnswerRepository answerRepository, IUnitOfWork unitOfWork)
        {
            this.answerRepository = answerRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddAnswer(Answer answer)
        {
             answerRepository.Add(answer);
        }

        public void DeleteAnswer(Answer answer)
        {
            answerRepository.Delete(answer);
        }

        public void UpdateAnswer(Answer answer)
        {
           answerRepository.Update(answer);
        }
    }
}
