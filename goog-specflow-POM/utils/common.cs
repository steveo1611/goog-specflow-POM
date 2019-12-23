using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace goog_specflow_POM.utils
{
    class common
    {
        IWebElement element;
   
        public void WaitForElementToBeClickable<T>(IWebDriver driver, T locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            if (locator.GetType() == typeof(By))
            {
                By newLocator = (By)(object)locator;
                wait.Until(c => c.FindElement(newLocator).Enabled && c.FindElement(newLocator).Displayed);
            }
            else if (locator.GetType() == typeof(IWebElement))
            {
                IWebElement newLocator = (IWebElement)(object)locator;
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(newLocator));
            }
        }
        public void WaitForPageUrl(IWebDriver driver, string expectedUrl)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlMatches(expectedUrl));
        }
        public string GetPageUrl(IWebDriver driver)
        {
            return driver.Url;
        }
       
    }
}
