using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace App_8.Model
{
    class Player : Ship
    {
        static Size PlayerSize = new Size(25, 15);
        public const int speed = 10;
        public Player():base(new Point(200,10),PlayerSize)
        {

        }

        public override void Move(Direction direction)
        {
            if (Direction.Down == direction)
            {
                if (Location.Y <= 0)
                    return;
                else
                    Location = new Point(Location.X, Location.Y - 10);
            }
            if (Direction.up == direction)
            {
                if (Location.Y >= 300)
                    return;
                else
                    Location = new Point(Location.X, Location.Y + 10);
            }
            if (Direction.Left == direction)
            {
                if (Location.X <= 0)
                    return;
                else
                    Location = new Point(Location.X - 10, Location.Y);
            }
            if (Direction.Right == direction)
            {
                if (Location.Y >= 400)
                    return;
                else
                    Location = new Point(Location.X + 10, Location.Y);
            }

        }
    }
    }

