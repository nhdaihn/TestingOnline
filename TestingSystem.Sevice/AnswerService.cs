namespace TestingSystem.Sevice
{
    using System.Collections.Generic;
    using TestingSystem.Data.Infrastructure;
    using TestingSystem.Data.Repositories;
    using TestingSystem.Models;

    /// <summary>
    /// Defines the <see cref="IAnswerService" />
    /// </summary>
    public interface IAnswerService
    {
        /// <summary>
        /// The GetAnswersByQuestionID
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="List{Answer}"/></returns>
        List<Answer> GetAnswersByQuestionID(int? id);

        /// <summary>
        /// The AddAnswer
        /// </summary>
        /// <param name="answer">The answer<see cref="Answer"/></param>
        /// <returns>The <see cref="int"/></returns>
        int AddAnswer(Answer answer);

        /// <summary>
        /// The UpdateAnswer
        /// </summary>
        /// <param name="answer">The answer<see cref="Answer"/></param>
        /// <returns>The <see cref="bool"/></returns>
        bool UpdateAnswer(Answer answer);

        /// <summary>
        /// The DeleteAnswer
        /// </summary>
        /// <param name="answer">The answer<see cref="Answer"/></param>
        void DeleteAnswer(Answer answer);
    }

    /// <summary>
    /// Defines the <see cref="AnswerService" />
    /// </summary>
    public class AnswerService : IAnswerService
    {
        /// <summary>
        /// Defines the answerRepository
        /// </summary>
        private readonly IAnswerRepository answerRepository;

        /// <summary>
        /// Defines the unitOfWork
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerService"/> class.
        /// </summary>
        /// <param name="answerRepository">The answerRepository<see cref="IAnswerRepository"/></param>
        /// <param name="unitOfWork">The unitOfWork<see cref="IUnitOfWork"/></param>
        public AnswerService(IAnswerRepository answerRepository, IUnitOfWork unitOfWork)
        {
            this.answerRepository = answerRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// The AddAnswer
        /// </summary>
        /// <param name="answer">The answer<see cref="Answer"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int AddAnswer(Answer answer)
        {
            return answerRepository.AddAnswer(answer);
        }

        /// <summary>
        /// The DeleteAnswer
        /// </summary>
        /// <param name="answer">The answer<see cref="Answer"/></param>
        public void DeleteAnswer(Answer answer)
        {
            answerRepository.Delete(answer);
        }

        /// <summary>
        /// The GetAnswersByQuestionID
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="List{Answer}"/></returns>
        public List<Answer> GetAnswersByQuestionID(int? id)
        {
            return answerRepository.GetAnswersByQuestionID(id);
        }

        /// <summary>
        /// The UpdateAnswer
        /// </summary>
        /// <param name="answer">The answer<see cref="Answer"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool UpdateAnswer(Answer answer)
        {
            return answerRepository.UpdateAnswer(answer);
        }
    }
}
