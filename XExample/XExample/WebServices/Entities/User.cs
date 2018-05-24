using Newtonsoft.Json;
using System.Collections.Generic;


namespace XExample.WebServices.Entities
{
    internal class User
    {
        /// <summary>
        /// Page number.
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// Result per page.
        /// </summary>
        [JsonProperty("per_page")]
        public int UsersPerPage { get; set; }

        /// <summary>
        /// Total of users.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Total pages.
        /// </summary>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Collection of users in web service response.
        /// </summary>
        [JsonProperty("data")]
        public List<Information> Data { get; set; }
       
        public class Information
        {
            /// <summary>
            /// User identifier.
            /// </summary>
            public int id { get; set; }

            /// <summary>
            /// User first name.
            /// </summary>
            [JsonProperty("first_name")]
            public string FirstName { get; set; }


            /// <summary>
            /// User last name.
            /// </summary>
            [JsonProperty("last_name")]
            public string LastName { get; set; }

            /// <summary>
            /// URL where is stored the user image.
            /// </summary>
            [JsonProperty("avatar")]
            public string Avatar { get; set; }
        }

       
           
    }
}
