using hSenidPOS.BLL.IManager;
using hSenidPOS.DAL.IRepository;
using hSenidPOS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.BLL.Manager
{
    public class BillingManager : IBillingManager
    {
        private readonly IBillingRepository iBillingRepository;

        public BillingManager(IBillingRepository iBillingRepository)
        {
            this.iBillingRepository = iBillingRepository;
        }

        public IEnumerable<Items> GetItemsList()
        {
            return iBillingRepository.GetItemsList();
        }

        public void SaveBill(float discount, float vat, float GrandTotal, List<BillInfo> billInfos)
        {
            try
            {
                int BillNo = iBillingRepository.GetBillNo();

                foreach (BillInfo bill in billInfos)
                {
                    iBillingRepository.CreateBill(BillNo, bill);
                }

                iBillingRepository.CreateBillInfo(BillNo, discount, vat, GrandTotal);

            }
            catch (Exception e)
            {

            }

        }
    }
}
