using System.Collections.Generic;
using System.Web.Mvc;
using TestingSystem.Sevice;
using TestingSystem.Models;
using TestingSystem.DataTranferObject.Question;
using System.Net;

namespace TestingSystem.Areas.Admin.Controllers.Question
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }
        public ActionResult Index(QuestionFilterModel questionFilter)
        {
            //Test  Data
            List<QuestionCategory> listCategory = new List<QuestionCategory>();
            listCategory.Add(new QuestionCategory { CategoryID = 1, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "C#" });
            listCategory.Add(new QuestionCategory { CategoryID = 2, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "Java" });
            List<Level> listLevels = new List<Level>();
            listLevels.Add(new Level { LevelId = 1, LevelStep = 1, Name = "Easy" });
            listLevels.Add(new Level { LevelId = 2, LevelStep = 2, Name = "Normal" });
            listLevels.Add(new Level { LevelId = 3, LevelStep = 3, Name = "Hard" });
            //get all category
            ViewBag.listCategory = listCategory;
            //get all level
            ViewBag.listLevel = listLevels;
            var listQuetion = questionService.FilterQuestions(questionFilter);
            return View(listQuetion);
        }
        public ActionResult Search(string input)
        {
            List<QuestionCategory> listCategory = new List<QuestionCategory>();
            listCategory.Add(new QuestionCategory { CategoryID = 1, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "C#" });
            listCategory.Add(new QuestionCategory { CategoryID = 2, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "Java" });
            List<Level> listLevels = new List<Level>();
            listLevels.Add(new Level { LevelId = 1, LevelStep = 1, Name = "Easy" });
            listLevels.Add(new Level { LevelId = 2, LevelStep = 2, Name = "Normal" });
            listLevels.Add(new Level { LevelId = 3, LevelStep = 3, Name = "Hard" });

            ViewBag.listCategory = listCategory;
            ViewBag.listLevel = listLevels;

            var listQuetion = questionService.SearchByContent(input);
            return View(listQuetion);
        }

        public ActionResult Filter(QuestionFilterModel questionFilter)
        {
            List<QuestionCategory> listCategory = new List<QuestionCategory>();
            listCategory.Add(new QuestionCategory { CategoryID = 1, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "C#" });
            listCategory.Add(new QuestionCategory { CategoryID = 2, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "Java" });
            List<Level> listLevels = new List<Level>();
            listLevels.Add(new Level { LevelId = 1, LevelStep = 1, Name = "Easy" });
            listLevels.Add(new Level { LevelId = 2, LevelStep = 2, Name = "Normal" });
            listLevels.Add(new Level { LevelId = 3, LevelStep = 3, Name = "Hard" });

            ViewBag.listCategory = listCategory;
            ViewBag.listLevel = listLevels;
            var listQuestion = questionService.FilterQuestions(questionFilter);
            return View(listQuestion);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var question = questionService.FindID(id);
                if (question == null)
                {
                    return PartialView("~/Areas/Admin/Views/Question/NotFound.cshtml");
                }
                {                  
                    return View(question);
                }
            }

        }
        public JsonResult Delete(int id)
        {
            Models.Question myQuestion = questionService.GetQuetionById(id);
            if (myQuestion != null)
            {
                questionService.DeleteQuestion(id);
                return Json(new
                {
                    status = true,
                    JsonRequestBehavior.AllowGet
                });
            }
            return Json(new
            {
                status = false,
                JsonRequestBehavior.AllowGet
            });
        }
    }
}