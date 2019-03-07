namespace TestingSystem.Sevice
{
    using System.Collections.Generic;
    using TestingSystem.Data.Infrastructure;
    using TestingSystem.Data.Repositories;
    using TestingSystem.Models;

    /// <summary>
    /// Defines the <see cref="IExamPaperQuestionService" />
    /// </summary>
    public interface IExamPaperQuestionService
    {
        /// <summary>
        /// The DeleteExamPaperQuestionByExamPaperIdAndQuestionId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <param name="questionId">The questionId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        int DeleteExamPaperQuestionByExamPaperIdAndQuestionId(int examPaperId, int questionId);

        /// <summary>
        /// The DeleteExamPaperQuestion
        /// </summary>
        /// <param name="examPaperQuestionId">The examPaperQuestionId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        int DeleteExamPaperQuestion(int examPaperQuestionId);

        /// <summary>
        /// The InsertExamPaperQuestion
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <param name="questionId">The questionId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        int InsertExamPaperQuestion(int examPaperId, int questionId);

        /// <summary>
        /// The GetExamPaperQuesionByExamPaperIdAndQuestionId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <param name="questionId">The questionId<see cref="int"/></param>
        /// <returns>The <see cref="ExamPaperQuesion"/></returns>
        ExamPaperQuesion GetExamPaperQuesionByExamPaperIdAndQuestionId(int examPaperId, int questionId);

        /// <summary>
        /// The GetExamPaperQuestionsByExamPaperId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{ExamPaperQuesion}"/></returns>
        IEnumerable<ExamPaperQuesion> GetExamPaperQuestionsByExamPaperId(int examPaperId);
    }

    /// <summary>
    /// Defines the <see cref="ExamPaperQuestionService" />
    /// </summary>
    public class ExamPaperQuestionService : IExamPaperQuestionService
    {
        /// <summary>
        /// Defines the examPaperQuestionRepository
        /// </summary>
        private readonly IExamPaperQuestionRepository examPaperQuestionRepository;

        /// <summary>
        /// Defines the unitOfWork
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamPaperQuestionService"/> class.
        /// </summary>
        /// <param name="examPaperQuestionRepository">The examPaperQuestionRepository<see cref="IExamPaperQuestionRepository"/></param>
        /// <param name="unitOfWork">The unitOfWork<see cref="IUnitOfWork"/></param>
        public ExamPaperQuestionService(IExamPaperQuestionRepository examPaperQuestionRepository, IUnitOfWork unitOfWork)
        {
            this.examPaperQuestionRepository = examPaperQuestionRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// The GetExamPaperQuestionsByExamPaperId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{ExamPaperQuesion}"/></returns>
        public IEnumerable<ExamPaperQuesion> GetExamPaperQuestionsByExamPaperId(int examPaperId)
        {
            return examPaperQuestionRepository.GetExamPaperQuesionsByExamPaperId(examPaperId);
        }

        /// <summary>
        /// The GetExamPaperQuesionByExamPaperIdAndQuestionId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <param name="questionId">The questionId<see cref="int"/></param>
        /// <returns>The <see cref="ExamPaperQuesion"/></returns>
        public ExamPaperQuesion GetExamPaperQuesionByExamPaperIdAndQuestionId(int examPaperId, int questionId)
        {
            return examPaperQuestionRepository.GetExamPaperQuesionByExamPaperIdAndQuestionId(examPaperId, questionId);
        }

        /// <summary>
        /// The DeleteExamPaperQuestionByExamPaperIdAndQuestionId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <param name="questionId">The questionId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteExamPaperQuestionByExamPaperIdAndQuestionId(int examPaperId, int questionId)
        {
            return examPaperQuestionRepository.DeleteExamPaperQuestionByExamPaperIdAndQuestionId(examPaperId, questionId);
        }

        /// <summary>
        /// The DeleteExamPaperQuestion
        /// </summary>
        /// <param name="examPaperQuestionId">The examPaperQuestionId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteExamPaperQuestion(int examPaperQuestionId)
        {
            return examPaperQuestionRepository.DeleteExamPaperQuestion(examPaperQuestionId);
        }

        /// <summary>
        /// The InsertExamPaperQuestion
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <param name="questionId">The questionId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int InsertExamPaperQuestion(int examPaperId, int questionId)
        {
            return examPaperQuestionRepository.InsertExamPaperQuestion(examPaperId, questionId);
        }
    }
}
