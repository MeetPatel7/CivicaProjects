using System.Runtime.Serialization;

namespace BankingSystem
{
    [Serializable]
    public class TransactionLimitReachedException : Exception
    {
        public TransactionLimitReachedException(): base("Maximum transaction limit per account holder is 3")
        {
        }

        public TransactionLimitReachedException(string msg):base(msg)
        {
        }
    }
}