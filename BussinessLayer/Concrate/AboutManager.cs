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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About entity)
        {
            _aboutDal.Insert(entity);
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About TGetbyId(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
        }

        public List<About> TGetList()
        {
            return _aboutDal.List();
        }

        public void TUpdate(About entitiy)
        {
            _aboutDal.Update(entitiy);
        }
    }
}
