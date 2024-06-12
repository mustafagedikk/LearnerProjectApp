using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProjectApp.Models
{
    public class CourseCategoryCountViewModel
    {
      
        public int CourseId { get; set; }
        public int Coursecount { get; set; }
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public bool Status { get; set; }


        public int categoryid { get; set; }
    }
}