using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzKata
{
    public class StringCalcTest
    {
        [Fact]
        public void Add_WhenPass_EmptyZero_Should_Return_Zero()
        {
            StringCalc sc = new StringCalc();
            int ActualResult = sc.Add("");
            Assert.Equal(0, ActualResult);
        }

        [Fact]
        public void Add_WhenPass_a_Number_Should_Return_Number()
        {
            StringCalc sc = new StringCalc();
            int ActualResult = sc.Add("4");
            Assert.Equal(4, ActualResult);
        }

        [Fact]
        public void Add_WhenPass_two_Numbers_Should_Return_Number()
        {
            StringCalc sc = new StringCalc();
            int ActualResult = sc.Add("4,2");
            Assert.Equal(6, ActualResult);
        }

        [Fact]
        public void Add_WhenPass_More_Numbers_Should_Return_Number()
        {
            StringCalc sc = new StringCalc();
            int ActualResult = sc.Add("1 2 3");
            Assert.Equal(6, ActualResult);
        }

        [Fact]
        public void Add_Throw_Exception_when_number_is_negative()
        {
            StringCalc sc = new StringCalc();
            Exception ex = Record.Exception(() => sc.Add("1,-2,-3"));
            Assert.IsType<ArgumentOutOfRangeException>(ex);

        }
    }

    public class StringCalc
    {

        public int Add(string input)
        {
            if(String.IsNullOrEmpty(input))
                return 0;
            
            else
            {
                if(input.Length == 1)
                    return Convert.ToInt32(input);
                
                else
                {
                    var number = input.Split(',',' ');
                    //var number = input.Split(new char[]{','});
                    int sum = 0;

                    foreach(var item in number)
                    {
                        if(Convert.ToInt32(item) < 0)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        else
                        {
                            sum = sum + Convert.ToInt32(item);
                        }
                    }
                    return sum;
                    //return Convert.ToInt32(number[0]) + Convert.ToInt32(number[1]) + Convert.ToInt32(number[2]);
                }
                
            }
        }
    }
}
