using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PostSecondaryPassport
{
	//Mandatory Levels
	public class LevelUpPage : LevelPage
	{
		List<LevelContent> _prerequisites;
		public LevelUpPage(String title, List<LevelContent> prereqs = null) : base(title)
		{
			this.setCompletion(false);
			_prerequisites = new List<LevelContent>();
			addAllPrerequisites(prereqs);
		}

		public List<LevelContent> getPrerequisites()
		{
			return _prerequisites;
		}

		/**
		 * aaddPrerequisite
		 * 
		 * */
		public void addPrerequisite(LevelContent prereq)
		{
			this._prerequisites.Add(prereq);
			if (prereq.GetType().Equals(typeof(Sublevel)) && this.isAccessible())
			{
				((Sublevel)prereq).getSublevel().addSection(this.asLevelContent());
			}
		}

		/**
		 * addAllPrerequisites
		 * 
		 * */
		public void addAllPrerequisites(List<LevelContent> prereqs)
		{
			if (prereqs != null)
			{
				for (int i = 0; i < prereqs.Count; i++)
				{
					this.addPrerequisite(prereqs[i]);
				}
			}
		}

		//A level is accessible whenall its preerquisites are completed
		public override bool isAccessible()
		{
			bool canaccess = true;
			if (!base.isAccessible() && _prerequisites != null && _prerequisites.Count > 0)
			{
				for (int i = 0; i < _prerequisites.Count && canaccess; i++)
				{
					canaccess &= _prerequisites[i].isCompleted();
				}
			}
			return canaccess;
		}
	}
}