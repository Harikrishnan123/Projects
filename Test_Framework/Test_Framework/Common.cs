using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;

namespace Test_Framework
{
    [TestFixture]
    public class Common : GenericKeywords
    {
        public static void parseidentifyByAndlocator(String identifyByAndLocator)
        {

            try
            {
                GenericKeywords.locatorDescription = identifyByAndLocator.Substring(0, identifyByAndLocator.IndexOf("#"));
                identifyByAndLocator = identifyByAndLocator.Substring(identifyByAndLocator.IndexOf("#") + 1);
            }
            catch (Exception e)
            {
                GenericKeywords.locatorDescription = "";
            }
            finally
            {
                GenericKeywords.identifier = identifyByAndLocator.Substring(0, identifyByAndLocator.IndexOf("=", 0)).ToLower();
                
                GenericKeywords.locator = identifyByAndLocator.Substring(identifyByAndLocator.IndexOf("=", 0) + 1);

                //GenericKeywords.idType = GenericKeywords.identifier;// identifierType.tagname;// (GenericKeywords.identifier);
            }
        }

        public enum identifierType
        {
            xpath,
            name,
            id,
            lnktext,
            partiallinktext,
            classname,
            cssselector,
            tagname
        }
    }
}
