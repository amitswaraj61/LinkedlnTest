using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using static LinkedinApp.LinkedinBase;

using SeleniumExtras.PageObjects;
using System.Threading;

namespace LinkedinApp.Pages

{
    class LoginPageObject
    {
       public IWebDriver driver;


        public LoginPageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

       

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'username')]")] 


        public IWebElement Email;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'password')]")]


        public IWebElement Pass;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn__primary--large from__button--floating']")]


        public IWebElement LoginButton;



        public void LoginToLinkedin(String email,String Password)
        {
            
            Email.SendKeys(email);
            Thread.Sleep(1000);
            Pass.SendKeys(Password);
            Thread.Sleep(1000);
            LoginButton.Click();
            Thread.Sleep(1000);
        }
    }
}
//

