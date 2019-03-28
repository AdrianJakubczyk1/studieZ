using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Animacje.View;
using _Animacje.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.Foundation;
using DispatcherTimer = Windows.UI.Xaml.DispatcherTimer;
using UIElement = Windows.UI.Xaml.UIElement;
namespace _Animacje.ViewModel
{
    class BeeStarViewModel
    {
        private readonly ObservableCollection<UIElement>
            _sprites = new ObservableCollection<UIElement>();
        public INotifyCollectionChanged Sprites { get { return _sprites; } }

        private readonly Dictionary<Star, StarControl> _stars = new Dictionary<Star, StarControl>();

        private readonly List<StarControl> _fadedStars = new List<StarControl>();//all stars that will be removed with next update() call

        private BeeStarModel _model = new BeeStarModel();

        private readonly Dictionary<Bee, AnimatedImage> _bees = new Dictionary<Bee, AnimatedImage>();

        private DispatcherTimer _timer = new DispatcherTimer();

        public Size PlayAreaSize
        {
            get { return _model.PlayAreaSize; }
            set { _model.PlayAreaSize = value; }
        }

        public BeeStarViewModel()
            {
            _model.BeeMoved += BeeMovedHandler;
            _model.StarChanged += StarChangedHandler;
            _timer.Interval = TimeSpan.FromSeconds(2); 
            _timer.Tick += timer_Tick;
            _timer.Start();//run clock

            }

        void timer_Tick(object sender, object e)
        {
            foreach (StarControl starControl in _fadedStars)
                _sprites.Remove(starControl);//remove every star in each tick that is in faded star collection
            _model.Update();
        }

        void BeeMovedHandler(object sender, BeeMovedEventArgs e)
        {
            if(!_bees.ContainsKey(e.BeethatMoved))//if there is no given bee in bees collection create one 
            {
                AnimatedImage beeControl = Helper.BeeFactory(
                    e.BeethatMoved.Width, e.BeethatMoved.Height, TimeSpan.FromMilliseconds(5));
                Helper.SetCanvasLocation(beeControl, e.X, e.Y);
                _bees[e.BeethatMoved] = beeControl;
                _sprites.Add(beeControl);
            }
            else
            {//if there is in collection move it
                AnimatedImage beeControl = _bees[e.BeethatMoved] ;
                Helper.MoveElementOnCanvas(beeControl, e.X, e.Y);
            }
        }

        void StarChangedHandler(object sender, StarChangedEventArgs e)
        {
            if (e.Removed)//if removed than move to faded stars collection
            {
                StarControl starControl = _stars[e.StarThatChanged];
                _stars.Remove(e.StarThatChanged);
                _fadedStars.Add(starControl);
                starControl.FadeOut();
            }
            else
            {//if exsits then take reference
                StarControl newStar;
                if (_stars.ContainsKey(e.StarThatChanged))
                    newStar = _stars[e.StarThatChanged];
                else//else create one and add to sprites collection
                {
                    newStar = new StarControl();
                    _stars[e.StarThatChanged] = newStar;
                    newStar.Fadein();
                    Helper.SendToBack(newStar);
                    _sprites.Add(newStar);
                }
                Helper.SetCanvasLocation(newStar, e.StarThatChanged.Location.X, e.StarThatChanged.Location.Y);
            }
        }
    }
}
