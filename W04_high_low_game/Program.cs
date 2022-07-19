using System.Collections.Generic;

namespace W04_high_low_game
{
    public class Program
    {
        static int Main(string[] arg)
        {
            Director director = new Director();
            Card card = new Card();
            int firstCard = card.cardChoice();
            card.cards.Add(firstCard);
            Console.WriteLine($"The Card is {firstCard}");
            director.StartGame(card);
            return 0;
        }
    }
}
