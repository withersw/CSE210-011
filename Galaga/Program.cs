using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Galaga.Game.Casting;
using Galaga.Game.Directing;
using Galaga.Game.Services;


namespace Galaga
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        public static int CELL_SIZE = 30; //15
        public static int FONT_SIZE = 30; //15
        private static int COLS = 30; //60
        private static int ROWS = 20; //40
        private static string CAPTION = "Galaga";
        private static string DATA_PATH = "Data/messages.txt";
        public static Color WHITE = new Color(255, 255, 255);
        public static Color ELECTRIC_BLUE = new Color(50, 100, 255);
        private static int  ENEMIES_ONE = 10;
        private static int ENEMIES_TWO = 20;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the bannr 
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the spaceship
            Ship ship = new Ship();
            ship.SetText("A");
            ship.SetFontSize(FONT_SIZE);
            ship.SetColor(WHITE);
            ship.SetPosition(new Point(MAX_X / 2, MAX_Y + MAX_Y - 30)); //15
            cast.AddActor("ship", ship); 

            //Actor ship = cast.GetFirstActor("ship");
            //Point position = ship.GetPosition();
            //Point velocity = new Point(x, y);
            //Actor blast =  new Actor();

            // load the messages
            List<string> messages = File.ReadAllLines(DATA_PATH).ToList<string>();

            // create the enemy spaceships
            Random random = new Random();
            for (int i = 0; i < ENEMIES_ONE; i++)
            {
                
                string text = "X";
                int score = -100;
                int dx = 0;
                int dy = 5;
                Point velocity = new Point(dx,dy);


                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                Color color = new Color(255, 0, 0);

                Enemies enemy = new Enemies();
                enemy.SetText(text);
                enemy.SetFontSize(FONT_SIZE);
                enemy.SetColor(color);
                enemy.SetPosition(position);
                enemy.setScore(score);
                enemy.SetVelocity(velocity);
                cast.AddActor("enemies", enemy);
            }

            for (int i = 0; i < ENEMIES_TWO; i++)
            {
                string text = "X";
                int score = -100;
                int dx = 0;
                int dy = 10;
                Point velocity = new Point(dx,dy);


                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                Color color = new Color(0, 255, 0);

                Enemies enemy = new Enemies();
                enemy.SetText(text);
                enemy.SetFontSize(FONT_SIZE);
                enemy.SetColor(color);
                enemy.SetPosition(position);
                enemy.setScore(score);
                enemy.SetVelocity(velocity);
                cast.AddActor("enemies", enemy);
            }

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);

            // test comment
        }
    }
}