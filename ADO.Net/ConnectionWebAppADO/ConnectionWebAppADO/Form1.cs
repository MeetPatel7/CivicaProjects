using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ConnectionWebAppADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from Employee_ADO where Name like '"+textBox1.Text+"%' ";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                BindingSource bs = new BindingSource();
                bs.DataSource = dr;
                dataGridView1.DataSource = bs;

            }
        }
    }
}
