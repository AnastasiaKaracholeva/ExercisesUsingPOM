using DemoQA.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesUsingPOM._3._Automation_practice_registration
{
    public class AutomationPracticePage : BasePage
    {
        public AutomationPracticePage(IWebDriver driver) : base(driver)
        {

        }
        public IWebElement signInButton => Wait.Until(d => d.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a")));

        public IWebElement emailField => Wait.Until(d => d.FindElement(By.CssSelector("#email_create")));

        public IWebElement createAccountButton => Wait.Until(d => d.FindElement(By.CssSelector("#SubmitCreate > span")));

        public IWebElement emailAlreadyFilled => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[1]/div[4]/input")));


    }
}
