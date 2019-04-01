using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace App_8.Model
{
    class Shot
    {

        public const double ShotPixelsPerSecond = 95;//speed of shoot

        public Point Location { get; private set; }

        public static Size ShotsSize = new Size(2, 10);

        private Direction direction;
        public Direction Direction { get; private set; }

        private DateTime lastMoved;

        public Shot(Point location, Direction direction)
        {
            Location = location;
            this.direction = direction;
            lastMoved = DateTime.Now;
        }

        public void Move()
        {
            TimeSpan timeSinceLastMoved = DateTime.Now - lastMoved;
            double distance = timeSinceLastMoved.Milliseconds * ShotPixelsPerSecond / 1000;

            if (Direction == Direction.up) distance *= -1;
            Location = new Point(Location.X, Location.Y + distance);
            lastMoved = DateTime.Now;

        }

    }
}
