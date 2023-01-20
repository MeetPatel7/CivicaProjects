
namespace BankingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard creditCard = new CreditCard();
            creditCard.transactionNotification += ShowSMS;
            creditCard.MakePayment(100);
            
        }

        static void ShowSMS(double message)
        {
            Console.WriteLine(message+"Amount is debited");
        }
    }
}