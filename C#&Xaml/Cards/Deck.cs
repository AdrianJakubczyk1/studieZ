using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace ryby2
{
    
    class Deck
    {
        private List<Card> cards;
            private Random random = new Random();
        public Deck()
        {
            cards = new List<Card>();
            for (int i = 0; i <= 3; i++)
                for (int value = 1; value <= 13; value++)
                    cards.Add(new Card((Numbers)value, (Type)i));
        }
       
        public Deck(IEnumerable<Card>initialCard)
        {
            cards = new List<Card>(initialCard);
        }
        public int Count { get { return cards.Count; } }
        public void Add(Card cardtoAdd)
        {
            cards.Add(cardtoAdd);
        }
        public Card Deal(int index)
        {
            Card CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal;
        }
        public void Shuffle()
        {
            List<Card> NewCard = new List<Card>();
            while(cards.Count  > 0)
            {
                int CardToMove = random.Next(cards.Count);
                NewCard.Add(cards[CardToMove]);
                cards.RemoveAt(CardToMove);
            }
            cards = NewCard;
        }
        public IEnumerable<string> GetCardNames()
        {
            int Size = cards.Count;
           string[] tablica = new string[Size];
            for (int i = 0; i < Size; i++)
                tablica[i] = cards[i].Name;
            return tablica;
        }
        public void Sort()
        {
            cards.Sort(new CardCompar(0));
        }
        public Card peek(int cardNumber)
        {
            return cards[cardNumber];
        }
        public Card Deal()
        {
            return Deal(0);
        }
        public bool ContainsValue(Numbers number)
        {
            foreach (Card card in cards)
                if (card.number == number)
                    return true;
            return false;
        }
        public Deck PullOutValue(Numbers number)
        {
            Deck decktoReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
                if (cards[i].number == number)
                    decktoReturn.Add(Deal(i));
            return decktoReturn;
        }
        public bool HasBook(Numbers number)
        {
            int NumberOfCards = 0;
            foreach (Card card in cards)
                if (card.number == number)
                    NumberOfCards++;
            if (NumberOfCards == 4)
                return true;
            else return false;
        }
        public void SortByValue()
        {
            cards.Sort(new CardCompar(1));
        }
        public void WriteCards(string FileName)
        {
            using (StreamWriter write_here = new StreamWriter(FileName))
            {
                for (int i = 0; i < cards.Count; i++)
                    write_here.WriteLine(cards[i].Name);
            }
        }
        public void ReadCards(string type)
        {
            Type typ;
            switch (type)
            {

                case "Spades":
                    typ = Type.Spades;
                    break;
                case "Hearts":
                    typ = Type.Hearts;
                    break;
                case "belly":
                    typ = Type.belly;
                    break;
                case "Diamond":
                    typ = Type.Diamond;
                    break;
                default:
                MessageBox.Show(type + "nie jest prawidlowym kolorem!");
                    break;

            }
        }
        public Deck(string FileName)
        {
            cards = new List<Card>();
            StreamReader reader = new StreamReader(FileName);
            while(!reader.EndOfStream)
            {
                bool invalidCart = false;
                string nextCard = reader.ReadLine();
                string[] cardParts = nextCard.Split(new char[] { ' ' });
                Numbers number = Numbers.Ace;
                switch (cardParts[0])
                {
                    case "Ace": number = Numbers.Ace; break;
                    case "Two": number = Numbers.two; break;
                    case "three": number = Numbers.three; break;
                    case "four": number = Numbers.four; break;
                    case "five": number = Numbers.four; break;
                    case "six": number = Numbers.six; break;
                    case "seven": number = Numbers.seven; break;
                    case "eight": number = Numbers.eight; break;
                    case "nine": number = Numbers.nine; break;
                    case "ten": number = Numbers.ten; break;
                    case "Lord": number = Numbers.Lord; break;
                    case "Queen": number = Numbers.Queen; break;
                    case "King": number = Numbers.King; break;
                    default:
                        invalidCart = true; break;
                }
                Type typ = Type.belly;
                    switch(cardParts[2])
                {
                    case "belly":typ = Type.belly;break;
                    case "Diamonds":typ = Type.Diamond;break;
                    case "Hearts":typ = Type.Hearts;break;
                    case "Spades":typ = Type.Spades;break;
                    default:invalidCart = true;break;
                }
                if (!invalidCart)
                    cards.Add(new Card(number, typ));

                }
            }
        
        }

    }
        

    

