using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PostSecondaryPassport
{
	public class SMARTGoalForm : TabbedPage, BonusGoalForm
	{
		public static List<SMARTGoalTemplate> GOAL_TEMPLATES;
		public static int TEMPLATE_INDEX;
		protected SMARTGoalTab form_s, form_m, form_a, form_r, form_t;
		SMARTGoalTab[] tabs;
		public SMARTGoalForm() : base()
		{
			if (Device.OS == TargetPlatform.iOS)
			{
				// move layout under the status bar
				Padding = new Thickness(0, 20, 0, 0);
			}

			TEMPLATE_INDEX = 0;
			GOAL_TEMPLATES = new List<SMARTGoalTemplate>();
			GOAL_TEMPLATES.Add(new SMARTGoalTemplate("I want to buy something", "dollars", "I can make money by:"));
			//GOAL_TEMPLATES.Add(new SMARTGoalTemplate("I need to improve my grades" 
			GOAL_TEMPLATES.Add(new SMARTGoalTemplate("I want to do well on a test", "%", "I need to study: "));
			GOAL_TEMPLATES.Add(new SMARTGoalTemplate("Create your own", "", ""));
			form_s = new SForm();
			form_m = new MForm();
			form_a = new AForm();
			form_r = new RForm();
			form_t = new TForm();
			tabs = new SMARTGoalTab[] { form_s, form_m, form_a, form_r, form_t };

		}
		static SMARTGoalTemplate GET_VISABLE_TEMPLATE()
		{
			return GOAL_TEMPLATES[TEMPLATE_INDEX];
		}

		public Challenge onComplete()
		{
			return new Challenge(form_s.getCurrentTemplate().getSDetailLabel());
		}

		public void addButtonFunctionality(LevelPage parent)
		{
			for (int i = 0; i < tabs.Length; i++)
			{
				Children.Add(tabs[i]);
				tabs[i].addCancelFunctionality(parent);
			}
			((TForm)form_t).submitGoal(parent);
		}
		public Page asPage()
		{
			return (Page)this;
		}

		protected class SForm : SMARTGoalTab
		{
			public SForm() : base("Specific", "Be Detailed! Stay away from vague and confusing goals", Color.Red)
			{
				Picker templates = new Picker
				{
					HorizontalOptions = LayoutOptions.Fill
				};

				addPageContent(templates);
				foreach (SMARTGoalTemplate goal in SMARTGoalForm.GOAL_TEMPLATES)
				{
					templates.Items.Add(goal.getSDetailLabel());
				}
				templates.SelectedIndexChanged += (object sender, EventArgs e) =>
				{
					TEMPLATE_INDEX = templates.SelectedIndex;
				};
			}
		}
		protected class MForm : SMARTGoalTab
		{
			Label label;
			public MForm() : base("Measure", "Set a value you need to pass in order to achieve your goal", Color.Yellow)
			{
				label = new Label();
				Entry bar_value = new Entry();
				addPageContent(bar_value);
				addPageContent(label);
			}
			protected override void OnAppearing()
			{
				base.OnAppearing();
				label.Text = getCurrentTemplate().getMDetailLabel();
			}

		}
	}
	class AForm : SMARTGoalTab
	{
		Entry firstAction;
		public AForm() : base("Action", "What will you do? How are you get there?", Color.Aqua)
		{
			Button addAction = new Button();
			addAction.Clicked += delegate
			{
				addPageContent(newAction());
			};
			addAction.Text = "Add new action";
			firstAction = new Entry();

			addPageContent(addAction);
			addPageContent(firstAction);
		}

		public View newAction()
		{
			StackLayout action = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Fill,
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.Accent
			};
			action.Children.Add(new Entry { HorizontalOptions = LayoutOptions.FillAndExpand });
			Label closelink = new Label
			{
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,
				Text = "Close",
				TextColor = Color.Red
			};
			TapGestureRecognizer tgr = new TapGestureRecognizer();
			tgr.Tapped += (sender, e) =>
			{
				action.IsVisible = false;
			};
			closelink.GestureRecognizers.Add(tgr);
			action.Children.Add(closelink);
			return action;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			firstAction.Text = getCurrentTemplate().getADetailLabel();
		}
	}
	class RForm : SMARTGoalTab
	{
		public RForm() : base("Realistic", "Check your goals. Is it doable?", Color.Purple)
		{
			Label promise = new Label { Text = " Is this reasonable?" };
			Slider s = new Slider();
			StackLayout content = new StackLayout { Orientation = StackOrientation.Horizontal };
			content.Children.Add(promise);
			content.Children.Add(s);
			addPageContent(content);
		}
	}
	class TForm : SMARTGoalTab
	{
		Button createGoal;
		public TForm() : base("Timed", "Give yourself time, but not too much!", Color.Green)
		{
			createGoal = new Button();
			createGoal.Text = "Create SMART Goal";

			addToButtonBar(createGoal);
			StackLayout duedate = new StackLayout { Orientation = StackOrientation.Horizontal };
			duedate.Children.Add(new Label { Text = "Due Date:" });
			DatePicker dp = new DatePicker();
			duedate.Children.Add(dp);
			dp.Date.Add(TimeSpan.FromDays(7));
			addPageContent(new Label { Text = String.Format("Today is {0}", DateTime.Now.ToString("D")) });
			addPageContent(duedate);
		}

		public void submitGoal(LevelPage parent)
		{
			createGoal.Clicked += delegate
			{
				parent.addSection(new Challenge(getCurrentTemplate().getSDetailLabel()));
				App.switchPage(parent);
			};
		}
	}
}
