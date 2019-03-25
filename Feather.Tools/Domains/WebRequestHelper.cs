using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Feather.Tools.Domains
{
    public static class WebRequestHelper
    {
        public static string Post(string url, object param)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var result = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(param)));
                var value = result.Result.Content.ReadAsStringAsync().Result;
                return value;
            }
        }
    }
}
