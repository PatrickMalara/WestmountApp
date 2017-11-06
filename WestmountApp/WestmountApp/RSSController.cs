using System;
using System.Collections.Generic;

namespace WestmountApp
{
    class RSSController
    {
        public RSSController()
        {
            items = addFeedItems();
            items = sortFeedItems();
        }

        RSS[] feeds = new RSS[] {
            new RSS("https://595.commons.hwdsb.on.ca/presentation/announcements/feed/", 1), //Westmount Announcements
            new RSS("https://595.commons.hwdsb.on.ca/feed/", 2), //Westmount News
            new RSS("https://newspaper.commons.hwdsb.on.ca/feed/", 3), //Westmount Newspaper 
            new RSS("https://westmountguidance.commons.hwdsb.on.ca/feed/", 4), //Westmount Guidance
            new RSS("https://595.commons.hwdsb.on.ca/feed/", 5) //HWDSB
        };

        public List<item> items = new List<item>();

        public List<item> addFeedItems() {
            List<item> newItems = new List<item>();
            for (int i = 0; i < feeds.Length; i++)
            {
                for (int k = 0; k < feeds[i].items.Count; k++)
                {
                    newItems.Add(feeds[i].items[k]);
                }
            }

            return newItems;
        }

        public List<item> sortFeedItems() {
            //First Make a stringList for all of the dates.
            List<DateTime> itemDates = new List<DateTime>();
            for (int i = 0; i < items.Count; i++) { itemDates.Add(items[i].formmatedDate);  }

            //Second Sort the dates
            itemDates.Sort((a, b) => b.CompareTo(a));

            //Third Make a newItemsList that looks at stringDates[i] == items[k].formattedDate
            //                                          newItems.Add(items[k]);
            List<item> newItems = new List<item>();
            for (int i = 0; i < itemDates.Count; i++)
            {
                for (int k = 0; k < items.Count; k++)
                {
                    if (itemDates[i] == items[k].formmatedDate) {
                        newItems.Add(items[k]);
                    }
                }
            }

            return newItems;
        }
    }
}
