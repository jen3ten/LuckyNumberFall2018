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
                int[] userPicks = new int[6];
                int[] luckyNums = new int[6];
                int minNum;
                int maxNum;
                int inputUserPick;
                int randLuckyNum;
                int numMatches = 0;
                bool outOfRange;
                bool repeatNum = false;
                Random randNum = new Random();
                double winnings = 0;

                //User Input
                //Ask user for min value of range
                do
                {
                    outOfRange = false;
                    Console.Write("Please enter a minimum value for the Lucky Numbers (greater than 0): ");
                    minNum = int.Parse(Console.ReadLine());
                    if (minNum <= 0)
                    {
                        Console.WriteLine("The number you entered is not greater than 0.  Please try again.");
                        outOfRange = true;
                    }
                } while (outOfRange);

                //Ask user to max value of range
                do
                {
                    outOfRange = false;
                    Console.Write("Please enter a maximum value for the Lucky Numbers ({0} or greater): ", minNum + 19);
                    maxNum = int.Parse(Console.ReadLine());
                    if (maxNum < minNum + 19)
                    {
                        Console.WriteLine("The number you entered is not large enough.  Please try again.");
                        outOfRange = true;
                    }
                } while (outOfRange);

                //Ask user to enter their 6 unique lucky numbers within the defined range
                Console.WriteLine("Please enter 6 unique numbers between {0} and {1}", minNum, maxNum);
                for (int i = 0; i < userPicks.Count(); i++)
                {
                    do
                    {
                        Console.Write("Enter your Lucky Number pick #{0}: ", i + 1);
                        inputUserPick = int.Parse(Console.ReadLine());
                        if (inputUserPick < minNum || inputUserPick > maxNum)
                        {
                            Console.WriteLine("The number you entered is out of range.  Please try again.");
                            outOfRange = true;
                        }
                        else if (userPicks.Contains(inputUserPick))
                        {
                            Console.WriteLine("You have entered a duplicate number.  Please try again.");
                            repeatNum = true;
                        }
                        else
                        {
                            userPicks[i] = inputUserPick;
                            repeatNum = false;
                            outOfRange = false;
                        }
                    } while (repeatNum || outOfRange);
                }

                //Generate 6 unique random numbers within the range given by the user
                //Display the list of lucky numbers as 'Lucky Number: #'
                Console.WriteLine();
                Console.WriteLine("I will now generate 6 random Lucky Numbers between {0} and {1}", minNum, maxNum);
                Console.WriteLine("The Lucky Numbers are....");
                for (int i = 0; i < luckyNums.Count(); i++)
                {
                    do
                    {
                        repeatNum = false;
                        randLuckyNum= randNum.Next(minNum, maxNum + 1);
                        if (luckyNums.Contains(randLuckyNum))
                        {
                            repeatNum = true;
                        }
                    } while (repeatNum);
                    luckyNums[i] = randLuckyNum;
                    Console.WriteLine("Lucky Number: #{0}", luckyNums[i]);
                }

                //Count the number of lucky numbers guessed correctly
                for(int i = 0; i < userPicks.Count(); i++) //check all user picks for a match
                {
                    if (luckyNums.Contains(userPicks[i]))
                    {
                        numMatches++;
                    }
                }

                //Calculate the winnings
                Console.WriteLine("You matched {0} numbers.", numMatches);
                if(numMatches == 0)
                {
                    Console.WriteLine("Sorry, you didn't win...");
                }
                else
                {
                    winnings = ((double)numMatches / 6.0) * jackpot;
                    Console.WriteLine("You win {0:$0,000.00}", winnings);
                }

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
