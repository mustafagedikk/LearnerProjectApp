using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class StudentLayoutController : Controller
    {
        // GET: StudentLayout
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult StudentLayoutSideBar()
        {
            return View();
        }
    }
}