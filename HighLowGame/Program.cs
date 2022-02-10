// Lisa Nguyen (lnguyen2263)
// Conestoga College Skills Coding 2022
// February 1 2022
// Console game of High Low made in C#

using System;
using System.Threading;

namespace HighLowGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Card player;
            Card CPU;
            int choice, guess = 0;
            bool game = true;
            bool win;

            HighLowFunctions func = new HighLowFunctions();

            func.initializeDeck();

            //////////////////////////////////////////////////////////////////////

            Console.WriteLine("Welcome to High-Low!\n");

            while (game)
            {
                func.menu();

                choice = Convert.ToInt32(Console.ReadLine()); // user input

                switch (choice)
                {
                    case 1:                 // play game
                        bool guessChoice = true;

                        Console.WriteLine("\nShuffling deck...\n");
                        func.Shuffle();

                        Thread.Sleep(1000); // wait 1s

                        func.faceUp = player = func.randomSelect();
                        func.faceDown = CPU = func.randomSelect();

                        Console.WriteLine("\nYour card is:\n" + func.getRank(player.cardNum) + " of " + func.getSuit(player.cardSuit) + "\n");

                        Console.WriteLine("Do you think the opponent's card is higher or lower?\n");
                        Console.WriteLine("1 - Higher\n2 - Lower");

                        while (guessChoice)
                        {
                            guess = Convert.ToInt32(Console.ReadLine()); // user input

                            switch (guess)
                            {
                                case 1: // higher
                                case 2: // lower
                                    win = func.compareCards(player.cardNum, CPU.cardNum, guess);

                                    Console.WriteLine("The opponent's card was...");

                                    Thread.Sleep(1000); // wait 1s

                                    Console.WriteLine(func.getRank(CPU.cardNum) + " of " + func.getSuit(CPU.cardSuit) + "!\n");

                                    if (win)
                                    {
                                        Console.WriteLine("You win!\n");
                                        func.increaseScore();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You lost!\n");
                                    }

                                    func.increaseRound();
                                    guessChoice = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid selection. Please try again.\n");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nResetting Stats...\n\n");
                        func.resetStats();

                        Thread.Sleep(1000); // wait 1s

                        break;
                    case 3:                 // exit
                        Console.WriteLine("\nThank you for playing!\n");
                        game = false;
                        break;
                    default:                // invalid choice
                        Console.WriteLine("Invalid selection. Please try again.\n");
                        break;
                }

            }

            System.Environment.Exit(0);
        }
    }
}
