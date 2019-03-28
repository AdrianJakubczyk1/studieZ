using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ryby2
{
    class expectioncs:System.Exception
    {
        public expectioncs(string err):base(err)
        {

        }
    }
}
