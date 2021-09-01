using Microsoft.VisualStudio.TestTools.UnitTesting;
using TZASPART.ActionClass;

namespace TestTZ
{
    [TestClass]
    public class TestAccountManager
    {
        [TestMethod]
        public void TestPassw_ReturnTrue()
        {
            // Arrange 
            string TestEmalExp = "Email@gmail.com";
            //Act
            AccountManager v = new AccountManager();
            bool IsEmlTry = v.IsValidEmail(TestEmalExp);
            //Assert
            Assert.IsTrue(IsEmlTry);
        }
    }
}
