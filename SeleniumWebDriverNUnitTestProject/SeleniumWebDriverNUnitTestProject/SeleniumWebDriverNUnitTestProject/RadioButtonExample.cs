using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriverNUnitTestProject
{
    class RadioButtonExample
    {
        [Test]
        public void RadioButtonTest()
        {
            IWebDriver driver = new ChromeDriver(@"C:\driver\chromedriver_win32 (1)");
            driver.Url = "https://demoqa.com/radio-button";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement radioButtonLabel = driver.FindElement(By.XPath("//label[@for='yesRadio']"));
            IWebElement radioButton = driver.FindElement(By.Id("yesRadio"));
            bool radioButtonState = radioButton.Selected;
            Assert.IsFalse(radioButtonState);

            radioButtonLabel.Click();

            radioButtonState = radioButton.Selected;
            Assert.IsTrue(radioButtonState);
        }
        [Test]
        public void RadioButtonTest1()
        {
            IWebDriver driver = new ChromeDriver(@"C:\driver\chromedriver_win32 (1)");
            driver.Url = "https://demoqa.com/radio-button";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement radioButtonLabel2 = driver.FindElement(By.XPath("//label[@for='impressiveRadio']"));
            IWebElement radioButton2 = driver.FindElement(By.Id("impressiveRadio"));
            bool radioButtonState = radioButton2.Selected;
            Assert.IsFalse(radioButtonState);

            radioButtonLabel2.Click();

           radioButtonState = radioButtonLabel2.Selected;
            Assert.IsTrue(radioButtonState);
            
        }
        [Test]
        public void RadioButtonTest2()
        {

            IWebDriver driver = new ChromeDriver(@"C:\driver\chromedriver_win32 (1)");
            driver.Url = "https://demoqa.com/radio-button";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
    }
}
