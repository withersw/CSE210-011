using System;
using System.Collections.Generic;

namespace W04_high_low_game
{
    public class Director
    {
        public Card card = new Card();
        public bool isPlaying = true;
        public int score = 300;
        public string userChoice = "";

        public Director()
        {

        }

        
        public string getUserChoice()
        {
            Console.WriteLine("Higher or lower? [h/l] ");
            return userChoice = Console.ReadLine();
        }

        public void displayCards()
        {
            Console.WriteLine(card.previousCard);
            Console.WriteLine(card.currentCard);

        }

        public void doUpdates()
        {
            while (isPlaying == true)
            {
                if (userChoice == "h" && card.currentCard > card.previousCard
                || userChoice == "l" && card.currentCard < card.previousCard)
                {
                    score += 100;
                }
                else
                {
                    score -= 75;
                }
                
            }
            
        }

        public void doOutputs()
        {

        }
        public void StartGame(int score)
        {
            if (score > 0)
            {
                isPlaying = true;
            }
            else if (score <= 0)
            {
                isPlaying = false;
            }

            while (isPlaying == true)
            {
                getUserChoice();
                doUpdates();
            }
        }

    }
}