using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SqlCommandADO
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

        //============== For Retrieve data ==========================    

                /*using (conn = new SqlConnection(cs))
                {
                    string query = "select * from Employee_ADO";
                    SqlCommand cmd = new SqlCommand(query,conn);

                //-----For store Procedure ----------------
                    //string query = "spGetEmployee_ADO";
                    //SqlCommand cmd = new SqlCommand(query, conn);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    //SqlCommand cmd2 = new SqlCommand();
                    //cmd2.CommandText = query;
                    //cmd2.Connection = conn;


                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("id :"+ reader["Id"]+"  name :" + reader["Name"]+"  gender :" + reader["Gender"]+"  Age :" + reader["Age"]+"  City :" + reader["City"]+"  Salary :" + reader["Salary"]);
                    }

                    //if(conn.State == ConnectionState.Open)
                    //{
                    //    Console.WriteLine("Connected Successfully");
                    //}
                }*/

        //==================== Insert data in database ========================

            /*
                using(conn = new SqlConnection(cs))
                {
                    Console.WriteLine("Enter id:");
                    string id = Console.ReadLine();
                    Console.WriteLine("Enter name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter gender:");
                    string gender = Console.ReadLine();
                    Console.WriteLine("Enter age:");
                    string age = Console.ReadLine();
                    Console.WriteLine("Enter city:");
                    string city= Console.ReadLine();
                    Console.WriteLine("Enter salary:");
                    string salary = Console.ReadLine();

                    string query = "insert into Employee_ADO values(@Id,@Name,@Gender,@Age,@City,@Salary)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    conn.Open();
                    int a = cmd.ExecuteNonQuery();

                    if(a>0)
                    {
                        Console.WriteLine("Data inserted");
                    }
                    else
                    {
                        Console.WriteLine("data not inserted");
                    }
                }*/

        //================= Update data in database ============================

            /*
                using(conn = new SqlConnection(cs))
                {
                    Console.WriteLine("Enter id:");
                    string id = Console.ReadLine();
                    Console.WriteLine("Enter name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter gender:");
                    string gender = Console.ReadLine();
                    Console.WriteLine("Enter age:");
                    string age = Console.ReadLine();
                    Console.WriteLine("Enter city:");
                    string city = Console.ReadLine();
                    Console.WriteLine("Enter salary:");
                    string salary = Console.ReadLine();

                    string query = "update Employee_ADO set Name=@name,Gender=@gender,Age=@age,City=@city,Salary=@salary where Id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    conn.Open();
                    int a = cmd.ExecuteNonQuery();

                    if (a > 0)
                    {
                        Console.WriteLine("Data updated");
                    }
                    else
                    {
                        Console.WriteLine("data not updated");
                    }

                }*/

        //==================== delete data ==============================================
            /*
                using(conn = new SqlConnection(cs))
                {
                    Console.WriteLine("Enter id:");
                    string id = Console.ReadLine();

                    string query = "delete from Employee_ADO where Id = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    int a = cmd.ExecuteNonQuery();

                    if (a > 0)
                    {
                        Console.WriteLine("Data deleted");
                    }
                    else
                    {
                        Console.WriteLine("data not deleted");
                    }
                }*/

        //================ ExecuteScalar for aggregate functions (sum(),max(),min(),count(),avg())==============

                using(conn = new SqlConnection(cs))
                {
                    string query = "select avg (salary) from Employee_ADO";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    int a = (int)cmd.ExecuteScalar();
                    Console.WriteLine(a);
                }


            }

            catch(SqlException sqle)
            {
                Console.WriteLine(sqle.Message);
            }

            finally
            {
                conn.Close();
            }
        }
    }
}
