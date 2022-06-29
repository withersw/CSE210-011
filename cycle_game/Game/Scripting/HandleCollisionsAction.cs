using System;
using System.Collections.Generic;
using System.Data;
using cycle_game.Game.Casting;
using cycle_game.Game.Services;


namespace cycle_game.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        public static bool isGameOver = false;
        public static bool playerOneWins = false;
        public static bool playerTwoWins = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {

                HandleSegmentCollisions(cast);
                //HandleGameOver(cast);
            }
            else if (isGameOver == true)
            {
                 HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor head = snake.GetHead();
            Actor head2 = snake2.GetHead();
            List<Actor> body = snake.GetBody();
            List<Actor> body2 = snake2.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    head.SetColor(Constants.WHITE);
                    isGameOver = true;
                    playerTwoWins = true;
                }
            }

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    head2.SetColor(Constants.WHITE);
                    isGameOver = true;
                    playerOneWins = true;
                }
            } 

            foreach (Actor segment2 in body2)
            {
                if (segment2.GetPosition().Equals(head2.GetPosition()))
                {
                    head2.SetColor(Constants.WHITE);
                    isGameOver = true;
                    playerOneWins = true;
                }
            }

            foreach (Actor segment2 in body2)
            {
                if (segment2.GetPosition().Equals(head.GetPosition()))
                {
                    head.SetColor(Constants.WHITE);
                    isGameOver = true;
                    playerTwoWins = true;
                }
            }
        }

        public void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                List<Actor> segments = snake.GetSegments();
                Snake snake2 = (Snake)cast.GetFirstActor("snake2");
                List<Actor> segments2 = snake2.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                if (isGameOver == true && playerTwoWins == true)
                {
                    foreach (Actor segment in segments)
                    {
                        segment.SetColor(Constants.WHITE);                
                    }
                }

                if (isGameOver == true && playerOneWins == true)
                {
                    foreach (Actor segment2 in segments2)
                    {
                        segment2.SetColor(Constants.WHITE);
                    }
                }
            }
        }

    }
}