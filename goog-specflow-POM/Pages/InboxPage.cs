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
        readonly By inboxMailTopRow = By.XPath("//*[@role='main']/div[6]/div/div/div[2]/div/table/tbody/tr");
        readonly By inboxMailTopSubject = By.XPath("//*[@role='main']/div[6]/div/div/div[2]/div/table/tbody/tr/td/div/div/div/span/span");
        // + [text()='<<what is in subject line>>']
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
        public void OpenTopEmail(IWebDriver driver) 
        {
            driver.FindElement(inboxMailTopRow).Click();
        }

        // - view inbound emails
        
        // - Sign out button


    }
}
