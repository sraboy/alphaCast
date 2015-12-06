using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Windows.Media.Playback;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace alphaCast
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Podcast> _searchResults;

        private Podcast _selectedPodcast;
        private PodcastLibrary _library;
        private string _searchCriteria;

        public ObservableCollection<Podcast> SearchResults
        {
            get
            {
                return _searchResults;
            }

            set
            {
                this._searchResults = value;
            }
        }
        public string SearchCriteria
        {
            get
            {
                return _searchCriteria;
            }

            set
            {
                this._searchCriteria = value;
            }
        }
        public Podcast SelectedPodcast
        {
            get
            {
                return _selectedPodcast;
            }

            set
            {
                if (value != this._selectedPodcast)
                {
                    this._selectedPodcast = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedPodcast"));
                }
            }
        }
        public PodcastLibrary Library
        {
            get
            {
                return _library;
            }

            set
            {
                this._library = value;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.DataContext = this;
        }
        

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void button_PlayClick(object sender, RoutedEventArgs e)
        {
            
        }
        private void button_StopClick(object sender, RoutedEventArgs e)
        {

        }
        private void button_searchClick(object sender, RoutedEventArgs e)
        {
            var jsonResults = Helpers.SearchiTunes(SearchCriteria).Result;
            this.SearchResults = new ObservableCollection<Podcast>(jsonResults.results);
            this.itemsViewSource.Source = this.SearchResults;
            MainPageHub.ScrollToSection(HubSectionSearchResults);

        }
        private void btnSubscribe_Click(object sender, RoutedEventArgs e)
        {
            BackgroundMediaPlayer.Current.SetUriSource(new Uri(this.SelectedPodcast.Link));
            BackgroundMediaPlayer.Current.Play();
        }
        private void searchBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                button_searchClick(sender, e);
            }
        }

        private void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedPodcast = e.AddedItems[0] as Podcast;
            if (this.SelectedPodcast.Description == null)
                Helpers.GetRSSDescription(this.SelectedPodcast);

            if (this.SelectedPodcast.Description == null || this.SelectedPodcast.Description == "")
                Helpers.ScrapeDescription(this.SelectedPodcast);

            this.HubSectionSummary.DataContext = this.SelectedPodcast;
            MainPageHub.ScrollToSection(HubSectionSummary);
        }

        private void Hub_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {

        }

    }
}
