using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingSystem.Sevice;
using TestingSystem.Models;
using PagedList;

namespace TestingSystem.Areas.Admin.Controllers.QuestionCategory
{
    public class QuestionCategoryController : BaseController
    {
        // GET: Admin/QuestionCategory
        public readonly IQuestionCategorySevice questionCategorySevice;

        public QuestionCategoryController(IQuestionCategorySevice questionCategorySevice)
        {
            this.questionCategorySevice = questionCategorySevice;
        }
        public ActionResult Index(/*string txtSearch, int? page*/)
        {
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //var listCategory = questionCategorySevice.GetAll();
            //if (!String.IsNullOrEmpty(txtSearch))
            //{
            //    var listQuestionCategory = questionCategorySevice.Search(txtSearch);
            //    return View(listQuestionCategory.ToPagedList(pageNumber, pageSize));

            //}
            //else
            //{
            //    ModelState.AddModelError("", "khong tim thay ket qua " + txtSearch);
            //}

            //var listCategories = new List<TestingSystem.Models.QuestionCategory>();
            //listCategories = questionCategorySevice.GetAll().ToList();
            //return Json(new { data = listCategories }, JsonRequestBehavior.AllowGet);
            //return View(listCategory);
            return View();


        }
        [ActionName("GetCategories")]
        public ActionResult GetCategories( /*string txtSearch, int? page*/)
        {
            var listCategories = new List<Models.QuestionCategory>();
            listCategories = questionCategorySevice.GetAll().ToList();
            return Json(new { data = listCategories }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddCategory()
        {
            setviewbagcreatedby();
            setviewbagmodifiedby();

            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Models.QuestionCategory category)
        {
            //category.CreatedBy =
            //cate.createddate = 
            category.ModifiedBy = 1;
            setviewbagcreatedby();
            setviewbagmodifiedby();
            try
            {
                if (ModelState.IsValid)
                {
                    if (category.CategoryID == 0)
                    {
                        
                        if (questionCategorySevice.AddCategoryQuestion(category) > 0)
                        {
                            Success = "Insert question category successfully!";
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        //category.ModifiedDate = DateTime.Now;
                        category.ModifiedBy = 1;
                        if (questionCategorySevice.UpdateCategoryQuestion(category) > 0)
                        {
                            Success = "Update exam paper successfully!";
                            return RedirectToAction("Index");
                        }
                    }
                }
                Failure = "Something went wrong, please try again!";
                return new JsonResult { Data = new { status = false } };
            }
            catch (Exception exception)
            {
                Failure = exception.Message;
                return View(category);
            }

            //return View();
        }

        public void setviewbagcreatedby(long? selectedid = null)
        {
            ViewBag.createdby = new SelectList(questionCategorySevice.GetAllUser(), "userid", "username", selectedid);
        }
        public void setviewbagmodifiedby(long? selectedid = null)
        {
            ViewBag.modifiedby = new SelectList(questionCategorySevice.GetAllUser(), "userid", "username", selectedid);
        }
        public ActionResult EditCategory(int questionCategory)
        {
            setviewbagcreatedby();
            setviewbagmodifiedby();
            var list = questionCategorySevice.GetById(questionCategory);

            return View(list);
        }
        [HttpPost]
        public ActionResult EditCategory(Models.QuestionCategory questionCategory)
        {

            //var a =  Questioncategory(questionCategory.id)

            //a.Name = questionCategory.Name;
            //a.isactive
            //a..modifiledDate = date
            //a. 


            questionCategory.ModifiedBy = 1;
            setviewbagcreatedby();
            setviewbagmodifiedby();
            try
            {
                if (ModelState.IsValid)
                {
                   

                        if (questionCategorySevice.UpdateCategoryQuestion(questionCategory) > 0)
                        {
                            Success = "Update question category successfully!";
                            return RedirectToAction("Index");
                        }
                    
                    else
                    {
                        //category.ModifiedDate = DateTime.Now;
                        Success = "Update question category false!";
                    }
                }
                Failure = "Something went wrong, please try again!";
                return new JsonResult { Data = new { status = false } };
            }
            catch (Exception exception)
            {
                Failure = exception.Message;
                return View(questionCategory);
            }
        }

        //public ActionResult Delete(int[] dsxoa)
        //{
        //    setviewbagcreatedby();
        //    setviewbagmodifiedby();
        //    questionCategorySevice.DeleteQuestionCategory(dsxoa);

        //    return RedirectToAction("Index", "QuestionCategory");
        //}
        public ActionResult Delete(List<int> ids)
        {
            try
            {
                if (ids.Count > 0)
                {
                    int i = 0;
                    foreach (var id in ids)
                    {
                        if (questionCategorySevice.Delete(id) > 0)
                        {
                            i++;
                            continue;
                        }
                        else
                        {
                            
                            break;
                        }

                    }
                    if (i > 0)
                    {
                        Success = "Delete exam paper successfully!";
                        return Json(new { status = true }, JsonRequestBehavior.AllowGet);
                    }
                }
                Failure = "Something went wrong, please try again!";
                return Json(new { status = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                Failure = exception.Message;
                return Json(new { status = false }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}