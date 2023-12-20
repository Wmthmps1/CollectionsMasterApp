using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50
            int[] array50 = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50

            Populater(array50);
           

            //TODO: Print the first number of the array
            Console.WriteLine($"First number of array: {array50[0]}");

            //TODO: Print the last number of the array
            Console.WriteLine($"Last number of array: {array50[49]}");

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(array50);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");
            Array.Reverse(array50);
            NumberPrinter(array50);

            Console.WriteLine("---------REVERSE CUSTOM------------");

            int[] reversedArray = ReverseArray(array50);
            NumberPrinter(reversedArray);

            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(array50);
            NumberPrinter(array50);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(array50);
            NumberPrinter(array50);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            var numbers = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine($"List Capacity: {numbers.Capacity}");

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(numbers);

            //TODO: Print the new capacity
            Console.WriteLine($"New List Capacity: {numbers.Capacity}");

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");
            
            bool check = int.TryParse(Console.ReadLine(), out int validNumber);
            if (check == true)
            {
                NumberChecker(numbers, validNumber);
            } else
            {
                while (check == false)
                {
                    Console.WriteLine("Enter a valid search integer: ");
                    check = int.TryParse(Console.ReadLine(), out validNumber);
                }
                NumberChecker(numbers, validNumber);
            }
            
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(numbers);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(numbers);
            NumberPrinter(numbers);
            
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            numbers.Sort();
            NumberPrinter(numbers);
            
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            int[] numbersArray = numbers.ToArray();

            //TODO: Clear the list
            numbers.Clear();

            #endregion
        }
        
        private static void ThreeKiller(int[] numbers)
        {
            for(int i = 0; i < 50; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }
        }

        private static void OddKiller(List<int> numberList)
        {

            numberList.RemoveAll(i => i % 2 != 0);
            
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            bool found = false;
            int i = 0;

            do
            {
                if (searchNumber == numberList[i])
                {
                    found = true;
                }
                i++;
            } while (i < numberList.Count);

            if (found == true)
            {
                Console.WriteLine("Your number is in the list");
            } else
            {
                Console.WriteLine("Your number is not in the list");
            }

        }

        private static void Populater(List<int> numberList)
        {
            Random rng = new Random();

            for (int i = 0; i < 50; i++)
            {
                numberList.Add(rng.Next(1, 50));
            }
        }

        private static void Populater(int[] numbers)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
            {
                numbers[i] = rng.Next(1, 50);
            }


        }

        private static int[] ReverseArray(int[] array)
        {
            var newArray = new int[50];
            int newIndex = 0; 
            
            for(int i = 49; i >= 0; i--)
            {
                newArray[newIndex] = array[i];
                newIndex++;
            }
            return newArray;
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
