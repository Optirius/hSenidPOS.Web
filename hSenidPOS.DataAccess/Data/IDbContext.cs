using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.DAL.Data
{
    public interface IDbContext
    {
        public DataTable GetDataTable(string query, List<param> @params);
        public void ExecuteQuery(string query, List<param> @params);
    }
}
