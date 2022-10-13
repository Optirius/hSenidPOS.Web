using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.Models
{
    public class Dummy
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
