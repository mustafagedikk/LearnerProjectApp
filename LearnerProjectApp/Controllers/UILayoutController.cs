using BussinessLayer.Concrate;
using DataAccessLayer.Concrate.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProjectApp.Controllers
{
    
    public class UILayoutController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());
        // GET: UILayout
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult SocialMedia()
        {
            var values = socialMediaManager.TGetList();
            return PartialView(values);
        }

        public PartialViewResult Contact()
        {
            var values = contactManager.TGetList();
            return PartialView(values);
        }
    }
}