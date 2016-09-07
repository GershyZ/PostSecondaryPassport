using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using PostSecondaryPassport.DatabaseModels;
namespace PostSecondaryPassport
{
	public partial class App : Application
	{
		private static DBPSP _DATABASE;
		private static Stack<LevelPage> _history_stack;

		public static int OFFLINE_STUDENT_ID { get { return -1; } }

		public static int OFFLINE_DOMAIN_ID { get { return -1; } }

		public App()
		{
			InitializeComponent();
			_history_stack = new Stack<LevelPage>();
			MainPage = new PostSecondaryPassportPage();
		}

		public static void switchPage(LevelPage page)
		{
			if (_history_stack.Contains(page))
			{
				goBack(new BearTrack(page));
			}
			else {
				_history_stack.Push(page);
				page.populateBeartracks(_history_stack);
				var nav = new NavigationPage(page);
				Current.MainPage = nav;
			}
		}

		public static void goBack(BearTrack track)
		{
			bool found = false;
			if (track == null || _history_stack.Count == 0)
			{
				found = true;
			}
			LevelPage curr = null;
			while (_history_stack.Count > 0 && _history_stack.Peek() != null && !found)
			{
				curr = _history_stack.Pop();
				if (curr.Equals(track.getPage()))
				{
					found = true;
				}
			}
			if (found)
			{
				var nav = new NavigationPage(track.getPage());
				_history_stack.Push(track.getPage());
				Application.Current.MainPage = nav;
			}
		}

		public static Stack<LevelPage> getHistory()
		{
			return _history_stack;
		}
		public static DBPSP getDatabase()
		{
			if (_DATABASE == null)
			{
				Debug.WriteLine("Initializing DB Connection");
				_DATABASE = new DBPSP();
			}
			return _DATABASE;
		}

		protected override void OnStart()
		{
			base.OnStart();
			Debug.WriteLine("Initializing System");
			App.getDatabase();
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

