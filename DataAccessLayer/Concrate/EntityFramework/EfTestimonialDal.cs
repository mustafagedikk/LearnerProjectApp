﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate.EntityFramework
{
   public class EfTestimonialDal:GenericRepository<Testimonial>,ITestimonialDal
    {
    }
}
