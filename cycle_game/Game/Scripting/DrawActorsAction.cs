using System.Collections.Generic;
using cycle_game.Game.Casting;
using cycle_game.Game.Services;


namespace cycle_game.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");          
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");           
            List<Actor> segments = snake.GetSegments();
            List<Actor> segments2 = snake2.GetSegments();
            Actor score = cast.GetFirstActor("score");
            List<Actor> messages = cast.GetActors("messages");

            if (HandleCollisionsAction.isGameOver == true && HandleCollisionsAction.playerOneWins == true)
            {
                snake.GrowTail(Constants.ORANGE);
                snake2.GrowTail(Constants.WHITE);
            }
            else if (HandleCollisionsAction.isGameOver == true && HandleCollisionsAction.playerTwoWins == true)
            {
                snake.GrowTail(Constants.WHITE);
                snake2.GrowTail(Constants.BLUE);
            }
            else if (HandleCollisionsAction.isGameOver == false)
            {
                snake.GrowTail(Constants.ORANGE);
                snake2.GrowTail(Constants.BLUE);
            }
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments);
            videoService.DrawActors(segments2);
            videoService.DrawActor(score);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}