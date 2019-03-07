namespace TestingSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestingSystem.Data.Infrastructure;
    using TestingSystem.DataTranferObject;
    using TestingSystem.Models;

    /// <summary>
    /// Defines the <see cref="IExamPaperRepository" />
    /// </summary>
    public interface IExamPaperRepository : IRepository<ExamPaper>
    {
        /// <summary>
        /// The Filter
        /// </summary>
        /// <param name="examPaperFilterModel">The examPaperFilterModel<see cref="ExamPaperFilterModel"/></param>
        /// <returns>The <see cref="IQueryable{ExamPaper}"/></returns>
        IQueryable<ExamPaper> Filter(ExamPaperFilterModel examPaperFilterModel);

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="keySearch">The keySearch<see cref="string"/></param>
        /// <returns>The <see cref="List{ExamPaper}"/></returns>
        List<ExamPaper> Search(string keySearch);

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="examPaper">The examPaper<see cref="ExamPaper"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Create(ExamPaper examPaper);

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="examPaper">The examPaper<see cref="ExamPaper"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Edit(ExamPaper examPaper);

        /// <summary>
        /// The FindById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ExamPaper"/></returns>
        ExamPaper FindById(int id);

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Delete(int id);
    }

    /// <summary>
    /// Defines the <see cref="ExamPaperRepository" />
    /// </summary>
    public class ExamPaperRepository : RepositoryBase<ExamPaper>, IExamPaperRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExamPaperRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The dbFactory<see cref="IDbFactory"/></param>
        public ExamPaperRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="examPaper">The examPaper<see cref="ExamPaper"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Create(ExamPaper examPaper)
        {
            try
            {
                DbContext.ExamPapers.Add(examPaper);
                if (DbContext.SaveChanges() > 0)
                {
                    return examPaper.ExamPaperID;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="examPaper">The examPaper<see cref="ExamPaper"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Edit(ExamPaper examPaper)
        {
            try
            {
                ExamPaper exam = new ExamPaper();
                exam = DbContext.ExamPapers.Find(examPaper.ExamPaperID);
                exam.Title = examPaper.Title;
                exam.NumberOfQuestion = examPaper.NumberOfQuestion;
                exam.Time = examPaper.Time;
                exam.Status = examPaper.Status;
                exam.IsActive = examPaper.IsActive;
                exam.ModifiedBy = examPaper.ModifiedBy;
                exam.ModifiedDate = examPaper.ModifiedDate;
                return DbContext.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(int id)
        {
            try
            {
                ExamPaper objExamPaper = DbContext.ExamPapers.Find(id);
                if (objExamPaper != null)
                {
                    DbContext.ExamPapers.Remove(objExamPaper);
                    return DbContext.SaveChanges();
                }
                return 0;
            }

            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        /// <summary>
        /// The Filter
        /// </summary>
        /// <param name="examPaperFilterModel">The examPaperFilterModel<see cref="ExamPaperFilterModel"/></param>
        /// <returns>The <see cref="IQueryable{ExamPaper}"/></returns>
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

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="keySearch">The keySearch<see cref="string"/></param>
        /// <returns>The <see cref="List{ExamPaper}"/></returns>
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

        /// <summary>
        /// The FindById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ExamPaper"/></returns>
        ExamPaper IExamPaperRepository.FindById(int id)
        {

            try
            {
                ExamPaper exam = new ExamPaper();
                exam = DbContext.ExamPapers.Find(id);
                return exam;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }
    }
}
