using DemoQA.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesUsingPOM._1._Google_Search
{
    public class GoogleSearchPage : BasePage
    {

        //Here we have all the elements on Google search page
        public GoogleSearchPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement googleSearchField => Wait.Until(d => d.FindElement(By.Name("q")));

        public IWebElement seleniumFirstResultLink => Wait.Until(d => d.FindElement(By.CssSelector("#rso > div:nth-child(1) > div.rc > div.r > a > h3")));

        public IWebElement seleniumHeadline => Wait.Until(d => d.FindElement(By.CssSelector("body > section.hero.homepage > h1:nth-child(1)")));

        

    }
}
