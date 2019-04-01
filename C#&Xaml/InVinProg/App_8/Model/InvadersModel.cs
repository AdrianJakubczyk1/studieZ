using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
namespace App_8.Model
{
    class InvadersModel
    {
        public readonly static Size PlayAreaSize = new Size(400, 300);
        public const int MaximumPlayersShots = 3;
        public const int InitialStarCount = 50;

        private readonly Random random = new Random();

        public int Score { get; private set;}
        public int Wave { get; private set; }
        public int Lives { get; private set; }
        

        public bool GameOver { get; private set; }

        private DateTime? _playerDied = null;
        public bool PlayerDying { get { return _playerDied.HasValue; } }

        private Player _player;

        private readonly List<Invader> _invaders = new List<Invader>();
        private readonly List<Shot> _playersShots = new List<Shot>();
        private readonly List<Shot> _invaderShots = new List<Shot>();
        private readonly List<Point> _stars = new List<Point>();

        private Direction _invaderDirection = Direction.Left;
        private bool _justMovedDown = false;

        private DateTime _lastUpdated = DateTime.MinValue;

        public InvadersModel()
        {
            EndGame();
        }

        public event EventHandler<ShipChangedEventArgs> ShipChanged;

        private void OnShipChanged(Ship ship, bool tf)
        {
            EventHandler<ShipChangedEventArgs> shipChanged = ShipChanged;
            if(shipChanged != null)
            {
                shipChanged(this, new ShipChangedEventArgs(ship, tf));
            }
        }

        public event EventHandler<ShotMovedEventArgs> shotMoved;

        private void OnShotMoved(Shot shot, bool tf)
        {
            EventHandler<ShotMovedEventArgs> shotMoved = this.shotMoved;
            if (shotMoved != null)
                shotMoved(this, new ShotMovedEventArgs(shot, tf));
        }

        public event EventHandler<StarChangedEventArgs> starChanged;

        private void OnStarChanged(Point point, bool tf)
        {
            EventHandler<StarChangedEventArgs> starChanged = this.starChanged;
            if (starChanged != null)
                starChanged(this, new StarChangedEventArgs(point, tf));
        }

        public void EndGame()
        {
            GameOver = true;
        }

        public void StartGame()
        {
            GameOver = false;

            foreach (Invader invader in _invaders)
            {
                OnShipChanged(invader, true);
                _invaders.Remove(invader);
            }

            foreach(Shot shot in _invaderShots)
            {
                OnShotMoved(shot, true);
                _invaderShots.Remove(shot);
            }

            foreach(Shot shot in _playersShots)
            {
                OnShotMoved(shot, true);
                _playersShots.Remove(shot);
            }

            foreach(Point point in _stars)
            {
                OnStarChanged(point, true);
                int temp = _stars.IndexOf(point);
                _stars.Remove(point);
                _stars.Add(new Point());
            }



        }
    }
}
