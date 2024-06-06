using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
   public class CourseVideo
    {
        [Key]
        public int CourseVideoId { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int VideoNumaber { get; set; }
        public string VideoUrl { get; set; }

    }
}
