using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Review
    {

        [Key]
        public int ReviewId { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public double ReviewValue { get; set; }
        public string Comment { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
