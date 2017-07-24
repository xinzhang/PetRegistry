using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PetOwnerRepository : IPetOwnerRepository
    {
        private string REST_BASE_URL;
        private string REST_JSON_URL;

        public PetOwnerRepository(string baseUrl, string jsonUrl)
        {
            this.REST_BASE_URL = baseUrl;
            this.REST_JSON_URL = jsonUrl;
        }


        public List<Owner> GetOwnersFromRest()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this.REST_BASE_URL);

            var response = client.GetStringAsync(this.REST_JSON_URL).Result;
            return JsonConvert.DeserializeObject<List<Owner>>(response);
        }
    }
}
