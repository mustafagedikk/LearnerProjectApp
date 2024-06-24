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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListWithİsnotRead()
        {
            return _messageDal.List(x => x.IsRead == false).OrderByDescending(x => x.MessageId).ToList();
        }

        public List<Message> GetListWithİsRead()
        {
            return _messageDal.List(x => x.IsRead == true).OrderByDescending(x => x.MessageId).ToList();
        }

        public void TAdd(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void TDelete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public Message TGetbyId(int id)
        {
          return  _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> TGetList()
        {
            return _messageDal.List();
        }

        public void TUpdate(Message entitiy)
        {
            _messageDal.Update(entitiy);
        }
    }
}
