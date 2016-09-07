using System;

using Xamarin.Forms;

namespace PostSecondaryPassport
{
	public class VolunteerPage : BonusLevelPage
	{
		public VolunteerPage() : base("Volunteering", typeof(VolunteerForm))
		{
			setAccessibility(true);
			_setButtonText("Add a new volunteering service");
		}
	}
}


