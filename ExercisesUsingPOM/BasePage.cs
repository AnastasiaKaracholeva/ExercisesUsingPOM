using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace DemoQA.Pages
{
    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
        }
        protected IWebDriver Driver { get; set; }

        protected Actions Builder { get; set; }

        protected WebDriverWait Wait { get; set; }

        protected SelectElement Select { get; set; }

        protected IJavaScriptExecutor JS { get; set; }

        public void Initialize()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Builder = new Actions(Driver);
            JS = (IJavaScriptExecutor)Driver;
            Driver.Manage().Window.Maximize();
        }

    }


}
