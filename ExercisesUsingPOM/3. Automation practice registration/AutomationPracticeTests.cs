using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using Tests;

namespace ExercisesUsingPOM._3._Automation_practice_registration
{

    [TestFixture]
    public class AutomationPracticeTests : BaseTest
    {
        private AutomationPracticePage automationPracticePage;


        [SetUp]
        public void SetUp()
        {
            Initialize();
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Driver.Manage().Window.Maximize();
            automationPracticePage = new AutomationPracticePage(Driver);
        }

        [Test]

        public void VerifyEmailIsFilled()
        {
            automationPracticePage.signInButton.Click();
            automationPracticePage.emailField.SendKeys("test4375238@mailinator.com");
            automationPracticePage.createAccountButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            var expectedEmail = "test4375238@mailinator.com";
            var actualEmail = automationPracticePage.emailAlreadyFilled.GetAttribute("value");


            Assert.AreEqual(expectedEmail, actualEmail);



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
