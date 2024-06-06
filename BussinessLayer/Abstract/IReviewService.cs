﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IReviewService : IGenericService<Review>
    {
        List<Review> GetWithCourseID(int id);
    }
}
