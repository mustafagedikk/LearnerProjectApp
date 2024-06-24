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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void TAdd(Admin entity)
        {
            _adminDal.Insert(entity);  
        }

        public void TDelete(Admin entity)
        {
            _adminDal.Delete(entity);
        }

        public Admin TGetbyId(int id)
        {
          return  _adminDal.Get(x => x.AdminId == id);
        }

        public List<Admin> TGetList()
        {
            return _adminDal.List();
        }

        public void TUpdate(Admin entitiy)
        {
            _adminDal.Update(entitiy);
        }
    }
}
