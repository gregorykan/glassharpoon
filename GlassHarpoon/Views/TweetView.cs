using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Core.Interfaces;

namespace GlassHarpoon.Views
{
    class TweetView
    {
        public void RenderTweet(IEnumerable<ITweet> tweets)
        {
            foreach (ITweet tweet in tweets)
            {
                Console.WriteLine("Text is: " + tweet.Text);
                if (tweet.Coordinates != null)
                {
                    Console.WriteLine("Coordinates are: {0}, {1}", tweet.Coordinates.Latitude, tweet.Coordinates.Longitude);
                }
            }
        }
    }
}
