using BusinessList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer
{
    public class TweetList
    {

        public List<Tweet> list = new List<Tweet>();

        public void add(Tweet newTweet)
        {
            list.Add(newTweet);
        }

    }
}
