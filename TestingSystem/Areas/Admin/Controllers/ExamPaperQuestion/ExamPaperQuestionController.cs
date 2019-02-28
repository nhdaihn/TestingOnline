using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingSystem.Sevice;

namespace TestingSystem.Areas.Admin.Controllers.ExamPaperQuestion
{
    public class ExamPaperQuestionController : BaseController
    {
        private readonly IExamPaperQuestionService examPaperQuestionService;

        public ExamPaperQuestionController(IExamPaperQuestionService examPaperQuestionService)
        {
            this.examPaperQuestionService = examPaperQuestionService;
        }

        public ActionResult GetExamPaperQuestionsByExamPaperId(int examPaperId)
        {
            var examPaperQuestions = new List<TestingSystem.Models.ExamPaperQuesion>();
            examPaperQuestions = examPaperQuestionService.GetExamPaperQuestionsByExamPaperId(examPaperId).ToList();
            return Json(new { data = examPaperQuestions }, JsonRequestBehavior.AllowGet);
        }
    }
}