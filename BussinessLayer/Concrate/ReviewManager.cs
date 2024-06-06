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
    public class ReviewManager : IReviewService
    {
        IReviewDal _reviewDal;

        public ReviewManager(IReviewDal reviewDal)
        {
            _reviewDal = reviewDal;
        }

        public List<Review> GetWithCourseID(int id)
        {
            return _reviewDal.List(x => x.CourseId == id);
        }

        public void TAdd(Review entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Review entity)
        {
            throw new NotImplementedException();
        }

        public Review TGetbyId(int id)
        {
            return _reviewDal.Get(x=>x.ReviewId==id);
        }

        public List<Review> TGetList()
        {
           return _reviewDal.List();
        }

        public void TUpdate(Review entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
