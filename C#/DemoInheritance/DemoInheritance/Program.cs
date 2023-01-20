using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UPIPayment upip=new UPIPayment();
            upip.currentbalance = 1000;
            upip.gstpercentage = 10;
            upip.upicharge = 2;
            upip.withdraw(100);
            Console.ReadLine(); 
        }
    }

    public class Payment
    {
        public int currentbalance { get; set; }

        public virtual void withdraw(int wamount)
        {
            currentbalance = currentbalance-wamount;
            Console.WriteLine($"current balance={currentbalance}");
        }   
    }

    public class GSTPayment:Payment
    {
        public int gstpercentage { get; set; }

        public override void withdraw(int wamount)
        {
            int textamount = (wamount * gstpercentage / 100);
            wamount = wamount + textamount;
            base.withdraw(wamount);

        }
    }

    public class UPIPayment:GSTPayment
    {
        public int upicharge { get; set; }

        public override void withdraw(int wamount)
        {
            wamount = wamount - upicharge;
            base.withdraw(wamount);

        }
    }
}
