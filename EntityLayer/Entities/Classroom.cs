using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Classroom
    {
        [Key]
        public int ClassroomId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
