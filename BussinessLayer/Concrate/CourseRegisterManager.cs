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
    public class CourseRegisterManager : ICourseRegisterService
    {
        ICourseRegisterDal _courseRegisterDal;

        public CourseRegisterManager(ICourseRegisterDal courseRegisterDal)
        {
            _courseRegisterDal = courseRegisterDal;
        }

        public void TAdd(CourseRegister entity)
        {
            _courseRegisterDal.Insert(entity);
        }

        public void TDelete(CourseRegister entity)
        {
            _courseRegisterDal.Delete(entity);
        }

        public CourseRegister TGetbyId(int id)
        {
            return _courseRegisterDal.Get(x => x.CourseId == id);
        }

        public List<CourseRegister> TGetList()
        {
            return _courseRegisterDal.List();
        }

        public void TUpdate(CourseRegister entitiy)
        {
             _courseRegisterDal.Update(entitiy);
        }
    }
}
