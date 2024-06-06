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

        public void TAdd(Student entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Student entity)
        {
            throw new NotImplementedException();
        }

        public Student TGetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Student entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
