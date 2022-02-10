using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowGame
{
    public class Card
    {
        public int cardNum;
        public int cardSuit;
    }
    public class HighLowFunctions
    {
        const int rankCount = 13;
        const int suitCount = 4;
        const int deck = suitCount * rankCount;
        int score = 0;
        int round = 1;

        // initialize array
        Card[] CardDeck = new Card[deck];

        // player and CPU held cards
        public Card faceUp = new Card();
        public Card faceDown = new Card();

        enum cardRank
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }

        enum Suit
        {
            Hearts,
            Spades,
            Diamonds,
            Clubs
        }

        // initialize and fill the deck
        public void initializeDeck()
        {
            int index = 0;

            for (int i = 0; i < suitCount; i++)
            {
                for (int k = 0; k < rankCount; k++)
                {
                    CardDeck[index] = new Card();
                    CardDeck[index].cardNum = k;
                    CardDeck[index].cardSuit = i;

                    index++;
                }
            }

        }

        // randomize the card array
        public void Shuffle()
        {
            Random rnd = new Random();
            CardDeck = CardDeck.OrderBy(x => rnd.Next()).ToArray();
        }

        // randomly choose card, allow for use for both the CPU and Player
        public Card randomSelect()
        {
            Random rnd = new Random();
            Card card = new Card();
            int rndIndex;

            // could be optimized more
            // runs until the cards selected are not duplicates of the existing pulled card
            do
            {
                rndIndex = rnd.Next(0, deck);
            }while (CardDeck[rndIndex] == faceUp && CardDeck[rndIndex] == faceDown);

            card = CardDeck[rndIndex];

            return card;
        }

        int getRound()
        {
            return round;
        }

        int getScore()
        {
            return score;
        }
        public void increaseRound()
        {
            round++;
        }
        public void increaseScore()
        {
            score++;
        }

        public string getSuit(int s)
        {
            return Enum.GetName(typeof(Suit), s);
        }

        public string getRank(int r)
        {
            return Enum.GetName(typeof(cardRank), r);
        }

        public void resetStats()
        {
            score = 0;
            round = 1;
        }

        public void menu()
        {
            Console.WriteLine("1 - Start Game");
            Console.WriteLine("2 - Reset Game Stats");
            Console.WriteLine("3 - End Game\n");
            Console.WriteLine("Round " + getRound());
            Console.WriteLine("Current Player Score: " + getScore() + "\n");

            Console.WriteLine("\nWhat do you want to do?\n");
        }


        // card compare function
        // returns a bool to indicate whether the player has won or not
        public bool compareCards(int playerCard, int CPUCard, int guess)
        {
            int result = 0;

            if (playerCard < CPUCard) // face down is higher
                result = 1;
            else                      // face down is lower
                result = 2;

            if (guess == result)
                return true;
            else
                return false;
        }

    }
}
