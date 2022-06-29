using System;
using System.Collections.Generic;
using System.Linq;

namespace cycle_game.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Snake : Actor
    {
        private List<Actor> segments = new List<Actor>();
        //public Point position;
        //public Color color;

        /// <summary>
        /// Constructs a new instance of a Snake.
        /// </summary>
        public Snake(Point position, Color color)
        {
            SetColor(color);
            PrepareBody(position);
            //this.position = position;
            //PrepareBody(position);
        }

        /// <summary>
        /// Gets the snake's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the snake's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return segments[0];
        }

        /// <summary>
        /// Gets the snake's segments (including the head).
        /// </summary>
        /// <returns>A list of snake segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Grows the snake's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(Color color)
        {
            Actor head = segments.First<Actor>();
            Point position = head.GetPosition();

            Actor tail = segments.Last<Actor>();
            Point velocity = tail.GetVelocity();
            Point offset = velocity.Reverse();
            //Point position = tail.GetPosition().Add(offset);

            Actor segment = new Actor();
            segment.SetPosition(position);
            //segment.SetVelocity(velocity);
            segment.SetText("#");
            segment.SetColor(color);
            segments.Add(segment);

        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            Actor head = GetHead();
            head.MoveNext();
        }

        /// <summary>
        /// Turns the head of the snake in the given directionOne.
        /// </summary>
        /// <param name="velocity">The given directionOne.</param>
        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        private void PrepareBody(Point position)
        {
            // int x = Constants.MAX_X / 2;
            // int y = Constants.MAX_Y / 2;

            // for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            // {
                // Point position = new Point(x - i * Constants.CELL_SIZE, y);
                // Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                // string text = i == 0 ? "8" : "#";
                // Color color = i == 0 ? Constants.YELLOW : Constants.GREEN;
            Color color = GetColor();
            string text = "8";
            Actor segment = new Actor();
            segment.SetPosition(position);
            segment.SetVelocity(velocity);
            segment.SetText(text);
            segment.SetColor(color);
            segments.Add(segment);
            // }
        }
    }
}