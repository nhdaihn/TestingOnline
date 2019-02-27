using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestingSystem.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { set { ViewBag.Title = value; } }

        /// <summary>
        /// Sets the success.
        /// </summary>
        /// <value>The success.</value>
        public string Success { set { TempData["Success"] = ViewData["Success"] = value; } }
        /// <summary>
        /// Sets the failure.
        /// </summary>
        /// <value>The failure.</value>
        public string Failure { set { TempData["Failure"] = ViewData["Failure"] = value; } }
    }
}