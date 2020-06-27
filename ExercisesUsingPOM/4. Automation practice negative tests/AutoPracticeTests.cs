using AutoFixture;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests;

namespace ExercisesUsingPOM._4._Automation_practice_negative_tests
{
 [TestFixture]
    public class AutoPracticeTests : BaseTest
    {
        private AutoPracticePage autoPracticePage;
        private AutoPracticeModels autoPracticeModels;
        private AutoPracticeModels user;
        private Fixture fixture;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Driver.Manage().Window.Maximize();
            autoPracticePage = new AutoPracticePage(Driver);
            Builder = new Actions(Driver);

            user = AutoPracticeFormFactory.CreateUser();
            fixture = new Fixture();
        }

        [Test]
        public void VerifyErrorBlockIsPresentWhenAllTheFieldsAreEmpty()
        {

            autoPracticePage.buttonSignIn.Click();
            autoPracticePage.emailEmptyField.SendKeys("test1263@mailinator.com");
            autoPracticePage.buttonCreate.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);


            autoPracticePage.subheading.Click();
            Builder.MoveToElement(autoPracticePage.buttonRegister).Perform();
            autoPracticePage.buttonRegister.Click();
            

            Assert.IsTrue(autoPracticePage.errorBlock.Displayed);

        }
        [Test]
        public void CreateValidForm()
        {


            autoPracticePage.buttonSignIn.Click();
            autoPracticePage.emailEmptyField.SendKeys("test1324613@mailinator.com");
            autoPracticePage.buttonCreate.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);


                autoPracticePage.firstNameField.SendKeys(user.FirstName);
                autoPracticePage.lastNameField.SendKeys(user.LastName);
                autoPracticePage.passwordField.SendKeys(user.Password);
                autoPracticePage.addressField.SendKeys("825 Shelby Dry Frk, Shelbiana ");
                autoPracticePage.cityField.SendKeys(user.City);
                autoPracticePage.stateField.SendKeys("Georgia");
                autoPracticePage.postalCodeField.SendKeys("92009");
                autoPracticePage.phoneField.SendKeys(user.MobilePhone);

            autoPracticePage.buttonRegister.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            var expectedHeadline = "MY ACCOUNT";
            var actualHeadline = autoPracticePage.myAccountHeadline.Text;


            Assert.AreEqual(expectedHeadline, actualHeadline);

        }
        //Negative tests
        [Test]
        public void UserCanNotRegisterWithEmptyFirstName()
        {
            autoPracticePage.buttonSignIn.Click();
            autoPracticePage.emailEmptyField.SendKeys(user.Email);
            autoPracticePage.buttonCreate.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            autoPracticePage.lastNameField.SendKeys(user.LastName);
            autoPracticePage.passwordField.SendKeys(user.Password);
            autoPracticePage.addressField.SendKeys(user.Address);
            autoPracticePage.cityField.SendKeys(user.City);
            autoPracticePage.stateField.SendKeys(user.State);
            autoPracticePage.postalCodeField.SendKeys(user.PostalCode);
            autoPracticePage.phoneField.SendKeys(user.MobilePhone);

            autoPracticePage.buttonRegister.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            var errorMessage = autoPracticePage.errorBlock.Text;

            Assert.IsTrue(errorMessage.Contains("firstname"));

        }

        [Test]
        public void UserCanNotRegisterWithEmptyLastName()
        {
            autoPracticePage.buttonSignIn.Click();
            autoPracticePage.emailEmptyField.SendKeys(user.Email);
            autoPracticePage.buttonCreate.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            autoPracticePage.firstNameField.SendKeys(user.FirstName);
            autoPracticePage.passwordField.SendKeys(user.Password);
            autoPracticePage.addressField.SendKeys(user.Address);
            autoPracticePage.cityField.SendKeys(user.City);
            autoPracticePage.stateField.SendKeys(user.State);
            autoPracticePage.postalCodeField.SendKeys(user.PostalCode);
            autoPracticePage.phoneField.SendKeys(user.MobilePhone);

            autoPracticePage.buttonRegister.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            var errorMessage = autoPracticePage.errorBlock.Text;

            Assert.IsTrue(errorMessage.Contains("lastname"));
        }

        [Test]
        public void UserCanNotRegisterWhenPasswordIsUnderFiveCharacters()
        {
            autoPracticePage.buttonSignIn.Click();
            autoPracticePage.emailEmptyField.SendKeys(user.Email);
            autoPracticePage.buttonCreate.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            autoPracticePage.firstNameField.SendKeys(user.FirstName);
            autoPracticePage.lastNameField.SendKeys(user.LastName);
            autoPracticePage.passwordField.SendKeys("pass");
            autoPracticePage.addressField.SendKeys(user.Address);
            autoPracticePage.cityField.SendKeys(user.City);
            autoPracticePage.stateField.SendKeys(user.State);
            autoPracticePage.postalCodeField.SendKeys(user.PostalCode);
            autoPracticePage.phoneField.SendKeys(user.MobilePhone);

            autoPracticePage.buttonRegister.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            var errorMessage = autoPracticePage.errorBlock.Text;

            Assert.IsTrue(errorMessage.Contains("passwd is invalid"));
        }

        public void UserCanNotRegisterWhenCityIsEmpty()
        {
            autoPracticePage.buttonSignIn.Click();
            autoPracticePage.emailEmptyField.SendKeys(user.Email);
            autoPracticePage.buttonCreate.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            autoPracticePage.firstNameField.SendKeys(user.FirstName);
            autoPracticePage.lastNameField.SendKeys(user.LastName);
            autoPracticePage.passwordField.SendKeys(user.Password);
            autoPracticePage.addressField.SendKeys(user.Address);          
            autoPracticePage.stateField.SendKeys(user.State);
            autoPracticePage.postalCodeField.SendKeys(user.PostalCode);
            autoPracticePage.phoneField.SendKeys(user.MobilePhone);

            autoPracticePage.buttonRegister.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            var errorMessage = autoPracticePage.errorBlock.Text;

            Assert.IsTrue(errorMessage.Contains("city is required"));
        }
        [Test]
        public void UserCanNotRegisterWhenZIPCodeIsInvalid()
        {
            autoPracticePage.buttonSignIn.Click();
            autoPracticePage.emailEmptyField.SendKeys(user.Email);
            autoPracticePage.buttonCreate.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            autoPracticePage.firstNameField.SendKeys(user.FirstName);
            autoPracticePage.lastNameField.SendKeys(user.LastName);
            autoPracticePage.passwordField.SendKeys(user.Password);
            autoPracticePage.addressField.SendKeys(user.Address);
            autoPracticePage.cityField.SendKeys(user.City);
            autoPracticePage.stateField.SendKeys(user.State);
            autoPracticePage.postalCodeField.SendKeys("123");
            autoPracticePage.phoneField.SendKeys(user.MobilePhone);

            autoPracticePage.buttonRegister.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            var errorMessage = autoPracticePage.errorBlock.Text;

            Assert.IsTrue(errorMessage.Contains("The Zip/Postal code you've entered is invalid"));
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
