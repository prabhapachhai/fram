using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWebDriverNUnitTestProject
{
    class AlertExample
    {
        //Class member declaration
        IWebDriver driver;

        //This method will get executed before each test method
        [SetUp]
        public void BeforeTest()
        {
            //Initializing drive with ChromeDriver object
            driver = new ChromeDriver(@"E:\Drivers\chromedriver_win32");
            //Maximizing Automation launched browser
            driver.Manage().Window.Maximize();
            //Navigate to URL
            driver.Url = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
        }

        //Test method
        [Test]
        public void AlertTest()
        {
            //Finding WebElement on above browsed URL
            IWebElement clickMeButtonForAlert = driver.FindElement(By.XPath("//*[@class='btn btn-default']"));

            //Below code will through InvalidSelectorException : Compunded class name not allowed
            //As there are multiple class names
            //IWebElement clickMeButtonForAlert = driver.FindElement(By.ClassName("btn btn-default"));
            //To overcome this we need to use Css selector and remove whitespace by .(dot) and add .(dot) at start
            //IWebElement clickMeButtonForAlert = driver.FindElement(By.CssSelector(".btn.btn-default"));

            //Adding wait for just visible apperance, In practical we don't use it
            Thread.Sleep(2000);
            //On click of button, an Javascript Alert is shown 
            clickMeButtonForAlert.Click();
            //Adding wait for just visible apperance, In practical we don't use it
            Thread.Sleep(2000);

            //When an Alert is present, selenium is not able to access any of WebElement
            //If we try to do then UnhandledAlertException is thrown
            //clickMeButtonForAlert.Click();

            //Text property is used to get Text from Alert
            string alertText = driver.SwitchTo().Alert().Text;
            Assert.AreEqual("I am an alert box!", alertText);

            //Accept method will click on Ok button
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void ConfirmTest()
        {
            //Finding WebElement on above browsed URL
            IWebElement confirmButton = driver.FindElement(By.XPath("//*[@class='btn btn-default btn-lg' and text()='Click me!']"));
            //On click of button, an Javascript Confirm is shown 
            confirmButton.Click();

            //Adding wait for just visible apperance, In practical we don't use it
            Thread.Sleep(2000);

            //Text property is used to get Text from Alert
            string actualAlertText = driver.SwitchTo().Alert().Text;
            Assert.AreEqual("Press a button!", actualAlertText);

            //Dismiss method is used to click on Cancel button of Javascript Confirm
            driver.SwitchTo().Alert().Dismiss();

            //Adding wait for just visible apperance, In practical we don't use it
            Thread.Sleep(5000);
            Assert.AreEqual("You pressed Cancel!", driver.FindElement(By.Id("confirm-demo")).Text);

            //On click of button, an Javascript Confirm is shown 
            confirmButton.Click();

            //Adding wait for just visible apperance, In practical we don't use it
            Thread.Sleep(2000);

            //Text property is used to get Text from Alert
            actualAlertText = driver.SwitchTo().Alert().Text;
            Assert.AreEqual("Press a button!", actualAlertText);

            //Accept method will click on Ok button
            driver.SwitchTo().Alert().Accept();

            //Adding wait for just visible apperance, In practical we don't use it
            Thread.Sleep(5000);
            Assert.AreEqual("You pressed OK!", driver.FindElement(By.Id("confirm-demo")).Text);
        }

        [Test]
        public void PromptTest()
        {
            //Adding wait for just visible apperance, In practical we don't use it
            Thread.Sleep(2000);
            IWebElement promptButton = driver.FindElement(By.XPath("//*[@class='btn btn-default btn-lg' and text()='Click for Prompt Box']"));
            promptButton.Click();

            //Adding wait for just visible apperance, In practical we don't use it
            Thread.Sleep(2000);
            string promptMessage = driver.SwitchTo().Alert().Text;
            Assert.AreEqual("Please enter your name", promptMessage);

            //SendKeys method is used to enter text in Prompt text box
            driver.SwitchTo().Alert().SendKeys("Vaibhav");

            //Adding wait for just visible apperance, In practical we don't use it
            Thread.Sleep(2000);
            //Accept method will click on Ok button
            driver.SwitchTo().Alert().Accept();

            //Adding wait for just visible apperance, In practical we don't use it
            Thread.Sleep(5000);

            //Text property is used to get Text from Alert
            string actualPromptMessage = driver.FindElement(By.Id("prompt-demo")).Text;
            Assert.AreEqual("You have entered 'Vaibhav' !", actualPromptMessage);
        }

        //This method will get executed after each test method
        [TearDown]
        public void AfterTest()
        {
            driver.Close();
        }
    }
}
