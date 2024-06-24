using BussinessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace LearnerProjectApp.Controllers
{
    public class AdminContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessagesDal());

        // GET: AdminContact
        public ActionResult Index(int p=1)
        {
            var values = messageManager.GetListWithİsnotRead();
            var pagelistvalues = values.ToPagedList(p, 14);

            return View(pagelistvalues);
        }

        public ActionResult MessageIsRead(int p=1)
        {
            var values = messageManager.GetListWithİsRead();
            var pagelistvalues = values.ToPagedList(p, 14);

            return View(pagelistvalues);
        }

        public ActionResult MessageDetails(int id)

        {
            var values = messageManager.TGetbyId(id);
            if (values.IsRead==false)
            {
                values.IsRead = true;
            }
            
            messageManager.TUpdate(values);
            return View(values);
        }

        public ActionResult IsRead(int id)
        {
            var values = messageManager.TGetbyId(id);
            values.IsRead = true;
            messageManager.TUpdate(values);
            return RedirectToAction("Index");
        }

        public ActionResult MessageDelete(int id)
        {
            var values = messageManager.TGetbyId(id);
            messageManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}