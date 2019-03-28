using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace ryby2
{
    class Player : Deck
    {//Player properties
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private Game game;
   

        public Player(string name, Random random,Game game) 
        {
            this.game = game;
            this.name = name;
            this.random = random;
            this.cards = new Deck() { };
            try
            {
                if (name == "wpisz imie")
                    throw new expectioncs("give us proper name");
            }catch(expectioncs)
            {
                
            }

         game.AddProgress(this.name+" Dołączył do gry");
        }


        public IEnumerable<Numbers> PullOutBooks()
        {
            List<Numbers> books = new List<Numbers>();
            for(int i = 0;i<=13;i++)
            {
                Numbers number = (Numbers)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                    if (cards.peek(card).number == number)
                        howMany++;
                if(howMany == 4)
                {
                    books.Add(number);
                    for (int card = cards.Count - 1; card >= 0; card--)
                        cards.Deal(card);
                }
            }
            return books;
        }

        public Numbers GetRandomValue()
        {
            Card CardNumber = cards.peek(random.Next(cards.Count));//look on random card
            return CardNumber.number;
        }

        public Deck DoYouHaveAny(Numbers number)
        {
            int NumberOfSame = cards.PullOutValue(number).Count;//look for same cards with same numbers
            Deck SameCards = cards.PullOutValue(number);
            game.AddProgress(this.name + " posiada " + NumberOfSame + Card.Plural(number,NumberOfSame)); //write how much of them players has
            return SameCards;


        }


        public void AskForACard(List<Player> player, int myIndex, Deck stock)
        {
            if (stock.Count > 0)
                if (cards.Count == 0)
                    cards.Add(stock.Deal());
            Numbers number = GetRandomValue();
            AskForACard(player, myIndex, stock, number);
        }

        public void AskForACard(List<Player> player, int myIndex, Deck stock, Numbers number)
        {
            int totalCardsGiven = 0;
            game.AddProgress("Pyta czy ktoś ma : " + Card.Plural(number, 1));
            for (int i = 0; i < player.Count; i++)
            {
                if (i != myIndex)
                {
                    Player gamer = player[i];
                    Deck CardGiven = DoYouHaveAny(number);
                    totalCardsGiven += CardGiven.Count;
                    while (CardGiven.Count > 0)
                        cards.Add(CardGiven.Deal());
                }

                if (totalCardsGiven == 0)
                    game.AddProgress(Name + " Pobrał karty ze stocku");
                cards.Add(stock.Deal());
            }
            
        }
       
        public int CardCount { get { return cards.Count; } }
        public void TakeCard(Card card) { cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Card Peek(int cardNumber) { return cards.peek(cardNumber);}
        public void SortHand() { cards.SortByValue(); }
    }
}
