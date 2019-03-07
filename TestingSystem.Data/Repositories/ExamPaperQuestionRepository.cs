namespace TestingSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestingSystem.Data.Infrastructure;
    using TestingSystem.Models;

    /// <summary>
    /// Defines the <see cref="IExamPaperQuestionRepository" />
    /// </summary>
    public interface IExamPaperQuestionRepository : IRepository<ExamPaperQuesion>
    {
        /// <summary>
        /// The GetExamPaperQuesionsByExamPaperId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{ExamPaperQuesion}"/></returns>
        IEnumerable<ExamPaperQuesion> GetExamPaperQuesionsByExamPaperId(int examPaperId);

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
    }

    /// <summary>
    /// Defines the <see cref="ExamPaperQuestionRepository" />
    /// </summary>
    public class ExamPaperQuestionRepository : RepositoryBase<ExamPaperQuesion>, IExamPaperQuestionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExamPaperQuestionRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The dbFactory<see cref="IDbFactory"/></param>
        public ExamPaperQuestionRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// The GetExamPaperQuesionsByExamPaperId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{ExamPaperQuesion}"/></returns>
        public IEnumerable<ExamPaperQuesion> GetExamPaperQuesionsByExamPaperId(int examPaperId)
        {
            try
            {
                var examPaperQuestions = DbContext.ExamPaperQuesions.Where(e => e.ExamPaperID == examPaperId);
                return examPaperQuestions;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
        }

        /// <summary>
        /// The GetExamPaperQuesionByExamPaperIdAndQuestionId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <param name="questionId">The questionId<see cref="int"/></param>
        /// <returns>The <see cref="ExamPaperQuesion"/></returns>
        public ExamPaperQuesion GetExamPaperQuesionByExamPaperIdAndQuestionId(int examPaperId, int questionId)
        {
            try
            {
                ExamPaperQuesion examPaperQuesion = new ExamPaperQuesion();
                examPaperQuesion = DbContext.ExamPaperQuesions.SingleOrDefault(e => e.ExamPaperID == examPaperId && e.QuestionID == questionId);
                return examPaperQuesion;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
        }

        /// <summary>
        /// The DeleteExamPaperQuestionByExamPaperIdAndQuestionId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <param name="questionId">The questionId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteExamPaperQuestionByExamPaperIdAndQuestionId(int examPaperId, int questionId)
        {
            try
            {
                ExamPaperQuesion examPaperQuesion = new ExamPaperQuesion();
                examPaperQuesion = GetExamPaperQuesionByExamPaperIdAndQuestionId(examPaperId, questionId);
                DbContext.ExamPaperQuesions.Remove(examPaperQuesion);
                return DbContext.SaveChanges();
            }

            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        /// <summary>
        /// The DeleteExamPaperQuestion
        /// </summary>
        /// <param name="examPaperQuestionId">The examPaperQuestionId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteExamPaperQuestion(int examPaperQuestionId)
        {
            try
            {
                ExamPaperQuesion examPaperQuesion = new ExamPaperQuesion();
                examPaperQuesion = DbContext.ExamPaperQuesions.FirstOrDefault(e => e.ExamPaperQuesionID == examPaperQuestionId);
                DbContext.ExamPaperQuesions.Remove(examPaperQuesion);
                return DbContext.SaveChanges();
            }

            catch (Exception e)
            {
                Console.Write(e);
                throw;
            }
        }

        /// <summary>
        /// The InsertExamPaperQuestion
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <param name="questionId">The questionId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int InsertExamPaperQuestion(int examPaperId, int questionId)
        {
            try
            {
                ExamPaperQuesion examPaperQuesion = new ExamPaperQuesion();
                examPaperQuesion.ExamPaperID = examPaperId;
                examPaperQuesion.QuestionID = questionId;
                DbContext.ExamPaperQuesions.Add(examPaperQuesion);
                return DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
