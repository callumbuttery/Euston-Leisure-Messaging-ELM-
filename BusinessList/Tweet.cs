using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessList
{
    public class Tweet
    {
        private string _twitterID;
        private string _headerInfo;
        private string _messageBody;

        public string twitterID
        {
            get
            {
                return _twitterID;
            }
            set
            {
                _twitterID = value;
            }
        }


        public string headerInfo
        {
            get
            {
                return _headerInfo;
            }
            set
            {
                _headerInfo = value;
            }
        }

        public string messageBody
        {
            get
            {
                return _messageBody;
            }
            set
            {
                _messageBody = value;
            }
        }
    }

    public class tweetadded
    {

        public bool twitterIDChecker(TwitterID twitterid)
        {
            string tweetidtest = "@testusername";
            char pos1 = tweetidtest[0];

            if (tweetidtest.Contains("@") & pos1 == '@' & tweetidtest.Length < 15)
                return true;

            return false;
        }

        public bool twitterIDCheckerFail(TwitterID twitterid)
        {
            string tweetidtestfail = "failusernametestestest";
            char pos1 = tweetidtestfail[0];

            if (!tweetidtestfail.Contains("@") | tweetidtestfail.Length > 15 | pos1 != '@')
                return false;

            return true;
        }


    }




    public class hashtagsAdded
    {
        public bool hashtagChecker(Hashtags hashtags)
        {
            string hashtagstest = "#test #best";

            if (hashtagstest.Contains("#"))
                return true;

            return false;
        }

        public bool hashtagCheckerFail(Hashtags hashtags)
        {
            string hashtagtest = "test test";

            if (!hashtagtest.Contains("#"))
                return false;

            return true;
        }
    }




    public class messageBodyAdded
    {
        public bool bodychecker(BodyAdded body)
        {
            string bodytest = "this must be less than 140 characters";

            if (bodytest.Length < 140)
                return true;

            return false;
        }

        public bool bodycheckerfail(BodyAdded body)
        {
            //140+ chars
            string bodytestfail = " test for more than 140 chars Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque interdum rutrum sodales. Nullam mattis fermentum libero, non volutpat.";

            if (bodytestfail.Length > 141)
                return false;

            return true;
        }
    }





    public class TwitterID
    {
        public bool ContainsInfo { get; set; }
    }

    public class Hashtags
    {
        public bool ContainsInfo { get; set; }
    }

    public class BodyAdded
    {
        public bool containsinfo { get; set; }
    }

}
