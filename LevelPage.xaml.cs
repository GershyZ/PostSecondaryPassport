using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace PostSecondaryPassport
{
	/**
	 * LevelPage
	 * Composed of section
	 * */
	public partial class LevelPage : ContentPage, Node
	{
		bool _iscompleted, _isaccessible;
		List<LevelContent> _sections;
		public LevelPage(String title, List<LevelContent> sections = null)
		{
			InitializeComponent();
			this.Title = title;
			lbl_title.Text = title;
			_sections = new List<LevelContent>();
			addAllSections(sections);
		}

		/**
		 * addAllSections
		 * Easy way to make a route branch
		 * @param name="sections"
		 */
		public void addAllSections(List<LevelContent> sections)
		{
			if (sections != null)
			{
				for (int i = 0; i < sections.Count; i++)
				{
					addSection(sections[i]);
				}
			}
		}

		/**
		 * addSection
		 * adds a node to the branch
		 * @param name="ls"
		 **/
		public void addSection(LevelContent ls)
		{
			_sections.Add(ls);
		}
		public List<LevelContent> getLevelContents()
		{
			return _sections;
		}
		/**
		 * asSublevel
		 * allows page to be a subsection of  another page
		 * @return LevelContent
		 * */
		public LevelContent asLevelContent()
		{
			return new Sublevel(this);
		}

		/**
		 * populateBeartracks
		 * Since pathways can be varied, beartracks are not stored locally
		 * reloads beartracks into the navigation bar
		 * @param name="tracks"
		 */
		public void populateBeartracks(Stack<LevelPage> tracks)
		{
			if (!(tracks == null || tracks.Count == 0))
			{
				LevelPage[] arr_tracks = new LevelPage[tracks.Count];
				tracks.CopyTo(arr_tracks, 0);
				int lasttrack = 4;
				for (int i = arr_tracks.Length; lasttrack != 0 && i > 0; i--)
				{
					lasttrack--;
					sl_tracks.Children.Add(new BearTrack(arr_tracks[i - 1]));
				}
			}
		}
		public String getName()
		{
			return lbl_title.Text;
		}
		public virtual void showSummary() { }

		/**
		 * isCompleted
		 * checks to see if
		 * */
		public virtual bool isCompleted()
		{
			bool iscomplete = _iscompleted;
			var content = getLevelContents();
			if (content != null)
			{
				for (int i = 0; i < content.Count && iscomplete; i++)
				{
					if (!((LevelContent)content[i]).isCompleted())
					{
						iscomplete = false;
					}
				}
			}

			return iscomplete;
		}
		public void setCompletion(bool completion)
		{
			_iscompleted = completion;
		}

		public void setAccessibility(bool access)
		{
			_isaccessible = access;
		}

		public virtual bool isAccessible()
		{
			return _isaccessible;
		}

		protected void _addToHeader(View v)
		{
			sl_header.Children.Add(v);
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			_refresh();
		}
		protected void _refresh()
		{
			level_content.Children.Clear();
			for (int i = 0; _sections != null && i < _sections.Count; i++)
			{
				level_content.Children.Add(_sections[i]);
				if (!_sections[i].isAccessible())
				{
					_sections[i].Opacity = .75;
				}
				else if (_sections[i].isCompleted())
				{
					_sections[i].setCompletionColors();
				}
				_sections[i].setGestureDefinitions(isAccessible());
			}
		}
	}
}