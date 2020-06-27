using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Interactions;
using DemoQA.Pages;

namespace ExercisesUsingPOM._5._Interaction_tests
{
    [TestFixture]
    public class InteractionsTests : BaseTest
    {
        private InteractionsPage interactionsPage;

        private NavigationPage navigationPage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            Driver.Navigate().GoToUrl("http://demoqa.com/");
            Driver.Manage().Window.Maximize();
            interactionsPage = new InteractionsPage(Driver);
            navigationPage = new NavigationPage(Driver);
            Builder = new Actions(Driver);
        }
        //draggable tests 
        [Test]
        public void DraggableItemIsMovedAndPositionXIsDifferent()
        {
            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.dragabbleSection.Click();

            var draggableBoxX = interactionsPage.draggableBox.Location.X;

            Builder.DragAndDropToOffset(interactionsPage.draggableBox, 200, 100).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var draggableBoxXpositionAfter = interactionsPage.draggableBox.Location.X;
            Assert.AreNotEqual(draggableBoxX, draggableBoxXpositionAfter);

        }

        [Test]
        public void DraggableItemIsMovedAndPositionYIsDifferent()
        {

            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.dragabbleSection.Click();

            var draggableBoxX = interactionsPage.draggableBox.Location.Y;

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Builder.DragAndDropToOffset(interactionsPage.draggableBox, 200, 100).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var draggableBoxYpositionAfter = interactionsPage.draggableBox.Location.Y;
            Assert.AreNotEqual(draggableBoxX, draggableBoxYpositionAfter);


        }

        [Test]
        public void DraggableItemIsNotMoved()
        {
            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.dragabbleSection.Click();

            var draggableBoxX = interactionsPage.draggableBox.Location.Y;

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Builder.DragAndDropToOffset(interactionsPage.draggableBox, 0, 0).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            var draggableBoxYpositionAfter = interactionsPage.draggableBox.Location.Y;
            Assert.AreEqual(draggableBoxX, draggableBoxYpositionAfter);

        }

        //droppable tests
        [Test]
        public void DragAndDropCheckColor()
        {

            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.droppableSection.Click();

            var colourBefore = interactionsPage.droppableDestinationBox.GetCssValue("background-color");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.DragAndDrop(interactionsPage.droppableSourceBox, interactionsPage.droppableDestinationBox).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);



            var colorAfter = interactionsPage.droppableDestinationBox.GetCssValue("color");

            Assert.AreNotEqual(colourBefore, colorAfter);


        }
        [Test]
        public void DragAndDropCheckMessageAfterDrop()
        {

            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.droppableSection.Click();



            Builder.DragAndDrop(interactionsPage.droppableSourceBox, interactionsPage.droppableDestinationBox).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            var actualMessage = interactionsPage.messageAfter.Text;

            Assert.IsTrue(actualMessage.Contains("Dropped!"));



        }

        [Test]
        public void DragAndDropCheckMessageIsChanged()
        {

            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.droppableSection.Click();



            Builder.DragAndDrop(interactionsPage.droppableSourceBox, interactionsPage.droppableDestinationBox).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            var actualMessage = interactionsPage.messageAfter.Text;

            Assert.IsFalse(actualMessage.Contains("Drop here"));

        }

        // resizable tests

        [Test]
        public void MakeSureItemIsResizedByWidth()
        {
            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.resizableSection.Click();

            var boxSize = interactionsPage.resizableBox.GetCssValue("width");


            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            Builder.ClickAndHold(interactionsPage.resizableHandle);
            Builder.DragAndDropToOffset(interactionsPage.resizableHandle, 100, 50);
            Builder.Release().Perform();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            var boxSizeAfter = interactionsPage.resizableBox.GetCssValue("width");

            Assert.AreNotEqual(boxSize, boxSizeAfter);

        }

        [Test]
        public void MakeSureItemIsResizedByHeight()
        {
            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.resizableSection.Click();

            var boxSize = interactionsPage.resizableBox.GetCssValue("height");


            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            Builder.ClickAndHold(interactionsPage.resizableHandle);
            Builder.DragAndDropToOffset(interactionsPage.resizableHandle, 100, 150);
            Builder.Release().Perform();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            var boxSizeAfter = interactionsPage.resizableBox.GetCssValue("height");

            Assert.AreNotEqual(boxSize, boxSizeAfter);

        }
        // selectable tests

        [Test]
        public void CheckIfItemIsSelectable()
        {
            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.selectableSection.Click();

            var firstItemColor = interactionsPage.selectableItem.GetCssValue("background-color");
            interactionsPage.selectableItem.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);


            var firstItemColorAfter = interactionsPage.selectableItem.GetCssValue("color");


            Assert.AreNotEqual(firstItemColor, firstItemColorAfter);

        }
        // sortable tests

        [Test]
        public void CheckIfItemsCanBeSorted()
        {
            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.sortableSection.Click();

            var firstItemText = interactionsPage.firstSortableItem.Text;



            Builder.DragAndDrop(interactionsPage.firstSortableItem, interactionsPage.thirdItemDestination).Perform();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            var newFirstItemText = interactionsPage.newFirstElement.Text;


            Assert.AreNotEqual(firstItemText, newFirstItemText);

        }
        [Test]
        public void CheckIfItemsCanBeSortedProperly()
        {
            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.sortableSection.Click();

            Builder.DragAndDrop(interactionsPage.firstSortableItem, interactionsPage.thirdItemDestination).Perform();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            var newFirstItemText = interactionsPage.newFirstElement.Text;


            Assert.IsTrue(newFirstItemText.Contains("Two"));

        }

        [Test]
        public void CheckIfItemIsSameColorAfterBeingSelectedTwice()
        {
            navigationPage.interactionsSectionButton.Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Builder.MoveToElement(navigationPage.interactionsSection).Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            navigationPage.selectableSection.Click();

            var firstItemColor = interactionsPage.selectableItem.GetCssValue("color");

            Builder.DoubleClick(interactionsPage.selectableItem);


            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);


            var firstItemColorAfter = interactionsPage.selectableItem.GetCssValue("color");


            Assert.AreEqual(firstItemColor, firstItemColorAfter);

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
