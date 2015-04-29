using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using GlassHarpoon.Models;
using GlassHarpoon.Views;
using Newtonsoft.Json;
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
            TwitterAuth auth = new TwitterAuth();
            SentimentAnalysis analyze = new SentimentAnalysis();
            ParseString parser = new ParseString();

            //using (client)
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

            //GetTweet getter = new GetTweet();
            //TweetView view = new TweetView();

            //view.RenderTweet(getter.Fetch("my cat"));

            var filteredStream = Stream.CreateFilteredStream();
            filteredStream.AddTrack("lol");
            filteredStream.MatchingTweetReceived += (sender, arg) =>
            {
                if (arg.Tweet.Coordinates != null)
                {
                    string sentiment = analyze.Analyze(parser.Parse(arg.Tweet.Text));
                    MyTweet thisTweet = new TweetWithCoords(arg.Tweet.Text, sentiment, arg.Tweet.Coordinates.Latitude.ToString(), arg.Tweet.Coordinates.Longitude.ToString());
                    pusher.Trigger("tweetStream", "tweetEvent", new { message = thisTweet });
                    Console.WriteLine(arg.Tweet.Text);
                    Console.WriteLine("coords: " + arg.Tweet.Coordinates.Latitude + ", " + arg.Tweet.Coordinates.Longitude);
                    Console.WriteLine(sentiment);
                }
                else if (arg.Tweet.Place != null)
                {
                    string sentiment = analyze.Analyze(parser.Parse(arg.Tweet.Text));
                    MyTweet thisTweet = new TweetWithPlace(arg.Tweet.Text, sentiment, arg.Tweet.Place.Name);
                    pusher.Trigger("tweetStream", "tweetEventWithPlace", new { message = thisTweet });
                    Console.WriteLine(arg.Tweet.Text);
                    Console.WriteLine("place: " + arg.Tweet.Place.Name);
                    Console.WriteLine(sentiment);
                }
            };
            //filteredStream.DisconnectMessageReceived += (sender, eventArgs) => Console.WriteLine("Disconnect");
            //filteredStream.LimitReached += (sender, eventArgs) => Console.WriteLine("Limit");
            while (true)
            {
                filteredStream.StartStreamMatchingAllConditions();
            }

            

        }
    }
}
