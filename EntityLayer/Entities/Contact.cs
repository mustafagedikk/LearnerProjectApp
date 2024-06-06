using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
   public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string  OpenHours { get; set; }
        public string  Email { get; set; }
        public string  Phone { get; set; }

        public string Address { get; set; }

    }
}
