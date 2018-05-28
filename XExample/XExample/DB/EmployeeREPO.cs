using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using XExample.DB.Models;

namespace XExample.DB
{
    /// <summary>
    /// Employee repository for <see cref="Models.Employee"/> model.
    /// </summary>
    public class EmployeeREPO:Database
    {
        /// <summary>
        /// Create the database instance and create Employee table.
        /// </summary>
        public EmployeeREPO(): base() // with ": base()" whe call the baseclass(Database) for creating the connection object.
        {
            connection.CreateTableAsync<Employee>().Wait();
        }

        /// <summary>
        /// Get all employees in DB.
        /// </summary>
        /// <returns>Collection of <see cref="Models.Employee"/>.</returns>
        public Task<List<Employee>> GetEmployeeAsync()
        {
            return connection.Table<Employee>().ToListAsync();
        }

        /// <summary>
        /// Return an specific employee.
        /// </summary>
        /// <param name="Id">Employee identifier to query.</param>
        /// <returns>Employee model of <see cref="Models.Employee"/> type.</returns>
        public Task<Employee> GetEmployeeAsync(int Id)
        {
            return connection.Table<Employee>().Where(x => x.Id == Id).FirstAsync();
        }

        public Task<int> SaveEmployeeAsync(Employee Employee)
        {
            if (Employee.Id != 0)
                return connection.UpdateAsync(Employee);
            else
                return connection.InsertAsync(Employee);

        }

        public Task<int> DeleteEmployeeAsync(Employee Employee)
        {
            return connection.DeleteAsync(Employee);
        }

       
    }

}

