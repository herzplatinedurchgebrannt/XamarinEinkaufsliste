using SQLite;

namespace Einkaufsliste
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

