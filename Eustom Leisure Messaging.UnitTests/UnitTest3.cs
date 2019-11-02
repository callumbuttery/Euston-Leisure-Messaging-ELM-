using System;
using BusinessList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eustom_Leisure_Messaging.UnitTests
{
    [TestClass]
    public class Tweet_info_Unit_tests
    {
        //checks twitter id input validation for @ sign
        [TestMethod]
        public void check_twitterID()
        {
            //Arrange
            var twitteridcheck = new tweetadded();

            //Act
            var result = twitteridcheck.twitterIDChecker(new TwitterID { ContainsInfo = true });

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void check_TwitterID_fail()
        {
            //Arrange
            var twitteridcheck = new tweetadded();

            //Act
            var result = twitteridcheck.twitterIDCheckerFail(new TwitterID { ContainsInfo = false });

            //Assert
            Assert.IsFalse(result);
        }






        //Check that hashtags contains #
        //second test checks its doesn't contain #
        [TestMethod]
        public void check_hashtags()
        {
            //Arrange
            var hashtagcheck = new hashtagsAdded();

            //Act
            var result = hashtagcheck.hashtagChecker(new Hashtags { ContainsInfo = true });

            //Assert
            Assert.IsTrue(result);
        }

        public void check_hashtags_fail()
        {
            //Arrange
            var hashtagcheck = new hashtagsAdded();

            //Act
            var result = hashtagcheck.hashtagCheckerFail(new Hashtags { ContainsInfo = false });

            //Assert
            Assert.IsFalse(result);
        }







        //Check that the message body is less than 140 characters in size
        [TestMethod]
        public void check_body_size()
        {
            //Arrange
            var checkbodysize = new messageBodyAdded();

            //Act
            var result = checkbodysize.bodychecker(new BodyAdded { containsinfo = true });

            //Assert
            Assert.IsTrue(result);
        }


        //assert for messagebody which is greater than 140 chars
        [TestMethod]
        public void check_body_size_fail()
        {
            //Arrange
            var checkbodysizefail = new messageBodyAdded();

            //Act
            var result = checkbodysizefail.bodycheckerfail(new BodyAdded { containsinfo = false });

            //Assert
            Assert.IsFalse(result);
        }
    }

}
