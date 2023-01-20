using System.Data;
using System.Data.SqlClient;

namespace GettingStared
{
    internal class Program
    {
        private static readonly string _connetctionstring;
        static Program()
        {
            _connetctionstring = "Data Source=IN-LT-17262\\SQL2019;Database=EMS;integrated Security=true";
        }
        static void Main(string[] args)
        {
            connectedWay();
            //disConnectedWay();
        }

        static void connectedWay()
        {
            SqlConnection sqlConnection = new SqlConnection(_connetctionstring);

            const string selectCommand = "employee_getAll";

            SqlCommand sqlCommand = new SqlCommand(selectCommand, sqlConnection);

            sqlCommand.Connection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                string lastName = sqlDataReader["lastName"].ToString();

                bool isActive = sqlDataReader.GetBoolean(4);

                Console.Write(isActive);
            }

            Console.ReadKey();
            sqlConnection.Close();
        }

        static void disConnectedWay()
        {
            SqlConnection sqlConnection = new SqlConnection(_connetctionstring);

            const string insertCommand = "employee_add";

            SqlCommand sqlCommand = new SqlCommand(insertCommand, sqlConnection);

            sqlCommand.Connection.Open();

            DataTable dataTable = new DataTable();

            IDataReader sqlDataReader = sqlCommand.ExecuteReader();

            dataTable.Load(sqlDataReader);

            sqlCommand.Connection.Close();

            if (dataTable.Rows.Count >= 1)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    string lastName = item["lastName"].ToString();

                    Console.Write(lastName);
                }
            }
        }
    }
}