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
    public class ClassroomManager : IClassroomService
    {
       private readonly  IClassroomDal _classroomDal;

        public ClassroomManager(IClassroomDal classroomDal)
        {
            _classroomDal = classroomDal;
        }

        public int ClassroomCount()
        {
            return _classroomDal.List().Count();
        }

        public void TAdd(Classroom entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Classroom entity)
        {
            throw new NotImplementedException();
        }

        public Classroom TGetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Classroom> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Classroom entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
