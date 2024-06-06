using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public bool Status { get; set; }

        public int? EducatorId { get; set; }
        public virtual Educator Educator { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<CourseRegister> CourseRegisters { get; set; }

        public ICollection<CourseVideo> CourseVideos { get; set; }

    }
}
