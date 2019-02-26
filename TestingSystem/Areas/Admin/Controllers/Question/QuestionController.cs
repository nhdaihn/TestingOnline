using System.Collections.Generic;
using System.Web.Mvc;
using TestingSystem.Sevice;
using TestingSystem.Models;
using TestingSystem.DataTranferObject.Question;

namespace TestingSystem.Areas.Admin.Controllers.Question
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            //Test  Data
            List<QuestionCategory> listCategory = new List<QuestionCategory>();
            listCategory.Add(new QuestionCategory { CategoryID = 1, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "C#" });
            listCategory.Add(new QuestionCategory { CategoryID = 2, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "Java" });
            List<Level> listLevels = new List<Level>();
            listLevels.Add(new Level { LevelId = 1, LevelStep = 1, Name = "Easy" });
            listLevels.Add(new Level { LevelId = 2, LevelStep = 2, Name = "Normal" });
            listLevels.Add(new Level { LevelId = 3, LevelStep = 3, Name = "Hard" });

            ViewBag.listCategory = listCategory;
            ViewBag.listLevel = listLevels;
            ViewBag.list = questionService.GetAllQuestion();
            return View();
        }
        [HttpPost]
        public ActionResult Index(QuestionFilterModel searchModel)
        {
            var model = questionService.FilterQuestions(searchModel);
            return View(model);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            Models.Question myQuestion = questionService.GetById(id);
            if (myQuestion != null)
            {
                questionService.DeleteQuestion(myQuestion);
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