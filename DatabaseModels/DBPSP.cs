using System;
using System.Diagnostics;
using System.IO;
using SQLite;
using Xamarin.Forms;
//http://www.janaks.com.np/using-sqlite-net-with-xamarin-forms/
//https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/
namespace PostSecondaryPassport.DatabaseModels
{
	public class DBPSP
	{
		public DBPSP()
		{
			var database = getDBConnection();
			database.CreateTable<RouteTable>();
			database.CreateTable<RouteContentTable>();
			database.CreateTable<LevelTable>();
			database.CreateTable<ChallengeTable>();
			Debug.WriteLine("DB Tables Created");
		}
		public static SQLiteConnection getDBConnection()
		{
			return DependencyService.Get<ISQLite>().GetConnection();
		}


		public void addRouteToDatabase(Route r)
		{
			try
			{
				if (RouteTable.hasRoute(r.getRouteName()))
				{
					Debug.WriteLine("Route Exists");
				}
				else {
					int route_id = RouteTable.ADD_ROUTE(r.getRouteName());
					RouteContentTable.populateRouteContentTable(route_id, r);
				}
			}
			catch (SQLiteException ex)
			{
				Debug.WriteLine(ex.Message);
			}
		}
	}
}