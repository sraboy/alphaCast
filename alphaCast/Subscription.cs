using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alphaCast
{
    public class Subscription
    {
        private Podcast _subscribedPodcast;
        private int _episodesDownloaded;
        private Dictionary<string, string> _settings;


        public Podcast SubscribedPodcast
        {
            get
            {
                return _subscribedPodcast;
            }

            set
            {
                this._subscribedPodcast = value;
            }
        }
        public int EpisodesDownloaded
        {
            get
            {
                return _episodesDownloaded;
            }

            set
            {
                this._episodesDownloaded = value;
            }
        }
        public Dictionary<string, string> Settings
        {
            get
            {
                return _settings;
            }

            set
            {
                this._settings = value;
            }
        }

        public Subscription(Podcast pc)
        {
            this.SubscribedPodcast = pc;
        }

        public async Task<bool> Update()
        {
            //check settings and download
            //await
            Task<bool> result = new Task<bool>(() =>
            {
                return false;
            });


            return false;
        }
    }
}
