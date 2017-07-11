using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System.Drawing.Imaging;



namespace Test_Framework
{
    [TestFixture]
    public class TestCases : ApplicationKeywords
    {
        

        [Test]
        public void login_Valid()
        {
            testStarts("Tc_Login_001", "Verify the field displays correctly in login page");

            // verifyLinkText(OR.Login_Moreinfo_linktext);
            openBrowser("http://localhost:3000/login");
            verifyElementText(OR.Login_Header2, "Log In");
            verifyElementText(OR.Login_Header_validation, "Please enter your username and password.");
            verifyElementText(OR.Login_Moreinfo, "For more information, or to request additional privileges, please");
            verifyElementText(OR.Login_Accountinfo, "Account Information");
                //verifyElement(OR.Login_Forgotpassword);
            verifyPageTitle("Cloud Console");
            verifyElementText(OR.Login_UserName_label, "Username");
            verifyElementText(OR.Login_Password_label, "Password");
        }

        [Test]
        public void Testthod()
        {
            testStarts("Tc_Login_002", "Verify by login with valid credentails, verify the home page fields");
            openBrowser("http://localhost:3000/login");
            login();
            home();
        }

        [TearDown]
        public void Strop()
        {
            driver.Quit();
            extd.EndTest(test);
            extd.Flush();
        }


    }
}
