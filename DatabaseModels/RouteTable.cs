using System;
using System.Collections.Generic;
using SQLite;

namespace PostSecondaryPassport.DatabaseModels
{
	[Table("Route")]
	public class RouteTable
	{
		public RouteTable()
		{
			Domain_id = -1;
		}

		public static bool hasRoute(string routename)
		{
			SQLiteConnection db = DBPSP.getDBConnection();
			IEnumerable<RouteTable> result =
				db.Query<RouteTable>(String.Format("SELECT * FROM Route WHERE NAME ='{0}'", routename));

			return result.GetEnumerator().MoveNext();
		}
		public static int ADD_ROUTE(string name)
		{
			RouteTable route = new RouteTable();
			route.Name = name;
			return DBPSP.getDBConnection().Insert(route);
		}
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public int Domain_id { get; set; }
		public string Name { get; set; }
	}
}

