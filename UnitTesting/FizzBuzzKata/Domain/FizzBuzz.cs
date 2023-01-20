namespace Domain
{
    public class FizzBuzz
    {
        public static string GetResult(int number)
        {
            string output = string.Empty;

            if (number % 3 == 0)
                output = "fizz";
            else if (number % 5 == 0)
                output = "buzz";
            //else if (number % 3 == 0 && number % 5 == 0)
            //    return "fizzbuzz";

            return output;
        }
    }
}