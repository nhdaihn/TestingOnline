﻿using System.Collections.Generic;
using System.Web.Mvc;
using TestingSystem.Sevice;
using TestingSystem.Models;
using TestingSystem.DataTranferObject.Question;
using System.Net;
using System.Web;
using System.IO;

namespace TestingSystem.Areas.Admin.Controllers.Question
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService questionService;
        private readonly IAnswerService answerService;

        public QuestionController(IQuestionService questionService, IAnswerService answerService)
        {
            this.questionService = questionService;
            this.answerService = answerService;
        }
        public ActionResult Index(QuestionFilterModel questionFilter)
        {
            //Test  Data
            List<Models.QuestionCategory> listCategory = new List<Models.QuestionCategory>();
            listCategory.Add(new Models.QuestionCategory { CategoryID = 8, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "C#" });
            listCategory.Add(new Models.QuestionCategory { CategoryID = 10, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "Java" });
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
        public ActionResult Delete(int id)
        {
            var question = questionService.DeleteQuestion(id);
            if (question)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error!!");
                return View();
            }
        }
        public ActionResult Create()
        {
            List<Models.QuestionCategory> listCategory = new List<Models.QuestionCategory>();
            listCategory.Add(new Models.QuestionCategory { CategoryID = 8, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "C#" });
            listCategory.Add(new Models.QuestionCategory { CategoryID = 10, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "Java" });

            List<Level> listLevels = new List<Level>();
            listLevels.Add(new Level { LevelId = 1, LevelStep = 1, Name = "Easy" });
            listLevels.Add(new Level { LevelId = 2, LevelStep = 2, Name = "Normal" });
            listLevels.Add(new Level { LevelId = 3, LevelStep = 3, Name = "Hard" });

            //get all category
            ViewBag.listCategory = listCategory;
            //get all level
            ViewBag.listLevel = listLevels;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Models.Question question, HttpPostedFileBase Image, Answer answer)
        {

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
            if (questionService.AddQuestion(question) > 0)
            {
                
                answer.QuestionID = questionService.AddQuestion(question);
                answerService.AddAnswer(answer);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error!");
            }

           

            return View(question);

        }
        public ActionResult Edit(int? id)
        {
            List<Models.QuestionCategory> listCategory = new List<Models.QuestionCategory>();
            listCategory.Add(new Models.QuestionCategory { CategoryID = 8, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "C#" });
            listCategory.Add(new Models.QuestionCategory { CategoryID = 10, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "Java" });
            listCategory.Add(new Models.QuestionCategory { CategoryID = 11, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "Python" });

            List<Level> listLevels = new List<Level>();
            listLevels.Add(new Level { LevelId = 1, LevelStep = 1, Name = "Easy" });
            listLevels.Add(new Level { LevelId = 2, LevelStep = 2, Name = "Normal" });
            listLevels.Add(new Level { LevelId = 3, LevelStep = 3, Name = "Hard" });

            //get all category
            ViewBag.listCategory = listCategory;
            //get all level
            ViewBag.listLevel = listLevels;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Models.Question question, HttpPostedFileBase Image)
        {
            if (Image != null && Image.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Content/QuestionUpload/Images/"), Path.GetFileName(Image.FileName));
                Image.SaveAs(filePath);
                question.Image = Image.FileName;
            }
            else
            {
                var img = questionService.GetQuetionById(question.QuestionID).Image;
                question.Image = img;
            }
            questionService.UpdateQuestion(question);
            return RedirectToAction("Index");
        }
    }
}