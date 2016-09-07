
using System;

using Xamarin.Forms;

namespace PostSecondaryPassport
{
	/**
	 * LevelContent
	 * nodes of a route
	 **/
	public partial class LevelContent : ContentView, Node
	{
		private bool _iscompleted, _isaccessible;

		public LevelContent(string description, string imgloc = null) : base()
		{
			InitializeComponent();
			section_name.Text = description;
			setCompletion(false);
			setAccessibility(false);
		}
		public bool isCompleted()
		{
			return _iscompleted;
		}

		public void setCompletion(bool complete)
		{
			_iscompleted = complete;
		}
		//Since the status of level content is dependent on data,
		//there needs to be a way to change the color scheme as
		//the levelpage populates its content (onAppearing)
		public void setCompletionColors()
		{
			BackgroundColor = (Color)App.Current.Resources["secondaryColor"];
			section_name.TextColor = (Color)App.Current.Resources["primaryColor"];
		}

		public void setGestureDefinitions(bool accessible)
		{
			TapGestureRecognizer tgr = new TapGestureRecognizer();
			tgr.Tapped += delegate
			{
				var cmd = new Command(_executeSingleTap(accessible));
				cmd.Execute(null);
			};
			//_testAccessibility();
			section_layout.GestureRecognizers.Add(tgr);
		}

		private Action _executeSingleTap(bool isaccessible)
		{
			return new Action(delegate
			{
				if (isaccessible)
				{
					_tapActiveNode();
				}
				else {
					_tapCompletedNode();
				}
			});
		}

		public virtual bool isAccessible()
		{
			return _isaccessible;
		}

		public void setAccessibility(bool accessible)
		{
			_isaccessible = accessible;
		}
		protected virtual void _tapActiveNode()
		{
			if (isCompleted())
			{
				setCompletionColors();
			}
		}
		protected virtual void _tapCompletedNode()
		{
			setCompletionColors();
		}

		private void _testAccessibility()
		{
			if (isCompleted())
			{
				section_layout.BackgroundColor = Color.Yellow;
			}
			else if (isAccessible())
			{
				section_layout.BackgroundColor = Color.Green;
			}
			else {
				section_layout.BackgroundColor = Color.Red;
			}
		}

		public string getName()
		{
			return section_name.Text;
		}
	}

	public class Challenge : LevelContent
	{
		protected CarouselPage _detail_carousel;

		public Challenge(String description, int owner_id = 0, string imgloc = null) : base(description, imgloc)
		{
			DatabaseModels.ChallengeTable.ADD_CHALLENGE(description, owner_id);
			_detail_carousel = new CarouselPage();
		}

		public void addDetailPage(ContentPage page)
		{
			_detail_carousel.Children.Add(page);
		}

		protected override void _tapActiveNode()
		{
			setCompletion(true);
			setCompletionColors();
		}

		protected override void _tapCompletedNode()
		{
			setCompletionColors();
		}
	}
	/**
	 * Sublevel
	 * how levelpages populate as content
	 * */
	public class Sublevel : LevelContent
	{
		LevelPage _level;
		public Sublevel(LevelPage page) : base(page.Title)
		{
			_level = page;
		}
		public LevelPage getSublevel()
		{
			return _level;
		}
		public override bool isAccessible()
		{
			return _level.isAccessible();
		}
		protected override void _tapActiveNode()
		{
			if (this.isAccessible())
			{
				App.switchPage(_level);
			}
			else {
				//not accesible
			}
		}

		protected override void _tapCompletedNode()
		{
			_level.showSummary();

		}
	}
}