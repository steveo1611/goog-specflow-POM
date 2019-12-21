using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace goog_specflow_POM.Pages
{
    class InboxPage
    {
        private readonly IWebDriver driver;
        readonly By composeButton = By.XPath("//*[contains(text(),'Compose')]");
        readonly By accountName = By.XPath("//a[contains(@aria-label, 'Google Account:')]");
        readonly By inboxMailTopRow = By.XPath("//*[@role='main']/div[6]/div/div/div[2]/div/table/tbody/tr[1]");
        readonly By inboxMailTopSubject = By.XPath("//*[@role='main']/div[6]/div/div/div[2]/div/table/tbody/tr[1]/td/div/div/div/span/span");
        readonly By emailTextBody = By.XPath("//*[@style='display:']/div[2]/div[3]/div[3]/div/div");
        readonly By emailBackToInbox = By.XPath("//*[@title='Back to Inbox']");
        readonly By logOut = By.XPath("//*[text()='Sign out']");

        public InboxPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void SelectComposeButton(IWebDriver driver)
        {
            driver.FindElement(composeButton).Click();
        }
        public bool VerifyLoggedIn(IWebDriver driver)
        {
            try
            {
                var element = driver.FindElement(accountName);
                return element.Displayed;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public string OpenTopEmail(IWebDriver driver) 
        {
            driver.FindElement(inboxMailTopRow).Click();
            var element = driver.FindElement(emailTextBody);
            return element.Text;
        }

        public string VerifySentEmailInInbox(IWebDriver driver)
        {
          var element = driver.FindElement(inboxMailTopSubject);
            return element.Text;

        }
        public void ReturnToInbox(IWebDriver driver)
        {
            Console.WriteLine(emailBackToInbox);
          driver.FindElement(emailBackToInbox).Click();
        }
        public void LogOut(IWebDriver driver)
        {
            driver.FindElement(accountName).Click();
            driver.FindElement(logOut).Click();
        }
    }
}
