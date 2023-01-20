
namespace ExtensionMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            string a = "7";
            int stringToInt = a.AsInt(0);
            Console.WriteLine("oldvalue: " + a);
            Console.WriteLine("newvalue: " + stringToInt);

            string b = "true";
            bool stringToBool = b.AsBool(false);
            Console.WriteLine("oldvalue: " + b);
            Console.WriteLine("newvalue: " + stringToBool);

            string c = "77.77";
            float stringToFloat = c.AsFloat(0);
            Console.WriteLine("oldvalue: " + c);
            Console.WriteLine("newvalue: " + stringToFloat);

            string d = "87.58";
            decimal stringToDecimal = d.AsDecimal(0);
            Console.WriteLine("oldvalue: " + d);
            Console.WriteLine("newvalue: " + stringToDecimal);

            string e = "2000.11.20";
            DateTime stringToDatetime = e.AsDatetime(DateTime.MinValue);
            Console.WriteLine("oldvalu7e: " + e);
            Console.WriteLine("newvalue: " + stringToDatetime);

        }
    }
}