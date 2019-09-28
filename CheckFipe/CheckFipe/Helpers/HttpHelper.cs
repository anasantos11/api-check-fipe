using CheckFipe.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheckFipe.Helpers
{
    public class HttpHelper
    {
        public HttpHelper(string url)
        {
            this.Url = url;
        }

        protected string Url { get; set; }

        public T DoRequestGet<T>()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    return JsonConvert.DeserializeObject<T>(httpClient.GetStringAsync(this.Url).Result);
                }
            }
            catch (Exception exception)
            {
                throw new UnexpectedServiceResponseException(exception);
            }
        }
    }
}
