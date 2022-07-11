using System;
using System.Collections.Generic;

namespace W04_high_low_game
{
    public class Card
    {
        public int currentCard = 0;
        public int previousCard = 0;
        public List<int> cards = new List<int>();

        public Card()
        {
            this.currentCard = currentCard;
            this.previousCard = previousCard;
            this.cards = cards;
        }

        public void cardChoice(List<int> cards)
        {
            Random random = new Random();
            public int card = random.Next(1,14);
            cards.Add(card);
        }

        public int getCurrentCard(int currentCard, List<int> cards)
        {
            currentCard = cards[cards.Count - 1];
            return currentCard;
        }

        public int getPreviousCard(int previousCard, List<int> cards)
        {
            previousCard = cards[cards.Count - 2];
            return previousCard;
        }
        // public void DisplayCurrentCard(currentCard)
        // {
            
        //     Console.WriteLine(currentCard);
        // }
        // public void DisplayPreviousCard(previousCard)
        // {
        //     Console.WriteLine(previousCard);
        // }

    }
}