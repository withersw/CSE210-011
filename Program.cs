//Wade Withers
//CSE210

using System.Collections.Generic;

static void main()
{
    
string[] grid = {"0","1","2","3","4","5","6","7","8","9"};
int game = 0; //checks of game is still going. If calue is 1 someone won. If value is -1 it's a draw.
int choice; //user's choice of where they want to mark
int playerOne = 1;
int winner = 0;


Console.WriteLine("Player one will be X and player two will be O.");

Board();
gamePlay();

 void Board()//create tic tac toe table
{
    Console.WriteLine("   |   |   ");
    Console.WriteLine($" {grid[1]} | {grid[2]} | {grid[3]}");
    Console.WriteLine("___|___|___");
    Console.WriteLine("   |   |   ");
    Console.WriteLine($" {grid[4]} | {grid[5]} | {grid[6]}");
    Console.WriteLine("___|___|___");
    Console.WriteLine("   |   |   ");
    Console.WriteLine($" {grid[7]} | {grid[8]} | {grid[9]}");
    Console.WriteLine("   |   |   ");
}

 void gamePlay() 
 {
    int turn = 0;
    while (game == 0)
    {        
            Console.Write("Player 1 enter where you want to go(1-9): ");
            int playerOneTurn = int.Parse(Console.ReadLine());
            grid[playerOneTurn] = "X";
            Board();
            turn++;
            gameOutcome();
        
        if (game == 1)
        {
            winner = 1;
            Console.WriteLine("Player 1 wins!");
            break;            
        }
        else if (turn == 9)
        {
            Console.WriteLine("The game has ended in a draw.");
            break;
        }
        
            Console.WriteLine("PLayer 2 enter where you want to go(1-9): ");
            int playerTwoTurn = int.Parse(Console.ReadLine());
            grid[playerTwoTurn] = "O";
            Board();
            turn++;
            gameOutcome();
        
        if (game == 1)
        {
            winner = 2;
            Console.WriteLine("Player 2 wins!");
            break;            
        }
        else if (turn == 9)
        {
            Console.WriteLine("The game has ended in a draw.");
            break;
        }       
    }
   
 }

 void gameOutcome()
 {
     if (grid[1] == grid[2] && grid[2] == grid[3])
     {
         game = 1;
     }
     else if (grid[4] == grid[5] && grid[5] == grid[6])
     {
         game = 1;
     }
     else if (grid[7] == grid[8] && grid[8] == grid[9])
     {
         game = 1;
     }
     else if (grid[1] == grid[4] && grid[4] == grid[7])
     {
         game = 1;
     }
     else if (grid[2] == grid[5] && grid[5] == grid[8])
     {
         game = 1;
     }
     else if (grid[3] == grid[6] && grid[6] == grid[9])
     {
         game = 1;
     }
     else if (grid[1] == grid[5] && grid[5] == grid[9])
     {
         game = 1;
     }
     else if (grid[7] == grid[5] && grid[5] == grid[3])
     {
         game = 1;
     }
     else 
        game = 0;
 }

}
main();