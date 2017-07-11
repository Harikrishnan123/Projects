using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Framework
{
    [TestFixture]
    public class GenericKeywords 
    {
        public static IWebDriver driver ;
        public static ExtentReports extd;
        public static ExtentTest test;
        public static String locatorDescription;
        public static String locator;
        public static Common.identifierType idType;
        public static String identifier;
        public static IWebElement webElement;
        public static int implicitlyWaitTime =80;
        public static string timestamp = DateTime.Now.ToString("yy-MM-dd hh-mm-ss");
        public static int elementLoadWaitTime =100;
        public static String screenshot = @"C:\Users\Acer\Desktop\dev_ionic\re.png";
        String FilePathScreenshot = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshot\\");

        [OneTimeSetUp]
        public void onetime()
        {
            try
            {
                extd = new ExtentReports("C:\\Users\\Acer\\Desktop\\file\\report.html");
                Logger.WriteLog("The the report path is present ");
                

            }
            catch(Exception e)
            {
                Logger.WriteLog("One time decalaration of test report path is not present "+e);
            }

        }

        public static void testStarts(String TestCaseName, String Description)
        {
            try
            {
                test = extd.StartTest(TestCaseName, Description);
                Logger.WriteLog("Added the Testcasename '"+ TestCaseName +"' and Description '"+Description);
            }
            catch (Exception e)
            {
                Logger.WriteLog("Error - "+ " Unable to add the testcasename and description in test report " + e);
               

            }
        }

        public static void testLogInfo(String Desc)
        {
            test.Log(LogStatus.Info, Desc);
        }

        public static void testLogPass(String Desc)
        {
            test.Log(LogStatus.Pass, Desc);
        }
        public static void testLogError(String Screenshotlocation)
        {
            

            test.Log(LogStatus.Error, test.AddScreenCapture(screenshot));
        }

        public static void testLogFail(String ErrorMessage)
        {
            test.Log(LogStatus.Fail, ErrorMessage);
            Takescreenshot();
            testLogError(screenshot);
            Assert.Fail();
        }
        public static void openBrowser(String URL)
        {
            try
            {
                
                driver = new ChromeDriver(@"C:\Users\Acer\Desktop\Dll");
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
                //driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Window.Maximize();
                testLogPass("Chrome Browser launchaed");
                driver.Navigate().GoToUrl(URL);
                testLogPass("Open Browser " + URL);
            }
            catch (Exception e)
            {
                testLogFail(" Unable to add the testcasename and description in test report " + e.ToString());
            }
        }

        public static void verifyElement(String objLocator)
        {
            waitForElementToDisplay(objLocator, elementLoadWaitTime);

            try
            {
                testLogInfo("Element '" + locatorDescription + "' is present as expected");
                testLogPass("Verify Element : '" + locatorDescription + "' is present as expected");
            }

            catch (Exception e)
            {
                testLogFail("Verify Element : " + locatorDescription + "' is not present as expected"+"\n"+ "Exception Error '" + e.ToString() + "'");
            }
        }

        public static void verifyElementText(String objectLocator, String expectedText)
        {

            waitForElementToDisplay(objectLocator, elementLoadWaitTime);
            try
            {
                if (webElement.Text.Trim().Contains((expectedText.Trim())))
                {
                    testLogPass("verify if the " + locatorDescription + " element contains text '" + expectedText);
                }
                else
                {
                    testLogFail("verify if the " + locatorDescription + " element contains text '" + expectedText);
                }
            }
            catch (Exception e)
            {
                testLogFail(("Exception Error '" + e.ToString() + "'"));
            }
        }

        public static void typeIn(String objectLocator, String inputValue)
        {
            waitForElementToDisplay(objectLocator, elementLoadWaitTime);

            {
                try
                {
                    webElement.Click();
                    webElement.Clear();
                    webElement.SendKeys(inputValue);
                    testLogInfo("Typing '" + inputValue + "' in : " + locatorDescription);
                    testLogPass("Type '" + inputValue + "' in : " + locatorDescription);
                }
                catch (InvalidSelectorException e)
                {
                    waitTime(1L);
                }
                catch (StaleElementReferenceException e)
                {
                    waitTime(1L);
                }
                catch (ElementNotVisibleException e)
                {
                    waitTime(1L);
                }
                catch (UnhandledAlertException e)
                {
                    waitTime(1L);
                }
                catch (WebDriverException e)
                {
                    waitTime(1L);
                }
                catch (Exception e)
                {
                    testLogFail("Exception Error '" + e.ToString() + "'");
                }
            }
        }
        public static void verifyPageTitle(String partialTitle)
        {
            for (int i = 1; i <= elementLoadWaitTime; i++)
            {
                try
                {
                    if (driver.Title.Contains(partialTitle))
                    {
                        Logger.WriteLog("Info - "+ "'" + partialTitle + "' is present in the page title : " + driver.Title);
                        test.Log(LogStatus.Info, "'" + partialTitle + "' is present in the page title : " + driver.Title);
                        test.Log(LogStatus.Pass, "Verify if the page title contains text '" + partialTitle + "'");
                        break;
                    }
                    else
                    {
                        Logger.WriteLog("Error - " + "'" + partialTitle + "' is not present in the page title : " + driver.Title);
                        testLogFail("Verify if the page title contains text '" + partialTitle + "'");
                    }

                }
                catch (InvalidSelectorException e)
                {
                    waitTime(1L);
                }
                catch (StaleElementReferenceException e)
                {
                    waitTime(1L);
                }
                catch (ElementNotVisibleException e)
                {
                    waitTime(1L);
                }
                catch (UnhandledAlertException e)
                {
                    waitTime(1L);
                }
                catch (WebDriverException e)
                {
                    waitTime(1L);
                }
                catch (Exception e)
                {
                    testLogFail("Exception Error '" + e.ToString() + "'");
                }

                if (i == elementLoadWaitTime)
                {
                    testLogFail(locatorDescription + " element found but its not in editable/clickable state within " + elementLoadWaitTime + " timeouts");
                }
            }
        }
        public static void navigateTo(String URL)
        {
            try
            {
                testLogInfo( "Navigating to URL : "+URL);
                driver.Navigate().GoToUrl(URL);
                testLogPass( "Navigating Successful : " + URL);
            }
            catch (Exception e)
            {
                testLogFail("Browser: Open Failure/Navigation cancelled, please check the application window."+ "Exception :\n" + e.ToString());
             
            }
        }

        public static void clickOn(String objLocator)
        {
            waitForElementToDisplay(objLocator, elementLoadWaitTime);
            try
            {
                webElement.Click();
                testLogInfo("Successfuly clicked on " + locatorDescription);
                testLogPass("Click on :" + locatorDescription);
            }
            catch (Exception e)
            {
                testLogFail("Error - " + " Unable to click the element \n"+"Exception :\n" + e.ToString());
            }
        }

        public static void findWebElement(String objectLocator)
        {
            Common.parseidentifyByAndlocator(objectLocator);
            identifyBy(idType);
        }

        public static void identifyBy(Common.identifierType t)
        {
            switch (t)
            {
                case Common.identifierType.classname:
                    webElement = driver.FindElement(By.ClassName(locator));
                    break;
                case Common.identifierType.id:
                    webElement = driver.FindElement(By.Id(locator));
                    break;
                case Common.identifierType.cssselector:
                    webElement = driver.FindElement(By.CssSelector(locator));
                    break;
                case Common.identifierType.lnktext:
                    webElement = driver.FindElement(By.LinkText(locator));
                    break;
                case Common.identifierType.name:
                    webElement = driver.FindElement(By.Name(locator));
                    break;
                case Common.identifierType.partiallinktext:
                    webElement = driver.FindElement(By.PartialLinkText(locator));
                    break;
                case Common.identifierType.tagname:
                    webElement = driver.FindElement(By.TagName(locator));
                    break;
                case Common.identifierType.xpath:
                    webElement = driver.FindElement(By.XPath(locator));
                    break;
                default:
                    break;
            }
        }

        public static void waitTime(long waittime)
        {
            //writeToLogFile("INFO", "Waiting for " + waittime + " seconds...");
            try
            {
                
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                //writeToLogFile("ERROR", "Thread.sleep operation failed, during waitTime function call");
            }
        }
        public static void waitForElement(String objectName, int timeout)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0L));

                for (int i = 1; i <= timeout; i++)
                {
                    try

                    {
                        findWebElement(objectName);
                    }
                    catch (InvalidSelectorException e)
                    {
                        waitTime(1L);
                    }
                    catch (StaleElementReferenceException e)
                    {
                        waitTime(1L);
                    }
                    catch (NoSuchElementException e)
                    {
                        waitTime(1L);
                    }
                    catch (ElementNotVisibleException e)
                    {
                        waitTime(1L);
                    }
                   
                    catch (WebDriverException e)
                    {
                        waitTime(1L);
                    }

                    if (i == timeout)
                    {
                        //testStepFailed(locatorDescription + " element not found in '" + timeout + "' seconds timeout ");
                    }
                }
            }
            catch (Exception e)
            {
               // testStepFailed("Exception error '" + e.toString() + "'");
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(implicitlyWaitTime));
            }
        }

        public static void waitForElementToDisplay(String objLocator, int timeout)
        {
            bool webElementStatus = false;
            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0L));

                for (int i = 1; i <= timeout; i++)
                {
                    try
                    {
                        if (!webElementStatus)
                        {
                            findWebElement(objLocator);
                            webElementStatus = true;
                        }
                        if (webElement.Displayed)
                        {
                            break;
                        }

                        waitTime(1L);
                    }
                    catch (InvalidSelectorException e)
                    {
                        waitTime(1L);
                    }
                    catch (StaleElementReferenceException e)
                    {
                        waitTime(1L);
                    }
                    catch (NoSuchElementException e)
                    {
                        waitTime(1L);
                    }
                    catch (ElementNotVisibleException e)
                    {
                        waitTime(1L);
                    }
                    catch (WebDriverException e)
                    {
                        waitTime(1L);
                    }

                    if (i == timeout)
                    {
                        if (webElementStatus)
                        {
                            testLogFail(locatorDescription + " element is present but its not in clickable/editable state within '" + timeout + "' timeout");
                        }
                        else
                        {
                            testLogFail(locatorDescription + " element not found in '" + timeout + "' seconds timeout ");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                testLogFail("Exception error '" + e.ToString() + "'");
            }
            finally
            {
                webElementStatus = false;

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(80));
            }
        }

        public static void Takescreenshot()
        {
           
            Screenshot ss;
            ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(screenshot, ScreenshotImageFormat.Jpeg);
        }

    }
}
