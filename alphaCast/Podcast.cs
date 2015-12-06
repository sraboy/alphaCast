using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace alphaCast
{
    public class Podcast : INotifyPropertyChanged
    {
        //from: http://json2csharp.com/
        private string wrapperType;
        private string kind;
        private int artistId;
        private int collectionId;
        private int trackId;
        private string artistName;
        private string collectionName;
        private string trackName;
        private string collectionCensoredName;
        private string trackCensoredName;
        private string artistViewUrl;
        private string collectionViewUrl;
        private string feedUrl;
        private string trackViewUrl;
        private string artworkUrl30;
        private string artworkUrl60;
        private string artworkUrl100;
        private double collectionPrice;
        private double trackPrice;
        private int trackRentalPrice;
        private int collectionHdPrice;
        private int trackHdPrice;
        private int trackHdRentalPrice;
        private string releaseDate;
        private string collectionExplicitness;
        private string trackExplicitness;
        private int trackCount;
        private string country;
        private string currency;
        private string primaryGenreName;
        private string radioStationUrl;
        private string artworkUrl600;
        private List<string> genreIds;
        private List<string> genres;

        private string description;
        private string link;

        [JsonProperty("wrapperType")]
        public string WrapperType
        {
            get
            {
                return wrapperType;
            }

            set
            {
                this.wrapperType = value;
            }
        }
        [JsonProperty("kind")]
        public string Kind
        {
            get
            {
                return kind;
            }

            set
            {
                this.kind = value;
            }
        }
        [JsonProperty("artistId")]
        public int ArtistId
        {
            get
            {
                return artistId;
            }

            set
            {
                this.artistId = value;
            }
        }
        [JsonProperty("collectionId")]
        public int CollectionId
        {
            get
            {
                return collectionId;
            }

            set
            {
                this.collectionId = value;
            }
        }
        [JsonProperty("trackId")]
        public int TrackId
        {
            get
            {
                return trackId;
            }

            set
            {
                this.trackId = value;
            }
        }
        [JsonProperty("artistName")]
        public string ArtistName
        {
            get
            {
                return artistName;
            }

            set
            {
                this.artistName = value;
            }
        }
        [JsonProperty("collectionName")]
        public string CollectionName
        {
            get
            {
                return collectionName;
            }

            set
            {
                this.collectionName = value;
            }
        }
        [JsonProperty("collectionCensoredName")]
        public string CollectionCensoredName
        {
            get
            {
                return collectionCensoredName;
            }

            set
            {
                this.collectionCensoredName = value;
            }
        }
        [JsonProperty("trackCensoredName")]
        public string TrackCensoredName
        {
            get
            {
                return trackCensoredName;
            }

            set
            {
                this.trackCensoredName = value;
            }
        }
        [JsonProperty("artistViewUrl")]
        public string ArtistViewUrl
        {
            get
            {
                return artistViewUrl;
            }

            set
            {
                this.artistViewUrl = value;
            }
        }
        [JsonProperty("collectionViewUrl")]
        public string CollectionViewUrl
        {
            get
            {
                return collectionViewUrl;
            }

            set
            {
                this.collectionViewUrl = value;
            }
        }
        [JsonProperty("feedUrl")]
        public string FeedUrl
        {
            get
            {
                return feedUrl;
            }

            set
            {
                this.feedUrl = value;
            }
        }
        [JsonProperty("trackViewUrl")]
        public string TrackViewUrl
        {
            get
            {
                return trackViewUrl;
            }

            set
            {
                this.trackViewUrl = value;
            }
        }
        [JsonProperty("artworkUrl30")]
        public string ArtworkUrl30
        {
            get
            {
                return artworkUrl30;
            }

            set
            {
                this.artworkUrl30 = value;
            }
        }
        [JsonProperty("artworkUrl60")]
        public string ArtworkUrl60
        {
            get
            {
                return artworkUrl60;
            }

            set
            {
                this.artworkUrl60 = value;
            }
        }
        [JsonProperty("artworkUrl100")]
        public string ArtworkUrl100
        {
            get
            {
                return artworkUrl100;
            }

            set
            {
                this.artworkUrl100 = value;
            }
        }
        [JsonProperty("collectionPrice")]
        public double CollectionPrice
        {
            get
            {
                return collectionPrice;
            }

            set
            {
                this.collectionPrice = value;
            }
        }
        [JsonProperty("trackPrice")]
        public double TrackPrice
        {
            get
            {
                return trackPrice;
            }

            set
            {
                this.trackPrice = value;
            }
        }
        [JsonProperty("trackRentalPrice")]
        public int TrackRentalPrice
        {
            get
            {
                return trackRentalPrice;
            }

            set
            {
                this.trackRentalPrice = value;
            }
        }
        [JsonProperty("collectionHdPrice")]
        public int CollectionHdPrice
        {
            get
            {
                return collectionHdPrice;
            }

            set
            {
                this.collectionHdPrice = value;
            }
        }
        [JsonProperty("trackHdPrice")]
        public int TrackHdPrice
        {
            get
            {
                return trackHdPrice;
            }

            set
            {
                this.trackHdPrice = value;
            }
        }
        [JsonProperty("trackHdRentalPrice")]
        public int TrackHdRentalPrice
        {
            get
            {
                return trackHdRentalPrice;
            }

            set
            {
                this.trackHdRentalPrice = value;
            }
        }
        [JsonProperty("releaseDate")]
        public string ReleaseDate
        {
            get
            {
                return releaseDate;
            }

            set
            {
                this.releaseDate = value;
            }
        }
        [JsonProperty("collectionExplicitness")]
        public string CollectionExplicitness
        {
            get
            {
                return collectionExplicitness;
            }

            set
            {
                this.collectionExplicitness = value;
            }
        }
        [JsonProperty("trackExplicitness")]
        public string TrackExplicitness
        {
            get
            {
                return trackExplicitness;
            }

            set
            {
                this.trackExplicitness = value;
            }
        }
        [JsonProperty("country")]
        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                this.country = value;
            }
        }
        [JsonProperty("currency")]
        public string Currency
        {
            get
            {
                return currency;
            }

            set
            {
                this.currency = value;
            }
        }
        [JsonProperty("primaryGenreName")]
        public string PrimaryGenreName
        {
            get
            {
                return primaryGenreName;
            }

            set
            {
                this.primaryGenreName = value;
            }
        }
        [JsonProperty("radioStationUrl")]
        public string RadioStationUrl
        {
            get
            {
                return radioStationUrl;
            }

            set
            {
                this.radioStationUrl = value;
            }
        }
        [JsonProperty("artworkUrl600")]
        public string ArtworkUrl600
        {
            get
            {
                return artworkUrl600;
            }

            set
            {
                this.artworkUrl600 = value;
            }
        }
        [JsonProperty("genreIds")]
        public List<string> GenreIds
        {
            get
            {
                return genreIds;
            }

            set
            {
                this.genreIds = value;
            }
        }

        [JsonProperty("trackcount")]
        public int TrackCount
        {
            get
            {
                return trackCount;
            }

            set
            {
                this.trackCount = value;
                NotifyPropertyChanged();
            }
        }
        [JsonProperty("genres")]
        public List<string> Genres
        {
            get
            {
                return genres;
            }

            set
            {
                this.genres = value;
                NotifyPropertyChanged();
            }
        }
        [JsonProperty("trackName")]
        public string TrackName
        {
            get
            {
                return trackName;
            }

            set
            {
                this.trackName = value;
                NotifyPropertyChanged();
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (value != this.description)
                {
                    NotifyPropertyChanged();
                    this.description = value;
                }
            }
        }
        public string Link
        {
            get
            {
                return link;
            }

            set
            {
                if (value != this.link)
                {
                    NotifyPropertyChanged();
                    this.link = value;
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Podcast()
        {
            //this.PropertyChanged += RaisePropertyChangedEvent();
        }

        //public PropertyChangedEventHandler RaisePropertyChangedEvent(object sender, PropertyChangedEventArgs e)
        //{
        //    return new PropertyChangedEventHandler(sender, e);
        //}
    }
}
