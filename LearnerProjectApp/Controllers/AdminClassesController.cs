using BussinessLayer.Concrate;
using DataAccessLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EntityLayer.Entities;

namespace LearnerProjectApp.Controllers
{
    public class AdminClassesController : Controller
    {
        ClassroomManager classroomManager = new ClassroomManager(new EfClassroomDal());
        public ActionResult Index(int p=1)
        {
            var values = classroomManager.TGetList().ToPagedList(p, 18);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddClassroom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClassroom(Classroom classroom)
        {
            classroomManager.TAdd(classroom);
            return RedirectToAction("Index");
        }
        [HttpGet]
       public ActionResult EditClassroom(int id)
        {
            var values = classroomManager.TGetbyId(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult EditClassroom(Classroom classroom)
        {
            classroomManager.TUpdate(classroom);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClassroom(int id)
        {
            var values = classroomManager.TGetbyId(id);
            classroomManager.TDelete(values);
            return RedirectToAction("Index");

        }
    }
}