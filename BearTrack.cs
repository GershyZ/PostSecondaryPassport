using System;
using Xamarin.Forms;

namespace PostSecondaryPassport
{
	public class BearTrack : Button
	{
		LevelPage _page;
		public BearTrack(LevelPage page) : base()
		{
			_page = page;
			Text = "UKN";
			BackgroundColor = (Color)App.Current.Resources["primaryColor"];
			TextColor = (Color)App.Current.Resources["secondaryColor"];
			if (page.Title != null)
			{
				Text = page.Title.Substring(0, (page.Title.Length > 3 ? 4 : page.Title.Length));
			}
			Clicked += delegate
			{
				App.goBack(this);
			};
			this.VerticalOptions = LayoutOptions.Start;
		}
		public LevelPage getPage()
		{
			return _page;
		}

	}
}
