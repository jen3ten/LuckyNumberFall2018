using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbers09._2018
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome to Lucky Numbers
            //Present the jackpot amount to the user
            Console.WriteLine("Welcome to LUCKY NUMBERS");

            //Calculate the winning jackpot based on the current date
            double dayOfMonth = DateTime.Now.Day;
            double monthNum = DateTime.Now.Month;
            double jackpot = dayOfMonth / monthNum * 1234567.89;
            Console.WriteLine("Today's winning jackpot is {0:$0,000.00}.  Good Luck!!", jackpot);
            Console.WriteLine();

            bool playAgain = true;
            do
            {
                //Initialize variables
                int[] luckyNums = new int[6];
                int[] randomNums = new int[6];
                int minNum;
                int maxNum;
                int inputLuckyNum;
                bool outOfRange;
                bool repeatNum = false;

                //User Input
                //Ask user for min value of range
                do
                {
                    outOfRange = false;
                    Console.Write("Please enter a minimum value for the Lucky Numbers (0 or greater): ");
                    minNum = int.Parse(Console.ReadLine());
                    if(minNum < 0)
                    {
                        Console.WriteLine("The number you entered is not greater than 0.  Please try again.");
                        outOfRange = true;
                    }
                } while (outOfRange);

                //Ask user to max value of range
                do
                {
                    outOfRange = false;
                    Console.Write("Please enter a maximum value for the Lucky Numbers ({0} or greater): ", minNum + 20);
                    maxNum = int.Parse(Console.ReadLine());
                    if(maxNum < minNum + 20)
                    {
                        Console.WriteLine("The number you entered is not large enough.  Please try again.");
                        outOfRange = true;
                    }
                } while (outOfRange);

                //Ask user to enter their 6 unique lucky numbers within the defined range
                Console.WriteLine("Please enter 6 unique Lucky Numbers between {0} and {1}", minNum, maxNum);
                for(int i = 0; i < 6; i++)
                {
                    do
                    {
                        Console.Write("Enter Lucky Number #{0}: ", i + 1);
                        inputLuckyNum = int.Parse(Console.ReadLine());
                        if(inputLuckyNum < minNum || inputLuckyNum > maxNum)
                        {
                            Console.WriteLine("The number you  entered is out of range.  Please try again.");
                            outOfRange = true;
                        }
                        else if (luckyNums.Contains(inputLuckyNum))
                        {
                            Console.WriteLine("You have entered a duplicate number.  Please try again.");
                            repeatNum = true;
                        }
                        else
                        {
                            luckyNums[i] = inputLuckyNum;
                            repeatNum = false;
                            outOfRange = false;
                        }
                    } while (repeatNum || outOfRange);
                }

                //Generate 6 unique random numbers within the range given by the user
                //Display the list of lucky numbers as 'Lucky Number: #'

                //Count the number of lucky numbers guessed correctly

                //Calculate the winnings

                //Allow user to quit or play again by typing 'yes' or 'no'
                //If user ends game display 'Thanks for playing'
                Console.WriteLine();
                Console.Write("Would you like to play again? (yes/no): ");
                if(Console.ReadLine().ToLower() != "yes")
                {
                    playAgain = false;
                    Console.WriteLine("Thanks for playing.");
                }
            } while (playAgain);
        }
    }
}
