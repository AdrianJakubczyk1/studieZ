using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
namespace _Animacje.Model
{
    class BeeStarModel
    {
        public static readonly Size StarSize = new Size(150, 100);

        private readonly Dictionary<Bee, Point> _bees = new Dictionary<Bee, Point>();
        private readonly Dictionary<Star, Point> _stars = new Dictionary<Star, Point>();
        private Random random = new Random();

       
        public BeeStarModel()
        {
            _playAreaSize = Size.Empty;
        }

        //Updating
        public void Update()
        {
            MoveOneBee();
            AddOrRemoveAStar();
        }

      
        private void MoveOnBee()
        {
            throw new NotImplementedException();
        }

        //checking if rect are overlapping ,if so  then return true otherwise false;
        private static bool RectsOverlap(Rect r1, Rect r2)
        {
            r1.Intersect(r2);
            if(r1.Width > 0 || r1.Height >0)
                return true;
            return false;
        }

        private Size _playAreaSize;
        //adjsutting Aniamtion's page size
        public Size PlayAreaSize
        {
            get
            {
                return _playAreaSize;
            }
            set
            {
                _playAreaSize = value;
                CreateBees();
                CreateStars();
            }
        }

        private void CreateBees()
        {
            if (PlayAreaSize == Size.Empty) return;//if empty then end executing method

            if (_bees.Count() > 0)
            {
                List<Bee> allBees = _bees.Keys.ToList();
                foreach (Bee bee in allBees)
                    MoveOneBee(bee);//Moving Bee
            }
            else
            {//Creating new Bees
                int beeCount = random.Next(5, 16);
                for(int i = 0;i<beeCount;i++)
                {
                    int s = random.Next(40, 151);
                    Size beeSize = new Size(s, s);//setting size of Bee
                    Point newLocation = FindNonOverLappingPoint(beeSize);//looking for good placement
                    Bee newBee = new Bee(newLocation, beeSize); 
                    _bees[newBee] = new Point(newLocation.X, newLocation.Y); //adding location of bee to dict
                    OnBeeMoved(newBee, newLocation.X, newLocation.Y); //calling  event
                }
            }
            }
        private void CreateStars()
        {
            if (PlayAreaSize == Size.Empty) return;//if empty end ,method

            if(_stars.Count>0)
            {
                foreach(Star star in _stars.Keys)
                {//if there are stars then callout event
                    star.Location = FindNonOverLappingPoint(StarSize);
                    OnStarChanged(star, false);
                }
            }
            else
            {//creating new stars
                int starCount = random.Next(5, 11);
                for (int i = 0; i < starCount; i++)
                    CreateAStar();
            }
        }

        private void CreateAStar()//method creates star
        {
            Point newLocation = FindNonOverLappingPoint(StarSize);
            Star newStar = new Star(newLocation);
            _stars[newStar] = new Point(newLocation.X, newLocation.Y);
            OnStarChanged(newStar, false);

        }

      

        private Point FindNonOverLappingPoint(Size size)
        {
            Rect newRect;
            bool NoOverlap = false;
            int count = 0;
            while(!NoOverlap)
            {
                newRect = new Rect(random.Next((int)PlayAreaSize.Width - 150),
                    random.Next((int)PlayAreaSize.Height - 150), size.Width, size.Height);//creating rectangle to look for no overlapping space
                //checking if any of Bees either stars are overlapping
                var overlappingBees =
                    from bee in _bees.Keys
                    where RectsOverlap(bee.Position, newRect)
                    select bee;

                var overlappingStars =
                    from star in _stars.Keys
                    where RectsOverlap(
                        new Rect(star.Location.X, star.Location.Y, StarSize.Width, StarSize.Width), newRect) 
                    select star;

                if ((overlappingBees.Count() + overlappingStars.Count() == 0) || (count++ > 1000))//if loop will execute more than 1000 times it means its too hard to find new place and loop will end
                    NoOverlap = true;
            }
            return new Point(newRect.X, newRect.Y);
        }

        private void MoveOneBee(Bee bee=null)
        {
            if (_bees.Keys.Count() == 0) return;//if there is no bees
            if (bee == null)
            {//choose random bee
                List<Bee> bees = _bees.Keys.ToList();
                bee = bees[random.Next(bees.Count)];
            }
            bee.Location = FindNonOverLappingPoint(bee.Size);//finding spot to move on
            _bees[bee] = bee.Location;//update Bee pos
            OnBeeMoved(bee, bee.Location.X, bee.Location.Y);//calling event
        }
        private void AddOrRemoveAStar()
        {
            if ((random.Next(2) == 0) || (_stars.Count <= 5) && (_stars.Count < 20))
                CreateAStar();//Create a star when random will generate zero but always create when there is less than 20 stars
            else//else remove random star
            {
                Star starToRemove = _stars.Keys.ToList()[random.Next(_stars.Count)];
                _stars.Remove(starToRemove);
                OnStarChanged(starToRemove, true);
            }
        }

        public event EventHandler<BeeMovedEventArgs> BeeMoved; 

        private void OnBeeMoved(Bee beeThatMoved, double x, double y)//event
         {
            EventHandler<BeeMovedEventArgs> beeMoved = BeeMoved;
            if(BeeMoved!=null)
            {
                beeMoved(this, new BeeMovedEventArgs(beeThatMoved, x, y));
            }
        }

        public event EventHandler<StarChangedEventArgs> StarChanged;
        private void OnStarChanged(Star star, bool v)
        {
            EventHandler<StarChangedEventArgs> starChanged = StarChanged;
                if(starChanged != null )
            {
                starChanged(this, new StarChangedEventArgs(star, v));
            }
        }



    }

      
    }

