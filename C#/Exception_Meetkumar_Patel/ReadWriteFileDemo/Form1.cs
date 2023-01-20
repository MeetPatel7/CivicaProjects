using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ReadWriteFileDemo
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void readtext_TextChanged(object sender, EventArgs e)
        {

        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            try
            {
                string file = @"C:\Users\meetkumar.patel\Downloads\ReadWriteDemo.txt";

                if (File.Exists(file))
                {
                    string a = Convert.ToString(Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text));
                    string[] values = { "First value:" + textBox1.Text, "Second value:" + textBox2.Text, "Answer:" + a };
                    File.WriteAllLines(file, values);
                    readtext.Text = File.ReadAllText(file);
                    /*string[] lines = File.ReadAllLines(file);

                    foreach (string ln in lines)
                    {
                        readtext.Text = ln;
                    }*/
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            try
            {
                string file = @"C:\Users\meetkumar.patel\Downloads\ReadWriteDemo.txt";

                if (File.Exists(file))
                {
                    string a = Convert.ToString(Convert.ToDouble(textBox1.Text) - Convert.ToDouble(textBox2.Text));
                    string[] values = { "First value:" + textBox1.Text, "Second value:" + textBox2.Text, "Answer:" + a };
                    File.WriteAllLines(file, values);
                    readtext.Text = File.ReadAllText(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnmul_Click(object sender, EventArgs e)
        {
            try
            {
                string file = @"C:\Users\meetkumar.patel\Downloads\ReadWriteDemo.txt";

                if (File.Exists(file))
                {
                    string a = Convert.ToString(Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text));
                    string[] values = { "First value:" + textBox1.Text, "Second value:" + textBox2.Text, "Answer:" + a };
                    File.WriteAllLines(file, values);
                    readtext.Text = File.ReadAllText(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            try
            {
                string file = @"C:\Users\meetkumar.patel\Downloads\ReadWriteDemo.txt";

                if (File.Exists(file))
                {
                    string a = Convert.ToString(Convert.ToDouble(textBox1.Text) / Convert.ToDouble(textBox2.Text));
                    string[] values = { "First value:" + textBox1.Text, "Second value:" + textBox2.Text, "Answer:" + a };
                    File.WriteAllLines(file, values);
                    readtext.Text = File.ReadAllText(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        string file2=null;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                file2 = @"C:\Users\meetkumar.patel\Downloads\"+ forfilebtntext.Text;

                if (!File.Exists(file2))
                {
                    File.CreateText(file2);
                    MessageBox.Show("file created");
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("file already created", ex.Message);
            }
        }

        private void btnwrite_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file2))
                {
                    string wvalue = forfilebtntext.Text;
                    sw.WriteLine(wvalue);
                    MessageBox.Show("data inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnread_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file2))
                {
                    forfilebtntext.Text= sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            file2 = @"C:\Users\meetkumar.patel\Downloads\" + forfilebtntext.Text;
            try
            {
                if(File.Exists(file2))
                {
                    File.Delete(file2);
                    MessageBox.Show("file deleted");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("file not found");
            }
        }
    }
}
