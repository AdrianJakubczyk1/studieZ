using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
namespace _Animacje.Model
{//Bee moved event
    class BeeMovedEventArgs : EventArgs
    {
        public Bee BeethatMoved { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }

        public BeeMovedEventArgs(Bee beeThatMoved, double x, double y)
        {
            BeethatMoved = beeThatMoved;
            X = x;
            Y = y;
        }

       
    }
}
