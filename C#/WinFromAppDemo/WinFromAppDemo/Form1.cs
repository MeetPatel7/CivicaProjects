using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFromAppDemo
{
    public partial class textvalu1 : Form
    {
        public textvalu1()
        {
            InitializeComponent();
        }

        private void badd_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (text1.Text == string.Empty || text2.Text == string.Empty)
                {
                    MessageBox.Show("*please enter the value");
                }
                else
                {
                    textanswer.Text = Convert.ToString(Convert.ToDouble(text1.Text) + Convert.ToDouble(text2.Text));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void bsub_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (text1.Text == string.Empty || text2.Text == string.Empty)
                {
                    MessageBox.Show("*please enter the value");
                }
                else
                {
                    textanswer.Text = Convert.ToString(Convert.ToDouble(text1.Text) - Convert.ToDouble(text2.Text));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void bmul_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (text1.Text == string.Empty || text2.Text == string.Empty)
                {
                    MessageBox.Show("*please enter the value");
                }
                else
                {
                    textanswer.Text = Convert.ToString(Convert.ToDouble(text1.Text) * Convert.ToDouble(text2.Text));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void bdiv_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (text1.Text == string.Empty || text2.Text == string.Empty)
                {
                    MessageBox.Show("*please enter the value");
                }
                else
                {
                    textanswer.Text = Convert.ToString(Convert.ToDouble(text1.Text) / Convert.ToDouble(text2.Text));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
