

namespace DotNetPractice
{
    class Program
    {
        /*public void sumOfInt(int[] number)
        {

        }

        public int sumOfEvenNumber(int[] numbers)
        {
            int total=0;
            foreach (var number in numbers)
            {
                if(number%2==0)
                {
                    total += number;
                }
                //Console.WriteLine(number);
            }
            return total;
        }


        static void Main(string[] args)
        {
            int[] value = new int[5] {1,2,3,4,5};
            Program program = new Program();
            Console.WriteLine(program.sumOfEvenNumber(value));
            Console.ReadLine();
        }*/

        /*public delegate void GoodAfterNoonDele();
        public void GoodMorningDele();

        static void sayGoodAfternoon()
        {
            Console.WriteLine("Good afternoon");
        }
        static void sayGoodMorning()
        {
            Console.WriteLine("Good morning");
        }

        static void Main(string[] args)
        {
            GoodAfterNoonDele greetDel = new GoodAfterNoonDele(sayGoodAfternoon);
            greetDel.Invoke();

            GoodAfterNoonDele greetmorningDel = new GoodAfterNoonDele(sayGoodMorning);
            greetmorningDel.Invoke();
        }*/


        static void Main(string[] args)
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };

            int[] arrs=Array.FindAll(values,IsEven);

            foreach(int i in arrs)
            {
                Console.WriteLine(i);
            }

            int[] arr=Array.FindAll(values, delegate (int num) { return num%2==0; });

            foreach(int num in arr)
            {
                Console.WriteLine(num);
            }

            Console.ReadLine();
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}
