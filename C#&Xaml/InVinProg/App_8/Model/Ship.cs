using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace App_8.Model
{
   abstract class Ship
    {
        public Point Location { get; protected set; } //location of ship

        public Size size { get; private set; } //size of ship

        public Rect Area { get { return new Rect(Location, size); } } //property used for collisions

        public Ship(Point location, Size size)
        {
            Location = location;
            this.size = size;
        }

        public abstract void Move(Direction direction);
    }
}
