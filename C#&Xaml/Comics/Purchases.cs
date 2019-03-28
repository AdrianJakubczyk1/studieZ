using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jan_Linq
{
    class Purchases
    {
        public int Issue { get; set; }
        public decimal Price { get; set; }
       public static IEnumerable<Purchases> FindPurchase()//list of purchases
        {
            List<Purchases> purchases = new List<Purchases>
            {
                new Purchases(){Issue = 68, Price=225M},
                new Purchases(){Issue = 19, Price=2375M},
                new Purchases(){Issue = 6, Price=3600M},
                new Purchases(){Issue = 57, Price=22M},
                new Purchases(){Issue = 36, Price=660M},
            };
            return purchases;
        }
        public static PriceRange EvaluatePrice(int price)//method telling if comic is cheap/midrange/expensive
        {
            if (price < 100M) return PriceRange.Cheap;
            else if (price <= 1000m) return PriceRange.Midrange;
            else return PriceRange.Expensive;
        }
    }
}
