using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrate
{
    public class IEducatorManager : IEducatorService
    {
        IEducatorDal _educatorDal;

        public IEducatorManager(IEducatorDal educatorDal)
        {
            _educatorDal = educatorDal;
        }

        public Educator GetEducatorvalue(Educator entity)
        {
            return _educatorDal.List().FirstOrDefault(x=> x.UserName == entity.UserName && x.Password == entity.Password);
        }

        

        public void TAdd(Educator entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Educator entity)
        {
            throw new NotImplementedException();
        }

        public Educator TGetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Educator> TGetList()
        {
           return _educatorDal.List();
        }

        public void TUpdate(Educator entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
