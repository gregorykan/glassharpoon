using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace GlassHarpoon.Models
{
    public class SentimentAnalysis 
    {
        //public HttpClient client { get; set; }

        public SentimentAnalysis()
        {
            //client = new HttpClient();
        }

        public void Analyze(string input)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://twinword-sentiment-analysis.p.mashape.com/analyze/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("X-Mashape-Key", "N4MPgxvq15mshZ8tt68Jq3JN6lsfp1mDN9OjsniaiLvFJ4cDAZ");
                HttpResponseMessage response = client.GetAsync("?text=" + input).Result;
                if (response.IsSuccessStatusCode)
                {
                    JObject whatIsThis = response.Content.ReadAsAsync<JObject>().Result;
                    Console.WriteLine(whatIsThis["type"]);
                }
            }
        }
    }
}
