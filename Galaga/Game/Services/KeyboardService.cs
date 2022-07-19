using Raylib_cs;
using Galaga.Game.Casting;

namespace Galaga.Game.Services
{
    /// <summary>
    /// <para>Detects player input.</para>
    /// <para>
    /// The responsibility of a KeyboardService is to detect player key presses and translate them 
    /// into a point representing a direction.
    /// </para>
    /// </summary>
    public class KeyboardService
    {
        private int cellSize = 30;
        // public Point blastDirection = new Point(0, Program.CELL_SIZE);
        //public Color color;

        /// <summary>
        /// Constructs a new instance of KeyboardService using the given cell size.
        /// </summary>
        /// <param name="cellSize">The cell size (in pixels).</param>
        public KeyboardService(int cellSize)
        {
            this.cellSize = cellSize;
        }

        /// <summary>
        /// Gets the selected direction based on the currently pressed keys.
        /// </summary>
        /// <returns>The direction as an instance of Point.</returns>
        public Point GetDirection()
        {
            int dx = 0;
            int dy = 0;
            //Color color = new Color();

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                dx = -1;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                dx = 1;
            }    

            Point direction = new Point(dx, dy);
            direction = direction.Scale(cellSize);

            return direction;
        }
        public void GetBlastDirection(Cast cast)
            {
                if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                { 
                // Cast cast = new Cast();
                Ship ship = (Ship)cast.GetFirstActor("ship");
                ship.FireBlast(cast);
                }
            }
    }
}