using BoDi;
using goog_specflow_POM.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace goog_specflow_POM
{
    [Binding]

    public class Hooks
    {
        static IWebDriver driver = null;
        private static readonly string ProjectFilesPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().
            Location) + "\\..\\..";
        private readonly ScenarioContext context;
        private readonly FeatureContext featureContext;
        private static TestContext _testContextInstance;

        public Hooks(ScenarioContext injectedContext, FeatureContext _featureContext, TestContext testContextInstance)
        {
            context = injectedContext;
            featureContext = _featureContext;
            _testContextInstance = testContextInstance;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverFactory.InitBrowser("Chrome");
            driver = DriverFactory.Driver;
            context.Add("webdriver", driver);
            featureContext.Add("Environment", "gmail");
        }

    }
}
