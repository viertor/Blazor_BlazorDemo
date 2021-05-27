using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace JsonPlaceholder.Adapter
{
    public class Client
    {
        public static async System.Threading.Tasks.Task<List<Models.User>> GetUsersAsync()
        {
     
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("users");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Models.User>>(await jsonString);

                }
                else
                {
                    return null;
                }
            }
        }
    }
}
