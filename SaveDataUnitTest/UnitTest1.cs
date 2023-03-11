using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SaveDataUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PasswordIncorrectTest()
        {
            var password = "password";

            Assert.IsFalse(Security.PasswordCheck(password));
        }
        
        [TestMethod]
        public void PasswordCorrectTest()
        {
            var password = "Password1";

            Assert.IsTrue(Security.PasswordCheck(password));
        }
         
        [TestMethod]
        public void IsPasswordHeshedCorrectly()
        {   
            var password = "Password1";
            var passwordHeshed = "2AC9CB7DC02B3C0083EB70898E549B63";

            Assert.IsTrue(passwordHeshed == Security.HashPassword(password));
        }
    }
}
