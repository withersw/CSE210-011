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

        
        // public string getUserChoice()
        // {
        //     Console.Write("Higher or lower? [h/l] ");
        //     return userChoice = Console.ReadLine();
        // }

        public void displayPreviousCard(Card card)
        {
            Console.WriteLine($"The card is {card.getPreviousCard}");
        }
        public void displayCurrentCard(Card card)
        {
            Console.WriteLine($"The new card is: {card.getCurrentCard}");
        }

        public void getInputs()
        {
            Console.Write("Higher or lower? [h/l] ");
            userChoice = Console.ReadLine();
           
        }

        public void doUpdates(Card card)
        {
            int newCard = card.cardChoice();
            //int newCard = card.getCurrentCard();
            int oldCard = card.cards.Last();
            //displayCurrentCard(card);
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
            //card.displayCurrentCard();
            Console.WriteLine($"Your score is {score}");
            Console.Write("Play again? [y/n] ");
            playAgain = Console.ReadLine();
            if (playAgain == "n")
            {
                isPlaying = false;
            }
            else
            {
                isPlaying = true;
            }

            if (score > 0)
            {
                isPlaying = true;
            }
            else if (score <= 0)
            {
                isPlaying = false;
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