using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Framework
{
    [TestFixture]
    public class OR
    {
        public static String Header = "Header#xpath=//h1[contains(., 'Cloud Services Console')]";
        public static String Footer = "Footer#xpath=//div[contains(.,'© 2017 Aspire Ventures, an Aspire Universal Company')]";
        // Login page

        public static String Login_Header2 = "headerLogin#xpath=//h2[contains(.,'Log In')]";
        public static String Login_Header_validation = "invalidation#xpath=//p[contains(.,'Please enter your username and password.')]";
        public static String Login_Moreinfo = "Moreinfo#xpath=//p[contains(.,'For more information, or to request additional privileges, please')]";
        public static String Login_Accountinfo = "Accountinfo#xpath=//legend [contains(.,'Account Information')]";
        public static String Login_Forgotpassword = "Forgotpassword#xpath=//*[@href='/forgotpassword']";
        
        
        public static String Login_Moreinfo_linktext = "moreinforlink#lnktext=contact the Aspire Core Technology team";
        public static String Login_UserName = "userNametextbox#xpath=//*[@name='username']";
        public static String Login_Password = "Passwordtextbox#xpath=//*[@id='Password']";
        public static String Login_UserName_label = "userNamelabel#xpath=//*[@id='UserNameLabel']";
        public static String Login_Password_label = "Passwordlabel#xpath=//*[@id='PasswordLabel']";
        public static String Login_Login = "loginbtn#xpath=//button[contains(.,'Login')]";

        // Home page

        public static String Home_username = "username#xpath=//*[@id='HeadLoginView_HeadLoginName']";
        public static String Home_Logout = "Logout#xpath=//a[contains(.,'Log Out')]";
        public static String Home_Application = "ApplicationTab#xpath=//*[@href='/application']";
        public static String Home_users = "usersTab#xpath=//*[@href='/users']";
        public static String Home_role = "roleTab#xpath=//*[@href='/role']";
        public static String Home_organization = "organizationTab#xpath=//*[@href='/organization']";
        public static String Home_organizationtype = "organizationtypeTab#xpath=//*[@href='/organization/type']";
        public static String Home_communication = "communicationTab#xpath=//*[@href='/communications/list']";
        public static String Home_securitylog = "securitylog#xpath=//*[@href='/securitylog']";
    }
}

