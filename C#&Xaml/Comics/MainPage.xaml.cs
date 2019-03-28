using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Jan_Linq
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        //when list view click event will happen then..
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ComicQuery query = e.ClickedItem as ComicQuery;
            if (query != null)
            {
                Suspension_manager.CurrentQuery = query.Title;//save chosen query in purpose to restore if needed.
                if (query.Title == "Zobacz Wszystkie komiksy")
                    this.Frame.Navigate(typeof(QueryZoom), query); //if will be chosen see all comics with zoom option query then move to specific page
                else//move to standard page with results without zoom option
                    this.Frame.Navigate(typeof(QueryDetail), query);
            }
        }
    }
}
