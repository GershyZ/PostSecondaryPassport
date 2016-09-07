
using System;
using System.Collections.Generic;
namespace PostSecondaryPassport
{
	public class YearSectionPage : BonusLevelPage
	{
		double _gpa;
		YearSectionPage _prereq;
		public YearSectionPage(string title) : base(title, typeof(CourseForm))
		{
			_gpa = 0;
			_setButtonText("Add new Course");
		}
		/**
		 * showSummary
		 * a popup to show yearsectionpage
		 * TODO: create
		 * */
		public override void showSummary()
		{
			if (isCompleted())
			{
			}
		}

		/**
		 * setPreviousSection
		 * AKA Prerequisite
		 * */
		public void setPreviousSection(YearSectionPage prereq)
		{
			_prereq = prereq;
		}

		public override bool isAccessible()
		{
			return (_prereq == null || _prereq.isCompleted());
		}
		/**
		 * an empty section is not a completed section
		 * */
		public override bool isCompleted()
		{
			bool complete = base.isCompleted(); //prerequisites already are checked by this
			List<LevelContent> courses = getLevelContents();

			if (!(!complete || courses == null || courses.Count == 0))
			{
				double culmgpa = 0;
				int numcredits = 0;
				Course currcourse;
				for (int i = 0; i < courses.Count && complete; i++)
				{
					currcourse = (Course)courses[i];
					complete &= currcourse.isCompleted();
					if (complete)
					{
						culmgpa += currcourse.getCourseGPA() * currcourse.getCredits();
						numcredits += currcourse.getCredits();
					}
				}
				if (complete)
				{
					_gpa = culmgpa / numcredits;
				}
			}
			return complete;
		}
	}
}