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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace alphaCast
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        int x1, x2;

        public SearchPage()
        {
            this.InitializeComponent();

            ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
            ManipulationStarted += (s, e) => x1 = (int) e.Position.X;
            ManipulationCompleted += (s, e) =>
            {
                x2 = (int) e.Position.X;
                if (x1 > x2)
                {
                    Frame.GoBack();
                    //Frame.Navigate(Frame.BackStack.First(p => p.GetType() == typeof(MainPage)));
                }
            };
        }

        private void searchBox_KeyDown(object sender, RoutedEventArgs e)
        {

        }

        private void button_searchClick(object sender, RoutedEventArgs e)
        {

        }

        private void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}
