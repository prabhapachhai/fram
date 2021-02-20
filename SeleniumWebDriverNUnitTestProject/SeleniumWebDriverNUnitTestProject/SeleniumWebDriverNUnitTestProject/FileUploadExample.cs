using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriverNUnitTestProject
{
    class FileUploadExample
    {
        //Declaration of Driver
        IWebDriver driver;

        //declaration of Wait
        WebDriverWait wait;

        [SetUp]
        public void BeforeTest()
        {
            //Initialization of Chrome Driver
            driver = new ChromeDriver(@"C:\Users\12144\Desktop\chromedriver_win32");

            //Initialization of Web Driver Wait
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [Test]
        public void FileUploadNonStandardHTMLTest1()
        {
            //Navigating to URL
            driver.Url = "https://online2pdf.com/";

            //Finding the Web Element
            IWebElement selectFiles = driver.FindElement(By.Id("input_file0"));

            //Performing the Sendkeys operation on a File Upload WebElement with file path of file to be uploaded 
            selectFiles.SendKeys(@"C:\Users\12144\Downloads\17_Oct_2020_IFrame.docx");

            //Finding the Web Element
            IWebElement uploadedFile = driver.FindElement(By.Id("file0_0_name"));

            //Local variable
            string expectedText = "17_Oct_2020_IFrame.docx";

            //Geting text(inner HTML) of WebElement
            string actualText = uploadedFile.Text;

            //Assertion
            Assert.AreEqual(expectedText, actualText);

            //Finding Web Element
            IWebElement convertButton = driver.FindElement(By.ClassName("convert_button"));
            //Clicking on Convert Button
            convertButton.Click();

            //Explicit Wait for the WebElement to be visible on UI
            //In this situation we cannot use Implicit wait as the element is already present in DOM 
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='completed_window_text']/child::b")));

            //Finding WebElement
            IWebElement finishMessage = driver.FindElement(By.XPath("//*[@class='completed_window_text']/child::b"));
            //Printing the Text of WebElement in console
            Console.WriteLine(finishMessage.Text);
        }

        [Test]
        public void FileUploadNonStandardHTMLTest2()
        {   
            //Navigating to URL
            driver.Url = "https://smallpdf.com/pdf-to-word";

            //Waiting for Page Load
            WaitForPageLoad(driver);

            //Finding the WebElement
            IWebElement crossButton = driver.FindElement(By.CssSelector(".sc-2xfn8l-0.bxyVaO.sxq67w-0.sc-1c9rd1d-0.gXPuQM"));
            //Clicking on the close Button
            crossButton.Click();

            //Finding the WebElement
            IWebElement chooseFiles = driver.FindElement(By.Id("__picker-input"));

            //Performing the Sendkeys operation on a File Upload WebElement with file path of file to be uploaded 
            chooseFiles.SendKeys(@"E:\Tuition\Documents\QA1005\ClassNotes\Selenium\1_Oct_2020_Assignment.pdf");

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

        [TearDown]
        public void AfterTest()
        {
            //driver.Close();
        }
    }
}
