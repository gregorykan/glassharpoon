using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace GlassHarpoon
{
    class Program
    {
        static void Main(string[] args)
        {
 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.1.3:9393/");
                HttpResponseMessage response = client.GetAsync("help").Result;
                if (response.IsSuccessStatusCode)
                {
                    JObject whatIsThis = response.Content.ReadAsAsync<JObject>().Result;
                    Console.WriteLine(whatIsThis);
                    Console.ReadKey();
                }
            }
        }
    }
}
