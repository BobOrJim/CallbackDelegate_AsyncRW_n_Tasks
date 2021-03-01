using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable enable
namespace Delegates_n_Tasks
{
    internal class PreparationAssignmentApplication
    {
        private Utilities Utils = new Utilities();
        private Random rand = new Random();
        AsynchronousFileIO FileIOHandler = new AsynchronousFileIO();

        public PreparationAssignmentApplication()
        {
            FileIOHandler.callbackDelegate += Assignment_07_08_CallbackDelegate; //This instance, is now monitoring this event. If triggered/raised this function will run.
        }

        public async Task Run()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            while (true)
            {
                Console.WriteLine();
                switch (Utils.GetChoice())
                {
                    case 0:
                        Assignment_00();
                        break;
                    case 1:
                        Assignment_01();
                        break;
                    case 2:
                        Assignment_02();
                        break;
                    case 3:
                        Assignment_03();
                        break;
                    case 4:
                        Assignment_04();
                        break;
                    case 5:
                        Assignment_05(); //Polymorfism
                        break;
                    case 6:
                        Assignment_06();
                        break;
                    case 7:
                        Assignment_07(); //Asynchronous Task, with "token" and callback Delegate
                        break;
                    case 8:
                        Assignment_08(); //Asynchronous Task, with "token" and callback Delegate
                        break;
                    case 9:
                        Assignment_09();
                        break;
                    case 10:
                        Assignment_10();
                        break;
                    case 11:
                        Assignment_11();
                        break;
                    case 12:
                        Assignment_12();
                        break;
                    case 13:
                        Assignment_13();
                        break;
                    case 14:
                        Assignment_14(); 
                        break;
                    case 15:
                        Assignment_15();
                        break;
                    case 16:
                        Assignment_16();
                        break;
                    default:
                        break;
                }
            }
        }

        private void Assignment_00()
        {
            System.Environment.Exit(1);
        }
        private void Assignment_01()
        {
            Console.WriteLine("Hello World");
        }
        private void Assignment_02()
        {
            Console.WriteLine($"Please enter Firstname:");
            string? firstname = Utils.GetValidString();
            Console.WriteLine($"Please enter Lastname:");
            string? lastname = Utils.GetValidString();
            Console.WriteLine($"Please enter Age");
            int? age = Utils.GetValidint();
            Console.WriteLine($"Angiven data är:  {firstname} {lastname} {age} ");
        }
        private void Assignment_03()
        {
            if (Console.BackgroundColor == Utils.DefaultBackgroundColor)
                Console.BackgroundColor = ConsoleColor.Red;
            else
                Console.BackgroundColor = Utils.DefaultBackgroundColor;
        }
        private void Assignment_04()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        private void Assignment_05()
        {
            Console.WriteLine($"Please enter two comma separated numbers (integer or decimal) example '3.33, 4.44' or '66, 77 ");
            string[] words = Console.ReadLine().Split(", ");
            try
            {
                var FirstNumber = words[0].Contains(".") ? Convert.ToDecimal(words[0]) : Convert.ToUInt64(words[0]);
                var SecondNumber = words[1].Contains(".") ? Convert.ToDecimal(words[1]) : Convert.ToUInt64(words[1]);
                var result = Utils.LargestNumber(FirstNumber, SecondNumber);
                Console.WriteLine($"The largest number is = {result}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($" Exception in Assignment_05 = {e}");
            }
        }
        private void Assignment_06()
        {
            int secretNumber = rand.Next(1, 100);
            int? guessedNumber = -1;
            Console.WriteLine("Try and guess the secret number between 1-100:");
            while (guessedNumber != secretNumber)
            {
                try
                {
                    guessedNumber = Utils.GetValidint();
                    if (guessedNumber < secretNumber)
                        Console.WriteLine("To low, try again:");
                    else if (guessedNumber > secretNumber)
                        Console.WriteLine("To high, try again:");
                }
                catch (Exception e)
                {
                    Debug.WriteLine($" Exception in Assignment_06 = {e}");
                }
            }
            Console.WriteLine("Correct, the secret number was " + secretNumber);
        }
        private void Assignment_07()
        {
            Console.WriteLine($"Please enter some text to save to file.");
            string? userInput = Utils.GetValidString();
            if (!FileIOHandler.IsBusy)
                FileIOHandler.AsyncWriteStringToFile($"{userInput}");
            else
                Console.WriteLine($"Please wait, file is busy");
        }
        private void Assignment_08()
        {
            if (!FileIOHandler.IsBusy)
                FileIOHandler.AsyncReadStringFromFile();
            else
                Console.WriteLine($"Please wait, file is already in use!");
        }
        static void Assignment_07_08_CallbackDelegate(string typeOfOperation)
        {
            Console.WriteLine($"Dear user, the {typeOfOperation} is now done. (I.E Any greyed out save/load button goes back to normal).");
        }
        private void Assignment_09()
        {
            Console.WriteLine($"Please enter a decimal or Integer to preform some math on:");
            string? userInput = Utils.GetValidString();
            try
            {
                var number = userInput.Contains(".") ? Convert.ToDecimal(userInput) : Convert.ToUInt64(userInput);
                Console.WriteLine($"The calculated value is = {Utils.CustomMathCalculaton((decimal)number)}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($" Exception in Assignment_09 = {e}");
            }
        }
        private void Assignment_10()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    string _numberToPrint = Convert.ToString(i*j);
                    while (_numberToPrint.Length < 4)
                    {
                        _numberToPrint = " " + _numberToPrint;
                    }
                    Console.Write(_numberToPrint);
                }
                Console.WriteLine();
            }
        }
        private void Assignment_11()
        {
            int[] randomArray = Enumerable.Repeat(0, 100).Select(i => rand.Next(0, 100)).ToArray();
            Console.WriteLine("Array with random unsorted numbers: {0}", string.Join(", ", randomArray));
            Array.Sort(randomArray);
            Console.WriteLine("Same array with sorted numbers: {0}", string.Join(", ", randomArray));
        }
        private void Assignment_12() 
        {
            Console.WriteLine($"Please enter a word to check if its a panidrome ");
            string? phrase = Utils.GetValidString();
            try
            {
                char[] chars = phrase.ToLower().ToCharArray();
                if (chars.Reverse().SequenceEqual(chars))
                    Console.WriteLine($"{phrase} is a palindrome ");
                else
                    Console.WriteLine($"{phrase} is not a palindrome ");
            }
            catch (Exception e)
            {
                Debug.WriteLine($" Exception in Assignment_12 = {e}");
            }
        }
        private void Assignment_13()
        {
            Console.WriteLine($"Please enter two comma separated integers in any order ");
            List<int> betweenNumbers = new List<int>();
            try
            {
                string[] words = Console.ReadLine().Split(", ");
                List<int> numbers = words.Select(s => int.Parse(s)).ToList();
                numbers.Sort();
                for (int i = numbers[0]; i < numbers[1]; i++)
                {
                    betweenNumbers.Add(i);
                }
                Console.WriteLine("Between numers: {0}", string.Join(", ", betweenNumbers));
            }
            catch (Exception e)
            {
                Debug.WriteLine($" Exception in Assignment_13 = {e}");
            }
        }
        private void Assignment_14()
        {
            Console.WriteLine($"Please enter alot of comma-separated integers ");
            try
            {
                string[] words = Console.ReadLine().Split(", ");
                List<int> numbers = words.Select(s => int.Parse(s)).ToList();
                List<int> evenNumbers = new List<int>();
                List<int> oddNumbers = new List<int>();
                foreach (int number in numbers)
                    ((number % 2 == 0) ? (Action)(() => { evenNumbers.Add(number); }) : () => { oddNumbers.Add(number); })();
                evenNumbers.Sort();
                oddNumbers.Sort();
                Console.WriteLine("Even numbers: {0}", string.Join(", ", evenNumbers));
                Console.WriteLine("Odd numbers: {0}", string.Join(", ", oddNumbers));
            }
            catch (Exception e)
            {
                Debug.WriteLine($" Exception in Assignment_14 = {e}");
            }
        }
        private void Assignment_15()
        {
            Console.WriteLine($"Please enter alot of comma separated numbers, and please mix integer and decimal numbers '3.33, 4, 6.77, 500' ");
            List<string> words = Console.ReadLine().Split(", ").ToList();
            try
            {
                decimal _sum = 0;
                foreach (string word in words)
                {
                    var _number = word.Contains(".") ? Convert.ToDecimal(word) : Convert.ToUInt64(word);
                    _sum += (decimal) _number;
                }
                Console.WriteLine($"The total is = {_sum}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($" Exception in Assignment_15 = {e}");
            }
        }
        private void Assignment_16()
        {
            Console.WriteLine($"This is a game, enter player name");
            string? playerCharacterName = Utils.GetValidString();
            Console.WriteLine($"This is a game, enter the enemys name");
            string? enemyCharacterName = Utils.GetValidString();
            try
            {
                Character PlayerCharacter = new Character(playerCharacterName);
                Character EnemyCharacter = new Character(enemyCharacterName);
            }
            catch (Exception e)
            {
                Debug.WriteLine($" Exception in Assignment_16 = {e}");
            }
        }
    }
}