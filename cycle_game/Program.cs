using cycle_game.Game.Casting;
using cycle_game.Game.Directing;
using cycle_game.Game.Scripting;
using cycle_game.Game.Services;


namespace cycle_game
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            int x = 300;
            int y = 225;
            int x2 = 600;
            int y2 = 450;
            Point position = new Point(x, y);
            Point position2 = new Point(x2,y2);
            Color color = Constants.ORANGE;
            Color color2 = Constants.BLUE;
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("snake", new Game.Casting.Snake(position, color));
            cast.AddActor("snake2", new Game.Casting.Snake(position2, color2));
            cast.AddActor("score", new Score());

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}