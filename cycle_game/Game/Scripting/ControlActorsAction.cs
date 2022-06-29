using cycle_game.Game.Casting;
using cycle_game.Game.Services;


namespace cycle_game.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the directionOne and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point directionOne = new Point(Constants.CELL_SIZE, 0);
        private Point directionTwo = new Point(-Constants.CELL_SIZE, 0);
        

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                directionOne = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                directionOne = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                directionOne = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                directionOne = new Point(0, Constants.CELL_SIZE);
            }
            if (keyboardService.IsKeyDown("j"))
            {
                directionTwo = new Point(-Constants.CELL_SIZE, 0);
            }
            if (keyboardService.IsKeyDown("l"))
            {
                directionTwo = new Point(Constants.CELL_SIZE, 0);
            }
            if (keyboardService.IsKeyDown("i"))
            {
                directionTwo = new Point(0, -Constants.CELL_SIZE);
            }
            if (keyboardService.IsKeyDown("k"))
            {
                directionTwo = new Point(0, Constants.CELL_SIZE);
            }

            Snake snake = (Snake)cast.GetFirstActor("snake");
            snake.TurnHead(directionOne);
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            snake2.TurnHead(directionTwo);

        }
    }
}