using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Framework
{
    [TestFixture]
    public class ApplicationKeywords : GenericKeywords
    {
        public static void login()
        {
            verifyElementText(OR.Header, "Cloud Services Console");
            verifyElementText(OR.Footer, "© 2017 Aspire Ventures, an Aspire Universal Company");
            typeIn(OR.Login_UserName, "harikrishnan@aspirevc.com");
            typeIn(OR.Login_Password, "Hari@12345");
            clickOn(OR.Login_Login);
        }

        public static void home()
        {

            verifyElementText(OR.Header, "Cloud Services Console");
            verifyElementText(OR.Footer, "© 2017 Aspire Ventures, an Aspire Universal Company");
            verifyElementText(OR.Home_Logout, "Log Out");
            verifyElementText(OR.Home_Application, "Application");
            verifyElementText(OR.Home_users, "Users");
            verifyElementText(OR.Home_role, "Roles");
            verifyElementText(OR.Home_organization, "Organization");
            verifyElementText(OR.Home_organizationtype, "Organization Type");
            verifyElementText(OR.Home_communication, "Communications");
            verifyElementText(OR.Home_securitylog, "Security Log");
        }
    }
}
