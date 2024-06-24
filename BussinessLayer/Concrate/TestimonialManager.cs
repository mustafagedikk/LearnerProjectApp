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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TAdd(Testimonial entity)
        {
            _testimonialDal.Insert(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _testimonialDal.Delete(entity);
        }

        public Testimonial TGetbyId(int id)
        {
            return _testimonialDal.Get(x => x.TestimonialId == id);
        }

        public List<Testimonial> TGetList()
        {
          return  _testimonialDal.List();
        }

        public void TUpdate(Testimonial entitiy)
        {
            _testimonialDal.Update(entitiy);
        }
    }
}
