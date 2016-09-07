using System;
using System.Collections.Generic;
using System.Diagnostics;
using SQLite;

namespace PostSecondaryPassport.DatabaseModels
{
	/**
	 * RouteContentTable
	 * 
	 * */
	public class RouteContentTable
	{
		public RouteContentTable()
		{
		}
		public int Route_id { get; set; }
		public int Content_id { get; set; }
		public int lft { get; set; }
		public double rgt { get; set; }


		public static void populateRouteContentTable(int route_id, Route r)
		{
			_iterateBranch(route_id, 1, r.getStartLevel());
		}

		private static void _iterateBranch(int route_id, int tracker, LevelPage branch)
		{
			String branchtype = "";
			if (branch.GetType().Equals(typeof(BonusLevelPage)))
			{
				branchtype = "Bonus";
			}
			RouteContentTable branchnode = new RouteContentTable();
			branchnode.Content_id = LevelTable.ADD_LEVEL(branch.getName(), branchtype) * -1;
			branchnode.Route_id = route_id;
			branchnode.lft = tracker;
			Debug.WriteLine(branch.getName() + " starts at " + tracker);
			List<LevelContent> leaves = branch.getLevelContents();
			LevelContent leaf;
			for (int i = 0; i < leaves.Count; i++)
			{
				tracker++;
				leaf = leaves[i];
				Debug.WriteLine(leaf.getName());
				if (leaf.GetType().Equals(typeof(Sublevel)))
				{
					Debug.WriteLine(" is a branch");
					_iterateBranch(route_id, tracker, ((Sublevel)leaf).getSublevel());
					tracker++;
				}
				else {
					Debug.WriteLine("'s positon is " + tracker);
					RouteContentTable leafnode = new RouteContentTable();
					leafnode.Route_id = route_id;
					leafnode.Content_id = ChallengeTable.ADD_CHALLENGE(leaf.getName());
					leafnode.lft = tracker;
					leafnode.rgt = ++tracker;
					DBPSP.getDBConnection().Insert(leafnode, typeof(RouteContentTable));
				}
			}
			tracker++;
			branchnode.rgt = tracker;
			Debug.WriteLine(branch.getName() + " ends at " + tracker);
			DBPSP.getDBConnection().Insert(branchnode, typeof(RouteContentTable));
		}
	}
}
