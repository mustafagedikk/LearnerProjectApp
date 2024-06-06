using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrate
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;
        

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public int CourseCount()
        {
           return _courseDal.List().Count();
        }

        public int CoursePriceExpencive()
        {
            return (int)_courseDal.List().Max(x => x.Price);
        }

        public string ExpenciveCourseName()
        {
          return   _courseDal.List().OrderByDescending(x => x.Price).Select(x => x.CourseName).FirstOrDefault();
        }

        public List<Course> GetlistByEducatorUserName(string username)
        {
            return _courseDal.List(x => x.Educator.NameSurname == username && x.Status == true);
        }

        public List<Course> GetPassiveCourseList()
        {
            return _courseDal.List(x => x.Status == false);
        }

   

        public void TAdd(Course entity)
        {
            _courseDal.Insert(entity);
        }

        public void TDelete(Course entity)
        {
            _courseDal.Delete(entity);
        }

        public Course TGetbyId(int id)
        {
            return _courseDal.Get(x => x.CourseId == id);
        }

        public List<Course> TGetList()
        {
            return _courseDal.List(x=>x.Status==true);
        }

        public void TUpdate(Course entitiy)
        {
            _courseDal.Update(entitiy);
        }

        public List<Course> GetlistwithReview()
        {
            throw new NotImplementedException();
        }

        public List<Course> GetListWtihSearch(string search,int username)
        {
            return _courseDal .List(x => x.CourseName.Contains(search)).ToList();
        }
    }
}
