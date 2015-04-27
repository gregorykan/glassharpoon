using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;

namespace GlassHarpoon.Models
{
    class GetTweet
    {
        public IEnumerable<ITweet> Fetch(string term)
        {
            return Search.SearchTweets(term);
        }
    }
}
