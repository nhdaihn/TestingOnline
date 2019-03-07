namespace TestingSystem.Sevice
{
    using System.Collections.Generic;
    using TestingSystem.Data.Infrastructure;
    using TestingSystem.Data.Repositories;
    using TestingSystem.Models;

    /// <summary>
    /// Defines the <see cref="QuestionCategorySevice" />
    /// </summary>
    public class QuestionCategorySevice : IQuestionCategorySevice
    {
        /// <summary>
        /// Defines the questionCategory
        /// </summary>
        public readonly IQuestionCategoryRepository questionCategory;

        /// <summary>
        /// Defines the unitOf
        /// </summary>
        public readonly IUnitOfWork unitOf;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionCategorySevice"/> class.
        /// </summary>
        /// <param name="questionCategory">The questionCategory<see cref="IQuestionCategoryRepository"/></param>
        /// <param name="unitOf">The unitOf<see cref="IUnitOfWork"/></param>
        public QuestionCategorySevice(IQuestionCategoryRepository questionCategory, IUnitOfWork unitOf
        )
        {
            this.questionCategory = questionCategory;
            this.unitOf = unitOf;
        }

        /// <summary>
        /// The AddCategoryQuestion
        /// </summary>
        /// <param name="category">The category<see cref="QuestionCategory"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int AddCategoryQuestion(QuestionCategory category)
        {
            return questionCategory.AddCategoryQuestion(category);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(int id)
        {
            return questionCategory.Delete(id);
        }

        /// <summary>
        /// The DeleteQuestionCategory
        /// </summary>
        /// <param name="dsxoa">The dsxoa<see cref="int[]"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteQuestionCategory(int[] dsxoa)
        {
            return questionCategory.DeleteQuestionCategory(dsxoa);
        }

        /// <summary>
        /// The FindCategoryByID
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="QuestionCategory"/></returns>
        public QuestionCategory FindCategoryByID(int? id)
        {
            return questionCategory.FindCategoryByID(id);
        }

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="IEnumerable{QuestionCategory}"/></returns>
        public IEnumerable<QuestionCategory> GetAll()
        {
            return questionCategory.GetAll();
        }

        /// <summary>
        /// The GetAllQuestionCategories
        /// </summary>
        /// <returns>The <see cref="IEnumerable{QuestionCategory}"/></returns>
        public IEnumerable<QuestionCategory> GetAllQuestionCategories()
        {
            return questionCategory.GetAllQuestionCategories();
        }

        /// <summary>
        /// The GetAllUser
        /// </summary>
        /// <returns>The <see cref="IEnumerable{User}"/></returns>
        public IEnumerable<User> GetAllUser()
        {
            return questionCategory.GetAllUser();
        }

        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="QuestionCategory"/></returns>
        public QuestionCategory GetById(int id)
        {
            return questionCategory.GetById(id);
        }

        /// <summary>
        /// The QuestionCategoryID
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool QuestionCategoryID(int id)
        {
            return questionCategory.QuestionCategoryID(id);
        }

        /// <summary>
        /// The SaveQuestionCategory
        /// </summary>
        public void SaveQuestionCategory()
        {
            unitOf.Commit();
        }

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="txtSearch">The txtSearch<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionCategory}"/></returns>
        public IEnumerable<QuestionCategory> Search(string txtSearch)
        {
            return questionCategory.SearchCategories(txtSearch);
        }

        /// <summary>
        /// The SearchCategories
        /// </summary>
        /// <param name="txtSearch">The txtSearch<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionCategory}"/></returns>
        public IEnumerable<QuestionCategory> SearchCategories(string txtSearch)
        {
            return questionCategory.SearchCategories(txtSearch);
        }

        /// <summary>
        /// The UpdateCategoryQuestion
        /// </summary>
        /// <param name="category">The category<see cref="QuestionCategory"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int UpdateCategoryQuestion(QuestionCategory category)
        {
            return questionCategory.UpdateCategoryQuestion(category);
        }
    }

    /// <summary>
    /// Defines the <see cref="IQuestionCategorySevice" />
    /// </summary>
    public interface IQuestionCategorySevice
    {
        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="IEnumerable{QuestionCategory}"/></returns>
        IEnumerable<QuestionCategory> GetAll();

        /// <summary>
        /// The AddCategoryQuestion
        /// </summary>
        /// <param name="category">The category<see cref="QuestionCategory"/></param>
        /// <returns>The <see cref="int"/></returns>
        int AddCategoryQuestion(QuestionCategory category);

        /// <summary>
        /// The SaveQuestionCategory
        /// </summary>
        void SaveQuestionCategory();

        /// <summary>
        /// The GetAllUser
        /// </summary>
        /// <returns>The <see cref="IEnumerable{User}"/></returns>
        IEnumerable<User> GetAllUser();

        /// <summary>
        /// The UpdateCategoryQuestion
        /// </summary>
        /// <param name="questionCategory">The questionCategory<see cref="QuestionCategory"/></param>
        /// <returns>The <see cref="int"/></returns>
        int UpdateCategoryQuestion(QuestionCategory questionCategory);

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="txtSearch">The txtSearch<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionCategory}"/></returns>
        IEnumerable<QuestionCategory> Search(string txtSearch);

        /// <summary>
        /// The DeleteQuestionCategory
        /// </summary>
        /// <param name="dsxoa">The dsxoa<see cref="int[]"/></param>
        /// <returns>The <see cref="int"/></returns>
        int DeleteQuestionCategory(int[] dsxoa);

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Delete(int id);

        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="QuestionCategory"/></returns>
        QuestionCategory GetById(int id);

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

        /// <summary>
        /// The SearchCategories
        /// </summary>
        /// <param name="txtSearch">The txtSearch<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{QuestionCategory}"/></returns>
        IEnumerable<QuestionCategory> SearchCategories(string txtSearch);
    }
}
