using DemoQA.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesUsingPOM._5._Interaction_tests
{
    public class InteractionsPage : BasePage
    {
        public InteractionsPage(IWebDriver driver) : base(driver)
        {

        }
        //navigation

        public IWebElement interactionsSectionButton => Wait.Until(d => d.FindElement(By.CssSelector("#app > div > div > div.home-body > div > div:nth-child(5) > div > div.avatar.mx-auto.white > svg")));

        public IWebElement sortableSection => Wait.Until(d => d.FindElement(By.CssSelector("#item-0 > span")));

        public IWebElement selectableSection => Wait.Until(d => d.FindElement(By.CssSelector("#item-1 > span")));

        public IWebElement resizableSection => Wait.Until(d => d.FindElement(By.CssSelector("#item-2 > span")));

        public IWebElement droppableSection => Wait.Until(d => d.FindElement(By.CssSelector("#item-3 > span")));



        // draggable elements 
        public IWebElement draggableBox => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div")));

        // droppable elements

      
        public IWebElement droppableSourceBox => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[1]")));

        public IWebElement droppableDestinationBox => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[2]")));

        public IWebElement messageAfter => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[2]/p")));

        // resizable elements

        public IWebElement resizableBox => Wait.Until(d => d.FindElement(By.Id("resizableBoxWithRestriction")));

        public IWebElement resizableHandle => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[1]/div/span")));

        // selectable elements

        public IWebElement firstSelectableItem => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[1]")));

        public IWebElement selectableItem => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[3]")));

        // sortable elements 

        public IWebElement firstSortableItem => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[1]")));

        public IWebElement thirdItemDestination => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[3]")));

        public IWebElement newFirstElement => Wait.Until(d => d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[1]")));

    }
}
