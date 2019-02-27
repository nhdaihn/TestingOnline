using System.Collections.Generic;
using System.Web.Mvc;
using TestingSystem.DataTranferObject;
using TestingSystem.Sevice;
using TestingSystem.Models;
using System.Linq;

namespace TestingSystem.Areas.Admin.Controllers.ExamPaper
{
    public class ExamPaperController : Controller
    {
        private readonly IExamPaperService examPaperService;

        public ActionResult ExamPapers()
        {
            return View();
        }

        public ActionResult GetExamPapers()
        {
            var examPapers = new List<TestingSystem.Models.ExamPaper>();
            examPapers = examPaperService.GetAll().ToList();
            return Json(new { data = examPapers }, JsonRequestBehavior.AllowGet);
        }


        public ExamPaperController(IExamPaperService examPaperService)
        {
            this.examPaperService = examPaperService;
        }
        // GET: Admin/ExamPaper
        [HttpGet]
        public ActionResult Index(ExamPaperFilterModel examPaperFilterModel)
        {

            return View(examPaperService.Filter(examPaperFilterModel));
            //return View(examPaperService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.ExamPaper examPaper)
        {
            if (examPaperService.Create(examPaper).Equals("success"))
            {
                return RedirectToAction("Index", "ExamPaper");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View(examPaperService.Details(id));
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                if (examPaperService.Delete(id).Equals("success"))
                {
                    return RedirectToAction("Index", "ExamPaper");
                }
                else
                {
                    ViewBag.DeleteError = "Delete Error";
                    return RedirectToAction("Index", "ExamPaper");
                }
            }
            else
            {
                ViewBag.DeleteError = "Exam Paper does not exist ";
                return RedirectToAction("Index", "ExamPaper");
            }


        }


    }
}