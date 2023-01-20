namespace BankingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Khushal", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} balance.");

            account.MakeDeposit(100, DateTime.Now, " Amount Credited Successfully");

            try
            {
                var invalidAccount = new BankAccount("invalid", 5000);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance"+ e.ToString());
            }
        }
    }
}