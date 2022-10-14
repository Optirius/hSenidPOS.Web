using hSenidPOS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.DAL.IRepository
{
    public interface IBillingRepository
    {
        public IEnumerable<Items> GetItemsList();
        public int GetBillNo();
        public void CreateBill(int billNo, BillInfo bill);
        public void CreateBillInfo(int billNo, float discount, float vat, float GrandTotal);
    }
}
