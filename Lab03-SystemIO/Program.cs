using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Lab03_SystemIO
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Challenge 1
            //GetProductFromUserInput();

            //Challenge 2
            //GetAverageFromUserInput();

            //Challenge 3
            PrintDiamond();
        }

        //Challenge 1
        /// <summary>
        /// Asks the user for three or more numbers, and returns their product.
        /// </summary>
        /// <remarks>
        /// Uses ThreeNumbersProduct() to calculate the product.
        /// </remarks>
        static void GetProductFromUserInput()
        {
            Console.WriteLine("Fortune to you my good friend! We get to find out the proudct of three numbers in the most laborous modern way possible!\n");
            Console.WriteLine("Please enter your three numbers separated by one or more spaces:");
            string userInput = Console.ReadLine();
            int product = ThreeNumbersProduct(userInput);
            Console.WriteLine("Your product is: {0}", product);
        }

        /// <summary>
        /// Takes a string of space-separated "words" and "multiples" the first three of
        /// of those "words" together. If a given "word" can be parsed to a number value,
        /// this is included in the final product. If a given "word" cannot be parsed
        /// as a number, then we multiple the product by 1. IF the string contains less than
        /// three "words", the function returns 0.
        /// </summary>
        /// <param name="input">A string consisting of one or more space-separated "words"</param>
        /// <returns>The product of the parsed "words" from the input string.</returns>
        public static int ThreeNumbersProduct(string input)
        {
            string[] spaceSep = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (spaceSep.Length < 3)
            {
                return 0;
            }
            int product = 1;
            for (int i = 0; i < 3; i++)
            {
                if (Int32.TryParse(spaceSep[i], out int result))
                {
                    product *= result;
                }
            }
            return product;
        }

        //Challenge 2
        /// <summary>
        /// Asks user for how many numbers they want to calculate the average of,
        /// and then user enters the numbers. Shows the user the average as an integer
        /// rounded down.
        /// </summary>
        static void GetAverageFromUserInput()
        {
            bool arraySizeValidInput = false;
            int arraySize = 0;
            do
            {
                Console.Write("Please enter a number between 2 - 10: ");
                string userInput = Console.ReadLine();
                if (Int32.TryParse(userInput, out int result))
                {
                    if (result >= 2 && result <= 10)
                    {
                        arraySizeValidInput = true;
                        arraySize = result;
                    }
                    else
                    {
                        Console.WriteLine("Number not with the specified range (2 - 10)");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number");
                }
            } while (!arraySizeValidInput);
            int[] intArray = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                bool arrayInsertValidInput = false;
                do
                {
                    Console.Write("{0} of {1} - Enter a number: ", i + 1, arraySize);
                    string userInput = Console.ReadLine();
                    if (Int32.TryParse(userInput, out int result))
                    {
                        arrayInsertValidInput = true;
                        intArray[i] = result;
                    }
                    else
                    {
                        Console.WriteLine("Entry is not a number, please enter another.");
                    }
                } while (!arrayInsertValidInput);
            }
            int average = AverageArray(intArray);
            Console.WriteLine("The average of these {0} numbers is {1}", arraySize, average);
        }

        /// <summary>
        /// Calculates the average, as an integer rounded down, of the numbers in
        /// the parameter array.
        /// </summary>
        /// <param name="array">An array of integers</param>
        /// <returns>The average of the integers in the array, as an integer rounded
        /// down.
        /// </returns>
        public static int AverageArray(int[] array)
        {
            int sum = 0;
            foreach (int oneInt in array)
            {
                sum += oneInt;
            }
            return sum / array.Length;
        }


        //Challenge 3
        static void PrintDiamond()
        {
            int rowSize = 9;
            int rowsAboveAndBelowMiddle = rowSize / 2;
            string[] diamondTopAndMiddleArray = new string[rowsAboveAndBelowMiddle + 1];
            string[] diamondRow = new string[rowSize];
            for (int i = 0; i < diamondTopAndMiddleArray.Length; i++)
            {
                Array.Fill(diamondRow, " ");
                int startingStarIndex = (rowSize / 2) - i;
                for (int j = startingStarIndex; j <= startingStarIndex + (i * 2); j++)
                {
                    diamondRow[j] = "*";
                }
                diamondTopAndMiddleArray[i] = String.Join("", diamondRow);
            }
            string[] diamondBottomArray = new string[rowsAboveAndBelowMiddle];
            for (int i = 0; i < rowsAboveAndBelowMiddle; i++)
            {
                diamondBottomArray[i] = diamondTopAndMiddleArray[diamondTopAndMiddleArray.Length - (i + 2)];
            }
            foreach (string oneRow in diamondTopAndMiddleArray)
            {
                Console.WriteLine(oneRow);
            }
            foreach (string oneRow in diamondBottomArray)
            {
                Console.WriteLine(oneRow);
            }

        }
    }
}
