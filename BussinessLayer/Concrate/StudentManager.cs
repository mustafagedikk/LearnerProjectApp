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
    public class StudentManager : IStudentService
    {
        IStudentDal _studentDal;

        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

        public int GetStudentCount()
        {
            return _studentDal.List().Count();
        }

        public Student GetStudentValue(Student student)
        {
          return  _studentDal.List(x => x.UserName == student.UserName && x.Password == student.Password).FirstOrDefault();
        }

        public void TAdd(Student entity)
        {
            _studentDal.Insert(entity);
        }

        public void TDelete(Student entity)
        {
            _studentDal.Delete(entity);
        }

        public Student TGetbyId(int id)
        {
          return  _studentDal.Get(x => x.StudentId == id);
        }

        public List<Student> TGetList()
        {
            return _studentDal.List();
        }

        public void TUpdate(Student entitiy)
        {
            _studentDal.Update(entitiy);
        }
    }
}
