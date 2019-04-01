using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_8.Model
{
    class ShipChangedEventArgs:EventArgs
    {
        public Ship ShipUpdate { get; private set; }

        public bool Killed { get; private set; }

        public ShipChangedEventArgs(Ship ship, bool killed)
        {
            ShipUpdate = ship;
            Killed = killed;
        }
    }
}
