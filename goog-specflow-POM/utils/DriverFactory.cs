using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;

namespace goog_specflow_POM.utils
{
    class DriverFactory
    {
        private static IWebDriver driver;
        private static readonly string ProjectFilesPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\..\\..\\..";

        public static IWebDriver Driver
        {
            get
            {
                return driver;
            }
            private set
            {
                driver = value;
            }
        }
        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (Driver == null)
                    {
                        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Program Files (x86)\Mozilla Firefox");
                        service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                        driver = new FirefoxDriver(service);
                        driver.Manage().Window.Maximize();
                    }
                    break;

                case "Edge":
                    if (Driver == null)
                    {
                        //driver = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");
                        EdgeDriverService service = EdgeDriverService.CreateDefaultService(@"C:\Users\deyt\Downloads");
                        //service1.e = @"C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe";
                        driver = new EdgeDriver(service);
                        driver.Manage().Window.Maximize();
                    }
                    break;

                case "Chrome":

                     if (Driver == null)
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("chrome.switches", "--disable-extensions");
                        options.AddArguments("--start-maximized");
                        options.AddArguments("--incognito");

                        driver = new ChromeDriver(Path.Combine(ProjectFilesPath + "\\Drivers\\Chrome"), options);
                        driver.Manage().Window.Maximize();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    }
                    break;
            }
        }
/*        public static void LoadApplication(string url)
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().GoToUrl(url);
        }
*/
        public static void CloseDriver()
        {
            Console.WriteLine("Closing driver...");
            driver.Quit();
            Driver = null;
        }
    }
}
