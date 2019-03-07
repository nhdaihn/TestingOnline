namespace TestingSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestingSystem.Data.Infrastructure;
    using TestingSystem.DataTranferObject.Question;
    using TestingSystem.Models;

    /// <summary>
    /// Defines the <see cref="IQuestionRepository" />
    /// </summary>
    public interface IQuestionRepository : IRepository<Question>
    {
        /// <summary>
        /// Fuction Get Question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        QuestionDto GetQuestionInQuestionDTO(int? id);

        /// <summary>
        /// The GetNameLevelByQuestionID
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="string"/></returns>
        string GetNameLevelByQuestionID(int id);

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
        /// The DeleteQuestion
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        int DeleteQuestion(int id);

        /// <summary>
        /// The FindID
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="Question"/></returns>
        Question FindID(int? id);

        /// <summary>
        /// The CheckQuestionInExamPaperQuesion
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        bool CheckQuestionInExamPaperQuesion(int id);

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
    /// Defines the <see cref="QuestionRepository" />
    /// </summary>
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        /// <summary>
        /// Defines the questionCategory
        /// </summary>
        private readonly IQuestionCategoryRepository questionCategory;

        /// <summary>
        /// Defines the examPaperQuestionRepository
        /// </summary>
        private readonly IExamPaperQuestionRepository examPaperQuestionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The dbFactory<see cref="IDbFactory"/></param>
        /// <param name="questionCategory">The questionCategory<see cref="IQuestionCategoryRepository"/></param>
        /// <param name="examPaperQuestionRepository">The examPaperQuestionRepository<see cref="IExamPaperQuestionRepository"/></param>
        public QuestionRepository(IDbFactory dbFactory, IQuestionCategoryRepository questionCategory, IExamPaperQuestionRepository examPaperQuestionRepository) : base(dbFactory)
        {
            this.questionCategory = questionCategory;
            this.examPaperQuestionRepository = examPaperQuestionRepository;
        }

        /// <summary>
        /// The FindID
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="Question"/></returns>
        public Question FindID(int? id)
        {
            var question = this.DbContext.Questions.SingleOrDefault(x => x.QuestionID == id);
            return question;
        }

        /// <summary>
        /// The DeleteQuestion
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteQuestion(int id)
        {
            if (CheckQuestionInExamPaperQuesion(id) == false)
            {
                var question = this.DbContext.Questions.Find(id);
                if (question != null)
                {
                    this.DbContext.Questions.Remove(question);
                    return DbContext.SaveChanges();
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// The FilterQuestions
        /// </summary>
        /// <param name="searchModel">The searchModel<see cref="QuestionFilterModel"/></param>
        /// <returns>The <see cref="IQueryable{Question}"/></returns>
        public IQueryable<Question> FilterQuestions(QuestionFilterModel searchModel)
        {
            var result = this.DbContext.Questions.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.QuestionID.HasValue)
                    result = result.Where(x => x.QuestionID == searchModel.QuestionID);

                if (!string.IsNullOrEmpty(searchModel.Content))
                    result = result.Where(x => x.Content.Contains(searchModel.Content));

                if (searchModel.Level.HasValue)
                    result = result.Where(x => x.Level == searchModel.Level);

                if (searchModel.CategoryID.HasValue)
                    result = result.Where(x => x.CategoryID == searchModel.CategoryID);

                if (searchModel.CreatedBy.HasValue)
                    result = result.Where(x => x.CreatedBy == searchModel.CreatedBy);

                if (searchModel.CreatedDate.HasValue)
                    result = result.Where(x => x.CreatedDate == searchModel.CreatedDate);
            }

            return result;
        }

        /// <summary>
        /// The SearchByContent
        /// </summary>
        /// <param name="input">The input<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{Question}"/></returns>
        public IEnumerable<Question> SearchByContent(string input)
        {
            var search = this.DbContext.Questions.OrderByDescending(x => x.QuestionID)
                .Where(x => x.Content.Contains(input.ToLower().Trim())).ToList();
            return search;
        }

        /// <summary>
        /// The AddQuestion
        /// </summary>
        /// <param name="question">The question<see cref="Question"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int AddQuestion(Question question)
        {
            question.CreatedDate = DateTime.Now;
            DbContext.Questions.Add(question);
            DbContext.SaveChanges();
            return question.QuestionID;
        }

        /// <summary>
        /// The UpdateQuestion
        /// </summary>
        /// <param name="question">The question<see cref="Question"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool UpdateQuestion(Question question)
        {
            var objQuestion = this.DbContext.Questions.Find(question.QuestionID);
            if (objQuestion != null)
            {
                objQuestion.Content = question.Content;
                objQuestion.Image = question.Image;
                objQuestion.Level = question.Level;
                objQuestion.CategoryID = question.CategoryID;
                objQuestion.IsActive = question.IsActive;
                objQuestion.CreatedBy = question.CreatedBy;
                objQuestion.CreatedDate = objQuestion.CreatedDate;
                objQuestion.ModifiedBy = question.ModifiedBy;
                objQuestion.ModifiedDate = DateTime.Now;
                this.DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// The GetAllQuestionDtos
        /// </summary>
        /// <returns>The <see cref="IEnumerable{QuestionDto}"/></returns>
        public IEnumerable<QuestionDto> GetAllQuestionDtos()
        {
            List<QuestionDto> listQuestionDTOs = new List<QuestionDto>();
            foreach (var item in GetAll())
            {
                listQuestionDTOs.Add(new QuestionDto
                {
                    QuestionID = item.QuestionID,
                    IsActive = item.IsActive,
                    Content = item.Content,
                    Image = item.Image,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    ModifiedBy = item.ModifiedBy,
                    ModifiedDate = item.ModifiedDate,
                    CategoryID = item.CategoryID,
                    CategoryName = questionCategory.FindCategoryByID(item.CategoryID).Name,
                    Level = item.Level,
                    LevelName = GetNameLevelByQuestionID(item.QuestionID)
                });
            }

            return listQuestionDTOs;
        }

        /// <summary>
        /// The GetQuestionsByExamPaperId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionDto}"/></returns>
        public IEnumerable<QuestionDto> GetQuestionsByExamPaperId(int examPaperId)
        {
            DbContext.Configuration.ProxyCreationEnabled = false;
            var examPaperQuestions = DbContext.ExamPaperQuesions.Where(e => e.ExamPaperID == examPaperId).ToList();
            List<QuestionDto> questionsDto = new List<QuestionDto>();
            foreach (var item in examPaperQuestions)
            {
                var question = new Question();
                var questionDto = new QuestionDto();
                question = DbContext.Questions.SingleOrDefault(e => e.QuestionID == item.QuestionID);
                questionDto.IsActive = question.IsActive;
                questionDto.Content = question.Content;
                questionDto.Image = question.Image;
                questionDto.QuestionID = question.QuestionID;
                questionDto.CreatedBy = question.CreatedBy;
                questionDto.CreatedDate = question.CreatedDate;
                questionDto.ModifiedBy = question.ModifiedBy;
                questionDto.ModifiedDate = question.ModifiedDate;
                questionDto.CategoryID = question.CategoryID;
                questionDto.CategoryName = DbContext.QuestionCategories.SingleOrDefault(q => q.CategoryID == question.CategoryID).Name;
                questionDto.ExamPaperQuestionID = item.ExamPaperQuesionID;
                questionsDto.Add(questionDto);
            }
            return questionsDto;
        }

        /// <summary>
        /// The GetQuestionsByQuestionCategoryIdAndExamPaperId
        /// </summary>
        /// <param name="categoryId">The categoryId<see cref="int"/></param>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionDto}"/></returns>
        public IEnumerable<QuestionDto> GetQuestionsByQuestionCategoryIdAndExamPaperId(int categoryId, int examPaperId)
        {
            DbContext.Configuration.ProxyCreationEnabled = false;

            List<int> temQuestionId = new List<int>();
            List<ExamPaperQuesion> examPaperQuesions = new List<ExamPaperQuesion>();
            examPaperQuesions = examPaperQuestionRepository.GetExamPaperQuesionsByExamPaperId(examPaperId).ToList();
            foreach (var item in examPaperQuesions)
            {
                temQuestionId.Add(item.QuestionID);
            }

            var questions = DbContext.Questions.Where(e => e.CategoryID == categoryId).ToList();
            List<QuestionDto> questionsDto = new List<QuestionDto>();
            foreach (var item in questions)
            {
                int i = 0;
                foreach (var id in temQuestionId)
                {
                    if (item.QuestionID == id)
                    {
                        i++;
                        break;
                    }
                }
                if (i == 0)
                {
                    var questionDto = new QuestionDto();
                    questionDto.IsActive = item.IsActive;
                    questionDto.Content = item.Content;
                    questionDto.Image = item.Image;
                    questionDto.CreatedBy = item.CreatedBy;
                    questionDto.CreatedDate = item.CreatedDate;
                    questionDto.ModifiedBy = item.ModifiedBy;
                    questionDto.ModifiedDate = item.ModifiedDate;
                    questionDto.CategoryID = item.CategoryID;
                    questionDto.CategoryName = DbContext.QuestionCategories.SingleOrDefault(q => q.CategoryID == item.CategoryID).Name;
                    questionDto.QuestionID = item.QuestionID;
                    questionsDto.Add(questionDto);
                }
            }
            return questionsDto;
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
            List<QuestionDto> tempQuestionDtos = new List<QuestionDto>();
            tempQuestionDtos = GetQuestionsByQuestionCategoryIdAndExamPaperId(categoryId, examPaperId).ToList();
            if (tempQuestionDtos.Count <= number)
            {
                return tempQuestionDtos;
            }
            else
            {
                List<QuestionDto> questionDtos = new List<QuestionDto>();
                int length = tempQuestionDtos.Count();
                List<int> indexs = new List<int>();
                for (int i = 0; i < number; i++)
                {
                    int index = 0;
                    Random rnd = new Random();
                    do
                    {
                        index = rnd.Next(0, length);
                    }
                    while (indexs.Contains(index));
                    indexs.Add(index);
                    questionDtos.Add(tempQuestionDtos[index]);
                }
                return questionDtos;
            }
        }

        /// <summary>
        /// The GetAnswersByQuestionId
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="IEnumerable{Answer}"/></returns>
        public IEnumerable<Answer> GetAnswersByQuestionId(int? id)
        {
            var listAnswer = DbContext.Answers.Where(x => x.QuestionID == id);
            return listAnswer.ToList();
        }

        /// <summary>
        /// The GetAllQuestions
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Question}"/></returns>
        public IEnumerable<Question> GetAllQuestions()
        {
            return DbContext.Questions.ToList();
        }

        /// <summary>
        /// The GetAllAnswers
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Answer}"/></returns>
        public IEnumerable<Answer> GetAllAnswers()
        {
            return DbContext.Answers.ToList();
        }

        /// <summary>
        /// The GetAlLevels
        /// </summary>
        /// <returns>The <see cref="IEnumerable{Level}"/></returns>
        public IEnumerable<Level> GetAlLevels()
        {
            List<Level> listLevels = new List<Level>();
            listLevels.Add(new Level { LevelId = 1, LevelStep = 1, Name = "Easy" });
            listLevels.Add(new Level { LevelId = 2, LevelStep = 2, Name = "Normal" });
            listLevels.Add(new Level { LevelId = 3, LevelStep = 3, Name = "Hard" });
            return listLevels;
        }

        /// <summary>
        /// The GetNameLevelByQuestionID
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string GetNameLevelByQuestionID(int id)
        {
            var name = DbContext.Questions.FirstOrDefault(x => x.QuestionID == id);
            if (name.Level == 1)
            {
                return "Easy";
            }
            if (name.Level == 2)
            {
                return "Normal";
            }
            if (name.Level == 3)
            {
                return "Hard";
            }
            else
            {
                return "None";
            }
        }

        /// <summary>
        /// The GetQuestionInQuestionDTO
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="QuestionDto"/></returns>
        public QuestionDto GetQuestionInQuestionDTO(int? id)
        {
            var question = GetAllQuestionDtos().SingleOrDefault(x => x.QuestionID == id);
            return question;
        }

        /// <summary>
        /// The CheckQuestionInExamPaperQuesion
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool CheckQuestionInExamPaperQuesion(int id)
        {
            var question = DbContext.ExamPaperQuesions.SingleOrDefault(x => x.QuestionID == id);
            if (question == null)
            {
                return false;//Not Exist
            }
            else
            {
                return true;// Exist
            }
        }
    }
}
