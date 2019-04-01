using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace App_8.Model
{
    class Invader : Ship
    {
        private const int speed = 2;
        public static readonly Size InvaderSize = new Size(25, 15);
        public InvaderType Type { get; private set; }
        public int Score { get; private set; }
        
        public Invader(int score, InvaderType type):base(new Point(), InvaderSize)
        {
            Score = score;
            Type = type;
            
        }
        public override void Move(Direction direction)
        {
            if(Direction.Down == direction)
            {
                if (Location.Y <= 0)
                    return;
                else
                    Location = new Point(Location.X, Location.Y - 10);
            }
            if(Direction.up == direction)
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
                    Location = new Point(Location.X+10, Location.Y);
            }

            }
    }
}
