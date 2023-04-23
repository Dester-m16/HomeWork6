using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork6
{

    class Program
    {
        static int Div(int x, int y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException();
            }
            return x / y;
        }

        static int ReadNumber(int start, int end)
        {
            int num;
            try
            {
                Console.Write($"Enter a number between {start} and {end}: ");
                num = int.Parse(Console.ReadLine());
                if (num < start || num > end)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return ReadNumber(start, end);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Number must be between {start} and {end}. Please try again.");
                return ReadNumber(start, end);
            }
            return num;
        }

        static void Main()
        {
            try
            {
                int num1 = ReadNumber(1, 100);
                int num2 = ReadNumber(1, 100);
                int result = Div(num1, num2);
                Console.WriteLine($"{num1} / {num2} = {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero.");
            }

            int[] nums = new int[10];
            int lastNum = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                try
                {
                    nums[i] = ReadNumber(lastNum, 100);
                    lastNum = nums[i] + 1;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    i--;
                }
            }
            Console.WriteLine("You entered the following numbers:");
            foreach (int num in nums)
            {
                Console.Write(num + " ");
            }
        }
    }
}