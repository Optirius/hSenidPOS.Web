using hSenidPOS.DAL.Data;
using hSenidPOS.DAL.IRepository;
using hSenidPOS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.DAL.Repository
{
    public class BillingRepository : IBillingRepository
    {
        private readonly IDbContext _dbContext;

        public BillingRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Items> GetItemsList()
        {
            string query = @"Select * from dbo.ItemList";

            List<Items> items = new List<Items>();
            items = new Items().ConvertToModel(_dbContext.GetDataTable(query));

            return items;
        }

        public int GetBillNo()
        {
            string query = @"select ISNULL(Max(BillNo),0)+1 from BillDetails";
            return _dbContext.GetSingleInt(query);

        }

        public void CreateBill(int billNo, BillInfo bill)
        {
            string query = @"Insert into BillDetails values(@BillNo, @Id, @Name, @Price, @Quantity, @Amount, GETDATE())";

            List<param> @params = new List<param>()
            {
                new param{ SqlDbType = SqlDbType.Int, ParamName="@BillNo", SqlValue = billNo},
                new param{ SqlDbType = SqlDbType.Int, ParamName="@Id", SqlValue = bill.id},
                new param{ SqlDbType = SqlDbType.VarChar, ParamName="@Name", SqlValue = bill.name},
                new param{ SqlDbType = SqlDbType.Money, ParamName="@Price", SqlValue = bill.price},
                new param{ SqlDbType = SqlDbType.Int, ParamName="@Quantity", SqlValue = bill.quantity},
                new param{ SqlDbType = SqlDbType.Int, ParamName="@Amount", SqlValue = bill.amount},
            };

            _dbContext.ExecuteQuery(query, @params);

        }

        public void CreateBillInfo(int billNo, float discount, float vat, float GrandTotal)
        {
            string query = @"Insert into BillInfo values(@BillNo, @Discount, @Vat, @GrandTotal)";

            List<param> @params = new List<param>()
            {
                new param{ SqlDbType = SqlDbType.Int, ParamName="@BillNo", SqlValue = billNo},
                new param{ SqlDbType = SqlDbType.Float, ParamName="@Discount", SqlValue = discount},
                new param{ SqlDbType = SqlDbType.Float, ParamName="@Vat", SqlValue = vat},
                new param{ SqlDbType = SqlDbType.Money, ParamName="@GrandTotal", SqlValue = GrandTotal},
            };

            _dbContext.ExecuteQuery(query, @params);

        }
    }
}
