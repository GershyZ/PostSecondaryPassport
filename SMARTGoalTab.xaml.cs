using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PostSecondaryPassport
{
	public partial class SMARTGoalTab : ContentPage
	{

		SMARTGoalTemplate currtemplate;
		public SMARTGoalTab(String headline, String description, Color headline_color)
		{
			InitializeComponent();
			Title = headline.Substring(0, 1);
			section_name.Text = headline;
			section_name.TextColor = headline_color;
			section_description.Text = description;
		}

		public void addPageContent(View v)
		{
			pageContent.Children.Add(v);
		}

		protected override void OnAppearing()
		{
			currtemplate = SMARTGoalForm.GOAL_TEMPLATES[SMARTGoalForm.TEMPLATE_INDEX];
		}

		public SMARTGoalTemplate getCurrentTemplate()
		{
			return currtemplate;
		}

		public void addCancelFunctionality(LevelPage parent)
		{
			Button cancel = new Button();
			cancel.Text = "Cancel";
			cancel.Clicked += delegate
			{
				parent.Navigation.PopModalAsync(true);
			};
			cancel.HorizontalOptions = LayoutOptions.Center;
			addToButtonBar(cancel);
		}

		public void addToButtonBar(View v)
		{
			sl_bottom.Children.Add(v);
		}
	}
}