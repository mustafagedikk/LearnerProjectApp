using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminLayoutHeadPartial()
        {
            return PartialView();

        }

        public PartialViewResult AdminLayoutSideBarPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutNavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutFooterPartial()
        {
            return PartialView();
        }
     
    }
}