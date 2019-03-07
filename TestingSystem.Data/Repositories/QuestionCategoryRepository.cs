namespace TestingSystem.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TestingSystem.Data.Infrastructure;
    using TestingSystem.Models;

    /// <summary>
    /// Defines the <see cref="QuestionCategoryRepository" />
    /// </summary>
    public class QuestionCategoryRepository : RepositoryBase<QuestionCategory>, IQuestionCategoryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionCategoryRepository"/> class.
        /// </summary>
        /// <param name="dbFactory">The dbFactory<see cref="IDbFactory"/></param>
        public QuestionCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        /// <summary>
        /// The AddCategoryQuestion
        /// </summary>
        /// <param name="questionCategory">The questionCategory<see cref="QuestionCategory"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int AddCategoryQuestion(QuestionCategory questionCategory)
        {


            questionCategory.ModifiedDate = DateTime.Now;
            questionCategory.CreatedDate = DateTime.Now;
            DbContext.QuestionCategories.Add(questionCategory);
            DbContext.SaveChanges();
            return questionCategory.CategoryID;
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
                QuestionCategory objExamPaper = DbContext.QuestionCategories.Find(id);
                if (objExamPaper != null)
                {
                    DbContext.QuestionCategories.Remove(objExamPaper);
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
        /// The DeleteQuestionCategory
        /// </summary>
        /// <param name="dsxoa">The dsxoa<see cref="int[]"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteQuestionCategory(int[] dsxoa)
        {
            foreach (int i in dsxoa)
            {
                QuestionCategory category = DbContext.QuestionCategories.Find(i);
                DbContext.QuestionCategories.Remove(category);
            }
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// The FindCategoryByID
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="QuestionCategory"/></returns>
        public QuestionCategory FindCategoryByID(int? id)
        {
            var questionCategory = this.DbContext.QuestionCategories.SingleOrDefault(x => x.CategoryID == id);
            return questionCategory;
        }

        /// <summary>
        /// The GetAllQuestionCategories
        /// </summary>
        /// <returns>The <see cref="IEnumerable{QuestionCategory}"/></returns>
        public IEnumerable<QuestionCategory> GetAllQuestionCategories()
        {
            var listCategory = this.DbContext.QuestionCategories.ToList();
            return listCategory;
        }

        /// <summary>
        /// The GetAllUser
        /// </summary>
        /// <returns>The <see cref="IEnumerable{User}"/></returns>
        public IEnumerable<User> GetAllUser()
        {
            return DbContext.Users.ToList();
        }

        /// <summary>
        /// The QuestionCategoryID
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool QuestionCategoryID(int id)
        {
            var quesiton1 = DbContext.Questions.Where(x => x.CategoryID == id).Count();
            if (quesiton1 > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// The SearchCategories
        /// </summary>
        /// <param name="txtSearch">The txtSearch<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionCategory}"/></returns>
        public IEnumerable<QuestionCategory> SearchCategories(string txtSearch)
        {
            var listSearchCategory = DbContext.QuestionCategories.Where(x => x.Name.Contains(txtSearch)).ToList();
            return listSearchCategory;
        }

        /// <summary>
        /// The UpdateCategoryQuestion
        /// </summary>
        /// <param name="questionCategory">The questionCategory<see cref="QuestionCategory"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int UpdateCategoryQuestion(QuestionCategory questionCategory)
        {
            QuestionCategory listQuestionCategory = DbContext.QuestionCategories.Find(questionCategory.CategoryID);
            listQuestionCategory.Name = questionCategory.Name;
            listQuestionCategory.IsActive = questionCategory.IsActive;
            listQuestionCategory.CreatedBy = questionCategory.CreatedBy;
            listQuestionCategory.CreatedDate = DateTime.Now;
            listQuestionCategory.ModifiedBy = questionCategory.ModifiedBy;
            listQuestionCategory.ModifiedDate = DateTime.Now;

            return DbContext.SaveChanges();
        }
    }

    /// <summary>
    /// Defines the <see cref="IQuestionCategoryRepository" />
    /// </summary>
    public interface IQuestionCategoryRepository : IRepository<QuestionCategory>
    {
        /// <summary>
        /// The GetAllUser
        /// </summary>
        /// <returns>The <see cref="IEnumerable{User}"/></returns>
        IEnumerable<User> GetAllUser();

        /// <summary>
        /// The AddCategoryQuestion
        /// </summary>
        /// <param name="questionCategory">The questionCategory<see cref="QuestionCategory"/></param>
        /// <returns>The <see cref="int"/></returns>
        int AddCategoryQuestion(QuestionCategory questionCategory);

        /// <summary>
        /// The UpdateCategoryQuestion
        /// </summary>
        /// <param name="questionCategory">The questionCategory<see cref="QuestionCategory"/></param>
        /// <returns>The <see cref="int"/></returns>
        int UpdateCategoryQuestion(QuestionCategory questionCategory);

        /// <summary>
        /// The DeleteQuestionCategory
        /// </summary>
        /// <param name="dsxoa">The dsxoa<see cref="int[]"/></param>
        /// <returns>The <see cref="int"/></returns>
        int DeleteQuestionCategory(int[] dsxoa);

        /// <summary>
        /// The SearchCategories
        /// </summary>
        /// <param name="txtSearch">The txtSearch<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionCategory}"/></returns>
        IEnumerable<QuestionCategory> SearchCategories(string txtSearch);

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Delete(int id);

        /// <summary>
        /// The FindCategoryByID
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="QuestionCategory"/></returns>
        QuestionCategory FindCategoryByID(int? id);

        /// <summary>
        /// The GetAllQuestionCategories
        /// </summary>
        /// <returns>The <see cref="IEnumerable{QuestionCategory}"/></returns>
        IEnumerable<QuestionCategory> GetAllQuestionCategories();

        /// <summary>
        /// The QuestionCategoryID
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        bool QuestionCategoryID(int id);
    }
}
