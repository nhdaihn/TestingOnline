namespace TestingSystem.Areas.Admin.Controllers.Question
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using TestingSystem.DataTranferObject.Question;
    using TestingSystem.Models;
    using TestingSystem.Sevice;
    using Excel = Microsoft.Office.Interop.Excel;

    /// <summary>
    /// Defines the <see cref="QuestionController" />
    /// </summary>
    public class QuestionController : BaseController, IDisposable
    {
        /// <summary>
        /// Defines the questionService
        /// </summary>
        private readonly IQuestionService questionService;

        /// <summary>
        /// Defines the answerService
        /// </summary>
        private readonly IAnswerService answerService;

        /// <summary>
        /// Defines the questionCategorySevice
        /// </summary>
        private readonly IQuestionCategorySevice questionCategorySevice;

        /// <summary>
        /// Defines the examPaperService
        /// </summary>
        private readonly IExamPaperService examPaperService;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionController"/> class.
        /// </summary>
        /// <param name="questionService">The questionService<see cref="IQuestionService"/></param>
        /// <param name="answerService">The answerService<see cref="IAnswerService"/></param>
        /// <param name="questionCategorySevice">The questionCategorySevice<see cref="IQuestionCategorySevice"/></param>
        /// <param name="examPaperService">The examPaperService<see cref="IExamPaperService"/></param>
        public QuestionController(IQuestionService questionService, IAnswerService answerService,
            IQuestionCategorySevice questionCategorySevice, IExamPaperService examPaperService)
        {
            this.questionService = questionService;
            this.answerService = answerService;
            this.questionCategorySevice = questionCategorySevice;
            this.examPaperService = examPaperService;
        }

        /// <summary>
        /// The AddCategory
        /// </summary>
        /// <param name="category">The category<see cref="Models.QuestionCategory"/></param>
        /// <returns>The <see cref="JsonResult"/></returns>
        [HttpPost]
        public JsonResult AddCategory(Models.QuestionCategory category)
        {
            //fix cung
            category.ModifiedBy = 1;
            category.CreatedBy = 1;
            // Default is true when create in CreateQuesiton View
            category.IsActive = true;
            return Json(questionCategorySevice.AddCategoryQuestion(category), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The Questions
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Questions()
        {
            var listCategory = questionCategorySevice.GetAllQuestionCategories();
            var listLevels = questionService.GetAlLevels();
            ViewData["Category"] = listCategory;
            ViewData["Level"] = listLevels;
            return View();
        }

        /// <summary>
        /// The GetQuestions
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        [ActionName("GetQuestions")]
        public ActionResult GetQuestions()
        {
            // đổi thành filter.
            var listQuestionDtos = questionService.GetAllQuestionDtos();
            return Json(new { data = listQuestionDtos.OrderBy(x => x.CategoryID) }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="input">The input<see cref="string"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Search(string input)
        {
            List<Models.QuestionCategory> listCategory = new List<Models.QuestionCategory>();
            listCategory.Add(new Models.QuestionCategory
            { CategoryID = 8, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "C#" });
            listCategory.Add(new Models.QuestionCategory
            { CategoryID = 10, IsActive = true, CreatedBy = 1, ModifiedBy = 1, Name = "Java" });
            List<Level> listLevels = new List<Level>();
            listLevels.Add(new Level { LevelId = 1, LevelStep = 1, Name = "Easy" });
            listLevels.Add(new Level { LevelId = 2, LevelStep = 2, Name = "Normal" });
            listLevels.Add(new Level { LevelId = 3, LevelStep = 3, Name = "Hard" });

            ViewBag.listCategory = listCategory;
            ViewBag.listLevel = listLevels;

            var listQuetion = questionService.SearchByContent(input);
            return View(listQuetion);
        }

        /// <summary>
        /// The Detail
        /// </summary>
        /// <param name="id">The id<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                ViewBag.listAnswerByQuestion = answerService.GetAnswersByQuestionID(id);
                var question = questionService.GetQuestionInQuestionDTO(id);
                if (question == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                {
                    return View(question);
                }
            }
        }

        /// <summary>
        /// The GetQuestionID
        /// </summary>
        /// <param name="questionId">The questionId<see cref="int?"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
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
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="ids">The ids<see cref="List{int}"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
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

        /// <summary>
        /// The Create
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
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

        /// <summary>
        /// The Create
        /// </summary>
        /// <param name="question">The question<see cref="Models.Question"/></param>
        /// <param name="Image">The Image<see cref="HttpPostedFileBase"/></param>
        /// <param name="listAnswers">The listAnswers<see cref="List{Answer}"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Models.Question question, HttpPostedFileBase Image, List<Answer> listAnswers)
        {
            //using (TransactionScope transaction = new TransactionScope())
            //{
            //    transaction.Complete();
            //}
            Session["CreatedBy"] = 1;
            Session["ModifiedBy"] = 1;
            question.CreatedBy = Convert.ToInt32(Session["CreatedBy"]);
            question.ModifiedBy = Convert.ToInt32(Session["ModifiedBy"]);
            if (Image != null && Image.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Content/QuestionUpload/Images/"),
                    Path.GetFileName(Image.FileName));
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
        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Edit(int id)
        {
            var listCategory = questionCategorySevice.GetAll();
            var listLevels = questionService.GetAlLevels();
            ViewBag.listCategory = listCategory;
            ViewBag.listLevel = listLevels;
            //Get Answer.
            var listAnswerByQuestionID = questionService.GetAnswersByQuestionId(id);
            ViewBag.listAnswerByQuestionID = listAnswerByQuestionID;

            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                // dto
                QuestionAnswerDTO mymodel = new QuestionAnswerDTO();
                var question = questionService.FindID(id);
                var answer = questionService.GetAnswersByQuestionId(id);
                ViewBag.Answer = answer;
                mymodel.Question = question;
                mymodel.Answers = answer.ToList();
                //
                if (question == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                {
                    return View(question);
                }
            }
        }

        /// <summary>
        /// The Edit
        /// </summary>
        /// <param name="question">The question<see cref="Models.Question"/></param>
        /// <param name="Image">The Image<see cref="HttpPostedFileBase"/></param>
        /// <param name="AnswerID">The AnswerID<see cref="int[]"/></param>
        /// <param name="AnswerContent">The AnswerContent<see cref="string[]"/></param>
        /// <param name="IsCorrect">The IsCorrect<see cref="string[]"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Models.Question question, HttpPostedFileBase Image, int[] AnswerID, string[] AnswerContent, string[] IsCorrect)
        {
            List<Answer> listAnswer = new List<Answer>();
            for (int i = 0; i < AnswerID.Length; i++)
            {
                Answer answer = new Answer();
                answer.AnswerID = AnswerID[i];
                answer.AnswerContent = AnswerContent[i];
                answer.IsCorrect = IsCorrect.Contains(AnswerContent[i]);
                listAnswer.Add(answer);
            }
            //fix cung
            question.ModifiedBy = 1;
            question.CreatedBy = 1;
            //
            if (Image != null && Image.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/Content/QuestionUpload/Images/"),
                    Path.GetFileName(Image.FileName));
                Image.SaveAs(filePath);
                question.Image = Image.FileName;
            }
            else
            {
                var img = questionService.FindID(question.QuestionID).Image;
                question.Image = img;
            }

            questionService.UpdateQuestion(question);

            foreach (var item in listAnswer)
            {
                item.QuestionID = question.QuestionID;
                if (item.QuestionID <= 0)
                {
                    return RedirectToAction("Edit", "Question");
                }
                else
                {

                    answerService.UpdateAnswer(item);
                }
            }

            return RedirectToAction("Questions");
        }

        /// <summary>
        /// The GetQuestionsByExamPaperId
        /// </summary>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult GetQuestionsByExamPaperId(int examPaperId)
        {
            var questions = new List<TestingSystem.DataTranferObject.Question.QuestionDto>();
            questions = questionService.GetQuestionsByExamPaperId(examPaperId).ToList();

            return Json(new { data = questions }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The GetQuestionsByQuestionCategoryIdAndExamPaperId
        /// </summary>
        /// <param name="categoryId">The categoryId<see cref="int"/></param>
        /// <param name="examPaperId">The examPaperId<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult GetQuestionsByQuestionCategoryIdAndExamPaperId(int categoryId, int examPaperId)
        {
            var questions = new List<TestingSystem.DataTranferObject.Question.QuestionDto>();
            questions = questionService.GetQuestionsByQuestionCategoryIdAndExamPaperId(categoryId, examPaperId)
                .ToList();

            return Json(new { data = questions }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The QuestionExcelAnswer
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult QuestionExcelAnswer()
        {
            return View();
        }

        /// <summary>
        /// The QuestionExcelAnswer
        /// </summary>
        /// <param name="excelfile">The excelfile<see cref="HttpPostedFileBase"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        public ActionResult QuestionExcelAnswer(HttpPostedFileBase excelfile)
        {
            if (excelfile == null)
            {
                ViewBag.ThongBao = "Please choose excel file to import exam paper!";
                return View();
            }
            else
            {
                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    string path = Path.Combine(Server.MapPath("~/FileExcel/"),
                        Guid.NewGuid().ToString() + Path.GetExtension(excelfile.FileName));
                    excelfile.SaveAs(path);
                    Excel.Application application = new Excel.Application
                    {
                        Visible = true
                    };
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.Sheets[@"ExamPaper"];
                    Excel.Range range = worksheet.UsedRange;


                    Models.ExamPaper examPaper = new Models.ExamPaper();
                    examPaper.Title = ((Excel.Range)range.Cells[3, 1]).Text;
                    examPaper.Time = int.Parse(((Excel.Range)range.Cells[4, 1]).Text);
                    examPaper.Status = Boolean.Parse(((Excel.Range)range.Cells[6, 1]).Text);
                    examPaper.IsActive = Boolean.Parse(((Excel.Range)range.Cells[5, 1]).Text);
                    examPaper.CreatedBy = 1;
                    examPaper.CreatedDate = DateTime.Now;
                    examPaper.ModifiedBy = 1;
                    examPaper.ModifiedDate = DateTime.Now;
                    int result = examPaperService.Create(examPaper);

                    for (int row = 11; row <= range.Rows.Count; row++)
                    {
                        Models.Question question = new Models.Question
                        {
                            Content = ((Excel.Range)range.Cells[row, 1]).Text,
                            Level = int.Parse(((Excel.Range)range.Cells[row, 2]).Text),
                            CategoryID = int.Parse(((Excel.Range)range.Cells[row, 3]).Text),
                            IsActive = true,
                            CreatedBy = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = 1,
                            ModifiedDate = DateTime.Now
                        };
                        int questionId = questionService.AddQuestion(question);

                        Answer answer = new Answer();
                        int j = 5;
                        for (int i = 4; i <= 13; i += 2)
                        {
                            string content = ((Excel.Range)range.Cells[row, i]).Text;
                            if (content != "")
                            {
                                answer.AnswerContent = content;
                                answer.IsCorrect = Boolean.Parse(((Excel.Range)range.Cells[row, j]).Text);
                                answer.QuestionID = questionId;
                                answerService.AddAnswer(answer);
                            }
                            else
                            {
                                continue;
                            }
                            j += 2;
                        }

                    }
                    return RedirectToAction("Questions");
                }
                else
                {
                    ViewBag.ThongBao = "Please choose excel file to import exam paper!";
                    return View();
                }
            }
        }
    }
}
