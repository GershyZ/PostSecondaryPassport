using SQLite;

namespace PostSecondaryPassport.DatabaseModels
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

