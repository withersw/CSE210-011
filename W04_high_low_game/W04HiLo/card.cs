using System;
using System.Collections.Generic;

namespace W04_high_low_game;

    public class Card
    {
        public int currentCard = 0;
        public int previousCard = 0;
        public List<int> cards = new List<int>();
        public int card;
        public Card()
        {
            
        }

        public int cardChoice()
        {
            Random random = new Random();
            card = random.Next(1,14);
            //cards.Add(card);
            return card;
        }

        public int getCurrentCard()
        {
            currentCard = cards.Last();
            return currentCard;
        }

        public int getPreviousCard()
        {
            previousCard = cards[^2];
            return previousCard;
        }

        public void displayPreviousCard()
        {
            Console.WriteLine($"The card is {getPreviousCard()}");
        }
        public void displayCurrentCard()
        {
            Console.WriteLine($"The new card is: {getCurrentCard()}");
        }
       

    }
