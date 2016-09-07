using System;
using SQLite;

namespace PostSecondaryPassport.DatabaseModels
{
	[Table("Challenge")]
	public class ChallengeTable
	{
		public ChallengeTable()
		{
		}

		public static int ADD_CHALLENGE(String name, int owner_id = 0)
		{
			ChallengeTable c = new ChallengeTable();
			c.Title = name;
			c.creator_id = owner_id;
			c.Completed = false;
			return DBPSP.getDBConnection().Insert(c);
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		[NotNull]
		public string Title { get; set; }
		public bool Completed { get; set; }
		public string MedalImgUrl { get; set; }
		public int creator_id { get; set; }
	}
}

