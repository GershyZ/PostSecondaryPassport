using System;
using System.Collections.Generic;
using SQLite;
namespace PostSecondaryPassport.DatabaseModels
{
	[Table("StudentChallenge")]
	public class StudentChallengeData
	{
		public StudentChallengeData()
		{
		}
		public void addChallengeData(int parent_id, int content_id, Dictionary<string, string> details)
		{
			List<StudentChallengeData> data = new List<StudentChallengeData>();
			StudentChallengeData curr;
			string currval;
			while (details.Keys.GetEnumerator().MoveNext())
			{
				curr = new StudentChallengeData();
				curr.level_id = parent_id;
				curr.challenge_id = content_id;
				curr.key = details.Keys.GetEnumerator().Current;
				details.TryGetValue(curr.key, out currval);
				curr.content = currval;
				data.Add(curr);
				DBPSP.getDBConnection().InsertAll(data, typeof(StudentChallengeData), true);
			}
		}

		public int level_id { get; set; }
		public int challenge_id { get; set; }
		public string key { get; set; }
		public string content { get; set; }
		[AutoIncrement]
		public int order { get; set; }
	}
}

