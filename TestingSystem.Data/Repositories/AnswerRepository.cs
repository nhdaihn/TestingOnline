namespace TestingSystem.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using TestingSystem.Data.Infrastructure;
    using TestingSystem.Models;

    /// <summary>
    /// Defines the <see cref="IAnswerRepository" />
    /// </summary>
    public interface IAnswerRepository : IRepository<Answer>
    {
        /// <summary>
        /// The GetAnswersByQuestionID
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="List{Answer}"/></returns>
        List<Answer> GetAnswersByQuestionID(int? id);

        /// <summary>
        /// The UpdateAnswer
        /// </summary>
        /// <param name="answer">The answer<see cref="Answer"/></param>
        /// <returns>The <see cref="bool"/></returns>
        bool UpdateAnswer(Answer answer);

        /// <summary>
        /// The AddAnswer
        /// </summary>
        /// <param name="answer">The answer<see cref="Answer"/></param>
        /// <returns>The <see cref="int"/></returns>
        int AddAnswer(Answer answer);
    }

    /// <summary>
    /// Defines the <see cref="AnswerRepository" />
    /// </summary>
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The dbFactory<see cref="IDbFactory"/></param>
        public AnswerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// The AddAnswer
        /// </summary>
        /// <param name="answer">The answer<see cref="Answer"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int AddAnswer(Answer answer)
        {
            {
                DbContext.Answers.Add(answer);
                this.DbContext.SaveChanges();
                return 1;
            }
        }

        /// <summary>
        /// The GetAnswersByQuestionID
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="List{Answer}"/></returns>
        public List<Answer> GetAnswersByQuestionID(int? id)
        {
            var listAnswer = DbContext.Answers.Where(x => x.QuestionID == id).ToList();
            return listAnswer;
        }

        /// <summary>
        /// The UpdateAnswer
        /// </summary>
        /// <param name="answer">The answer<see cref="Answer"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool UpdateAnswer(Answer answer)
        {
            var objQuestion = this.DbContext.Answers.Find(answer.AnswerID);
            if (objQuestion != null)
            {
                objQuestion.AnswerContent = answer.AnswerContent;
                objQuestion.IsCorrect = answer.IsCorrect;
                objQuestion.QuestionID = answer.QuestionID;
                this.DbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
