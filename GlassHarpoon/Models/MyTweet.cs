using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace GlassHarpoon.Models
{
    public class MyTweet
    {
        public string Text { get; set; }
        public string Sentiment { get; set; }

        public MyTweet(string text, string sentiment)
        {
            Text = text;
            Sentiment = sentiment;
        }

        //public MyTweet(string text, string place, string sentiment)
        //{
        //    Text = text;
        //    Place = place;
        //    Sentiment = sentiment;
        //}
    }

    public class TweetWithCoords : MyTweet
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public TweetWithCoords(string text, string sentiment, string lat, string lng) : base (text, sentiment)
        {
            Latitude = lat;
            Longitude = lng;
        }


    }

    public class TweetWithPlace : MyTweet
    {
        public string Place { get; set; }

        public TweetWithPlace(string text, string sentiment, string place) : base(text, sentiment)
        {
            Place = place;
        }


    }
}
