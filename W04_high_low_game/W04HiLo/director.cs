using System;
using System.Collections.Generic;

namespace W04_high_low_game
{
    public class Director
    {

        
        public bool isPlaying = true;
        public int score = 300;
        public string userChoice = "";
        public string playAgain = "";

        public Director()
        {

        }

        public void getInputs()
        {
            Console.Write("Higher or lower? [h/l] ");
            userChoice = Console.ReadLine();
           
        }

        public void doUpdates(Card card)
        {
            int newCard = card.cardChoice();
            int oldCard = card.cards.Last();

                if (userChoice == "h" && newCard > oldCard
                || userChoice == "l" && newCard < oldCard )
                {
                    score += 100;
                }
                else
                {
                    score -= 75;
                }
            Console.WriteLine($"The new card was {newCard}");
            card.cards.Add(newCard);
            
        }

        public void doOutputs()
        {
            Console.WriteLine($"Your score is {score}");
            Console.Write("Play again? [y/n] ");
            playAgain = Console.ReadLine();
            if (playAgain == "n" || score <= 0)
            {
                isPlaying = false;
            }
            else
            {
                isPlaying = true;
            }
        }
       
        public void StartGame(Card card)
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
                getInputs();
                doUpdates(card);
                doOutputs();
            }
        }

    }
}