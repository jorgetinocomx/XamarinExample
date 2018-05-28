using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XExample.DB
{
    /// <summary>
    /// Inherit this class in your repositories for having  common database stuffs.
    /// </summary>
    public abstract class Database
    {
        /// <summary>
        /// Database name.
        /// </summary>
        public const string Name  = "employees.db3"; // const because Never change

        /// <summary>
        /// Database connection.
        /// </summary>
        public readonly SQLite.SQLiteAsyncConnection connection; //readonly because will be changed in constructor initialization

        /// <summary>
        /// Constructor for creating the SQLite connection.
        /// </summary>
        public  Database()
        {
            connection =  DependencyService.Get<ISQLite>().Connection(Name); // Get the specific SQLite implementation for each platform 
        }
    }
}
