﻿using System;
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
        string Create(ExamPaper examPaper);
        List<ExamPaper> Details(int id);
        string Delete(int id);
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

        public string Create(ExamPaper examPaper)
        {
           return examPaperRepository.Create(examPaper);
        }

        public List<ExamPaper> Details(int id)
        {
            return examPaperRepository.FindById(id);
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

        public string Delete(int id)
        {
           return examPaperRepository.Delete(id);
        }
    }
}
