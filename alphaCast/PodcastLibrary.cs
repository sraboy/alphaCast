using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alphaCast
{
    public class PodcastLibrary
    {
        private ObservableDictionary _subscriptions;
        public ObservableDictionary Subscriptions
        {
            get
            {
                return _subscriptions;
            }

            set
            {
                this._subscriptions = value;
            }
        }

        public PodcastLibrary()
        {
            this.Subscriptions = new ObservableDictionary();
        }

        public bool SubscribeToPodcast(Podcast pc)
        {
            this.Subscriptions.Add(pc.CollectionName, pc);
            //this.Subscriptions[pc.CollectionName] = pc;

            return true;
        }
    }
}
