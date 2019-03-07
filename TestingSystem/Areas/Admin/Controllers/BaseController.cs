namespace TestingSystem.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="BaseController" />
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Sets the Title
        /// </summary>
        public string Title
        {
            set { ViewBag.Title = value; }
        }

        /// <summary>
        /// Sets the Success
        /// </summary>
        public string Success
        {
            set { TempData["Success"] = ViewData["Success"] = value; }
        }

        /// <summary>
        /// Sets the Failure
        /// </summary>
        public string Failure
        {
            set { TempData["Failure"] = ViewData["Failure"] = value; }
        }
    }
}
