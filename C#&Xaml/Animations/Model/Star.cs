using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
namespace _Animacje.Model
{
    class Star
    {
        //location of star
        public Point Location
        {
            get;set;
        }
        //set location
        public Star(Point location)
        {
            Location = location;
        }
    }
}
