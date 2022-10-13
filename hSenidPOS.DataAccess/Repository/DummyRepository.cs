using hSenidPOS.DAL.Data;
using hSenidPOS.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hSenidPOS.DAL.Repository
{
    public class DummyRepository : IDummyRepository
    {
        private readonly IDbContext _dbContext;

        public DummyRepository(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public DataTable GetData()
        {
            string query = @"Select * from Dummy where Id = @Id";

            List<param> @params = new List<param>()
            {
                new param{ SqlDbType = SqlDbType.Int, ParamName="@Id", SqlValue = 1},
                new param{ SqlDbType = SqlDbType.VarChar, ParamName="@Text", SqlValue = "OHNO!"},
            };

            return _dbContext.GetDataTable(query, @params);
            //return new DataTable();
        }

        public void InsertData()
        {
            string query = @"Insert into Dummy values(@Id, @Name, @Description)";

            List<param> @params = new List<param>()
            {
                new param{ SqlDbType = SqlDbType.Int, ParamName="@Id", SqlValue = 3},
                new param{ SqlDbType = SqlDbType.VarChar, ParamName="@Name", SqlValue = "OHNO!"},
                new param{ SqlDbType = SqlDbType.VarChar, ParamName="@Description", SqlValue = "OHNOOOO!"},
            };

            _dbContext.ExecuteQuery(query, @params);
            //return new DataTable();
        }
    }
}
