using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Windows.Forms;

namespace UnitTestProject1
{
    class FileUploadExampleWithDotNetFramework
    {
        //Declaration of WebDriver
        IWebDriver driver;

        //Declaration of Wait
        WebDriverWait wait;

        [SetUp]
        public void BeforeTest()
        {
            //Initialization of Chrome Driver
            driver = new ChromeDriver(@"E:\Drivers\chromedriver_win32");

            //Initialization of Web Driver Wait
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [Test]
        public void FileUploadNonStandardHTMLByWindowsFormsTest()
        {
            //Navigating to URL
            driver.Url = "https://smallpdf.com/pdf-to-word";

            //Waiting for Page Load
            WaitForPageLoad(driver);

            //Finding the WebElement
            IWebElement crossButton = driver.FindElement(By.CssSelector(".sc-2xfn8l-0.bxyVaO.sxq67w-0.sc-1c9rd1d-0.gXPuQM"));
            //Clicking on the close Button
            crossButton.Click();

            //Find WebElement by which Windows Forms application gets open
            IWebElement chooseFileButton = driver.FindElement(By.CssSelector(".sc-1rkezdt-7.cxlSWI"));
            chooseFileButton.Click();

            Thread.Sleep(2000);

            //It will type the file path in the Windows forms application
            //As the focus is on the File Name of the Windows forms application
            SendKeys.SendWait(@"E:\Tuition\Documents\QA1005\ClassNotes\Selenium\1_Oct_2020_Assignment.pdf");
            Thread.Sleep(3000);
            //Instead of Click the Open button from Windows forms application
            //We are using a workaround and using the Enter key of Keyboard
            SendKeys.SendWait(@"{Enter}");

            //Explicit Wait
            //Waiting till the Element is clickable
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@value='converter_normal']/parent::label")));

            //Finding the WebElement
            IWebElement covertToWordRadioButton = driver.FindElement(By.XPath("//*[@value='converter_normal']/parent::label"));

            //Clicking on the Radio button
            covertToWordRadioButton.Click();

            //Finding the Web Element
            IWebElement chooseOptionButton = driver.FindElement(By.CssSelector(".sc-1mvwhop-0.bqmdbl"));

            //Clicking on Choose Option button
            chooseOptionButton.Click();

            //In this case We can use Implicit Wait as well as Explicit Wait
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Explicit Wait
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".sc-3izlcx-5.iBSdrT")));

            //Finding WebElement
            IWebElement convertedFileName = driver.FindElement(By.CssSelector(".sc-3izlcx-5.iBSdrT"));

            //Geting the value attribute of WebElement
            string actualFileName = convertedFileName.GetAttribute("value");

            //Local variable
            string expectedFileName = "1_Oct_2020_Assignment-converted.docx";

            //Assertion
            Assert.AreEqual(expectedFileName, actualFileName);
        }

        //Java Script Page Load
        public void WaitForPageLoad(IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
