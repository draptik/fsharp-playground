using System;

namespace SomeAppConsole
{
    public class FizzBuzz
    {
        public string Create(int number) 
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }

            if (number % 5 == 0)
            {
                return "Buzz";
            }

            if (number % 3 == 0)
            {
                return "Fizz";
            }

            return number.ToString();
        }
    }
}