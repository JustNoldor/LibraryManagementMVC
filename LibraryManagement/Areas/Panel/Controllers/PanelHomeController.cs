using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagement.Areas.Panel.Controllers
{
    public class PanelHomeController : Controller
    {
        // GET: Panel/PanelHome
        public ActionResult Index()
        {
            return View();
        }
    }
}