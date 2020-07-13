using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            //PrintDiamond();

            //Challenge 4
            //int[] mostCommonIntArray = new int[] { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 };
            //Console.WriteLine("The most common value in the array {0} is: {1}", StringifyIntArray(mostCommonIntArray), FindMostCommon(mostCommonIntArray));
            //mostCommonIntArray = new int[] { 5, 12, 6, 12, 5, 7, 14, 9, 5 };
            //Console.WriteLine("The most common value in the array {0} is: {1}", StringifyIntArray(mostCommonIntArray), FindMostCommon(mostCommonIntArray));
            //mostCommonIntArray = new int[] { 43, 3, 19, 4, 19 };
            //Console.WriteLine("The most common value in the array {0} is: {1}", StringifyIntArray(mostCommonIntArray), FindMostCommon(mostCommonIntArray));
            //mostCommonIntArray = new int[] { 6, 5, 9, 5, 9, 4, 6, 23, 9, 7, 9 };
            //Console.WriteLine("The most common value in the array {0} is: {1}", StringifyIntArray(mostCommonIntArray), FindMostCommon(mostCommonIntArray));

            //Challenge 5
            //int[] maxValueIntArray = new int[] { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 };
            //Console.WriteLine("The largest value in the array {0} is: {1}", StringifyIntArray(maxValueIntArray), FindLargest(maxValueIntArray));
            //maxValueIntArray = new int[] { 5, 12, 6, 12, 5, 7, 14, 9, 5 };
            //Console.WriteLine("The largest value in the array {0} is: {1}", StringifyIntArray(maxValueIntArray), FindLargest(maxValueIntArray));
            //maxValueIntArray = new int[] { 43, 3, 19, 4, 19 };
            //Console.WriteLine("The largest value in the array {0} is: {1}", StringifyIntArray(maxValueIntArray), FindLargest(maxValueIntArray));
            //maxValueIntArray = new int[] { 6, 5, 9, 5, 9, 4, 6, 23, 9, 7, 9 };
            //Console.WriteLine("The largest value in the array {0} is: {1}", StringifyIntArray(maxValueIntArray), FindLargest(maxValueIntArray));

            //Challenge 6
            //WriteUserInputToFile();

            //Challenge 7
            //WriteWordsTxtFileToConsole();

            //Challenge 8
            //RemoveWordUserSelects();

            //Challenge 9
            //string input1 = "Money and chickens for nothing";
            //Console.WriteLine("For the sentence: {0}", input1);
            //Console.WriteLine("The letter count array is:");
            //Console.WriteLine(StringifyStringArray(WordLetterCount(input1)));
            //string input2 = "Monsters in the, purported, lampshade";
            //Console.WriteLine("For the sentence: {0}", input2);
            //Console.WriteLine("The letter count array is:");
            //Console.WriteLine(StringifyStringArray(WordLetterCount(input2)));
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
        /// <summary>
        /// Prints a diamond figure. Default is 9 but can make any size figure by adjusting rowSize
        /// variable.
        /// </summary>
        static void PrintDiamond()
        {
            //rowSize must be odd and >= 3 for function to work
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

        //Challenge 4
        /// <summary>
        /// Finds the most common value in an array of integers. If one or more values share
        /// the same frequency, finds whichever occurs first in the array.
        /// </summary>
        /// <param name="array">Array of integers</param>
        /// <returns>
        /// An integer the represents the most common value in the array.
        /// If multiple values of the same frequency, returns whichever is first in the array.
        /// </returns>
        public static int FindMostCommon(int[] array)
        {
            List<int[]> counts = new List<int[]>();
            foreach (int oneInt in array)
            {
                bool countExists = false;
                foreach (int[] countArray in counts)
                {
                    if (countArray[0] == oneInt)
                    {
                        countExists = true;
                        countArray[1] = countArray[1] + 1;
                    }
                }
                if (!countExists)
                {
                    counts.Add(new int[] { oneInt, 1 });
                }
            }
            int[] highestCount = counts.First();
            foreach (int[] countArray in counts)
            { 
                if (countArray[1] > highestCount[1])
                {
                    highestCount = countArray;
                }
            }
            return highestCount[0];
        }

        //Challenge 5
        /// <summary>
        /// Finds the largest value in an array of integers and returns it.
        /// </summary>
        /// <param name="array">
        /// An array of integers.
        /// </param>
        /// <returns>
        /// An integer representing the largest value.
        /// </returns>
        public static int FindLargest(int[] array)
        {
            BubbleSortArray(array);
            return array[array.Length - 1];
        }

        /// <summary>
        /// A simple bubble sort method. Takes in an array and integers, sorts it in place.
        /// </summary>
        /// <param name="array">
        /// An array of integers, positive or negative.
        /// </param>
        public static void BubbleSortArray(int[] array)
        {
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        notSorted = true;
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
        }

        //Challenge 6
        /// <summary>
        /// Prompts the user for the text they'd like to write to the "words.txt" file.
        /// </summary>
        static void WriteUserInputToFile()
        {
            Console.WriteLine("What words would like carved into eternity?");
            string userInput = Console.ReadLine();
            string path = "../../../words.txt";
            WriteStringToFile(userInput, path);
        }

        /// <summary>
        /// Appends the str parameter to the file specified in the path parameter. If file
        /// already has any text, new text will be appended on a new line.
        /// </summary>
        /// <param name="str">
        /// The text to be written to the file.
        /// </param>
        /// <param name="path">
        /// The path of the file
        /// </param>
        public static void WriteStringToFile(string str, string path)
        {
            str = System.Environment.NewLine + str;
            File.AppendAllText(path, str);
        }

        //Challenge 7
        /// <summary>
        /// Writes the text content of the "words.txt" file to the console.
        /// </summary>
        static void WriteWordsTxtFileToConsole()
        {
            string path = "../../../words.txt";
            Console.WriteLine(ReadFileAt(path));
        }

        /// <summary>
        /// Reads the file at the path parameter, and returns its contents as a string.
        /// </summary>
        /// <param name="path">
        /// The path of a file.
        /// </param>
        /// <returns>
        /// A string of the text contents of the file.
        /// </returns>
        public static string ReadFileAt(string path)
        {
            StringBuilder rtnString = new StringBuilder();
            using (StreamReader strmReader = File.OpenText(path))
            {
                string nextLine;
                while ((nextLine = strmReader.ReadLine()) != null)
                {
                    rtnString.AppendLine(nextLine);
                }
            }
            return rtnString.ToString();
        }

        //Challenge 8
        /// <summary>
        /// Prompts the user for which word they'd like to remove from the "words.txt" file.
        /// </summary>
        static void RemoveWordUserSelects()
        {
            Console.WriteLine("The file words.txt contains the following text:");
            WriteWordsTxtFileToConsole();
            Console.Write("Select one word to remove from the file: ");
            string word = Console.ReadLine();
            string path = "../../../words.txt";
            RemoveWordFromFile(word, path);
            Console.WriteLine("After removing {0} the file contains the following text:", word);
            WriteWordsTxtFileToConsole();
        }

        /// <summary>
        /// Removes a word from the file the given path.
        /// </summary>
        /// <param name="word">string: the word to be removed</param>
        /// <param name="path">string: the path of the file</param>
        /// <remarks>
        /// Does not work for any word next to a punctuation symbol. I couldn't figure out a simple way
        /// to preserve punctuation and capture words next to it.
        /// </remarks>
        public static void RemoveWordFromFile(string word, string path)
        {
            string fileText = ReadFileAt(path);
            string[] textLines = fileText.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            List<string> newText = new List<string>();
            //StringBuilder newText = new StringBuilder();
            StringBuilder newLine = new StringBuilder();
            char[] delimiters = { ' ' };
            foreach (string oneLine in textLines)
            {
                newLine.Clear();
                string[] words = oneLine.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    string oneWord = words[i];
                    if (oneWord.ToLower() != word.ToLower())
                    {
                        newLine.Append(oneWord);
                        if (i < words.Length - 1)
                        {
                            newLine.Append(" ");
                        }
                    }
                }
                newText.Add(newLine.ToString());
            }
            WriteTextToPath(path, newText.ToArray());
        }

        /// <summary>
        /// Writes text to the file at a given path without the blank line File.WriteAllText() adds.
        /// Based on this solution: https://stackoverflow.com/a/11689630/2149946
        /// </summary>
        /// <param name="path">string: the path of the file to write to.</param>
        /// <param name="text">string[]: the text to write, as an array of strings with each string being a line</param>
        public static void WriteTextToPath(string path, string[] textAsLines)
        {
            File.Delete(path);
            using (Stream fileStream = File.OpenWrite(path))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    if (textAsLines.Length > 0)
                    {
                        //write all but the last line using for loop
                        for (int i = 0; i < textAsLines.Length - 1; i++)
                        {
                            writer.WriteLine(textAsLines[i]);
                        }
                        //write last line
                        string lastLine = textAsLines[textAsLines.Length - 1];
                        writer.Write(lastLine);
                    }
                }
            }
        }

        //Challenge 9
        /// <summary>
        /// A method that takes a string sentence, and returns an array of strings showing how many words are in each word in the sentence.
        /// </summary>
        /// <param name="sentence">
        /// string: a sentence
        /// </param>
        /// <returns>
        /// An array of strings with each element in the format "aWord: 5".
        /// </returns>
        public static string[] WordLetterCount(string sentence)
        {
            char[] delimiters = { ' ', ',', '.', '?', '!', ':', ';' };
            string[] words = sentence.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            string[] wordLetterCounts = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                string oneWord = words[i];
                string wordAndCount = $"{oneWord.ToLower()}: {oneWord.ToCharArray().Length}";
                wordLetterCounts[i] = wordAndCount;
            }
            return wordLetterCounts;
        }

        //Helper methods
        /// <summary>
        /// Builds a nicely formatted string from an int array.
        /// </summary>
        /// <param name="intArray">
        /// An array of integers
        /// </param>
        /// <returns>
        /// A nicely formatted string representation of an integer array.
        /// </returns>
        static String StringifyIntArray(int[] intArray)
        {
            StringBuilder arrayString = new StringBuilder();
            for (int i = 0; i < intArray.Length; i++)
            {
                if (i >= intArray.Length - 1)
                {
                    arrayString.Append(intArray[i]);
                }
                else
                {
                    arrayString.Append($"{intArray[i]}, ");
                }
            }
            return arrayString.ToString();
        }
        
        /// <summary>
        /// Builds a nicely formatted string from a string array.
        /// </summary>
        /// <param name="strArray">
        /// An array of strings
        /// </param>
        /// <returns>
        /// A nicely formatted string representation of a string array.
        /// </returns>
        static String StringifyStringArray(string[] strArray)
        {
            StringBuilder arrayString = new StringBuilder();
            for (int i = 0; i < strArray.Length; i++)
            {
                if (i >= strArray.Length - 1)
                {
                    arrayString.Append(strArray[i]);
                }
                else
                {
                    arrayString.Append($"{strArray[i]}, ");
                }
            }
            return arrayString.ToString();
        }
    }
}
