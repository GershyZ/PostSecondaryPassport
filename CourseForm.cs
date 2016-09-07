using System;
using System.Collections.Generic;

namespace PostSecondaryPassport
{
	class CourseForm : BonusFormBuilder
	{
		public static Dictionary<string, double> gradetogpa;
		double course_grade;

		public CourseForm() : base()
		{
			gradetogpa = new Dictionary<string, double>();
			_initializeGPAMap();

			addTextEntry("Course Title", true);
			addTextEntry("Teacher");
			String[] arr = new string[gradetogpa.Count];
			gradetogpa.Keys.CopyTo(arr, 0);
			addDropdownEntry("Credits", new String[] { "1", "2", "3", "4", "5" });
			addDropdownEntry("Letter Grade", arr);
		}


		public override Challenge onComplete()
		{
			return new Course(getFieldValue("Course Title"), getFieldValue("Teacher"), Int32.Parse(getFieldValue("Credits")));
		}

		void _initializeGPAMap()
		{
			gradetogpa.Add("A", 4);
			gradetogpa.Add("A-", 3.67);
			gradetogpa.Add("B+", 3.33);
			gradetogpa.Add("B", 3);
			gradetogpa.Add("B-", 2.67);
			gradetogpa.Add("C+", 2.33);
			gradetogpa.Add("C", 2);
			gradetogpa.Add("C-", 1.67);
			gradetogpa.Add("D+", 1.33);
			gradetogpa.Add("D", 1);
			gradetogpa.Add("D-", 0.67);
			gradetogpa.Add("F", 0);
		}
	}

	/**
	 * Course
	 * A challenge created only by YearSectionPage
	 * */
	public class Course : Challenge
	{
		String _coursename, _teacher, _grade;
		int _numcredits;
		public Course(String title, String teacher, int credits, String grade = null) : base(title)
		{
			_coursename = title;
			_teacher = teacher;
			_numcredits = credits;
			setAccessibility(true);
			setGrade(grade);
		}

		public void setGrade(String lettergrade)
		{
			if (lettergrade != null)
			{
				_grade = lettergrade;
				setCompletion(true);
			}
		}

		public String getCourseName()
		{
			return _coursename;
		}

		public String getTeacher()
		{
			return _teacher;
		}

		public int getCredits()
		{
			return _numcredits;
		}

		public String getLetterGrade()
		{
			return (_grade == null ? "" : _grade);
		}

		public double getCourseGPA()
		{
			double gpa = -1;
			CourseForm.gradetogpa.TryGetValue(_grade, out gpa);
			return gpa;
		}
		protected override void _tapActiveNode()
		{
			if (_grade != null)
			{
				setCompletion(true);
			}
			setCompletionColors();
			//if(_grade == null || _grade.Trim().Length==0){
			//	string[] gradepicker;
			//	CourseForm.gradetogpa.Keys.CopyTo(gradepicker);
			//}
		}
	}
}