using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using XExample.DB;
using XExample.iOS.DB;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace XExample.iOS.DB
{
    /// <summary>
    /// SQLite implementation for iOS.
    /// </summary>
    public class SQLite_iOS : ISQLite
    {
        /// <summary>
        /// Implementing iOS method for creating SQLite connection.
        /// </summary>
        /// <param name="DB">Database name.</param>
        /// <returns>SQLite connection of <seealso cref="SQLiteAsyncConnection"/> type.</returns>
        public SQLiteAsyncConnection Connection(string DB)
        {
            string Path = string.Empty;
            string DocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string LibraryPath = System.IO.Path.Combine(DocumentPath, "..", "Library", "Databases");
            if (!Directory.Exists(LibraryPath))
                Directory.CreateDirectory(LibraryPath);
            else
                  Path  = System.IO.Path.Combine(LibraryPath, DB);
            SQLiteAsyncConnection conn = new SQLite.SQLiteAsyncConnection(Path);
            return conn;
        }
    }
}
