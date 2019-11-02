using System;
using BusinessList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eustom_Leisure_Messaging.UnitTests
{
    [TestClass]
    public class SMS_variables_test_unit
    {
        [TestMethod]
        public void CanBeAdded_Behaviour_ReturnsTrue()
        {
            //Arrange
            var smsadded = new Added();


            //Act
            var result = smsadded.PhoneNoIsAdded(new PhoneNo { IsAdded = true });

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void canBeAdded_Behaviour_ReturnsFalse()
        {
            //Arrabe
            var smsadded = new Added();

            //Act
            var result = smsadded.PhoneNoIsAdded(new PhoneNo { IsAdded = false });

            //Assert
            Assert.IsFalse(result);
        }









        [TestMethod]
        public void Add_Area_code()
        {
            //Arrange
            var areaCodeAdded = new Added();

            //Act
            var result = areaCodeAdded.areaCodeAdded(new AreaCode { IsAdded = true });

            //Assert
            Assert.IsTrue(result);

        }


        [TestMethod]
        public void Fail_Add_Area_Code()
        {
            //Arrange
            var areaCodeNotAdded = new Added();

            //ACt
            var result = areaCodeNotAdded.areaCodeNotAdded(new AreaCode { IsAdded = false });

            //Assert
            Assert.IsFalse(result);
        }










        [TestMethod]
        public void header_Added_Correctly()
        {
            //Arrange
            var headeradded = new Added();

            //Act
            var result = headeradded.headerAdded(new HeaderInfo { IsAdded = true });

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void header_Not_Added_Correctly()
        {
            //Arrange
            var headernotadded = new Added();

            //Act
            var result = headernotadded.headerNotAdded(new HeaderInfo { IsAdded = false });

            //Assert
            Assert.IsFalse(result);
        }









        [TestMethod]
        public void messagebody_Added_Correctly()
        {
            

            //Arrange
            var messageAdded = new Added();

            //Act
            var result = messageAdded.messageBodyAdded(new MessageBodyInfo { IsAdded = true });

            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void messagebody_NotAdded_Correctly()
        {
            //Arrange
            var messageNotAdded = new Added();

            //Act
            var result = messageNotAdded.messageBodyNotAdded(new MessageBodyInfo { IsAdded = true });

            //Assert
            Assert.IsTrue(result);
        }
    }



}
