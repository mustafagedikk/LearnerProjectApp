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
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public void TAdd(Question entity)
        {
            _questionDal.Insert(entity);
        }

        public void TDelete(Question entity)
        {
            _questionDal.Delete(entity);
        }

        public Question TGetbyId(int id)
        {
           return _questionDal.Get(x => x.QuestionId == id);
        }

        public List<Question> TGetList()
        {
            return _questionDal.List();
        }

        public void TUpdate(Question entitiy)
        {
            _questionDal.Update(entitiy);
        }
    }
}
