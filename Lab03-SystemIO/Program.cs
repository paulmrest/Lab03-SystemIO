using System;

namespace Lab03_SystemIO
{
    public class Program
    {
        static void Main(string[] args)
        {
            AskUserForThreeNumbers();
        }

        //Challenge 1
        /// <summary>
        /// Asks the user for three or more numbers, and returns their product.
        /// </summary>
        /// <remarks>
        /// Uses ThreeNumbersProduct() to calculate the product.
        /// </remarks>
        static void AskUserForThreeNumbers()
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
    }
}
