
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


        [Test]
        public void ValidLogin()
        {

           

            LoginPageObject login = new LoginPageObject(driver);
            login.LoginToLinkedin(credentails.email,credentails.password);
            String actualResult = driver.Title;
            String expectedResult = "LinkedIn";
            Assert.AreEqual(expectedResult,actualResult);
        }

    }
}
