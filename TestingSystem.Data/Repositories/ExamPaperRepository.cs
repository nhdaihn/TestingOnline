using System;
using System.Collections.Generic;
using System.Linq;
using TestingSystem.Data.Infrastructure;
using TestingSystem.Models;
using TestingSystem.DataTranferObject;
namespace TestingSystem.Data.Repositories
{

    public interface IExamPaperRepository : IRepository<ExamPaper>
    {
        IQueryable<ExamPaper> Filter(ExamPaperFilterModel examPaperFilterModel);
        List<ExamPaper> Search(string keySearch);
        string Create(ExamPaper examPaper);
        List<ExamPaper> FindById(int id);
        string Delete(int id);
    }

    public class ExamPaperRepository : RepositoryBase<ExamPaper>, IExamPaperRepository
    {
        public ExamPaperRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public string Create(ExamPaper examPaper)
        {
            try
            {
                if (examPaper != null)
                {
                    List<ExamPaper> listExamPapers = new List<ExamPaper>
                {
                    DbContext.ExamPapers.Add(new ExamPaper()
                    {
                       Title = examPaper.Title,
                       CreatedBy = examPaper.CreatedBy,
                       CreatedDate = examPaper.CreatedDate,
                       ExamPaperQuesions = examPaper.ExamPaperQuesions,
                       IsActive = examPaper.IsActive,
                       Status = examPaper.Status,
                       ModifiedBy = examPaper.ModifiedBy,
                       NumberOfQuestion = examPaper.NumberOfQuestion,
                       Time = examPaper.Time,
                       ModifiedDate = examPaper.ModifiedDate
                    })
                };
                    DbContext.SaveChanges();
                    return "success";
                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "fail";
            }
        }

        public string Delete(int id)
        {
            try
            {
                ExamPaper objExamPaper = DbContext.ExamPapers.Find(id);
                if (objExamPaper != null)
                {
                    DbContext.ExamPapers.Remove(objExamPaper);
                    DbContext.SaveChanges();
                    return "success";
                }
                else
                {
                    return "fail";
                }
            }

            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        public IQueryable<ExamPaper> Filter(ExamPaperFilterModel examPaperFilterModel)
        {
            try
            {
                var result = DbContext.ExamPapers.AsQueryable();
                if (examPaperFilterModel != null)
                {
                    if (examPaperFilterModel.NumberOfQuestion.HasValue)
                    {
                        result = result.Where(x => x.NumberOfQuestion == examPaperFilterModel.NumberOfQuestion);
                    }

                    if (examPaperFilterModel.CreatedBy.HasValue)
                    {
                        result = result.Where(x => x.CreatedBy == examPaperFilterModel.CreatedBy);
                    }

                    if (examPaperFilterModel.CreatedDate.HasValue)
                    {
                        result = result.Where(x => x.CreatedDate == examPaperFilterModel.CreatedDate);
                    }

                    if (examPaperFilterModel.Status.HasValue)
                    {
                        result = result.Where(x => x.Status == examPaperFilterModel.Status);
                    }

                    if (examPaperFilterModel.Time.HasValue)
                    {
                        result = result.Where(x => x.Time == examPaperFilterModel.Time);
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<ExamPaper> Search(string keySearch)
        {
            try
            {
                List<ExamPaper> listeExamPapers = new List<ExamPaper>();
                listeExamPapers = DbContext.ExamPapers.Where(x => x.Title.Contains(keySearch)).ToList();
                return listeExamPapers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
                throw;
            }
        }

        List<ExamPaper> IExamPaperRepository.FindById(int id)
        {

            try
            {
                List<ExamPaper> listeExamPapers = new List<ExamPaper>();
                listeExamPapers = DbContext.ExamPapers.Where(x => x.ExamPaperID == id).ToList();
                return listeExamPapers;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }


    }
}