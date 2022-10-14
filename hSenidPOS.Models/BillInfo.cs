using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.Models
{
    public class BillInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public float amount { get; set; }

    }
}
