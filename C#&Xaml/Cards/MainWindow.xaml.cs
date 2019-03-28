using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ryby2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        Game game = new Game();
        public MainWindow()
        {
            InitializeComponent();
            PageLayout.DataContext = game;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            game.StartGame();//startting game
        }
        //asking for cards 
        private void askForACard_Click(object sender, RoutedEventArgs e)
        {
            if (cards.SelectedIndex >= 0)
                game.PlayOneRound(cards.SelectedIndex);
    
        }
        //double clicked element event
        private void cards_DoubleTapped(object sender, MouseButtonEventArgs e)
        {
            if (cards.SelectedIndex >= 0)
                game.PlayOneRound(cards.SelectedIndex); 
            
        }
    }
}
