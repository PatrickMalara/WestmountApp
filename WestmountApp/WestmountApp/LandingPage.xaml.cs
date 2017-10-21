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
	public partial class LandingPage : ContentPage
	{


		public LandingPage()
		{

			InitializeComponent();

			ToolbarItem settings = new ToolbarItem();
			settings.Icon = "iconhome_02.png";
			settings.Order = ToolbarItemOrder.Secondary;
			settings.Priority = 1;
			ToolbarItems.Add(settings);

		}
	}
}