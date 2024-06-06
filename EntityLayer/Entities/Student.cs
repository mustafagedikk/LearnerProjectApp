using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
   public class Student
    {

        [Key]
        public int StudentId { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<CourseRegister> CourseRegisters { get; set; }
    }
}
