using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using JsonPlaceholder.Adapter.Models;

namespace JsonPlaceholder.Adapter
{
    public class Client
    {
        private const string JsonPlaceHolderBaseUri = "https://jsonplaceholder.typicode.com/";
 
        /// <summary>
        /// Initilize JsonPlaceHolder Client
        /// </summary>
        public static HttpClient SetUpHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(JsonPlaceHolderBaseUri)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        /// <summary>
        /// Get users from JsonPlaceHodder async
        /// </summary>
        /// <returns>List of users</returns>
        public static async Task<List<User>> GetUsersAsync()
        {
            var client = SetUpHttpClient();
            using (client)
            {
                var response = await client.GetAsync("users");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<User>>(await jsonResponse);
                }
                else
                    return null;
            }

        }
    }
}
