using System;
using System.Net;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace WestmountApp
{
	public class item
	{
		public string title { get; set; }
		public string description { get; set; }
		public string date { get; set; }
		public string link { get; set; }
	}

	public class RSS
	{
		/// <summary>
		/// A List of RSS Items
		/// </summary>
		public List<item> items;

		public RSS(string rssChannel)
		{
			items = getRssData(rssChannel);
		}

		/// <summary>
		/// Returns a List of rss Items
		/// </summary>
		private List<item> getRssData(string channel)
		{
			WebRequest myRequest = WebRequest.Create(channel);
			WebResponse myResponse = myRequest.GetResponse();

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

				rssNode = rssItems.Item(i).SelectSingleNode("link");
				rssItem.link = (rssNode != null) ? rssNode.InnerText : "";

				rssNode = rssItems.Item(i).SelectSingleNode("pubData");//publication date
				rssItem.date = (rssNode != null) ? rssNode.InnerText : "";

				tempRssItems.Add(rssItem);
			}
			return tempRssItems;
		}

	}
}
