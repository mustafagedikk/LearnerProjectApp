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
    public class FAQManager : IFAQService
    {
        IFAQDal _fAQDal;

        public FAQManager(IFAQDal fAQDal)
        {
            _fAQDal = fAQDal;
        }

        public void TAdd(FAQ entity)
        {
            _fAQDal.Insert(entity);
        }

        public void TDelete(FAQ entity)
        {
            _fAQDal.Delete(entity);
        }

        public FAQ TGetbyId(int id)
        {
           return _fAQDal.Get(x => x.FAQId == id);
        }

        public List<FAQ> TGetList()
        {
            return _fAQDal.List();
        }

        public void TUpdate(FAQ entitiy)
        {
            _fAQDal.Update(entitiy);
        }
    }
}
