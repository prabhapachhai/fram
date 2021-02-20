using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace SeleniumWebDriverNUnitTestProject
{
    class PopupExample
    {
        IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            driver = new ChromeDriver(@"E:\Drivers\chromedriver_win32");
        }

        [Test]
        public void SimplePopupTest()
        {
            driver.Url = "http://w2ui.com/web/demo/popup";
            IWebElement showPopupButton = driver.FindElement(By.XPath("//input[@class='btn btn-info' and @value='Show Popup']"));
            showPopupButton.Click();

            bool isPopupDisplayed = driver.FindElement(By.Id("w2ui-popup")).Displayed;
            Assert.IsTrue(isPopupDisplayed);

            IWebElement popupTitle = driver.FindElement(By.XPath("//div[@class='w2ui-popup-title']/descendant::div[@rel='title']"));
            string actualPopupTitle = popupTitle.Text;
            Assert.AreEqual("Popup #1 Title", actualPopupTitle);

            Thread.Sleep(2000);

            IWebElement closePopupButton = driver.FindElement(By.CssSelector(".w2ui-popup-button.w2ui-popup-close"));
            closePopupButton.Click();

            Thread.Sleep(2000);
            try
            {
                IWebElement postClosingOfPopup = driver.FindElement(By.Id("w2ui-popup"));
                bool b = postClosingOfPopup.Displayed;
                Assert.IsFalse(b);
            }
            catch (NoSuchElementException e)
            {
                isPopupDisplayed = false;
            }

            Assert.IsFalse(isPopupDisplayed);
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Close();
        }
    }
}
