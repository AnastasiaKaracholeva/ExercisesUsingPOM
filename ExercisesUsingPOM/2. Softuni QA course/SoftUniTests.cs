using DemoQA.Pages;
using Tests;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace ExercisesUsingPOM._2._Softuni_QA_course
{

    [TestFixture]
   public class SoftUniTests : BaseTest
    {
        private SoftUniPage softUnitests;

       
        

        [SetUp]
        public void SetUp()
        {
            Initialize();
            Driver.Navigate().GoToUrl("https://softuni.bg/");
            Driver.Manage().Window.Maximize();
            softUnitests = new SoftUniPage(Driver);

        }
        [Test]
        public void VerifySoftUniQACourseHeadline()
        {


            softUnitests.searchIcon.Click();
            softUnitests.searchField.SendKeys("QA automation" + Keys.Return);
            softUnitests.courseMay.Click();

            // This opens a new tab. We need to switch the focus! 

            var tabs = Driver.WindowHandles;
            if (tabs.Count > 1)
            {
                Driver.SwitchTo().Window(tabs[0]);
                
                Driver.SwitchTo().Window(tabs[1]);


            }
           
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            var actualCourseHeadline = softUnitests.qaHeadline.Text;
            var expectedCourseHeadline = "QA Automation - май 2020";


            Assert.AreEqual(expectedCourseHeadline, actualCourseHeadline);



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
