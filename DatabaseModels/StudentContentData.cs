using System;
namespace PostSecondaryPassport.DatabaseModels
{
	public class StudentContentData
	{
		public StudentContentData()
		{
			Student_id = -1;
			created_date = new DateTime();
			modified_date = new DateTime();
		}
		public int Student_id { get; set; }
		public int Challenge_id { get; set; }
		public string Content { get; set; }
		public DateTime created_date { get; set; }
		public DateTime modified_date { get; set; }
		public int order { get; set; }
	}
}

