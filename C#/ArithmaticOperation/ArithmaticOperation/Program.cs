

namespace ArithmaticOperation
{
    public delegate double Operation(double n1, double n2);
    class Program
    {
        
        static void Main(string[] args)
        {

            do
            {
                Console.WriteLine("Enter First value:");
                double firstvalue = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Second value:");
                double secondvalue = double.Parse(Console.ReadLine());


                Console.WriteLine("Press 1 for addition");
                Console.WriteLine("Press 2 for subtraction");
                Console.WriteLine("Press 3 for multiplication");
                Console.WriteLine("Press 4 for division");
                Console.WriteLine("Press 5 for find maximum value");

                Console.WriteLine("Enter your option");
                int option = int.Parse(Console.ReadLine());

                ArithmeticOperation arithmeticOperation=new ArithmeticOperation();
                Operation operation = null;

                switch (option)
                {
                    case 1:
                        {
                            operation = arithmeticOperation.Addition;
                            break;
                        }
                    case 2:
                        {
                            operation = arithmeticOperation.Subtraction;
                            break;
                        }
                    case 3:
                        {
                            operation = arithmeticOperation.Multiplication;
                            break;
                        }
                    case 4:
                        {
                            operation = arithmeticOperation.Division;
                            break;
                        }
                    case 5:
                        {
                            operation = arithmeticOperation.MaxValue;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("please choose a vaild option");
                            break;
                        }
                }

                var ans = operation(firstvalue, secondvalue);
                Console.WriteLine(ans);
            }
            while (true);
        }
    }
}
