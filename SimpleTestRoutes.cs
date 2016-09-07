using System;
using System.Collections.Generic;

namespace PostSecondaryPassport
{
	public class SimpleTestRoutes
	{

		/*TESTS*/
		public LevelPage simpleRoute()
		{
			LevelPage root, level1, level2;
			Challenge rootc, level1c;
			root = new LevelPage("Home");
			level1 = new LevelPage("Level 1");
			rootc = new Challenge("challenge 0");
			level1c = new Challenge("challenge 1");
			level2 = new LevelPage("Level 2");

			root.addAllSections(new List<LevelContent> { level1.asLevelContent(), rootc });
			level1.addSection(level1c);
			level1.addSection(level2.asLevelContent());
			return root;
		}

		public LevelPage prereqRoute()
		{
			LevelPage root;
			LevelUpPage level1, level2;
			Challenge prereq1;

			root = new LevelPage("Home");
			level1 = new LevelUpPage("No Prereqss");
			level2 = new LevelUpPage("has prereqs");
			prereq1 = new Challenge("prereq");
			level1.addSection(prereq1);
			level2.addPrerequisite(prereq1);
			root.addAllSections(new List<LevelContent> { level1.asLevelContent(), level2.asLevelContent() });
			return root;
		}

		LevelPage bonusRoute()
		{
			YearSectionPage root = new YearSectionPage("Volunteering");
			return root;
		}
	}
}