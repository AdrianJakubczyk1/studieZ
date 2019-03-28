using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace ryby2
{
    [Serializable]
    class Game : INotifyPropertyChanged
    {
        private List<Player> players;
        private Dictionary<Numbers, Player> books;
        private Deck stock;
        public bool GameInProgress { get; private set; }
        public bool GameNotStarted { get { return !GameInProgress; } }
        public string PlayerName { get; set; }
        public ObservableCollection<string> Hand { get; private set; }
        public string Books { get { return DescribeBooks(); } }
        public string GameProgress { get; private set; }
     

        public event PropertyChangedEventHandler PropertyChanged;

        public void ClearProgress()
        {
            GameProgress = String.Empty;
            OnPropertyChanged("GameProgress");
        }

        

       public void ResetGame()
        {
            GameInProgress = false;
          
            OnPropertyChanged("GameInProgress");
            OnPropertyChanged("GameNotStarted");
            books = new Dictionary<Numbers, Player>();
            stock = new Deck();
            Hand.Clear();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if(propertyChangedEvent!=null)
            propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
        }

        public void StartGame()
        {
            ClearProgress();
            GameInProgress = true;
            OnPropertyChanged("GameInProgress");
            OnPropertyChanged("GameNotStarted");
            Random random = new Random();
            players = new List<Player>();
            players.Add(new Player(PlayerName, random, this));
            players.Add(new Player("Johan", random, this));
            players.Add(new Player("John", random, this));
            Deal();
            players[0].SortHand();
            Hand.Clear();
            foreach (String cardName in GetPlayerCardNames())
                Hand.Add(cardName);
            if (!GameInProgress)
                AddProgress(DescribePlayerHands());
            OnPropertyChanged("Books");
        }

        public void AddProgress(string progress)
        {
            GameProgress = progress + Environment.NewLine + GameProgress;
            OnPropertyChanged("GameProgress");
        }

        public Game(Deck deck)
        {
            stock = deck;
        }

        private void Deal()
        {
            stock.Shuffle();
            for (int i = 0; i < 5; i++)
            {
                foreach (Player player in players)
                    player.TakeCard(stock.Deal());
                foreach (Player player in players)
                    PullOutBooks(player);
            }
        }

        public Game()
        {
            PlayerName = "wpisz imie";
            Hand = new ObservableCollection<string>();
            ResetGame();
        }
        public string Bookie()
        {
            return this.Books;
        }
        public void PlayOneRound(int selectedPlayerCard)
        {
            Numbers cardToAskFor = players[0].Peek(selectedPlayerCard).number;
            for (int i = 0; i < players.Count; i++)
            {
                if (i == 0)
                    players[0].AskForACard(players, 0, stock, cardToAskFor);
                else
                    players[i].AskForACard(players, i, stock);
                if (PullOutBooks(players[i]))
                {
                    AddProgress(players[i].Name + " ma nowa grupe");
                    int card = 1;
                    while (card <= 5 && stock.Count > 0)
                    {
                        players[i].TakeCard(stock.Deal());
                        card++;
                    }
                }
                OnPropertyChanged("Books");
                players[0].SortHand();
                AddProgress(DescribePlayerHands());
                Bookie();
                if (stock.Count == 0 || stock.Count == 1)
                {
            AddProgress("stock jest pusty,koniec gry");
                    AddProgress("Zwyciezcą jest : " + GetWinnerName());
                    ResetGame();
                    return;
                }
            }
            Hand.Clear();
            foreach (String cardName in GetPlayerCardNames())
                Hand.Add(cardName);
            if (!GameInProgress)
                AddProgress(DescribePlayerHands());
            return;
        }

        public bool PullOutBooks(Player player)
        {
            IEnumerable<Numbers> booksPulled = player.PullOutBooks();
            foreach (Numbers number in books.Keys)
            {

                books.Add(number, player);

            }
            if (player.CardCount == 0)
                return true;
            return false;

        }

        public string DescribeBooks()
        {
            string whoHasWhichBooks = " ";
            foreach (Numbers number in books.Keys)
                whoHasWhichBooks += books[number].Name + " ma grupe "
            + Card.Plural(number, 0) + Environment.NewLine;
            return whoHasWhichBooks;
        }
        public string GetWinnerName()
        {
            Dictionary<string, int> winners = new Dictionary<string, int>();
            foreach (Numbers number in books.Keys)
            {
                string name = books[number].Name;
                if (winners.ContainsKey(name))
                    winners[name]++;
                else
                    winners.Add(name, 1);
            }
            int mostBooks = 0;
            foreach (string name in winners.Keys)
                if (winners[name] > mostBooks)
                    mostBooks = winners[name];
            bool tie = false;
            string winnerList = " ";
            foreach (string name in winners.Keys)
                if (winners[name] == mostBooks)
                {
                    if (!String.IsNullOrEmpty(winnerList))
                    {
                        winnerList += " i ";
                        tie = true;
                    }
                    winnerList += name;
                }
            winnerList += "  " + mostBooks + " grup";
            if (tie)
                return "Remis pomiedzy " + winnerList;
            else
                return winnerList;

        }
        public IEnumerable<string> GetPlayerCardNames()
        { return players[0].GetCardNames(); }
        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += players[i].Name + " ma " + players[i].CardCount;
                if (players[i].CardCount == 1)
                    description += " karte" + Environment.NewLine;
                else if (players[i].CardCount == 2 || players[i].CardCount == 3 || players[i].CardCount == 4)
                    description += " karty " + Environment.NewLine;
                else
                    description += " kart" + Environment.NewLine;

            }
            description += "na stocku jest " + stock.Count + Environment.NewLine;
            return description;
        }
        
    }
}
