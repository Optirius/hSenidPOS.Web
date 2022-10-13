using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.DAL.IRepository
{
    public interface IDummyRepository
    {
        public DataTable GetData();
        public void InsertData();
    }
}
