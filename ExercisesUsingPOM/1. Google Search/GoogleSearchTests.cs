using DemoQA.Pages;
using Tests;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesUsingPOM._1._Google_Search
{

    [TestFixture]
    public class GoogleSearchTests : BaseTest
    {
        private GoogleSearchPage googleSearchPage;


        [SetUp]
        public void SetUp()
        {
            Initialize();
            Driver.Navigate().GoToUrl("http://www.google.com");
            Driver.Manage().Window.Maximize();
            googleSearchPage = new GoogleSearchPage(Driver);
        }


        [Test]
        public void VerifyCorrectHeadline()
        {
            googleSearchPage.googleSearchField.SendKeys("Selenium" + Keys.Return);
            googleSearchPage.seleniumFirstResultLink.Click();
            var actualHeadline = googleSearchPage.seleniumHeadline.Text;
            var expectedHeadline = "Selenium automates browsers. That's it!";

            Assert.AreEqual(expectedHeadline, actualHeadline);



        }
        [TearDown]
        public void TearDown()

        {
            

            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(@"D:\Screenshots", ScreenshotImageFormat.Png);
            }

            Driver.Quit();


        }

    }
        
    }
    







