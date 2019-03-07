namespace TestingSystem.Sevice
{
    using System.Collections.Generic;
    using System.Linq;
    using TestingSystem.Data.Infrastructure;
    using TestingSystem.Data.Repositories;
    using TestingSystem.DataTranferObject.Question;
    using TestingSystem.Models;

    /// <summary>
    /// Defines the <see cref="IQuestionService" />
    /// </summary>
    public interface IQuestionService
    {
        /// <summary>
        /// The GetQuestionInQuestionDTO
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="QuestionDto"/></returns>
        QuestionDto GetQuestionInQuestionDTO(int? id);

        /// <summary>
        /// The GetAlLevels
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Level}"/></returns>
        IEnumerable<Level> GetAlLevels();

        /// <summary>
        /// The GetAllQuestionDtos
        /// </summary>
        /// <returns>The <see cref="IEnumerable{QuestionDto}"/></returns>
        IEnumerable<QuestionDto> GetAllQuestionDtos();

        /// <summary>
        /// The UpdateQuestion
        /// </summary>
        /// <param name="question">The question<see cref="Question"/></param>
        /// <returns>The <see cref="bool"/></returns>
        bool UpdateQuestion(Question question);

        /// <summary>
        /// The AddQuestion
        /// </summary>
        /// <param name="question">The question<see cref="Question"/></param>
        /// <returns>The <see cref="int"/></returns>
        int AddQuestion(Question question);

        /// <summary>
        /// The FindID
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="Question"/></returns>
        Question FindID(int? id);

        /// <summary>
        /// The DeleteQuestion
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        int DeleteQuestion(int id);

        /// <summary>
        /// The GetQuetionById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Question"/></returns>
        Question GetQuetionById(int id);

        /// <summary>
        /// The SearchByContent
        /// </summary>
        /// <param name="input">The input<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{Question}"/></returns>
        IEnumerable<Question> SearchByContent(string input);

        /// <summary>
        /// The FilterQuestions
        /// </summary>
        /// <param name="searchModel">The searchModel<see cref="QuestionFilterModel"/></param>
        /// <returns>The <see cref="IQueryable{Question}"/></returns>
        IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel);

        /// <summary>
        /// The GetAllQuestion
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Question}"/></returns>
        IEnumerable<Question> GetAllQuestion();

        /// <summary>
        /// The GetQuestionsByExamPaperId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionDto}"/></returns>
        IEnumerable<QuestionDto> GetQuestionsByExamPaperId(int examPaperId);

        /// <summary>
        /// The GetQuestionsByQuestionCategoryIdAndExamPaperId
        /// </summary>
        /// <param name="categoryId">The categoryId<see cref="int"/></param>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionDto}"/></returns>
        IEnumerable<QuestionDto> GetQuestionsByQuestionCategoryIdAndExamPaperId(int categoryId, int examPaperId);

        /// <summary>
        /// The RandomQuestionsByCategoryIdAndExamPaperIdAndNumber
        /// </summary>
        /// <param name="categoryId">The categoryId<see cref="int"/></param>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <param name="number">The number<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionDto}"/></returns>
        IEnumerable<QuestionDto> RandomQuestionsByCategoryIdAndExamPaperIdAndNumber(int categoryId, int examPaperId, int number);

        /// <summary>
        /// The GetAnswersByQuestionId
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="IEnumerable{Answer}"/></returns>
        IEnumerable<Answer> GetAnswersByQuestionId(int? id);

        /// <summary>
        /// The GetAllQuestions
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Question}"/></returns>
        IEnumerable<Question> GetAllQuestions();

        /// <summary>
        /// The GetAllAnswers
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Answer}"/></returns>
        IEnumerable<Answer> GetAllAnswers();
    }

    /// <summary>
    /// Defines the <see cref="QuestionService" />
    /// </summary>
    public class QuestionService : IQuestionService
    {
        /// <summary>
        /// Defines the questionRepository
        /// </summary>
        private readonly IQuestionRepository questionRepository;

        /// <summary>
        /// Defines the unitOfWork
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionService"/> class.
        /// </summary>
        /// <param name="questionRepository">The questionRepository<see cref="IQuestionRepository"/></param>
        /// <param name="unitOfWork">The unitOfWork<see cref="IUnitOfWork"/></param>
        public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            this.questionRepository = questionRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// The DeleteQuestion
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteQuestion(int id)
        {
            return questionRepository.DeleteQuestion(id);
        }

        /// <summary>
        /// The FilterQuestions
        /// </summary>
        /// <param name="searchModel">The searchModel<see cref="QuestionFilterModel"/></param>
        /// <returns>The <see cref="IQueryable{Question}"/></returns>
        public IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel)
        {
            return questionRepository.FilterQuestions(searchModel);
        }

        /// <summary>
        /// The FindID
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="Question"/></returns>
        public Question FindID(int? id)
        {
            return questionRepository.FindID(id);
        }

        /// <summary>
        /// The GetAllQuestion
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Question}"/></returns>
        public IEnumerable<Question> GetAllQuestion()
        {
            return questionRepository.GetAll();
        }

        /// <summary>
        /// The GetAllQuestionDtos
        /// </summary>
        /// <returns>The <see cref="IEnumerable{QuestionDto}"/></returns>
        public IEnumerable<QuestionDto> GetAllQuestionDtos()
        {
            return questionRepository.GetAllQuestionDtos();
        }

        /// <summary>
        /// The GetQuetionById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Question"/></returns>
        public Question GetQuetionById(int id)
        {
            return questionRepository.GetById(id);
        }

        /// <summary>
        /// The SearchByContent
        /// </summary>
        /// <param name="input">The input<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{Question}"/></returns>
        public IEnumerable<Question> SearchByContent(string input)
        {
            return questionRepository.SearchByContent(input);
        }

        /// <summary>
        /// The UpdateQuestion
        /// </summary>
        /// <param name="question">The question<see cref="Question"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool UpdateQuestion(Question question)
        {
            return questionRepository.UpdateQuestion(question);
        }

        /// <summary>
        /// The AddQuestion
        /// </summary>
        /// <param name="question">The question<see cref="Question"/></param>
        /// <returns>The <see cref="int"/></returns>
        int IQuestionService.AddQuestion(Question question)
        {
            return questionRepository.AddQuestion(question);
        }

        /// <summary>
        /// The GetQuestionsByExamPaperId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionDto}"/></returns>
        public IEnumerable<QuestionDto> GetQuestionsByExamPaperId(int examPaperId)
        {
            return questionRepository.GetQuestionsByExamPaperId(examPaperId);
        }

        /// <summary>
        /// The GetQuestionsByQuestionCategoryIdAndExamPaperId
        /// </summary>
        /// <param name="categoryId">The categoryId<see cref="int"/></param>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionDto}"/></returns>
        public IEnumerable<QuestionDto> GetQuestionsByQuestionCategoryIdAndExamPaperId(int categoryId, int examPaperId)
        {
            return questionRepository.GetQuestionsByQuestionCategoryIdAndExamPaperId(categoryId, examPaperId);
        }

        /// <summary>
        /// The GetAlLevels
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Level}"/></returns>
        public IEnumerable<Level> GetAlLevels()
        {
            return questionRepository.GetAlLevels();
        }

        /// <summary>
        /// The RandomQuestionsByCategoryIdAndExamPaperIdAndNumber
        /// </summary>
        /// <param name="categoryId">The categoryId<see cref="int"/></param>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <param name="number">The number<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionDto}"/></returns>
        public IEnumerable<QuestionDto> RandomQuestionsByCategoryIdAndExamPaperIdAndNumber(int categoryId, int examPaperId, int number)
        {
            return questionRepository.RandomQuestionsByCategoryIdAndExamPaperIdAndNumber(categoryId, examPaperId, number);
        }

        /// <summary>
        /// The GetAnswersByQuestionId
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="IEnumerable{Answer}"/></returns>
        public IEnumerable<Answer> GetAnswersByQuestionId(int? id)
        {
            return questionRepository.GetAnswersByQuestionId(id);
        }

        /// <summary>
        /// The GetAllQuestions
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Question}"/></returns>
        public IEnumerable<Question> GetAllQuestions()
        {
            return questionRepository.GetAllQuestions();
        }

        /// <summary>
        /// The GetAllAnswers
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Answer}"/></returns>
        public IEnumerable<Answer> GetAllAnswers()
        {
            return questionRepository.GetAllAnswers();
        }

        /// <summary>
        /// The GetQuestionInQuestionDTO
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="QuestionDto"/></returns>
        public QuestionDto GetQuestionInQuestionDTO(int? id)
        {
            return questionRepository.GetQuestionInQuestionDTO(id);
        }
    }
}
