using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace App_8.Model
{
    class ShotMovedEventArgs:EventArgs
    {
        public Shot shot { get; private set; }

        public bool Disappeared { get; private set; }

        public ShotMovedEventArgs(Shot shot, bool disappeared)
        {
            this.shot = shot;
            Disappeared = disappeared;
        }

    }
}
