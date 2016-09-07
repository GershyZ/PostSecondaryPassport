using System;

using Xamarin.Forms;

namespace PostSecondaryPassport
{
	public class SATForm : BonusFormBuilder
	{
		public SATForm() : base()
		{
			addDateEntry("Test Date");
			addTextEntry("Math");
			addTextEntry("English");
			addTextEntry("Writing");
			addTextEntry("Total Score", true);
		}
	}
}


