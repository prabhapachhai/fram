using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumWebDriverNUnitTestProject
{
    class ActionsClassExample
    {
        //Class Member
        //Only Declaration
        IWebDriver driver;
        WebDriverWait wait;

        //This method will get executed before each Test Method
        [SetUp]
        public void BeforeTest()
        {
            //Initilizing the class member driver with Chrome Driver
            driver = new ChromeDriver(@"E:\Drivers\chromedriver_win32");
            
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();
        }

        //Test Method
        [Test]
        public void MouseHoverTest()
        {
            //Navigating to URL
            driver.Url = "https://www.amazon.com/";
            //Finding a WebElement
            IWebElement accountsAndList = driver.FindElement(By.Id("nav-link-accountList"));
            
            //Creating Actions class object by passing driver object as constructor parameter
            Actions action = new Actions(driver);
            //To Move Mouse cursor to specified WebElement and perform the action
            action.MoveToElement(accountsAndList).Perform();

            //Finding a WebElement
            IWebElement yourAccountsSpan = driver.FindElement(By.XPath("//span[text()='Your Account']"));
            //Calling WebElement Click method
            yourAccountsSpan.Click();

            //Finding a WebElement
            IWebElement heading = driver.FindElement(By.TagName("h1"));
            //Geting innerHTML (Text) from WebElement
            string actualHeadingText = heading.Text;
            //Assertion
            Assert.AreEqual("Your Account", actualHeadingText);
        }

        [Test]
        public void DoubleClickTest()
        {
            //Navigating to URL
            driver.Url = "https://api.jquery.com/dblclick/";

            //Switching to iFrame by index (zero-based)
            driver.SwitchTo().Frame(0);

            //Finding the element in iFrame
            IWebElement doubleClickBlock = driver.FindElement(By.XPath("//span[text()='Double click the block']/preceding::div"));

            //Stroing CSS property of type background-color of a WebElement
            string beforeDoubleClickBackgroundColor = doubleClickBlock.GetCssValue("background-color");
            //Printing the color in console
            Console.WriteLine("Before Double click block color is : " + beforeDoubleClickBackgroundColor);
            //Local variable
            string expectedBlueColor = "rgba(0, 0, 255, 1)";
            //Assertion
            Assert.AreEqual(expectedBlueColor, beforeDoubleClickBackgroundColor);

            //Creating Actions class object by passing driver object as constructor parameter
            Actions action = new Actions(driver);
            //To left double click of Mouse to specified WebElement and perform the action
            action.DoubleClick(doubleClickBlock).Perform();

            //Stroing CSS property of type background-color of a WebElement
            string afterDoubleClickBackgroundColor = doubleClickBlock.GetCssValue("background-color");
            //Printing the color in console
            Console.WriteLine("After Double click block color is : " + afterDoubleClickBackgroundColor);
            //Local variable
            string expectedYellowColor = "rgba(255, 255, 0, 1)";
            //Assertion
            Assert.AreEqual(expectedYellowColor, afterDoubleClickBackgroundColor);
        }

        [Test]
        public void RightClickTest()
        {
            //Navigating to URL
            driver.Url = "https://swisnl.github.io/jQuery-contextMenu/demo.html";
            //Finding a WebElement
            IWebElement rightClickButton = driver.FindElement(By.CssSelector(".context-menu-one.btn.btn-neutral"));

            //Creating Actions class object by passing driver object as constructor parameter
            Actions action = new Actions(driver);
            //To right click of Mouse to specified WebElement and perform the action
            action.ContextClick(rightClickButton).Perform();

            //Finding a WebElement
            IWebElement rightClickEditMenuOption = driver.FindElement(By.XPath("//span[text()='Edit']"));
            //Calling WebElement Click method
            rightClickEditMenuOption.Click();

            //Geting text from Alert
            string actualAlertText = driver.SwitchTo().Alert().Text;
            //Local variable
            string expectedAlertText = "clicked: edit";
            //Assertion
            Assert.AreEqual(expectedAlertText, actualAlertText);
            //Clicking on Ok button in Alert
            driver.SwitchTo().Alert().Accept();
        }

        [Test]
        public void DragAndDropImageTest()
        {
            //Navigate to Website
            driver.Url = "https://www.globalsqa.com/demo-site/draganddrop/";

            //Finding iframe as WebElement
            IWebElement iframe = driver.FindElement(By.XPath("//iframe[@class='demo-frame lazyloaded']"));
            //Switching to iFrame
            driver.SwitchTo().Frame(iframe);

            //Finding the Source WebElement to be draged
            IWebElement sourceWebElement = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']"));

            //Finding the Source WebElement's ul parent tag before Drag and Drop operation
            IWebElement sourceWebElementBeforeDragAndDropClass = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']/ancestor::ul"));

            //Finding the Source WebElement's ul parent tag class before Drag and Drop operation
            string actualSourceWebElementClassBeforeDragAndDrop = sourceWebElementBeforeDragAndDropClass.GetAttribute("class");
            Console.WriteLine("Before moving img : " + actualSourceWebElementClassBeforeDragAndDrop);

            //Finding the Target WebElement where Source Web Element need to be dropped
            IWebElement targetWebElement = driver.FindElement(By.Id("trash"));

            //Source WebElement X cordinates
            int sourceWebElementBeforeDragAndDropXOffset = sourceWebElement.Location.X;
            Console.WriteLine("Before moving img x offset : " + sourceWebElementBeforeDragAndDropXOffset);

            //Creating object of Actions class by passing driver object to constructor of Actions class
            Actions actions = new Actions(driver);
            //Actual Drag and Drop Operation
            actions.DragAndDrop(sourceWebElement, targetWebElement).Perform();

            //Hardcoded wait for changes to get applied
            Thread.Sleep(2000);

            //Finding Source WebElement after Drag And Drop operation
            IWebElement sourceWebElementAfterDragAndDrop = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']"));

            //Source WebElement X cordinates after Drag And Drop operation
            int sourceWebElementAfterDragAndDropXOffset = sourceWebElementAfterDragAndDrop.Location.X;
            Console.WriteLine("After moving img x offset : " + sourceWebElementAfterDragAndDropXOffset);

            //Finding the Source WebElement's ul parent tag after Drag and Drop operation
            IWebElement newSourceWebElement = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']/ancestor::ul"));

            //Finding the Source WebElement's ul parent tag class after Drag and Drop operation
            string actualClass = newSourceWebElement.GetAttribute("class");
            string expectedClass = "gallery ui-helper-reset";
            Console.WriteLine("After moving img : " + actualClass); 

            Assert.AreEqual(expectedClass, actualClass);

            //Asserting that x offest before and after drag and drop operation are not equal
            Assert.AreNotEqual(sourceWebElementBeforeDragAndDropXOffset, sourceWebElementAfterDragAndDropXOffset);
        }

        [Test]
        public void DragAndDropImageTestWithExplicitWait()
        {
            //Navigate to Website
            driver.Url = "https://www.globalsqa.com/demo-site/draganddrop/";

            //Finding iframe as WebElement
            IWebElement iframe = driver.FindElement(By.XPath("//iframe[@class='demo-frame lazyloaded']"));
            //Switching to iFrame
            driver.SwitchTo().Frame(iframe);

            //Finding the Source WebElement to be draged
            IWebElement sourceWebElement = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']"));

            //Finding the Source WebElement's ul parent tag before Drag and Drop operation
            IWebElement sourceWebElementBeforeDragAndDropClass = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']/ancestor::ul"));

            //Finding the Source WebElement's ul parent tag class before Drag and Drop operation
            string actualSourceWebElementClassBeforeDragAndDrop = sourceWebElementBeforeDragAndDropClass.GetAttribute("class");
            Console.WriteLine("Before moving img : " + actualSourceWebElementClassBeforeDragAndDrop);

            //Finding the Target WebElement where Source Web Element need to be dropped
            IWebElement targetWebElement = driver.FindElement(By.Id("trash"));

            //Source WebElement X cordinates
            int sourceWebElementBeforeDragAndDropXOffset = sourceWebElement.Location.X;
            Console.WriteLine("Before moving img x offset : " + sourceWebElementBeforeDragAndDropXOffset);

            //Creating object of Actions class by passing driver object to constructor of Actions class
            Actions actions = new Actions(driver);
            //Actual Drag and Drop Operation
            actions.DragAndDrop(sourceWebElement, targetWebElement).Perform();

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//img[@alt='The peaks of High Tatras']/ancestor::ul[@class='gallery ui-helper-reset']")));

            //Finding Source WebElement after Drag And Drop operation
            IWebElement sourceWebElementAfterDragAndDrop = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']"));

            //Source WebElement X cordinates after Drag And Drop operation
            int sourceWebElementAfterDragAndDropXOffset = sourceWebElementAfterDragAndDrop.Location.X;
            Console.WriteLine("After moving img x offset : " + sourceWebElementAfterDragAndDropXOffset);

            //Finding the Source WebElement's ul parent tag after Drag and Drop operation
            IWebElement newSourceWebElement = driver.FindElement(By.XPath("//img[@alt='The peaks of High Tatras']/ancestor::ul"));

            //Finding the Source WebElement's ul parent tag class after Drag and Drop operation
            string actualClass = newSourceWebElement.GetAttribute("class");
            string expectedClass = "gallery ui-helper-reset";
            Console.WriteLine("After moving img : " + actualClass);

            Assert.AreEqual(expectedClass, actualClass);

            //Asserting that x offest before and after drag and drop operation are not equal
            Assert.AreNotEqual(sourceWebElementBeforeDragAndDropXOffset, sourceWebElementAfterDragAndDropXOffset);
        }

        [Test]
        public void DragAndDropTest()
        {
            //Navigate to Website
            driver.Url = "https://demos.telerik.com/kendo-ui/dragdrop/index";

            //Hardcoded wait for site to get loaded
            Thread.Sleep(5000);

            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            //Above line of code can be written in below way as well
            //If we do not require the element in later part of the test
            //No need to store it
            //IWebElement acceptCookiesButton = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
            //acceptCookiesButton.Click();

            //After Accepting the cookies hardcoded wait
            Thread.Sleep(5000);

            //Finding the Source WebElement to be draged
            IWebElement sourceWebElement = driver.FindElement(By.Id("draggable"));

            //Finding the Target WebElement where Source Web Element need to be dropped
            IWebElement targetWebElement = driver.FindElement(By.Id("droptarget"));

            //Creating object of Actions class by passing driver object to constructor of Actions class
            Actions actions = new Actions(driver);
            //Actual Drag and Drop Operation
            actions.DragAndDrop(sourceWebElement, targetWebElement).Perform();

            //Hardcoded wait for drag and drop operation to be performed
            Thread.Sleep(2000);

            //Getting inner HTML of target WebElement
            string afterDragAndDropOperationText = driver.FindElement(By.Id("droptarget")).Text;
            //Assertion
            Assert.AreEqual("You did great!", afterDragAndDropOperationText);
        }

        [Test]
        public void DragAndDropTestWithExplicitWait()
        {
            //Navigate to Website
            driver.Url = "https://demos.telerik.com/kendo-ui/dragdrop/index";

            wait.Until(ExpectedConditions.ElementExists(By.Id("onetrust-accept-btn-handler")));
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("draggable")));

            //Finding the Source WebElement to be draged
            IWebElement sourceWebElement = driver.FindElement(By.Id("draggable"));

            //Finding the Target WebElement where Source Web Element need to be dropped
            IWebElement targetWebElement = driver.FindElement(By.Id("droptarget"));

            //Creating object of Actions class by passing driver object to constructor of Actions class
            Actions actions = new Actions(driver);
            //Actual Drag and Drop Operation
            actions.DragAndDrop(sourceWebElement, targetWebElement).Perform();

            wait.Until(ExpectedConditions.TextToBePresentInElement(targetWebElement, "You did great!"));

            //Getting inner HTML of target WebElement
            string afterDragAndDropOperationText = targetWebElement.Text;
            //Assertion
            Assert.AreEqual("You did great!", afterDragAndDropOperationText);
        }

        [Test]
        public void DragAndDropCircleMultipleTimesTest()
        {
            //Navigating to URL
            driver.Url = "https://demos.telerik.com/kendo-ui/dragdrop/area";
            //JavaScript wait for Page Load to be in document.readyState to complete
            WaitForPageLoad(driver);

            //Explicit wait for Accept Cookies button to be visible on UI
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("onetrust-accept-btn-handler")));

            //Finding the Accept Cookies button and performing click operation
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();

            //Explicit wait for Accept Cookies button is not present in DOM
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("onetrust-accept-btn-handler")));

            //Explicit wait for blue circle to be clickable
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("draggable")));

            //Finding the blue circle (source WebElement)
            IWebElement blueCircle = driver.FindElement(By.Id("draggable"));
            //Finding the target WebElement (blue box)
            IWebElement targetWebElement1 = driver.FindElement(By.ClassName("test1"));

            //Creating object of actions class by passing driver instance
            Actions actions1 = new Actions(driver);
            //Performing the Drag and Drop operation of actions class by below workaround
            actions1.ClickAndHold(blueCircle).MoveToElement(targetWebElement1).Release().Perform();

            //Re-Initilizing the same targetWebElement to overcome StaleElementRefrenceException
            //We need to Re-Initilizing the targetWebElement again as the innerHTML of targetWebElement is changed after drag and drop operation
            targetWebElement1 = driver.FindElement(By.ClassName("test1"));
            //driver.FindElement(By.XPath("//*[text()='You did great!']"))

            //Explicit wait for targetWebElement's innerHTMl to be "You did great!"
            wait.Until(ExpectedConditions.TextToBePresentInElement(targetWebElement1, "You did great!"));

            //Storing the innerHTML of targetWebElement after drag and drop operation
            string targetWebElement1TextAfterDragAndDrop = targetWebElement1.Text;
            //Assertion
            Assert.AreEqual("You did great!", targetWebElement1TextAfterDragAndDrop);

            //Explict wait for blue circle to be clickable
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("draggable")));

            //Re-Initilizing blue circle after first drag and drop operation
            blueCircle = driver.FindElement(By.Id("draggable"));

            //Finding the targetWebElement (orange box)
            IWebElement targetWebElement2 = driver.FindElement(By.ClassName("test2"));

            //Creating new object of actions class as driver has changed after performing first drag and drop operation
            Actions actions2 = new Actions(driver);
            //Performing the Drag and Drop operation of actions class by below workaround
            actions2.ClickAndHold(blueCircle).MoveToElement(targetWebElement2).Release().Perform();

            //Re-Initilizing the same targetWebElement to overcome StaleElementRefrenceException
            //We need to Re-Initilizing the targetWebElement again as the innerHTML of targetWebElement is changed after drag and drop operation
            targetWebElement2 = driver.FindElement(By.ClassName("test2"));

            //Explicit wait for targetWebElement's innerHTMl to be "You did great!"
            wait.Until(ExpectedConditions.TextToBePresentInElement(targetWebElement2, "You did great!"));

            //Storing the innerHTML of targetWebElement after drag and drop operation
            string targetWebElement2TextAfterDragAndDrop = targetWebElement2.Text;
            //Assertion
            Assert.AreEqual("You did great!", targetWebElement2TextAfterDragAndDrop);
        }

        //Java Script Page Load
        public void WaitForPageLoad(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Close();
        }
    }
}
