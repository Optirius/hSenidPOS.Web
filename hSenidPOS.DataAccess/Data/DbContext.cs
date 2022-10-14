using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace hSenidPOS.DAL.Data
{
    public class DbContext : IDbContext
    {
        string constr;

        public DbContext(IConfiguration configuration)
        {
            constr = configuration.GetConnectionString("DefaultConnection");
        }

        public void ExecuteQuery(string query, List<param> @params) //For insert and update and StoredProcedures without data
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;

                    foreach (param param in @params)
                    {
                        if (String.IsNullOrEmpty(Convert.ToString(param.SqlValue)))
                        {
                            param.SqlValue = DBNull.Value;
                        }

                        cmd.Parameters.Add(param.ParamName, param.SqlDbType).Value = param.SqlValue;
                    }

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

        }

        public DataTable GetDataTable(string query, List<param> @params) //For getting data and StoredProcedures with data
        {
            DataTable data = new DataTable();

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;

                    foreach (param param in @params)
                    {
                        if (String.IsNullOrEmpty(Convert.ToString(param.SqlValue)))
                        {
                            param.SqlValue = DBNull.Value;
                        }

                        cmd.Parameters.Add(param.ParamName, param.SqlDbType).Value = param.SqlValue;
                    }

                    con.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(data);
                    }

                    con.Close();

                }
            }

            return data;

        }

        public DataTable GetDataTable(string query)
        {
            DataTable data = new DataTable();

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;

                    con.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(data);
                    }

                    con.Close();

                }
            }

            return data;

        }

        public int GetSingleInt(string query)
        {
            var result = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;

                    con.Open();

                    result = (Int32)cmd.ExecuteScalar();

                    con.Close();

                }
            }

            return result;

        }


    }
}
