using BussinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class AdminFAQController : Controller
    {
        QuestionManager questionManager = new QuestionManager(new EfQuestionDal());
        public ActionResult Index()
        {
            var values = questionManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditFAQ(int id)
        {
            var values = questionManager.TGetbyId(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult EditFAQ(Question question)
        {
            questionManager.TUpdate(question);
            return RedirectToAction("Index");

        }

    }
}