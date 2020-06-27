using DemoQA.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesUsingPOM._4._Automation_practice_negative_tests
{
    public class AutoPracticePage : BasePage
    {
        public AutoPracticePage(IWebDriver driver) : base(driver)
        {
        }

       
        public IWebElement buttonSignIn => Wait.Until(d => d.FindElement(By.ClassName("login")));

        public IWebElement emailEmptyField => Wait.Until(d => d.FindElement(By.CssSelector("#email_create")));

        public IWebElement buttonCreate => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[1]/form/div/div[3]/button/span")));

        public IWebElement subheading => Wait.Until(d => d.FindElement(By.CssSelector("#account-creation_form > div:nth-child(1) > h3")));

        public IWebElement buttonRegister => Wait.Until(d => d.FindElement(By.Id("submitAccount")));

        public IWebElement errorBlock => Wait.Until(d => d.FindElement(By.CssSelector("#center_column > div")));


        //Form 
        public IWebElement firstNameField => Wait.Until(d => d.FindElement(By.CssSelector("#customer_firstname")));

        public IWebElement lastNameField => Wait.Until(d => d.FindElement(By.CssSelector("#customer_lastname")));

        public IWebElement emailInForm => Wait.Until(d => d.FindElement(By.Id("email")));

        public IWebElement passwordField => Wait.Until(d => d.FindElement(By.CssSelector("#passwd")));

        public IWebElement addressField => Wait.Until(d => d.FindElement(By.CssSelector("#address1")));

        public IWebElement cityField => Wait.Until(d => d.FindElement(By.CssSelector("#city")));

        public IWebElement stateField => Wait.Until(d => d.FindElement(By.CssSelector("#id_state")));

        public IWebElement postalCodeField => Wait.Until(d => d.FindElement(By.CssSelector("#postcode")));

        public IWebElement countryField => Wait.Until(d => d.FindElement(By.CssSelector("#id_country")));

        public IWebElement phoneField => Wait.Until(d => d.FindElement(By.CssSelector("#phone_mobile")));

        public IWebElement myAccountHeadline => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/h1")));
    }
    
}
