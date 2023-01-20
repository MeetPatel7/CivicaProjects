using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SqlConnectionADODotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.Connection();
            Console.ReadLine();
        }

        static void Connection()
        {
            //string DataBaseServerName = @"IN-LT-17262\SQL2019";
            //string cs = "Data Source =" + DataBaseServerName + ";Initial Catalog=ado_db;Integrated Security=true";

            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(cs))
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Connection Created");
                    }
                }
            }

            catch (SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
            }
            finally
            {
                con.Close();
            }

            //==============================================================================

            /*using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection Created");
                }
            }*/


            //=========================================================================================================
            /*SqlConnection con = new SqlConnection(cs);
            try
            {
                con.Open();

                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection Created");
                }
            }
            
            catch(SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
            }
            finally
            {
                con.Close();
            }*/
        }
    }
}
