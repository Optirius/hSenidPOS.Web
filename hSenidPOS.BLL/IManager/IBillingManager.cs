using hSenidPOS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.BLL.IManager
{
    public interface IBillingManager
    {
        public IEnumerable<Items> GetItemsList();
        public void SaveBill (float discount, float vat, float GrandTotal, List<BillInfo> billInfos);
    }
}
