
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using LinkedinApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinApp.LoginTestCase.TestCase
{
  
    class LoginTest :LinkedinBase
    {

        Credentails credentails = new Credentails();
        public ExtentReports extent = null;
        public ExtentTest test = null;

        [OneTimeSetUp]
        public void ExtentReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Kis\source\repos\LinkedinApp\LinkedinApp\Report\Report.html");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        [Test]
        public void ValidLogin()
        {
            test=extent.CreateTest("ValidLogin").Info("Test Started");
            LoginPageObject login = new LoginPageObject(driver);
            test.Log(Status.Info,"Chrome Browser Launched");
            login.LoginToLinkedin(credentails.email, credentails.password);
            test.Log(Status.Info,"Valid email and password is entered");
            String actualResult = driver.Url;
            test.Log(Status.Info,"get the URl of Linkedin");
            String expectedResult = "https://www.linkedin.com/feed/";
            Assert.AreEqual(expectedResult, actualResult);
            test.Log(Status.Pass,"Test valid Login passed");
        }
    }
}
