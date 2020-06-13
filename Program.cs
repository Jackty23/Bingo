using System;
using System.IO;
using System.Collections.Generic;

namespace Bingo
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";

            bool isNumeric = false;

            bool isNegative = false;

            int upperLimit = 0;

            while (!isNumeric || isNegative)
            {

                Console.WriteLine("Please enter an upper limit");
                userInput = System.Console.ReadLine();
                isNumeric = int.TryParse(userInput, out int number);

                if (isNumeric)
                {

                    if (number < 0)
                    {
                        isNegative = true;
                    }
                    else
                    {
                        isNegative = false;

                        upperLimit = number;
                    }
                }
            }

            Console.WriteLine("Welcome to the Swinburne Bingo Club");
            Console.WriteLine("1. Draw next number");
            Console.WriteLine("2. View all drawn numbers");
            Console.WriteLine("3. Check specific numbers ");
            Console.WriteLine("4. Exit");
            Console.WriteLine("5. Total of numbers drawn thus far");
            Console.WriteLine("6. Average of drawn thus far");


            userInput = System.Console.ReadLine();

            List<int> sortedListOfRandomNumbers = new List<int>();

            List<int> unSortedListOfRandomNumbers = new List<int>();



            while (userInput != "4")
            {

                if (userInput == "1")
                {
                    Random rand = new Random();

                    int randomNumber = 0;
                    randomNumber = rand.Next(upperLimit);

                    bool randomNumberExists = sortedListOfRandomNumbers.Contains(randomNumber);

                    if (!randomNumberExists)
                    {
                        Console.WriteLine("Your random Number is: " + randomNumber);
                        sortedListOfRandomNumbers.Add(randomNumber);
                        unSortedListOfRandomNumbers.Add(randomNumber);
                    }


                }
                if (userInput == "2")
                {
                    Console.WriteLine("a. Print all numbers in the order that they were drawn");
                    Console.WriteLine("b. Print all numbers in numerical order");
                    userInput = System.Console.ReadLine();

                    if (userInput == "a")
                    {
                        foreach (int item in unSortedListOfRandomNumbers)
                        {

                            Console.WriteLine(item);

                        }
                    }


                    if (userInput == "b")
                    {

                        sortedListOfRandomNumbers.Sort();
                        foreach (int item in sortedListOfRandomNumbers)
                        {

                            Console.WriteLine(item);

                        }

                    }

                }

                if (userInput == "3")
                {
                    Console.WriteLine("Enter a Number to check if it has been drawn ");
                    userInput = System.Console.ReadLine();
                    int userInputAsInt = Convert.ToInt32(userInput);

                    bool userEnteredNumberExists = sortedListOfRandomNumbers.Contains(userInputAsInt);

                    if (userEnteredNumberExists)
                    {

                        Console.WriteLine("The Number exists");


                    }

                    else
                    {

                        Console.WriteLine("The number does not exist");
                    }

                }

                if (userInput == "5")
                {

                    int totalSum = 0;


                    foreach (int item in unSortedListOfRandomNumbers)
                    {

                        totalSum = totalSum + item;

                    }




                    Console.WriteLine("Total sum of drawn numbers: " + totalSum);

                }

                if (userInput == "6")
                {

                    decimal averageSum = 0;

                    foreach (int item in unSortedListOfRandomNumbers)
                    {

                        averageSum = averageSum + item;
                    }

                    averageSum = averageSum / unSortedListOfRandomNumbers.Count;

                    Console.WriteLine("Total average of drawn numbers: " + averageSum);
                }





                Console.WriteLine("Choose another Option");
                userInput = System.Console.ReadLine();


            }

            // Create a string array with the lines of text
            //string[] lines = { "First line", "Second line", "Third line" };

            

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter( "drawn_numbers.txt"))
            {
                foreach (int line in sortedListOfRandomNumbers)
                    outputFile.WriteLine(line);
            }

        }
    }

}
