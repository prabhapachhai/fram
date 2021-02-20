using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWebDriverNUnitTestProject
{
    class IFrameHandlingExample
    {
        IWebDriver driver; 

        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver(@"E:\Drivers\chromedriver_win32");
            //To wait for the element, if it is dynamically loading
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //To wait for the website to load completely
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

            //Navigate to URL
            driver.Url = "http://demo.automationtesting.in/Frames.html";
        }

        [Test]
        public void IFrameTest()
        {
            //Switches to IFrame
            //Moves the control from parent html to nested html(iframe)
            driver.SwitchTo().Frame("singleframe");

            //Finding the element in the nested html(iframe)
            IWebElement singleIFrameInputTextBox = driver.FindElement(By.XPath("//input[@type='text']"));
            //Seting Text on input box
            singleIFrameInputTextBox.SendKeys("Vaibhav");
            Thread.Sleep(5000);

            //Switches to parent html
            driver.SwitchTo().DefaultContent();

            //Finding the button on the parent html
            IWebElement iframeWithInAnIframeButton = driver.FindElement(By.XPath("//*[@class='analystic' and @href='#Multiple']"));
            //Click operation
            iframeWithInAnIframeButton.Click();

            //Finding the iframe as as WebElement(because iframe was not having id or name as attribute)
            IWebElement parentOfMultipleIFrame = driver.FindElement(By.XPath("//iframe[@src='MultipleFrames.html']"));
            //Switching to IFrame by passing iframe as a WebElement
            driver.SwitchTo().Frame(parentOfMultipleIFrame);

            //In the IFrame, we need to switch to inner Iframe(as it is having multiple iframe)
            IWebElement innerIFrame = driver.FindElement(By.XPath("//iframe[@src='SingleFrame.html']"));
            driver.SwitchTo().Frame(innerIFrame);

            //In the innerIFrame finding a textbox
            IWebElement innerIFrameTextBox = driver.FindElement(By.XPath("//input[@type='text']"));
            //Seting text on input box
            innerIFrameTextBox.SendKeys("Learning Selenium");
            Thread.Sleep(5000);

            //Switching back to parent frame
            //It will get switch to parentOfMultipleIFrame
            driver.SwitchTo().ParentFrame();

            //Switching back to parent HTML
            driver.SwitchTo().ParentFrame();
            
            //If DefaultContent is used then we need not to call ParentFrame twice
            //driver.SwitchTo().DefaultContent();

            //Finding the single Iframe button
            IWebElement singleIFrameButton = driver.FindElement(By.XPath("//a[@class='analystic' and @href='#Single']"));
            //performing the click operation
            singleIFrameButton.Click();

            //Swithcing to iframe
            //As this iframe is having id, we are passing it to switch
            driver.SwitchTo().Frame("singleframe");

            //Previous text set at line number 34, we are clearing it
            singleIFrameInputTextBox.Clear();
            //Seting new text
            singleIFrameInputTextBox.SendKeys("Learning C# as well");
            Thread.Sleep(2000);
            driver.Close();
        }
    }
}
