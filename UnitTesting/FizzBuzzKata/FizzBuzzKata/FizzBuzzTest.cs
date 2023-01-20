using Domain;

namespace FizzBuzzKata
{
    public class FizzBuzzTest
    {
        [Trait("rules","numbers")]
        [Theory]
        [InlineData(1,"1")]
        [InlineData(2,"2")]
        public void Test1(int input,string expectedResult)
        {
            //arrange

            //act
            string actualoutput = FizzBuzz.GetResult(input);

            //assert
            Assert.Equal(expectedResult,actualoutput);
        }

        [Trait("rules","fizz")]
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void GetResult_NumberIsDivisibleBy3_Return_Fizz(int input)
        {
            string actualoutput = FizzBuzz.GetResult(input);

            Assert.Equal("fizz",actualoutput);
        }

        [Trait("relus","buzz")]
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        public void Test3(int input)
        {
            string actualoutput = FizzBuzz.GetResult(input);

            Assert.Equal("buzz", actualoutput);
        }

        
        public void Test4(int input)
        {
            string actualoutput = FizzBuzz.GetResult(input);

            Assert.Equal("fizzbuzz", actualoutput);
        }
    }
}