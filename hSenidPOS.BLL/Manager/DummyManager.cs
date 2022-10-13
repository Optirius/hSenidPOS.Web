using hSenidPOS.BLL.IManager;
using hSenidPOS.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.BLL.Manager
{
    public class DummyManager : IDummyManager
    {
        private readonly IDummyRepository iDummyRepository;

        public DummyManager(IDummyRepository iDummyRepository)
        {
            this.iDummyRepository = iDummyRepository;
        }

        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = iDummyRepository.GetData();
            }
            catch (Exception e)
            {

            }

            return dt;

        }

        public void InsertData()
        {
            try
            {
               iDummyRepository.InsertData();
            }
            catch (Exception e)
            {

            }

        }
    }
}
