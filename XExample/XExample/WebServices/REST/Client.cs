using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace XExample.WebServices.REST
{
    /// <summary>
    /// Client implementation for working with REST web service requests.
    /// </summary>
    class Client : IClient
    {
        private string WebServiceURL = @"https://reqres.in/api/users?page=2"; // Default(dummie) web service URL to query

        /// <summary>
        /// Generic method for consume REST web service,
        /// </summary>
        /// <typeparam name="T">Expected response object type.</typeparam>
        /// <returns>Response of <seealso cref="T"/> type.</returns>
        public async Task<T> Get<T>()
        {
            try
            {
                HttpClient Client = new HttpClient();
                var Response = await Client.GetAsync(WebServiceURL);
                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JSONstring = await Response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(JSONstring);
                }
                return default(T);
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message != null)
                    throw ex;
                else
                    throw new Exception("Hubo un error de red", ex.InnerException);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
        /// <summary>
        /// Call the generic class  <see cref="Get"/> for consuming REST web service.
        /// 
        /// </summary>
        /// <example>
        ///     <code>
        ///         <see cref="IClient"/> Client = new <seealso cref="REST.Client"/>();
        ///         Client.Get<T>(WebServiceURL);
        ///     </code>
        /// </example>
        /// <typeparam name="T">Generic of response type. </typeparam>
        /// <param name="URL">URL web services</param>
        /// <returns>Class of <seealso cref="T"/> type that contains returning object of requested web services.</returns>
        public async Task<T> Get<T>(string URL)
        {
            WebServiceURL = URL;
            if (string.IsNullOrEmpty(URL))
                throw new Exception("Es necesario definir el parámetro : URL");
            else
            {
                T Response = await Get<T>();
                return Response;
            }
        }
    }
}
