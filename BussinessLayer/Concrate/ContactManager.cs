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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TAdd(Contact entity)
        {
            _contactDal.Insert(entity);
        }

        public void TDelete(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact TGetbyId(int id)
        {
          return _contactDal.Get(x => x.ContactId == id);
        }

        public List<Contact> TGetList()
        {
            return _contactDal.List();
        }

        public void TUpdate(Contact entitiy)
        {
            _contactDal.Update(entitiy);
        }
    }
}
