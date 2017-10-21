using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WestmountApp
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
			var nxt = new NavigationPage(new LandingPage());

			Icon = "iconhome_02.png";

			NavigationPage.SetTitleIcon(nxt, "iconhome_02.png");
			nxt.BarBackgroundColor = Color.FromRgb(101, 171, 216);
			nxt.BarTextColor = Color.White;
			Detail = nxt;
		}
		void On_Clicked(object sender, System.EventArgs e)
		{

			var stack = new StackLayout();

			var nxt = new NavigationPage(new NewsPage());

			nxt.BarBackgroundColor = Color.FromHex("#508FD6");
			nxt.BarTextColor = Color.White;

			Detail = nxt;


			IsPresented = false;
		}

		void On_Clicked_Home(object sender, System.EventArgs e)
		{


			var nxt = new NavigationPage(new LandingPage());

			nxt.BarBackgroundColor = Color.FromHex("#508FD6");
			nxt.BarTextColor = Color.White;

			Detail = nxt;


			IsPresented = false;
		}
	}
}
