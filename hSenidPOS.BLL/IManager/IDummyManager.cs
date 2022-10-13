using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.BLL.IManager
{
    public interface IDummyManager
    {
        public DataTable GetDataTable();
        public void InsertData();
    }
}
