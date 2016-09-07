using System;

using System.Collections.Generic;

namespace PostSecondaryPassport
{
	public class HCVRoute : Route
	{
		LevelPage root;
		SchoolYearPage grade_9, grade_10, grade_11, grade_12;
		BonusLevelPage volunteer, SMARTGoal;

		public HCVRoute()
		{
			volunteer = new VolunteerPage();
			SMARTGoal = new SMARTGoalPage();
			grade_9 = new SchoolYearPage("9th Grade");
			grade_9.setAccessibility(true);
			grade_10 = new SchoolYearPage("10th Grade");
			grade_10.addPrerequisite(grade_9.asLevelContent());
			grade_11 = new SchoolYearPage("11th Grade");
			grade_11.addPrerequisite(grade_10.asLevelContent());
			grade_11.addSection(new Challenge("SAT Challenge"));
			grade_12 = new SchoolYearPage("12th Grade");
			grade_12.addPrerequisite(grade_11.asLevelContent());
			root = new LevelPage(getRouteName());
			root.addAllSections(new List<LevelContent> { new Challenge("Tutorial"), volunteer.asLevelContent(), SMARTGoal.asLevelContent(), grade_9.asLevelContent(), grade_10.asLevelContent(), grade_11.asLevelContent(), grade_12.asLevelContent() });
			root.setAccessibility(true);
		}

		public string getRouteName()
		{
			return "Homewood Children Villiage";
		}

		public LevelPage getStartLevel()
		{
			return root;
		}
	}
}

