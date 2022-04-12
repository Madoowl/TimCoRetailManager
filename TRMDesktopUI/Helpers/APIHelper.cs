using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Models;

namespace TRMDesktopUI.Helpers
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient ApiClient {
            get; set;
        }

        public APIHelper()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {

            string api = ConfigurationManager.AppSettings["api"];

            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(""); //hardcoding
            //check source video to set the tunnel to the working API project
            ApiClient.DefaultRequestHeaders.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),

            });
            using (HttpResponseMessage response = await ApiClient.PostAsync("/Token", data)) {
                if (response.IsSuccessStatusCode) {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>(); 
                    return result;
                }
                else {
                    throw new Exception(response.ReasonPhrase); // why it failed
                }
            }
        }
    }
}
