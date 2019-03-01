using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TestingSystem.Data.Infrastructure;
using TestingSystem.Models;

namespace TestingSystem.Data.Repositories
{
    public class QuestionCategoryRepository : RepositoryBase<QuestionCategory>, IQuestionCategoryRepository
    {
       
        public QuestionCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public int AddCategoryQuestion(QuestionCategory questionCategory)
        {
            List<QuestionCategory> listExamPapers = new List<QuestionCategory>
            {
                DbContext.QuestionCategories.Add(new QuestionCategory()
                {
                    Name = questionCategory.Name,
                    IsActive = questionCategory.IsActive,
                    CreatedBy = questionCategory.CreatedBy,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = questionCategory.ModifiedBy,
                    ModifiedDate = DateTime.Now,

                })
            };
            return DbContext.SaveChanges();
        }

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

        public int DeleteQuestionCategory(int[] dsxoa)
        {
            foreach(int i in dsxoa)
            {
                QuestionCategory category = DbContext.QuestionCategories.Find(i);
                DbContext.QuestionCategories.Remove(category);
            }
            return DbContext.SaveChanges();
        }

        public IEnumerable<User> GetAllUser()
        {
            return DbContext.Users.ToList();
        }

        public IEnumerable<QuestionCategory> SearchCategories(string txtSearch)  
        {
                 var listSearchCategory = from category in DbContext.QuestionCategories
                                     where category.Name.Contains(txtSearch) || category.CreatedDate.ToString().Contains(txtSearch)
                                           
                                          select category;
                 
            return listSearchCategory.ToList();
        }

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

    public interface IQuestionCategoryRepository : IRepository<QuestionCategory>
    {
        IEnumerable<User> GetAllUser();
        int AddCategoryQuestion(QuestionCategory questionCategory);
        int UpdateCategoryQuestion(QuestionCategory questionCategory);
        int DeleteQuestionCategory(int[] dsxoa);
        IEnumerable<QuestionCategory> SearchCategories(string txtSearch);
        int Delete(int id);

    }
}
