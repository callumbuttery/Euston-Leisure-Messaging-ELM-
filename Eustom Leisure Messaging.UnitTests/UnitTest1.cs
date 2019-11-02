using System;
using BusinessList;
using Datalayer;
using Euston_Leisure_Messaging__ELM_;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eustom_Leisure_Messaging.UnitTests
{
    [TestClass]
    public class EmailTest
    {
        //checks for normal email stored correctly
        [TestMethod]
        public void Storing_emailExpected_Behaviour_True()
        {
            //Arange
            var emailAdded = new AddedEmail();

            //Act
            var result = emailAdded.EmailAdded(new Emailvar { IsAdded = true });

            //Asset
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void Storing_emailExpect_behaviour_False()
        {
            //Arrange
            var emailAdded = new AddedEmail();

            //Act
            var result = emailAdded.EmailAdded(new Emailvar { IsAdded = true });

            //Asset
            Assert.IsTrue(result);
        }






        //Checks for Rec email stored correctly
        [TestMethod]
        public void Storing_recEmail_Behaviour_True()
        {
            //Arrange
            var recEmailAdded = new AddedRecEmail();

            //Act
            var result = recEmailAdded.RecEmailAdded(new RecEmailVar { IsAdded = true });

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Storing_recEmail_Behaviour_False()
        {
            //Arrange
            var recEmailAdded = new AddedRecEmail();

            //Act
            var result = recEmailAdded.RecEmailNotAdded(new RecEmailVar { IsAdded = false });

            //Assert
            Assert.IsFalse(result);
        }





    }


}
