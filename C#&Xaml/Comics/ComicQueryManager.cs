using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;
namespace Jan_Linq
{
    class ComicQueryManager
    {
        public ObservableCollection<ComicQuery> AvailableQueries { get; private set; }//first listview

        public ObservableCollection<object> CurrenQueryResults { get; private set; }//result list view
        public string Title { get; set; }


        public ComicQueryManager()
        {
            UpdateAvailable();
            CurrenQueryResults = new ObservableCollection<object>();
        }

        Random random = new Random();
        private string Text { get; set; }
        public string text { get; private set; }
        private void UpdateAvailable()
        {//creating Queries that will be available to click
            AvailableQueries = new ObservableCollection<ComicQuery> {
                new ComicQuery("ponizej 500zl", "500!", "zloty<.>", CreateImageFromAssets("Purple_250x250.jpg")),
                new ComicQuery("Drogie komiksy", "Komiksy powzyej 500zl","komiksy o wartosci przekraczajacej 500",CreateImageFromAssets("yh643x900.jpg")),
                new ComicQuery("grupuj wedlug ceny","liste zakupionych","komiksow",CreateImageFromAssets("purple_250x250.jpg")),
                new ComicQuery("Polacz zakupy z cenami"," "," ",CreateImageFromAssets("y643x900.jpg")),
                new ComicQuery("Zobacz Wszystkie komiksy","see all"," ", CreateImageFromAssets("new_gaph1920x1080.jpg")),
        };
        }

        private static BitmapImage CreateImageFromAssets(string imageFilename)
        {
            return new BitmapImage(new Uri("ms-appx:///Assets/" + imageFilename));
        }

        public void UpdateQueryResults(ComicQuery query)
        {
            Title = query.Title;
            switch(query.Title)
            {//use it to execute clicked query.
                case "ponizej 500zl": CheapComics();break;
                case "Drogie komiksy": ExpensiveComics();break;
                case "grupuj wedlug ceny":GroupByPrice();break;
                case "Polacz zakupy z cenami":Polacz();break;
                case "Zobacz Wszystkie komiksy": AllComics();break;
            }
        }
        
       private void AllComics()
        {
            foreach(Comic  comic in BuildCatalog())
            {//creating list of all comics
                var result = new
                {
                    Image = CreateImageFromAssets("new_grah1920x1080.jpg"),
                    Title = comic.Name,
                    Subtitle = "Numer " + comic.Issue,
                    Description = ":(",
                    Comic = comic,
                }; 
                CurrenQueryResults.Add(result); //adding results to result list view
            }
        }

        public static IEnumerable<Comic> BuildCatalog()
        {
            return new List<Comic> {//creating Catalog of comics
                new Comic { Name = "Johnny America vs. the Pinko", Issue = 6, Year = 1949, CoverPrice = "10 groszy",
                    MainVillain = "Pinko", Cover = CreateImageFromAssets("purple_250x250.jpg"),
                    Synopsis = "Kapitan Wspaniały musi ratować Amerykę przed komunikstami, gdyż Pinko i jego"
                        + " komunikstyczne pachołki uknuły plan obrabowania Fort Knox i ukradzenia całego złota." },

                new Comic { Name = "Rock and Roll (edycja limitowana)", Issue = 19, Year = 1957, CoverPrice = "10 groszy",
                    MainVillain = "Doktor Vortran", Cover = CreateImageFromAssets("purple_250x250.jpg"),
                    Synopsis = "Doktor Vortran sieje spustoszenie wśród młodzieży przy użyciu swego radiowego urządzenia,"
                        + " które korzysta z najnowszego tanecznego szaleństwa, by wprowadzać fanów rock'n'rolla"
                        + " w niekontrolowany trans."},

                new Comic { Name = "Woman’s Work", Issue = 36, Year = 1968, CoverPrice = "12 groszy",
                    MainVillain = "Hysterianna", Cover = CreateImageFromAssets("purple_250x250.jpg"),
                    Synopsis = "Kapitan staje twarzą w twarz ze swym pierwszym wrogiem płci żeńskiej, Hysterianna,"
                        + " której niesamowite, telepatyczne i telekinetyczne zdolności pozwalają powołać armię"
                        + " kobiet, jakiej nawet Kapitan będzie miał problemy sprostać." },

                new Comic { Name = "Hippie Madness (źle wydrukowany)", Issue = 57, Year = 1973, CoverPrice = "20 groszy",
                    MainVillain = "Mayor", Cover = CreateImageFromAssets("purple_250x250.jpg"),
                    Synopsis = "Apokalipsa zombie zagraża istnieniu Obiektowa, gdyż Mayor ustawił wybory"
                        + " wprowadzając agenta zombie do firmy dostarczającej papierosy całemu miastu." },

                new Comic { Name = "Skyfall", Issue = 68, Year = 1984,
                    CoverPrice = "75 groszy", MainVillain = "ground",
                    Cover = CreateImageFromAssets("new_grph1920x1080.jpg"),
                    Synopsis = "sky "
                        + " i fall." },

                new Comic { Name = "Casino Royale", Issue = 74, Year = 1986, CoverPrice = "75 groszy",
                    MainVillain = "badluck", Cover = CreateImageFromAssets("purple_250x250.jpg"),
                    Synopsis = "the game"
                        + " in casino game" },

                new Comic { Name = "vodoo", Issue = 83, Year = 1996, CoverPrice = "Dwa złote",
                    MainVillain = "doll", Cover = CreateImageFromAssets("l850x1129.jpg"),
                    Synopsis = "vo"
                        + " do "
                        + " o." },

                new Comic { Name = "no", Issue = 97, Year = 2013, CoverPrice = "Cztery złote",
                    MainVillain = "No", Cover = CreateImageFromAssets("Cdis1920x1080.jpg"),
                    Synopsis = "description "
                        + "opis" },
            };
        
        }
        //Method creating Dictionary of prices(value) and issues as Keys
        private static Dictionary<int, decimal> GetPrices()
        {
            return new Dictionary<int, decimal>
            {
                {6, 3600M }, {19, 500M}, {36, 650M}, {57, 1325M},
                {68, 250M }, {74, 6064M}, {83, 25.75M}, {97, 35.25M},
            };
        }

        
        private void Polacz()
        {
            IEnumerable<Comic> comics = BuildCatalog();//getting list of comics
            Dictionary<int, decimal> values = GetPrices(); //getting prices
            IEnumerable<Purchases> purchase = Purchases.FindPurchase(); //getting purchases list
            var results =
                from comic in comics
                join buy in purchase
                on comic.Issue equals buy.Issue //checking if any of issues are same and getting em if same
                orderby comic.Issue ascending
                select new
                {//creating object 
                    Comic = comic,
                    Price = buy.Price,
                    Title = comic.Name,
                    Subtitle = "Numer " + comic.Issue,
                    Description = String.Format("Kupiony za {0:c}", buy.Price),
                    Image = CreateImageFromAssets("yah643x900"),


                };
            decimal listvalue = 0;
            decimal totalspent = 0;
            //how much was spent on new comics.
            foreach(var result in results)
            {
                listvalue += values[result.Comic.Issue];
                totalspent += result.Price;
                CurrenQueryResults.Add(result);
            }
            Title = String.Format("Wydane zostalo {0:c} na komiksy warte {1:c}", totalspent, listvalue);
        }

        private void GroupByPrice()
        {
            Dictionary<int, decimal> values = GetPrices();
            var priceGroups =
                from pair in values
                group pair.Key by Purchases.EvaluatePrice((int)pair.Value)//checking if they are expsnive or cheap or maybe midrange
                into priceGroup
                orderby priceGroup.Key descending
                select priceGroup;

            foreach (var group in priceGroups)
            {
                string message = String.Format("Found {0} {1} komiksow numery ", group.Count(), group.Key.ToString());

                foreach (var issue in group)
                {//creating new objects on result
                    message += issue.ToString() + " ";
                    CurrenQueryResults.Add(CreateAnonymousListViewItem(message)
                        );
                }
}
        }
        //getting comics that are above 500
        private void ExpensiveComics()
        {
            IEnumerable<Comic> comics = BuildCatalog(); //getting list with comics
            Dictionary<int, decimal> values = GetPrices(); //getting dict with prices
            
            var mostExpensive = from comIc in comics
                                
                                where values[comIc.Issue] > 500 //selectin all with value > 500
                                orderby values[comIc.Issue] descending
                                select comIc;


            foreach (Comic comic in mostExpensive)
                CurrenQueryResults.Add(
                    new
                    {//adding elements of mostExpensive to result listView collection
                        Title = string.Format("{0} jest wart {1:c} ", comic.Name, values[comic.Issue]),
                        Image = CreateImageFromAssets("new_grah1920x1080.jpg"),
                    }); }
        //template for creating anonymous objects
        private object CreateAnonymousListViewItem(string title, string imageFilename = "purple_250x250.jpg")
        {
            return new
            {
                Title = title,
                Image = CreateImageFromAssets(imageFilename),
            };
        }

        private void CheapComics()
        {//working same as ExpensiveComics method, difference is that we are getting here to results all comics < 500
            IEnumerable<Comic> comics = BuildCatalog();
            Dictionary<int, decimal> values = GetPrices();

            var mostExpensive = from comIc in comics

                                where values[comIc.Issue] < 500
                                orderby values[comIc.Issue] descending
                                select comIc;


            foreach (Comic comic in mostExpensive)

                CurrenQueryResults.Add(
                    new
                    {
                        Title = string.Format("{0} jest wart {1:c} ", comic.Name, values[comic.Issue]),
                        Image = CreateImageFromAssets("new_grah1920x1080.jpg"),
                    });
        }
    }
    //enumertaion type used as key for price groups
    public enum PriceRange
    { Cheap, Midrange, Expensive }


}
 
            
        

  