using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Repository.Import
{
    public class ImportRepository
    {
        private SqlConnection connection;
    
        public ImportRepository(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void SaveData(List<string> headers, DataTable data, string tableName)
        {

            connection.Open();
            SqlTransaction tran = connection.BeginTransaction();

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("DELETE FROM " + tableName + "; ");
                foreach (DataRow row in data.Rows)
                {
                    sb.Append("INSERT INTO " + tableName);
                    sb.Append(" ( ");
                    foreach (var header in headers)
                    {
                        sb.Append("[" + header + "] ,");
                    }
                    sb.Length--;

                    sb.Append(" )");
                    sb.Append(" VALUES ( ");

                    foreach (var header in headers)
                    {
                        var value = row[header].ToString().Replace("'", "''");
                        sb.Append("\'" + value + "\'" + " ,");
                    }
                    sb.Length--;
                    sb.Append(" );");
                }

                string query = sb.ToString();

                SqlCommand cmd = new SqlCommand(query, connection, tran);
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally {
                connection.Close();
            }


        }

        public void MergeData()
        {
            connection.Open();
            SqlTransaction tran = connection.BeginTransaction();

            try
            {             

                SqlCommand cmd = new SqlCommand("MergeData", connection, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void CleanTable(string tableName)
        {
            connection.Open();
            SqlTransaction tran = connection.BeginTransaction();

            try
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM " + tableName, connection, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
