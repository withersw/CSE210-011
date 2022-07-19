namespace Galaga.Game.Casting
{
    public class Ship : Actor
    {
        public Actor spaceShip;
        public int shipHealth = 5;
        public Ship()
        {
            //SetColor(color);
        }

        public Actor GetSpaceShip()
        {
            return spaceShip;
        }

        public int GetHealth()
        {
            return shipHealth;
        }

        public void FireBlast(Cast cast)
        {
                int x = 0;
                int y = -10; 
                Actor ship = cast.GetFirstActor("ship");
                Point position = ship.GetPosition();
                Point velocity = new Point(x, y);
                Actor blast =  new Actor();

                
                blast.SetPosition(position);
                blast.SetText("^");
                blast.SetFontSize(30);
                blast.SetColor(Program.ELECTRIC_BLUE);
                blast.SetVelocity(velocity);
                cast.AddActor("blast", blast);
        }

    }
}