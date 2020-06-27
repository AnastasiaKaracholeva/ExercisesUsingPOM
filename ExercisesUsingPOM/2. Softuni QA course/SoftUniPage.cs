using DemoQA.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExercisesUsingPOM._2._Softuni_QA_course
{

   public class SoftUniPage : BasePage
    {
        //Here we have all elements needed from the Softuni page
        public SoftUniPage(IWebDriver driver) : base(driver) { }


        public IWebElement searchIcon => Wait.Until(d => d.FindElement(By.CssSelector("#search-icon-container > a > span > i")));

        public IWebElement searchField => Wait.Until(d => d.FindElement(By.Id("search-input")));

        public IWebElement courseMay => Wait.Until(d => d.FindElement(By.CssSelector("#fast-track-instance-results > ul > li:nth-child(1) > div > a > span.training-name.truncate-height")));

        public IWebElement qaHeadline => Wait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/header/h1")));
    }
    }
    


  
    

       




