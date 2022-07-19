using System.Collections.Generic;
using Galaga.Game.Casting;
using Galaga.Game.Services;
//using System.Random;




namespace Galaga.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;
        public int score = 200;
        

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
                if (score == 0)
                {
                    List<Actor> actors = cast.GetAllActors();
                    foreach (Actor actor in actors)
                    {
                        actor.SetColor(Program.WHITE);
                    }
                }
            }
            videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor ship = cast.GetFirstActor("ship");
            Point velocity = keyboardService.GetDirection();
            ship.SetVelocity(velocity);
            Actor blast = (Actor)cast.GetFirstActor("blast");
            keyboardService.GetBlastDirection(cast);
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with enemys.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            Actor ship = cast.GetFirstActor("ship");
            List<Actor> blasts = cast.GetActors("blast");
            List<Actor> enemies = cast.GetActors("enemies");

            banner.SetText($"Score {score}");
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            ship.MoveNext(maxX, maxY);

            //ship blaster
            foreach (Actor actor_blast in blasts)
            {
                actor_blast.MoveNext(maxX, maxY);

                foreach (Actor actor in enemies)
                {
                    if (actor_blast.GetPosition().Equals(actor.GetPosition()))
                    {
                        // Enemies enemy = (Enemies) actor;
                        // this.score = enemy.getScore();
                        score = score + 100;
                        banner.SetText($"Score {score}");
                        cast.RemoveActor("enemies", actor);
                        cast.RemoveActor("blast", actor_blast);
                        cast.RemoveActor("blast", actor_blast);
                    }
                }
                if (actor_blast.GetPosition().GetY() == (0))
                {
                    cast.RemoveActor("blast", actor_blast);
                }
            }

            //enemies
            foreach (Actor actor in enemies)
            {
                actor.MoveNext(maxX, maxY);

                if (ship.GetPosition().Equals(actor.GetPosition()))
                {
                    Enemies enemy = (Enemies) actor;
                    this.score += enemy.getScore();
                    banner.SetText($"Score {score}");
                }
                if (actor.GetPosition().GetY() == (maxY - 15))
                {
                    Enemies enemy = (Enemies) actor;
                    System.Random random = new System.Random();
                    int x = enemy.GetPosition().GetX();
                    int y = enemy.GetPosition().GetY();
                    int randX = random.Next(30, maxX-30) * 30;
                    x += randX;
                    Point position = new Point(x,y);
                    enemy.SetPosition(position);

                }
            } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

    }
}