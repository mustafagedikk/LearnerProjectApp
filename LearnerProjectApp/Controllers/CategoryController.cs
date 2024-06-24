using BussinessLayer.Concrate;
using DataAccessLayer.Concrate;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace LearnerProjectApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index(int p=1)
        {
            var values = cm.TGetList().ToPagedList(p, 18);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddCategory(Category category)
        {   

            cm.TAdd(category);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = cm.TGetbyId(id);
            cm.TDelete(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = cm.TGetbyId(id);
            return View(values);
        }
        [HttpPost]

        public ActionResult UpdateCategory(Category category)
        {
            cm.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}