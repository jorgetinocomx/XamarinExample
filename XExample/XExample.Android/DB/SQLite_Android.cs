using SQLite;
using Xamarin.Forms;
using XExample.DB;
using XExample.Droid.DB;

[assembly: Dependency(typeof (SQLite_Android))]
namespace XExample.Droid.DB
{
    /// <summary>
    /// SQLite implementation for Android.
    /// </summary>
    public class SQLite_Android : ISQLite
    {
        /// <summary>
        /// Implementing method that creates SQLite connection
        /// </summary>
        /// <param name="DB">Database name.</param>
        /// <returns>DB connection of <seealso cref="SQLiteAsyncConnection"/> type.</returns>
        public SQLiteAsyncConnection Connection(string DB)
        {
            string DocumentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string Path = System.IO.Path.Combine(DocumentsPath, DB);
            SQLiteAsyncConnection conn = new SQLite.SQLiteAsyncConnection(Path);
            return conn;
        }
    }
}