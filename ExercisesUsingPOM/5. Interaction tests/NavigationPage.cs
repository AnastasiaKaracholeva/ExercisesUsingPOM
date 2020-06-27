using DemoQA.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesUsingPOM._5._Interaction_tests
{
    public class NavigationPage : BasePage
    {
        public NavigationPage(IWebDriver driver) : base(driver)
        {

        }
        //navigation

        public IWebElement interactionsSectionButton => Wait.Until(d => d.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(5) > div > div.avatar.mx-auto.white > svg")));

        public IWebElement interactionsSection => Wait.Until(d => d.FindElement(By.CssSelector("#app > div > div > div.row > div:nth-child(1) > div > div > div:nth-child(6) > span > div")));

        public IWebElement sortableSection => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[1]")));

        public IWebElement selectableSection => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[2]")));

        public IWebElement resizableSection => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[3]")));

        public IWebElement droppableSection => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[4]")));

        public IWebElement dragabbleSection => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[5]")));
    }
}
