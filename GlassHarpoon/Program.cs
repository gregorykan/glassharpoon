﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using GlassHarpoon.Models;
using GlassHarpoon.Views;
using Newtonsoft.Json.Linq;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;
using PusherServer;

namespace GlassHarpoon
{
    class Program
    {
        private static string pusherAppId = "117600";
        private static string pusherAppKey = "45c06fa98717fe603c5a";
        private static string pusherAppSecret = "62f457d7131dbb7708b4";

        static void Main(string[] args)
        {
            var pusher = new Pusher(pusherAppId, pusherAppKey, pusherAppSecret);

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://192.168.1.3:9393/");
            //    HttpResponseMessage response = client.GetAsync("help").Result;
            //    if (response.IsSuccessStatusCode)
            //    {
            //        JObject whatIsThis = response.Content.ReadAsAsync<JObject>().Result;
            //        Console.WriteLine(whatIsThis);
            //        Console.ReadKey();
            //    }
            //}


            var filteredStream = Stream.CreateFilteredStream();
            filteredStream.AddTrack("lol");
            filteredStream.MatchingTweetReceived += (sender, arg) =>
            {
                if (arg.Tweet.Coordinates != null)
                {
                    pusher.Trigger("tweetStream", "tweetEvent", new {message = arg.Tweet.Coordinates.Latitude + "\n" + arg.Tweet.Coordinates.Longitude});
                    Console.WriteLine(arg.Tweet.Coordinates.Latitude + "\n" + arg.Tweet.Coordinates.Longitude);
                }
            };
            filteredStream.StartStreamMatchingAllConditions();
            
            //TwitterAuth auth = new TwitterAuth();
            //GetTweet getter = new GetTweet();
            //TweetView view = new TweetView();

            //view.RenderTweet(getter.Fetch("my cat"));

            Console.ReadKey();
        }
    }
}
