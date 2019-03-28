using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ryby2
{

    class CardCompar : IComparer<Card>//Class with methods that sort cards
    {
        public CardCompar(int i)
        {
            if (i == 1)
                Sort = SortBy.NumbersThenType;
                Sort = SortBy.TypeThenNumbers;

        }
        public SortBy Sort { get; private set; }
        public int Compare(Card x, Card y)
        {
            if(Sort == SortBy.NumbersThenType)
            
                if (x.number > y.number)
                    return 1;
                else if (x.number < y.number)
                    return -1;
                else
                    if (x.type > y.type)
                    return 1;
                else if (x.type < y.type)
                    return -1;
                else
                    return 0;
          
                  if (x.type > y.type)
                    return 1;
                else if (x.type < y.type)
                    return -1;
                if (x.number > y.number)
                    return 1;
                else if (x.number < y.number)
                    return -1;
                else
                    return 0;
            }
        }
        public enum SortBy
        {
            NumbersThenType,
            TypeThenNumbers,
        }
    }

