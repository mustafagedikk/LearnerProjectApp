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
            _classroomDal.Insert(entity);
        }

        public void TDelete(Classroom entity)
        {
            _classroomDal.Delete(entity);
        }

        public Classroom TGetbyId(int id)
        {
          return  _classroomDal.Get(x => x.ClassroomId == id);
        }

        public List<Classroom> TGetList()
        {
            return _classroomDal.List();
        }

        public void TUpdate(Classroom entitiy)
        {
            _classroomDal.Update(entitiy);
        }
    }
}
