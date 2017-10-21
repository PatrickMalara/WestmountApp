using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace WestmountApp
{
	public class NewsCard : Grid
	{
		static CardViewer navlink;
		private string globHeader;
		private string globBody;

		public NewsCard(string headerText, string bodyText, string date, ref CardViewer viewer)
		{

			navlink = viewer;
			globHeader = headerText;
			globBody = bodyText;
			string font = (Device.RuntimePlatform == Device.iOS) ? "Lobster-Regular" : "Droid Sans Mono";

			string defaultTxt = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi.";
			BoxView topBar = new BoxView { BackgroundColor = (Color)Application.Current.Resources["GlobCardPopClr"] };
			Label header = new Label { Text = globHeader, Margin = new Thickness(10, 0, 0, 0), FontSize = 18, TextColor = (Color)Application.Current.Resources["GlobCardPopClr"], FontFamily = font };
			Label body = new Label { Text = globBody, Margin = new Thickness(10, 0, 0, 25), FontSize = 14 };
			Label timeStamp = new Label { Text = date, Margin = new Thickness(10, 0, 10, 5), FontSize = 10, HorizontalTextAlignment = TextAlignment.End };
			Button clickRange = new Button { Opacity = 0 };

			clickRange.Clicked += On_Clicked_Card;


			//Row Definitions
			RowDefinitions.Add(new RowDefinition { Height = new GridLength(20) });
			RowDefinitions.Add(new RowDefinition { Height = new GridLength(0, GridUnitType.Auto) });
			RowDefinitions.Add(new RowDefinition { Height = new GridLength(80, GridUnitType.Auto) });
			RowDefinitions.Add(new RowDefinition { Height = new GridLength(80, GridUnitType.Auto) });
			//Column Definitions
			ColumnDefinitions.Add(new ColumnDefinition { });
			ColumnDefinitions.Add(new ColumnDefinition { });
			//Other Definitions
			BackgroundColor = Color.White;


			//Elements
			Children.Add(topBar, 0, 0);
			NewsCard.SetRowSpan(topBar, 1);
			NewsCard.SetColumnSpan(topBar, 2);
			Children.Add(header, 0, 1);
			NewsCard.SetRowSpan(header, 1);
			NewsCard.SetColumnSpan(header, 2);
			Children.Add(body, 0, 2);
			NewsCard.SetRowSpan(body, 1);
			NewsCard.SetColumnSpan(body, 2);
			Children.Add(timeStamp, 1, 3);
			NewsCard.SetRowSpan(body, 1);
			NewsCard.SetColumnSpan(body, 2);
			Children.Add(clickRange, 0, 0);
			NewsCard.SetRowSpan(clickRange, 4);
			NewsCard.SetColumnSpan(clickRange, 2);



		}
		void On_Clicked_Card(object sender, System.EventArgs e)
		{
			navlink.setData(globHeader, globBody);
			Navigation.PushAsync(navlink);


		}



	}
}
