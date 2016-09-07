using System;
using SQLite;

namespace PostSecondaryPassport.DatabaseModels
{
	[Table("Level")]
	public class LevelTable
	{
		public LevelTable()
		{
			Domain_id = App.OFFLINE_DOMAIN_ID;
		}
		public static int ADD_LEVEL(String title, String leveltype)
		{
			LevelTable l = new LevelTable();
			l.Title = title;
			l.Type = leveltype;
			return DBPSP.getDBConnection().Insert(l, typeof(LevelTable));
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public int Domain_id { get; set; }
		public string Title { get; set; }
		public string Type { get; set; }
	}
}

