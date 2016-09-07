using Xamarin.Forms;

namespace PostSecondaryPassport
{
	public partial class PostSecondaryPassportPage : ContentPage
	{
		Route route;
		public PostSecondaryPassportPage()
		{
			InitializeComponent();
			route = new HCVRoute();
			b_offline.Clicked += (sender, e) =>
			{
				App.switchPage(route.getStartLevel());
			};
			App.getDatabase().addRouteToDatabase(route);
		}
	}
}