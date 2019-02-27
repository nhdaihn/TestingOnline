using System.Collections.Generic;
using System.Web.Mvc;
using TestingSystem.Sevice;
using System.Linq;
using System;

namespace TestingSystem.Areas.Admin.Controllers.ExamPaper
{
    public class ExamPaperController : BaseController
    {
        private readonly IExamPaperService examPaperService;

        public ExamPaperController(IExamPaperService examPaperService)
        {
            this.examPaperService = examPaperService;
        }

       
        public ActionResult ExamPapers()
        {
            return View();
        }

        [ActionName("GetExamPapers")]
        public ActionResult GetExamPapers()
        {
            var examPapers = new List<TestingSystem.Models.ExamPaper>();
            examPapers = examPaperService.GetAll().ToList();
            return Json(new { data = examPapers }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [ActionName("ExamPaper")]
        public ActionResult ExamPaper(int? examPaperId)
        {
            var model = new Models.ExamPaper();

            if (examPaperId == null || examPaperId == 0)
            {
                ViewBag.IsUpdate = false;
                return View(model);
            }
            model = examPaperService.GetExamPaperById(examPaperId.Value);
            if (model != null)
            {

            }
            ViewBag.Status = model.Status;
            ViewBag.IsUpdate = true;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ExamPaper")]
        public ActionResult ExamPaper(Models.ExamPaper examPaper)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (examPaper.ExamPaperID == 0)
                    {
                        examPaper.CreatedDate = DateTime.Now;
                        examPaper.CreatedBy = 1;
                        examPaper.ModifiedBy = 1;
                        if (examPaperService.Create(examPaper) > 0)
                        {
                            Success = "Insert exam paper successfully!";
                            return RedirectToAction("ExamPapers");
                        }
                    }
                    else
                    {
                        examPaper.ModifiedDate = DateTime.Now;
                        examPaper.ModifiedBy = 1;
                        if (examPaperService.Edit(examPaper) > 0)
                        {
                            Success = "Update exam paper successfully!";
                            return RedirectToAction("ExamPapers");
                        }
                    }
                }
                Failure = "Something went wrong, please try again!";
                return new JsonResult { Data = new { status = false } };
            }
            catch (Exception exception)
            {
                Failure = exception.Message;
                return View(examPaper);
            }
        }

        public ActionResult Delete(List<int> ids)
        {
            try
            {
                if (ids.Count > 0)
                {
                    int i = 0;
                    foreach (var id in ids)
                    {
                        if (examPaperService.Delete(id) > 0)
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
            catch (Exception exception)
            {
                Failure = exception.Message;
                return Json(new { status = false }, JsonRequestBehavior.AllowGet);
            }
        }

        //// GET: Admin/ExamPaper
        //[HttpGet]
        //public ActionResult Index(ExamPaperFilterModel examPaperFilterModel)
        //{

        //    return View(examPaperService.Filter(examPaperFilterModel));
        //    //return View(examPaperService.GetAll());
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(Models.ExamPaper examPaper)
        //{
        //    if (examPaperService.Create(examPaper).Equals("success"))
        //    {
        //        return RedirectToAction("Index", "ExamPaper");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //public ActionResult Details(int id)
        //{
        //    return View(examPaperService.GetExamPaperById(id));
        //}
    }
}