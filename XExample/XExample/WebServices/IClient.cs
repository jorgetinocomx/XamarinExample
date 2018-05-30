using System.Threading.Tasks;

namespace XExample.WebServices
{
    /// <summary>
    /// Web services client interface.
    /// </summary>
    /// <remarks>
    ///     Define in this places all possible methods for working with webservices.
    /// </remarks>
    public interface IClient
    {
        /// <summary>
        /// Define a method for using a GET request for a web services.
        /// </summary>
        /// <typeparam name="T">Result object type from the web service.</typeparam>
        /// <returns>Result object o <seealso cref="T"/> type.</returns>
        Task<T> Get<T>();

        /// <summary>
        /// Defines a method for querying a web service using GET operation.
        /// </summary>
        /// <typeparam name="T">Result object type from the web service.</typeparam>
        /// <param name="URL">Web service URL to query.</param>
        /// <returns>Result object o <seealso cref="T"/> type.</returns>
        Task<T> Get<T>(string URL);
    }
}
