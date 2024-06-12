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
            throw new NotImplementedException();
        }

        public void TDelete(Testimonial entity)
        {
            throw new NotImplementedException();
        }

        public Testimonial TGetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> TGetList()
        {
          return  _testimonialDal.List();
        }

        public void TUpdate(Testimonial entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
