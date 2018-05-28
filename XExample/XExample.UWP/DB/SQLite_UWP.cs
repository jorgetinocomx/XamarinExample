using SQLite;
using Windows.Storage;
using Xamarin.Forms;
using XExample.DB;
using XExample.UWP.DB;

[assembly: Dependency (typeof(SQLite_UWP))]
namespace XExample.UWP.DB
{
    /// <summary>
    /// SQLite implementation for UWP.
    /// </summary>
    public class SQLite_UWP : ISQLite
    {
        /// <summary>
        /// UWP implementation for creating SQLite connection.
        /// </summary>
        /// <param name="DB">Database name.</param>
        /// <returns>DB connection of <seealso cref="SQLiteAsyncConnection"/> type.</returns>
        public SQLiteAsyncConnection Connection(string DB)
        {
            string LibraryPath = ApplicationData.Current.LocalCacheFolder.Path;
            string Path = System.IO.Path.Combine(LibraryPath, DB);
            SQLiteAsyncConnection conn = new SQLite.SQLiteAsyncConnection(Path);
            return conn;
        }
    }
}
