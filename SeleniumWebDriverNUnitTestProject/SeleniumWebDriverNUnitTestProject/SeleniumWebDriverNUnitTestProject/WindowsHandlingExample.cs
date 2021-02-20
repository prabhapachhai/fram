using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace SeleniumWebDriverNUnitTestProject
{
    class WindowsHandlingExample
    {
        //Class member
        //Only Declaration
        IWebDriver driver;

        //By Adding Setup Attribute, this method will get called before each Test Method
        [SetUp]
        public void BeforeTest()
        {
            //Initializing driver with Chrome Driver
            driver = new ChromeDriver(@"E:\Drivers\chromedriver_win32");    
            Thread.Sleep(2000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
        }

        //Test Method
        [Test]
        public void BasicWindowsHandlingTest()
        {
            //Navigate to URL
            driver.Url = "file:///E:/Tuition/Documents/QA1005/ClassNotes/Selenium/WindowsHandlingDemoSite.html";
            Thread.Sleep(2000);

            //CurrentWindowHandle property will return the Unique Id of Current Window in string data type
            string originalWindow = driver.CurrentWindowHandle;
            //WindowHandles returns the collection of all Unique Id's of all Windows which are opened
            ReadOnlyCollection<string> allWindows = driver.WindowHandles;

            //Finding the Element by Tag Name
            IWebElement amazonLink = driver.FindElement(By.TagName("a"));
            //Performing Click operation on Link
            amazonLink.Click();
            Thread.Sleep(2000);

            //Re-Initializing collection after opening new tab 
            allWindows = driver.WindowHandles;

            //Using foreach loop to iterate over the collection of all WindowHandles
            foreach (var item in allWindows)
            {
                Console.WriteLine(item);
                //Logic when original Window is not matching with the item of collection
                if (item != originalWindow)
                {
                    //Switching to the Window
                    driver.SwitchTo().Window(item);
                    //To Exit from loop
                    break;
                }
            }

            //Finding the element
            IWebElement amazonSearchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
            //Performing SendKeys Operation
            amazonSearchBox.SendKeys("iphone 12");

            Thread.Sleep(5000);

            //Switching back to original Window
            driver.SwitchTo().Window(originalWindow);

            //Finding Element
            IWebElement textbox = driver.FindElement(By.TagName("input"));
            //Performing SendKeys Operation
            textbox.SendKeys("Vaibhav");
            Thread.Sleep(5000);
        }

        [Test]
        public void MultipleWindowsHandlingTest()
        {
            //Navigating to URL
            driver.Url = "file:///E:/Tuition/Documents/QA1005/ClassNotes/Selenium/MultipleWindowsHandlingDemoSite.html";
            Thread.Sleep(2000);

            //Storing the Custom Site Window Handle
            //string OriginalWindow = driver.CurrentWindowHandle;

            //Finding Element
            IWebElement amazonLink = driver.FindElement(By.XPath("//a[@href='https://www.amazon.com']"));
            //Performing Click Operation
            amazonLink.Click();
            Thread.Sleep(10000);

            //Storing All Window Handle after opening Amazon site
            var allWindowsAfterOpeningTwoSite = driver.WindowHandles;

            //Finding Element
            IWebElement googleLink = driver.FindElement(By.XPath("//a[@href='https://www.google.com']"));
            //Performing Click Operation
            googleLink.Click();

            //Storing All Windows after opening Google Site
            var allWindowsAfterOpeningThreeSites = driver.WindowHandles;

            //First item of collection would be the original window
            var OriginalSite = allWindowsAfterOpeningThreeSites[0];
            //Second item of collection would be the second site opened in current context(Amazon site opened in line number 90)
            var AmazonSite = allWindowsAfterOpeningThreeSites[1];
            //Third item of collection would be the third site opened in current context(Amazon site opened in line number 96)
            var GoogleSite = allWindowsAfterOpeningThreeSites[2];

            //Switching to Amazon site
            driver.SwitchTo().Window(AmazonSite);

            //Finding element on Amazon site
            IWebElement amazonSearchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
            //Performing SendKeys operation
            amazonSearchBox.SendKeys("iphone 12");
            Thread.Sleep(5000);

            //Switching to Google site
            driver.SwitchTo().Window(GoogleSite);

            //Finding element on Google site
            IWebElement googleTextbox = driver.FindElement(By.Name("q"));
            //Performing SendKeys operation
            googleTextbox.SendKeys("Galaxy S20+");
            Thread.Sleep(5000);

            //Switching back to Orignal site
            driver.SwitchTo().Window(OriginalSite);

            //Finding element on Custom site
            IWebElement textbox = driver.FindElement(By.TagName("input"));
            //Performing SendKeys operation
            textbox.SendKeys("Vaibhav");
            Thread.Sleep(5000);
        }

        [Test]
        public void MultipleWindowsHandleTest()
        {
            //Navigate to URL
            driver.Url = "https://www.globalsqa.com/demo-site/frames-and-windows/#";

            //
            ReadOnlyCollection<IWebElement> allStrongWebElements = driver.FindElements(By.XPath("//strong"));

            List<string> actualStrongText = new List<string>();
            foreach (var item in allStrongWebElements)
            {
                actualStrongText.Add(item.Text);
            }

            string originalWindowHandle = driver.CurrentWindowHandle;
            IWebElement clickHereButton = driver.FindElement(By.XPath("//*[text()='Click Here']"));
            clickHereButton.Click();
            
            ReadOnlyCollection<string> allWindows = driver.WindowHandles;
            string newWindow = allWindows[1];
            driver.SwitchTo().Window(newWindow);
            Thread.Sleep(5000);
            IWebElement homeTab = driver.FindElement(By.XPath("//*[text()='Home']"));
            homeTab.Click();
        }

        [TearDown]
        public void AfterTest()
        {
            //driver.Close();
            driver.Quit();
        }
    }
}
