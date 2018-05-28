using SQLite;

namespace XExample.DB.Models
{
    /// <summary>
    /// Employee model that represents "employee" table in DB.
    /// </summary>
    [Table("employee")]
    public class Employee
    {
        /// <summary>
        /// Employee identifier. This is a unique column/property.
        /// </summary>
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Employee name.
        /// </summary>
        [MaxLength(250), Indexed, NotNull, Column("name")]
        public string Name { get; set; }


        /// <summary>
        /// Employee role. Used like the designations for this specific employee.
        /// </summary>
        [MaxLength(100),Column("role")]
        public string Role { get; set; }

        /// <summary>
        /// Employee age.
        /// </summary>
        [Column("age")]
        public int Age { get; set; }

        /// <summary>
        /// This property will not be stored in employee table.
        /// </summary>
        /// <remarks>Just one additional property.</remarks>
        [Ignore]
        public string Comments { get; set; }
    }
}
