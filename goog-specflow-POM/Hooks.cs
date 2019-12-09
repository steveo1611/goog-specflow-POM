using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

//namespace goog_specflow_POM
//{
//    [Binding]

//    public sealed class Hooks
//    {
//        private readonly IObjectContainer objectContainer;
//        public Hooks(IObjectContainer objectContainer)
//        {
//            this.objectContainer = objectContainer;
//        }

//        static IWebDriver driver = null;
//       // private static readonly string ProjectFilesPath = ConfigurationManager.AppSettings["ProjectFilesPath"].ToString();
//        [BeforeScenario (Order = 1)]
//        public void BeforeScenario()
//        {
//            ChromeOptions options = new ChromeOptions();
//            options.AddArguments(@"d:\\projects\\selenium\\", "--incognito");
//            // driver = new ChromeDriver(Path.Combine(ProjectFilesPath + "/Drivers/Chrome"), options);
//            driver = new ChromeDriver("d:\\projects\\selenium\\", options);
//         //   FeatureContext.Current.Add("webdriver", driver);  //says it's obsolete ???
//            driver.Manage().Window.Maximize();
//            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
//        }

//    }
//}
