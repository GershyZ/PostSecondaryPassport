namespace PostSecondaryPassport
{
	public interface BonusGoalForm
	{
		Challenge onComplete();
		Xamarin.Forms.Page asPage();
		void addButtonFunctionality(LevelPage parent);
	}
}