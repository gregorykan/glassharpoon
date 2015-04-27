using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassHarpoon.Models
{
    public class MyTweet
    {
        public string Text { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public MyTweet(string text, string latitude, string longitude)
        {
            Text = text;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
