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
        public DataTable GetDataTable(string query);
        public void ExecuteQuery(string query, List<param> @params);
        public int GetSingleInt(string query);
    }
}
