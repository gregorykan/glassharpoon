using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassHarpoon.Models
{
    public class ParseString
    {
        public string Parse(string input)
        {
            string tweetText = input;
            string[] tweetTextSplit = tweetText.Split(
                new char[] { '.', '?', '!', ' ', ';', ':', ',', '/', '\\', '@', '#', '_', '-', '\'', '&', '"' }, StringSplitOptions.RemoveEmptyEntries);
            string tweetTextWithPluses = "";

            for (int i = 0; i < tweetTextSplit.Length; i++)
            {
                if (i < tweetTextSplit.Length - 1)
                {
                    tweetTextWithPluses += tweetTextSplit[i] + "+";
                }
                else
                {
                    tweetTextWithPluses += tweetTextSplit[i];
                }
            }
            return tweetTextWithPluses;
        }
    }
}
