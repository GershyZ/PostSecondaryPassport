using System;

using Xamarin.Forms;

namespace PostSecondaryPassport
{
	public class SchoolYearPage : LevelUpPage
	{
		public enum SECTIONS { SEMESTER, TRIMESTER, QUARTERLY }
		public YearSectionPage[] _yearsections;
		public SchoolYearPage(String title, SECTIONS yearformat = SECTIONS.QUARTERLY) : base(title)
		{
			_createYearFormat(yearformat);
		}
		/**
		 * 
		 * **/
		void _createYearFormat(SECTIONS format)
		{
			String section_name = _getYearSectionName(format);
			for (int i = 0; i < _yearsections.Length; i++)
			{
				_yearsections[i] = new YearSectionPage(section_name + " " + (i + 1));
				addSection(_yearsections[i].asLevelContent());
				if (i > 0)
				{
					_yearsections[i].setPreviousSection(_yearsections[i - 1]);
				}
			}

		}
		private String _getYearSectionName(SECTIONS format)
		{
			String section_name;
			switch (format)
			{
				case SECTIONS.SEMESTER:
					_yearsections = new YearSectionPage[2];
					section_name = "Semester";
					break;
				case SECTIONS.TRIMESTER:
					_yearsections = new YearSectionPage[3];

					section_name = "Trimester";
					break;
				case SECTIONS.QUARTERLY:
					_yearsections = new YearSectionPage[4];
					section_name = "Quarter";
					break;
				default:
					_yearsections = new YearSectionPage[1];
					section_name = "Year";
					break;
			}
			return section_name;
		}
	}
}