using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodingExercises
{
    class Program
    {
        // Calls and tests functions (with example input where applicable)
        static void Main(string[] args)
        {
            // Problem 1 - Longest Sequence
            int[] sequence = { 1, 2, 1, 1, 0, 3, 1, 0, 0, 2, 4, 1, 0, 0, 0, 0, 2, 1, 0, 3, 1, 0, 0, 0, 6, 1, 3, 0, 0, 0 };
            Console.WriteLine("Longest sequence of days without a sale: {0}\n", P1_Sequence(sequence));

            // Problem 2 - Anagrams
            List<string> words = new List<string>() { "parts", "traps", "arts", "rats", "starts", "tarts", "rat", "art", "tar", "tars", "stars", "stray" };
            Console.WriteLine("Words in list that are anagrams of 'star': {0}", new string(string.Join(", ", P2_Anagram(words))));

            // Problem 3 - Stars on Screen (Pyramid)
            P3_Stars();

            // Problem 4 - Stars on Screen (Diamond)
            P4_Diamond();

            // Problem 5 - String Reversal
            string p5_test = "hello world";
            Console.WriteLine("Reversal of string \"{0}\" is \"{1}\"\n", p5_test, P5_Reversal(p5_test));

            // Problem 6 - Palindrome
            string[] p6_testArr = { "madam", "step on no pets", "book" };
            foreach (var s in p6_testArr)
                Console.WriteLine("String \"{0}\" is {1}", s, P6_Palindrome(s));
            Console.Write("\n");

            // Problem 7 - Sum of Digits
            int[] p7_testArr = { 12, 123, 5000 };
            foreach (var i in p7_testArr)
                Console.WriteLine("Sum of digits of {0} is {1}", i, P7_SumOfDigits(i));
            Console.Write("\n");

            // Problem 8 - TwoSums
            List<int> p8_testList = new List<int> { 3, 1, 5, 7, 5, 9 };
            int p8_testTarget = 10;
            Console.WriteLine("The indices of the first two elements of [{0}] which sum to {1} are: {2}\n",
                new String(string.Join(", ", p8_testList)), p8_testTarget, P8_TwoSums(p8_testList, p8_testTarget));

            // Problem 9 - Nth Prime
            List<int> p9_testList = new List<int> { 3, 5, 11, 24, 25 };
            foreach (int i in p9_testList)
                if (P9_NthPrime(i) != 0)
                    Console.WriteLine("Prime number #{0} is {1}", i, P9_NthPrime(i));
                else
                    Console.WriteLine("Prime number #{0} is out of range", i);
            Console.Write("\n");

            // Problem 10 - Next Prime
            List<int> p10_testList = new List<int> { 6, 11, 15, 228 };
            foreach (int i in p10_testList)
                Console.WriteLine("The next prime number after {0} is {1}", i, P10_NextPrime(i));
        }

        // Calculates and returns longest sequence of int i within int[] sequence
        static int P1_Sequence(int[] sequence)
        {
            int count = 0;
            int maxCount = 0;

            foreach (int i in sequence)
            {
                if (i == 0)
                {
                    count++;
                    if (count > maxCount)
                    {
                        maxCount = count;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            return maxCount;
        }

        // Finds and returns list of words that are an exact anagram of "star" in list<string> words
        static List<string> P2_Anagram(List<string> words)
        {
            List<string> newWords = new List<string>();
            Regex r = new Regex("[starSTAR]");

            foreach (string word in words)
            {
                if (!(word.Length != 4 || !r.IsMatch(word) || !(word.Contains('s') && word.Contains('t') && word.Contains('a') && word.Contains('r'))))
                {
                    newWords.Add(word);
                }
            }

            return newWords;
        }

        // Prints pyramid of stars with height equal to int r
        static void P3_Stars()
        {
            int r = 5;

            // Iterates from 0 to rows (r), incrementing
            for (int i = 0; i <= r; i++)
            {
                // Prints empty spaces according to the difference between rows and current row
                for (int j = 1; j <= r - i; j++)
                {
                    Console.Write(" ");
                }

                // Prints asterisks according to 2 times the current row, minus 1
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }

                // Prints a line break
                Console.Write("\n");
            }
        }

        // Prints diamond of stars, with centre line at int r
        static void P4_Diamond()
        {
            int r = 5;

            // Iterates from 0 to rows (r), incrementing
            for (int i = 0; i <= r; i++)
            {
                // Prints empty spaces according to the difference between rows and current row
                for (int j = 1; j <= r - i; j++)
                {
                    Console.Write(" ");
                }

                // Prints asterisks according to 2 times the current row, minus 1
                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }

                // Prints a line break
                Console.Write("\n");
            }

            // Iterates from rows - 1 to 0, decrementing
            // Prints as above loop, but inverted, to complete the diamond
            for (int i = r - 1; i >= 0; i--)
            {
                for (int j = 1; j <= r - i; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 1; j <= 2 * i - 1; j++)
                {
                    Console.Write("*");
                }

                Console.Write("\n");
            }
        }

        // Reverses and returns string input
        static string P5_Reversal(string input)
        {
            char[] charArr = input.ToCharArray();
            Array.Reverse(charArr);

            return new string(charArr);
        }

        // Uses P5_Reversal() to determine and return if string input is palindrome
        static string P6_Palindrome(string input)
        {
            if (P5_Reversal(input) == input)
                return "Palindrome";
            else
                return "Not Palindrome";
        }

        // Calculates and returns the sum of digits within int input
        static int P7_SumOfDigits(int input)
        {
            // LINQ Lambda function version
            // return input.ToString().Sum(c => c - 48);

            int output = 0;
            // Splits input into character array
            var charArr = input.ToString().ToCharArray();

            // Converts each character in array to its numeric representation. This does not parse the symbol directly!
            // Uses '- 48' as ASCII char '0' has value 48, therefore '0' - 48 => 0
            foreach (var c in charArr)
            {
                // Sums the decimal representation of each character
                output += (Convert.ToInt32(c) - 48);
            }

            return output;
        }

        // Calculates and returns Tuple<int, int> of the indices within List<int> corresponding to two values within List<int> which sum to int target
        // Returns the optimal pairing with respect to time, if pairing exists, otherwise, returns null
        static Tuple<int, int> P8_TwoSums(List<int> list, int target)
        {
            // Creates a new dictionary for int key, int value pairs
            Dictionary<int, int> dict = new Dictionary<int, int>();

            // Iterates through input list
            for (int i = 0; i < list.Count; i++)
            {
                int val = list[i];

                // If int target - current int value exists as a value within the dictionary...
                // Creates and returns tuple<int, int> containing int indices of corresponding values
                if (dict.TryGetValue(target - val, out int index))
                {
                    return Tuple.Create(index, i);
                }

                // Adds current int value to dictionary with corresponding int index
                dict[val] = i;
            }

            return null;
        }

        // Returns nth prime number (if 2 <= result <= 97) where int input = n
        static int P9_NthPrime(int input)
        {
            int[] primesUpTo100 = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

            // Ensures index exists in array
            if (input < primesUpTo100.Length && input >= 0)
                return primesUpTo100[input];
            else
                return 0;
        }

        // Uses P10_isPrime to increment int input until it is prime, before returning it
        static int P10_NextPrime(int n)
        {
            // 2 is the smallest prime number
            if (n <= 1) return 2;

            bool found = false;

            // Increments n until n is prime, before returning it
            while (!found)
            {
                n++;
                if (P10_isPrime(n)) found = true;
            }

            return n;
        }

        // Determines if int n is prime
        static bool P10_isPrime(int n)
        {
            // 1 and lower are not prime
            if (n <= 1) return false;

            // Increment from 2 up to n
            for (int i = 2; i < n; i++)
            {
                // If n modulus current i is 0, it is divisible and not prime
                if (n % i == 0 && i != n) return false;
            }

            return true;
        }
    }
}
