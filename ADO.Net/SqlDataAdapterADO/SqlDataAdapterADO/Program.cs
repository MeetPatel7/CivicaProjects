using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SqlDataAdapterADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            string query = "select * from Employee_ADO";
            SqlDataAdapter sda = new SqlDataAdapter(query,conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }

            Console.WriteLine("--------------------------------------------");

            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }

            Console.WriteLine("-------------------------------------------");

        // for Store Procedure

            string query1 = "spGetEmployee_ADO";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, conn);
            
            // when we use default constructor 
            
            // SqlDataAdapter sda1 = new SqlDataAdapter();
            // sda1.SelectCommand = new SqlCommand(query1,conn);
             
            sda1.SelectCommand.CommandType = CommandType.StoredProcedure; // we can get a data with using it and without using it
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1);

            foreach (DataRow dr in ds1.Tables[0].Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }

            // for parameterized store procedure

            Console.WriteLine("Enter id");
            int id = Convert.ToInt32(Console.ReadLine());

            string query2 = "spParGetEmployee_ADO";
            SqlDataAdapter sda2 = new SqlDataAdapter();
            sda2.SelectCommand = new SqlCommand(query2,conn);
            sda2.SelectCommand.CommandType = CommandType.StoredProcedure; // we can get a data with using it and without using it
            sda2.SelectCommand.Parameters.AddWithValue("@id",id);
            DataSet ds2 = new DataSet();
            sda2.Fill(ds2);

            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }


            Console.ReadLine();

        }
    }
}
