using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        public decimal Price { get; set; }


        public List<Items> ConvertToModel(DataTable dt)
        {
            List<Items> items = new List<Items>();
            
            for (int i=0; i< dt.Rows.Count; i++)
            {
                Items item = new Items();
                item.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                item.Name = Convert.ToString(dt.Rows[i]["Name"]);
                item.Price = Convert.ToDecimal(dt.Rows[i]["Price"]);
                items.Add(item);
            }

            return items;

        }

    }
}
