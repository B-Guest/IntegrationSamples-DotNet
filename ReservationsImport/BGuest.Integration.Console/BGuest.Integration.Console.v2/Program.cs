using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
//using Oracle.ManagedDataAccess.Client;

namespace BGuest.Integration.Console.v2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Please replace the connection string attribute settings
                //string constr = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVICE_NAME = XE)));user id=hr;password=hr";
                //string constr = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 172.31.17.4)(PORT = 1521))(CONNECT_DATA = (SERVICE_NAME = opera)));user id=opera;password=opera";
                string constr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

                //OracleConnection con = new OracleConnection(constr);
                //con.Open();
                //System.Console.WriteLine("Connected to Oracle Database {0}", con.ServerVersion);
                //con.Dispose();                
                //System.Console.WriteLine("Press RETURN to exit.");
                //System.Console.ReadLine();
                DataTable table = DbProviderFactories.GetFactoryClasses();

                // Display each row and column value.
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        System.Console.WriteLine(row[column]);
                    }
                }
                table.WriteXml(System.Console.Out);
                DbProviderFactory dbFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["OracleConnection"].ProviderName);
                var conn = dbFactory.CreateConnection();
                conn.ConnectionString = constr;
                conn.Open();
                System.Console.WriteLine("Connected to Oracle Database {0}", conn.ServerVersion);
                conn.Dispose();

                System.Console.WriteLine("Press RETURN to exit.");
                System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error : {0}", ex);
                System.Console.ReadLine();
            }
        }
    }
}
