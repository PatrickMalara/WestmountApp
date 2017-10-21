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
	public partial class CardViewer : ContentPage
	{

		public CardViewer()
		{

			InitializeComponent();


		}
		public void setData(string header, string body)
		{
			headerView.Text = header;
			bodyView.Text = body;
		}

	}
}