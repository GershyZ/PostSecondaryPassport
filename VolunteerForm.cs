using System;

using Xamarin.Forms;

namespace PostSecondaryPassport
{
	public class VolunteerForm : BonusFormBuilder
	{
		public VolunteerForm() : base()
		{
			addTextEntry("Who", true);
			addTextEntry("What");
			addTextEntry("Where");
			addDateEntry("When");
			addTextEntry("Why");
			addTextEntry("How Long");
		}
	}
}


