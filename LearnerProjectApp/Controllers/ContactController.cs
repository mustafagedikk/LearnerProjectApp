using BussinessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessagesDal());
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Contactİnfo()
        {
            var values = cm.TGetList();
          
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]

        public ActionResult SendMessage(Message message)
        {
            message.IsRead = false;
            mm.TAdd(message);

            return RedirectToAction("Index");
        }
    }
}