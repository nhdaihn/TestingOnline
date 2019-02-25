using System.Web.Mvc;
using System.Web.UI.WebControls;
using TestingSystem.Sevice;
using TestingSystem.Models;

namespace TestingSystem.Areas.Admin.Controllers.ExamPaper
{
    public class ExamPaperController : Controller
    {
        private readonly IExamPaperService examPaperService;

        public ExamPaperController(IExamPaperService examPaperService)
        {
            this.examPaperService = examPaperService;
        }
        // GET: Admin/ExamPaper
        public ActionResult Index()
        {
            return View(examPaperService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.ExamPaper examPaper)
        {
            examPaperService.Create(examPaper);
            
            return View();
        }

        public ActionResult Detail(int id)
        {
            examPaperService.Detail(id);
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}