namespace Task1;

using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using static System.Console;

public class Program
{
    static void Main(string[] args)
    {

        // Input first primes set
        string firstPrompt = "Enter first set of numbers (comma-separated):";
        List<int> numbers1 = GetInputSet(firstPrompt); //List<int> Numbers1 = new List<int>(); Numbers1 = GetInput(Prompt);
        // Input second primes set
        string secondPrompt = "Enter second set of numbers (comma-separated):";
        List<int> numbers2 = GetInputSet(secondPrompt);

        // Print first primes set
        PrintPrimesFromInputset(numbers1);
        // Print second primes set
        PrintPrimesFromInputset(numbers2);

    }

    public static void PrintPrimesFromInputset(List<int> numbers)
    {
        int start = Math.Min(numbers[0], numbers[1]);
        int end = Math.Max(numbers[0], numbers[1]);
        List<int> primesList = GetPrimes(start, end);
        string primesString = string.Join(", ", primesList);
        WriteLine($"Primes btw {start}-{end}: {primesString}");
    }

    public static bool IsPrime(int n)
    {
        //greater than 1 that has no divisor other than 1 and itself
        if (n < 2) return false;
        int sqrt = (int)Math.Sqrt(n);
        for (int i = 2; i <= sqrt; i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    public static List<int> GetPrimes(int first , int second)
    {

        int start = Math.Min(first, second);
        int end   = Math.Max(first, second);
        //int start = (first < second) ? first : second;
        //int end = (first < second) ? second : first;
        List<int> primesList = new List<int>();
        for (int i = start; i <= end; i++)
        {
            if (IsPrime(i)) primesList.Add(i);
        }
        return primesList;
    }


    public static List<int> GetInputSet(string prompt)
    {
        while (true)
        {
            Write(prompt);
            string? input = ReadLine(); // ex:"12,30"

            if (string.IsNullOrWhiteSpace(input))
            {
                WriteLine("No input provided");
                continue;
            }
            
            string[] parts = input.Split(','); // ["12", "30"]
            if (parts.Length != 2)
            {
                WriteLine($"Please enter 2 integers: {String.Join(", ", parts)}");
                //WriteLine("Please enter 2 integers");
                continue;
            }

            List<int> numbers = new List<int>();

            foreach (var part in parts)
            {
                if (int.TryParse(part.Trim(), out int num))
                {
                    numbers.Add(num);
                }
                else
                {
                    WriteLine($"Invalid integer: {part}");
                    break;
                }
            }
            if (numbers.Count == 2) return numbers;
           
        }
    }
        
        

}

