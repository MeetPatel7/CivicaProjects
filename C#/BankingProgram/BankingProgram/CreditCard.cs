using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgram
{
    public class CreditCard
    {
        private string CreditCardNo;
        private string CreditHolderName;
        private double BalanceAmount;
        private double CreditLimit;

        public event Action<double> transactionNotification; 
        public double GetBalance()
        {
            return BalanceAmount;
        }

        public double GetCreditLimit()
        {
            return CreditLimit;
        }

        public void MakePayment(double amountMakePayment)
        {
            transactionNotification.Invoke(amountMakePayment);
        }
    }
}
