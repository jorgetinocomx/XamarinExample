namespace XExample.DB
{
    public interface ISQLite
    {
        SQLite.SQLiteAsyncConnection Connection (string DB);
    }
}
