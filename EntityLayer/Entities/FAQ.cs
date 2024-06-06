using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class FAQ
    {
        [Key]
        public int FAQId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
