using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Data.Infrastructure;
using TestingSystem.Data.Repositories;
using TestingSystem.Models;
using TestingSystem.DataTranferObject;
namespace TestingSystem.Sevice
{
    public interface IExamPaperService
    {
        IQueryable<ExamPaper> Filter(ExamPaperFilterModel examPaperFilterModel);
        List<ExamPaper> Search(string keySearch);
        IEnumerable<ExamPaper> GetAll();
        void Create(ExamPaper examPaper);
        void Detail(int id);
        void GetById(int id);
        void Delete(ExamPaper examPaper);
    }
    public class ExamPaperService : IExamPaperService
    {
        private readonly IExamPaperRepository examPaperRepository;
        private readonly IUnitOfWork unitOfWork;
        public ExamPaperService(IExamPaperRepository examPaperRepository, IUnitOfWork unitOfWork)
        {
            this.examPaperRepository = examPaperRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Create(ExamPaper examPaper)
        {
            examPaperRepository.Create(examPaper);
        }

        public void Detail(int id)
        {
            examPaperRepository.GetById(id);
        }

        public void GetById(int id)
        {
            examPaperRepository.GetById(id);
        }

        public IQueryable<ExamPaper> Filter(ExamPaperFilterModel examPaperFilterModel)
        {
            return examPaperRepository.Filter(examPaperFilterModel);
        }

        public IEnumerable<ExamPaper> GetAll()
        {
            return examPaperRepository.GetAll();
        }

        public List<ExamPaper> Search(string keySearch)
        {
            return examPaperRepository.Search(keySearch);
        }

        public void Delete(ExamPaper examPaper)
        {
            examPaperRepository.Delete(examPaper);
        }
    }
}
