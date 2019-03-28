using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ryby2
{
    
    class Card : IComparable<Card>
    {
        public Type type { get; set; }
        public Numbers number { get; set; }

        public Card(Numbers x,Type p)//creating card
        {
            number = x;
            type = p;
        }
        public string Name
        {
            get
            {
                return type.ToString() + " of " + number.ToString(); 
            }
        }

        public int CompareTo(Card karta) //method for sorting cards in numbers order
        {
            if (this.number > karta.number)
                return 1;
            else if (this.number < karta.number)
                return -1;
            else
                return 0;
        }
        public override string ToString()
        {
            return Name;
        }

        public static string Plural(Numbers number, int count)//method used for proper spell
        {
            if (count == 0)
                return name0[(int)number - 1];//if 0 cards use name= table names
            else if (count == 1)
                return name1[(int)number];//if 1 use name1 table names
            return names2OrMore[(int)number];//else name20ormore table
        }
        static private string[] names2OrMore = new string[]//tables of names used in Plural method
        {
            "" ,"asow","dwojek","trojek","czworek","piatek","szostek","siodemek","osemek","dziewiatek","dziesatek","waletow","dam","krolow"
        };
        static private string[] name1 = new string[] { "", "asa", "dwojke", "trojke", "czworke", "piatke", "szostke", "siodemke", "osemke", "dziewiatke", "dziesiatke", "waleta", "dame", "krola" };
        static private string[] name0 = new string[] { "", "asy", "dwojek", "trojek", "czworek", "piatek", "szostek", "siodemek", "osemek", "dziewiatek", "waletow", "dam", "krola" };


    }
    
   
    enum Type
    {
        Diamond,
        Hearts,
        Spades,
        belly,
    }
}
