using System.Collections.Generic;
using System.Web.Mvc;
using TestingSystem.Sevice;
using TestingSystem.Models;
using TestingSystem.DataTranferObject.Question;
using System.Net;
using System.Web;
using System.IO;
using System.Linq;
using System;

namespace TestingSystem.Areas.Admin.Controllers.Question
{
    public class QuestionController : BaseController
    {
        private readonly IQuestionService questionService;
        private readonly IAnswerService answerService;
        private readonly IQuestionCategorySevice questionCategorySevice;

        public QuestionController(IQuestionService questionService, IAnswerService answerService, IQuestionCategorySevice questionCategorySevice)
        {
            this.questionService = questionService;
            this.answerService = answerService;
            this.questionCategorySevice = questionCategorySevice;
        }
        [HttpPost]
        public JsonResult AddCategory(Models.QuestionCategory category)
        {
            //fix cung
            category.ModifiedBy = 1;
            category.CreatedBy = 1;
            return Json(questionCategorySevice.AddCategoryQuestion(category), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Questions()
        {
            var listCategory = questionCategorySevice.GetAllQuestionCategories();
            var listLevels = questionService.GetAlLevels();
            ViewData["Category"] = listCategory;
            ViewData["Level"] = listLevels;
            return View();
        }
        [ActionName("GetQuestions")]
        public ActionResult GetQuestions()
        {        
            // đổi thành filter.
            var listQuestionDtos = questionService.GetAllQuestionDtos();
            return Json(new { data = listQuestionDtos.OrderBy(x => x.CategoryID) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string input)
        {
            List<Models.QuestionCategory> listCategory = new List<Models.QuestionCategory>();
            listCategory.Add(new Models.QuestionCategory { CategoryID = 8, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "C#" });
            listCategory.Add(new Models.QuestionCategory { CategoryID = 10, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "Java" });
            List<Level> listLevels = new List<Level>();
            listLevels.Add(new Level { LevelId = 1, LevelStep = 1, Name = "Easy" });
            listLevels.Add(new Level { LevelId = 2, LevelStep = 2, Name = "Normal" });
            listLevels.Add(new Level { LevelId = 3, LevelStep = 3, Name = "Hard" });

            ViewBag.listCategory = listCategory;
            ViewBag.listLevel = listLevels;

            var listQuetion = questionService.SearchByContent(input);
            return View(listQuetion);
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

        [HttpGet]
        [ActionName("GetQuestionID")]
        public ActionResult GetQuestionID(int? questionId)
        {
            if (questionId > 0)
            {

                return View(questionService.FindID(questionId));
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ViewBag.Status = model.Status;
            //ViewBag.IsUpdate = true;

        }

        [HttpGet]
        public ActionResult Delete(List<int> ids)
        {
            try
            {
                if (ids.Count > 0)
                {
                    int i = 0;
                    foreach (var id in ids)
                    {
                        if (questionService.DeleteQuestion(id) > 0)
                        {
                            i++;
                            continue;
                        }
                        else
                        {
                            //!!!!!!!!!!! break nhưng mà những cái record trc đó vẫn đã bị xóa
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
            catch (System.Exception exception)
            {
                Failure = exception.Message;
                return Json(new { status = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Create()
        {
            // This is only for show by default one row for insert data to the database
            List<Answer> answers = new List<Answer>
            {
                new Answer() { AnswerID = 0, AnswerContent = "", IsCorrect = false },
                new Answer() { AnswerID = 0, AnswerContent = "", IsCorrect = false },
            };
            //get all category
            var listCategory = questionCategorySevice.GetAllQuestionCategories();
            //get all level
            var listLevels = questionService.GetAlLevels();
            ViewData["Category"] = listCategory;
            ViewData["Level"] = listLevels;
            return View(answers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Models.Question question, HttpPostedFileBase Image, List<Answer> listAnswers)
        {
            Session["CreatedBy"] = 1;
            Session["ModifiedBy"] = 1;
            question.CreatedBy = Convert.ToInt32(Session["CreatedBy"]);
            question.ModifiedBy = Convert.ToInt32(Session["ModifiedBy"]);
            if (Image != null && Image.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Content/QuestionUpload/Images/"), Path.GetFileName(Image.FileName));
                Image.SaveAs(filePath);
                question.Image = Image.FileName;
            }
            else
            {
                question.Image = null;
            }
            var addQuestion = questionService.AddQuestion(question);
            TranferID.ID = addQuestion;
            // Create Answer
            foreach (var i in listAnswers)
            {
                i.QuestionID = TranferID.ID;
                if (i.QuestionID <= 0)
                {
                    return RedirectToAction("Create", "Question");
                }
                else
                {
                    answerService.AddAnswer(i);
                }
            }

            return RedirectToAction("Questions");

            //ViewBag.questionContent = question.Content;
            //ViewBag.questionID = question.QuestionID;

        }

        //public ActionResult CreateAnswer()
        //{

        //    // This is only for show by default one row for insert data to the database
        //    List<Answer> answers = new List<Answer> { new Answer() { AnswerID = 0, AnswerContent = "", IsCorrect = false } };
        //    return View(answers);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateAnswer(List<Answer> listAnswers)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (var i in listAnswers)
        //        {
        //            i.QuestionID = TranferID.ID;
        //            if (i.QuestionID <= 0)
        //            {
        //                return RedirectToAction("Create", "Question");
        //            }
        //            else
        //            {
        //                answerService.AddAnswer(i);
        //            }
        //        }

        //        ViewBag.Message = "Data successfully saved!";
        //        ModelState.Clear();
        //    }

        //    return RedirectToAction("Questions");
        //}

        public ActionResult Edit(int? id)
        {
            var listCategory = questionCategorySevice.GetAll();
            var listLevels = questionService.GetAlLevels();
            ViewBag.listCategory = listCategory;
            ViewBag.listLevel = listLevels;
            //Get Answer.
            var listAnswerByQuestionID = questionService.GetAnswersAndQuestion(id);
            ViewBag.listAnswerByQuestionID = listAnswerByQuestionID;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                // dto
                QuestionAnswerDTO mymodel = new QuestionAnswerDTO();
                var question = questionService.FindID(id);
                var answer = questionService.GetAnswersAndQuestion(id);
                ViewBag.Answer = answer;
                mymodel.Question = question;
                mymodel.Answers = answer.ToList();
                //
                if (question == null)
                {
                    return PartialView("~/Areas/Admin/Views/Question/NotFound.cshtml");
                }
                {
                    return View(question);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Models.Question question, HttpPostedFileBase Image, string[] AnswerContent, string[] IsCorrect)
        {
            //fix cung
            question.ModifiedBy = 1;
            question.CreatedBy = 1;
            //
            if (Image != null && Image.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Content/QuestionUpload/Images/"), Path.GetFileName(Image.FileName));
                Image.SaveAs(filePath);
                question.Image = Image.FileName;
            }
            else
            {
                var img = questionService.FindID(question.QuestionID).Image;
                question.Image = img;
            }
            questionService.UpdateQuestion(question);
            //
            //foreach (Answer item in listAnswers)
            //{
            //    if (item.QuestionID <= 0)
            //    {
            //        return RedirectToAction("Edit", "Question");
            //    }
            //    else
            //    {
            //        answerService.UpdateAnswer(item);
            //    }
            //}

            return RedirectToAction("Questions");
        }

        public ActionResult GetQuestionsByExamPaperId(int examPaperId)
        {
            var questions = new List<TestingSystem.DataTranferObject.Question.QuestionDto>();
            questions = questionService.GetQuestionsByExamPaperId(examPaperId).ToList();

            return Json(new { data = questions }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetQuestionsByQuestionCategoryIdAndExamPaperId(int categoryId, int examPaperId)
        {
            var questions = new List<TestingSystem.DataTranferObject.Question.QuestionDto>();
            questions = questionService.GetQuestionsByQuestionCategoryIdAndExamPaperId(categoryId, examPaperId).ToList();

            return Json(new { data = questions }, JsonRequestBehavior.AllowGet);
        }
    }
}