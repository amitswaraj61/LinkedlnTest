
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using LinkedinApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinApp.LoginTestCase.TestCase
{
    [TestFixture]
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
            String hostname = Dns.GetHostName();
            OperatingSystem os = Environment.OSVersion;
            extent.AddSystemInfo("operating system", hostname);
            extent.AddSystemInfo("Host name", hostname);
            extent.AddSystemInfo("Browser", "Google Chrome");


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

        [Test]
        public void AddPost()
        {
            test = extent.CreateTest("Create new Post").Info("Test Started");
            LoginPageObject login = new LoginPageObject(driver);
            test.Log(Status.Info, "Chrome Browser Launched");
            login.LoginToLinkedin(credentails.email, credentails.password);
            test.Log(Status.Info, "Valid email and password is entered");
            Article article = new Article(driver);
            article.CreatePost();
            test.Log(Status.Info, "Article is posted in Linkedin");
            String actualResult = driver.Url;
            String expected = "https://www.linkedin.com/home";
            Assert.AreEqual(expected, actualResult);
            test.Log(Status.Pass, "Post is uploaded , Test passed");




        }
    }
}
