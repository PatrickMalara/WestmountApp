using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WestmountApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsPage : TabbedPage
	{
		public NewsPage()
		{
			InitializeComponent();
			var image = new Image { Source = "iconhome_02.png" };
			loadCards();
			Feed.Children.Add(image);

		}

		public void loadCards()
		{
			RSS westmountFeed = new RSS("https://595.commons.hwdsb.on.ca/presentation/announcements/feed/");

			Feed.Spacing = 5;



			CardViewer viewerPage = new CardViewer();

			for (int i = 0; i < westmountFeed.items.Count; i++)
			{
				var card = new NewsCard(westmountFeed.items[i].title, westmountFeed.items[i].description, westmountFeed.items[i].date, ref viewerPage);

				Feed.Children.Add(card);
			}


		}


		void On_Clicked_Card(object sender, System.EventArgs e)
		{

		}

	}
}