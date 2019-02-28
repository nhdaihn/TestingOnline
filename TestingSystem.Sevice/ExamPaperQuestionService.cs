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
    public interface IExamPaperQuestionService
    {

        IEnumerable<ExamPaperQuesion> GetExamPaperQuestionsByExamPaperId(int examPaperId);
    }
    public class ExamPaperQuestionService : IExamPaperQuestionService
    {
        private readonly IExamPaperQuestionRepository examPaperQuestionRepository;
        private readonly IUnitOfWork unitOfWork;

        public ExamPaperQuestionService(IExamPaperQuestionRepository examPaperQuestionRepository, IUnitOfWork unitOfWork)
        {
            this.examPaperQuestionRepository = examPaperQuestionRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<ExamPaperQuesion> GetExamPaperQuestionsByExamPaperId(int examPaperId)
        {
            return examPaperQuestionRepository.GetExamPaperQuesionsByExamPaperId(examPaperId);
        }
    }
}
