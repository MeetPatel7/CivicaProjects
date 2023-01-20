using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SqlDataReaderADO
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
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = null;

            try
            {
                /*
                using(conn = new SqlConnection(cs))
                {
                    string query = "select * from Employee_ADO";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine(reader.FieldCount);
                    Console.WriteLine(reader.HasRows);   // for check a rows are available in table or not.//boolean
                    Console.WriteLine(reader.IsClosed);  // for check SqlDataReader close or not.//boolean
                    Console.WriteLine(reader.GetName(2)); // for find column name


                    //while (reader.Read())
                    //{
                    //    Console.WriteLine("id :" + reader["Id"] + "  name :" + reader["Name"] + "  gender :" + reader["Gender"] + "  Age :" + reader["Age"] + "  City :" + reader["City"] + "  Salary :" + reader["Salary"]);
                    //}

                }*/

                using(conn = new SqlConnection(cs))
                {
                    string query = "select * from Employee_ADO;select * from Student";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.Read())
                    {
                        Console.WriteLine("{0} {1} {2}", reader[0], reader[1], reader[2]);
                    }

                    Console.WriteLine("----------------------------");

                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1} {2}", reader[0], reader[1], reader[2]);
                        }
                    }
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();   
            }
        }
    }
}
