using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

#nullable enable
namespace Delegates_n_Tasks
{
    internal class Utilities
    {
        public System.ConsoleColor DefaultBackgroundColor { get; }
        public Utilities()
        {
            DefaultBackgroundColor = Console.BackgroundColor;
        }

        public int GetChoice()
        {
            try
            {
                Console.WriteLine("Please enter a integer between 0-16 (see assignment document for more info): ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in Utilities / GetChoice. Exception = {e}");
            }
            return -1;
        }
        public string? GetValidString()
        {
            try
            {
                return Convert.ToString(Console.ReadLine());
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in Utilities / GetValidString. Exception = {e}");
            }
            return null;
        }
        public int? GetValidint()
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception in Utilities / GetValidInteger. Exception = {e}");
            }
            return null;
        }
        public decimal LargestNumber(decimal value1, decimal value2)
        {
            return Math.Max(value1, value2);
        }
        public int LargestNumber(int value1, int value2)
        {
            return Math.Max(value1, value2);
        }
        public decimal CustomMathCalculaton(decimal value)
        {
            return (decimal)Math.Pow(Math.Sqrt((double)value), (2 * 10));
        }

    }
}
