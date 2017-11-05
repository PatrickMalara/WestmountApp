using System;
using System.Net;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace WestmountApp
{
    public class item
    {
        public item(string Title, string Description, string Date, string Link, string Tag)
        {
            title = Title;
            description = Description;
            date = date;
            link = Link;
            tag = Tag;
        }
        public item() { }

        public string title { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public string link { get; set; }

        public string tag { get; set; }
    }

    public class RSS
    {

        public List<item> items;

        public RSS(string rssChannel)
        {
            items = getRssData(rssChannel);
        }

        private string _getTag(string description) {
            string tag = "";

            string desc = description.ToLower();
            StringReader reader = new StringReader(desc);
            string[] descWords = reader.ReadToEnd().Split(' ');
            Categories cat = new Categories();
            for (int i = 0; i < descWords.Length; i++)
            {
                for (int k = 0; k < cat.categories.Length; k++)
                {
                    for (int j = 0; j < cat.categories[k].keywords.Length; j++)
                    {
                        if (descWords[i] == cat.categories[k].keywords[j]) { tag = cat.categories[k].category; }
                    }
                }
            }

            return tag;
        }

        /// <summary>
        /// Returns a List of rss Items
        /// </summary>
        private List<item> getRssData(string channel)
        {
            WebRequest myRequest = WebRequest.Create(channel);
            WebResponse myResponse;
            try
            {
                myResponse = myRequest.GetResponse();
            }
            catch (System.Net.WebException ex)
            {
                List<item> cantConnect = new List<item>();
                cantConnect.Add(new item(
                    "Server Machine Broke",
                    "Sorry, but there was an issue tring to get the news... Try to reopen this page.",
                    System.DateTime.Today.ToLocalTime().ToString(),
                    "",
                    "Error"
                ));
                return cantConnect;
                
                throw;
            }

            Stream rssStream = myResponse.GetResponseStream();
            XmlDocument rssDoc = new XmlDocument();

            rssDoc.Load(rssStream);

            XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");

            List<item> tempRssItems = new List<item>();

            for (int i = 0; i < rssItems.Count; i++)
            {
                XmlNode rssNode;
                item rssItem = new item();

                rssNode = rssItems.Item(i).SelectSingleNode("title");
                rssItem.title = (rssNode != null) ? rssNode.InnerText : "";

                rssNode = rssItems.Item(i).SelectSingleNode("description");
                rssItem.description = (rssNode != null) ? rssNode.InnerXml : "";
                rssItem.description = rssItem.description.Substring(9, (rssItem.description.Length - 9) - 3);
                rssItem.description = WebUtility.HtmlDecode(rssItem.description);

                //GetTag
                rssItem.tag = _getTag(rssItem.description);

                rssNode = rssItems.Item(i).SelectSingleNode("link");
                rssItem.link = (rssNode != null) ? rssNode.InnerText : "";

                rssNode = rssItems.Item(i).SelectSingleNode("pubDate");
                rssItem.date = (rssNode != null) ? rssNode.InnerText : "";
                rssItem.date = rssItem.date.Substring(0, 16);

                tempRssItems.Add(rssItem);
            }
            return tempRssItems;
        }

    }
}
