namespace TestingSystem.Sevice
{
    using System.Collections.Generic;
    using System.Linq;
    using TestingSystem.Data.Infrastructure;
    using TestingSystem.Data.Repositories;
    using TestingSystem.DataTranferObject;
    using TestingSystem.Models;

    /// <summary>
    /// Defines the <see cref="IExamPaperService" />
    /// </summary>
    public interface IExamPaperService
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
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="IEnumerable{ExamPaper}"/></returns>
        IEnumerable<ExamPaper> GetAll();

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
        /// The GetExamPaperById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ExamPaper"/></returns>
        ExamPaper GetExamPaperById(int id);

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Delete(int id);
    }

    /// <summary>
    /// Defines the <see cref="ExamPaperService" />
    /// </summary>
    public class ExamPaperService : IExamPaperService
    {
        /// <summary>
        /// Defines the examPaperRepository
        /// </summary>
        private readonly IExamPaperRepository examPaperRepository;

        /// <summary>
        /// Defines the unitOfWork
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamPaperService"/> class.
        /// </summary>
        /// <param name="examPaperRepository">The examPaperRepository<see cref="IExamPaperRepository"/></param>
        /// <param name="unitOfWork">The unitOfWork<see cref="IUnitOfWork"/></param>
        public ExamPaperService(IExamPaperRepository examPaperRepository, IUnitOfWork unitOfWork)
        {
            this.examPaperRepository = examPaperRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="examPaper">The examPaper<see cref="ExamPaper"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Create(ExamPaper examPaper)
        {
            return examPaperRepository.Create(examPaper);
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="examPaper">The examPaper<see cref="ExamPaper"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Edit(ExamPaper examPaper)
        {
            return examPaperRepository.Edit(examPaper);
        }

        /// <summary>
        /// The GetExamPaperById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ExamPaper"/></returns>
        public ExamPaper GetExamPaperById(int id)
        {
            return examPaperRepository.FindById(id);
        }

        /// <summary>
        /// The Filter
        /// </summary>
        /// <param name="examPaperFilterModel">The examPaperFilterModel<see cref="ExamPaperFilterModel"/></param>
        /// <returns>The <see cref="IQueryable{ExamPaper}"/></returns>
        public IQueryable<ExamPaper> Filter(ExamPaperFilterModel examPaperFilterModel)
        {
            return examPaperRepository.Filter(examPaperFilterModel);
        }

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="IEnumerable{ExamPaper}"/></returns>
        public IEnumerable<ExamPaper> GetAll()
        {
            return examPaperRepository.GetAll();
        }

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="keySearch">The keySearch<see cref="string"/></param>
        /// <returns>The <see cref="List{ExamPaper}"/></returns>
        public List<ExamPaper> Search(string keySearch)
        {
            return examPaperRepository.Search(keySearch);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(int id)
        {
            return examPaperRepository.Delete(id);
        }
    }
}
