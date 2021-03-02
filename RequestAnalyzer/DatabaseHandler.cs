using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class DatabaseHandler
    {
        //private SqlConnection con = new SqlConnection($"Server=127.0.0.1;Database=AnalyticDatabase;User ID=saied;Password=123!@#qwe;");
        private SqlConnection con = new SqlConnection($"Server=127.0.0.1;Database=AnalyticDatabase;Integrated Security=True;");
        public void Add(DateTime timestamp, string userName, bool isClick)
        {
            string command = "INSERT INTO dbo.AnaliticData(TimeStamp,UserName,Impression,InsertDate)VALUES(@timestamp, @userName,@impression,GETDate())";
            using (var sqlCmd = new SqlCommand(command, con))
            {
                try
                {
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                    sqlCmd.Parameters.Add(new SqlParameter("@timestamp", SqlDbType.DateTime)).Value = (object)timestamp ?? DBNull.Value;
                    sqlCmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar)).Value = (object)userName ?? DBNull.Value;
                    sqlCmd.Parameters.Add(new SqlParameter("@IsClick", SqlDbType.Bit)).Value = (object)isClick ?? DBNull.Value;

                    using (sqlCmd)
                    {
                        if (this.con.State != ConnectionState.Open)
                            this.con.Open();
                        sqlCmd.ExecuteNonQuery();
                        if (this.con.State == ConnectionState.Open) this.con.Close();
                    }
                }
                catch (Exception ex) { throw new Exception("Exception while Finding data from Person. Command:" + command + "  Values=>", ex); }
                finally
                {
                    if (this.con.State == ConnectionState.Open) this.con.Close();
                }
            }
        }
        public DataTable getReport(DateTime timestamp)
        {
            string command = $"SELECT COUNT(DISTINCT UserName) UserNameCount,SUM((CASE WHEN IsClick = 1 THEN 1 ELSE 0 end)) IsClickCount,SUM((CASE WHEN IsClick = 1 THEN 0 ELSE 1 end)) Impression FROM dbo.AnaliticData WHERE TimeStamp = '{timestamp}' ";
            using (var sqlCmd = new SqlCommand(command, con))
            {
                try
                {
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                    sqlCmd.Parameters.Add(new SqlParameter("@timestamp", SqlDbType.DateTime)).Value = (object)timestamp ?? DBNull.Value;

                    using (sqlCmd)
                    {
                        using (var da = new SqlDataAdapter(sqlCmd))
                        {
                            var dt = new DataTable();
                            da.Fill(dt);

                            return dt;
                        }
                    }
                }
                catch (Exception ex) { throw new Exception("Exception while Finding data from Person. Command:" + command + "  Values=>", ex); }
                finally
                {
                    if (this.con.State == ConnectionState.Open) this.con.Close();
                }
            }
        }

    }
}
