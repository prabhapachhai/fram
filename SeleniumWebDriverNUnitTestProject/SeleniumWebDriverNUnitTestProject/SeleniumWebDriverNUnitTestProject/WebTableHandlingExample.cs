using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace SeleniumWebDriverNUnitTestProject
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(@"E:\Drivers\chromedriver_win32");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        [Test]
        public void GoogleSearchTest()
        {
            driver.Url = "https://www.google.com";
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("IPhone 12");
        }

        [Test]
        public void GoogleSignInTest()
        {
            driver.Url = "https://www.google.com";
            IWebElement signInButton = driver.FindElement(By.XPath("//a[text()='Sign in']"));
            signInButton.Click();
        }

        [Test]
        public void ConventialHTMLSyntaxWebTableTest()
        {
            driver.Url = "https://www.seleniumeasy.com/test/table-sort-search-demo.html";

            //driver.FindElement(By.XPath("//input[@type='search']")).SendKeys("Wagner");
            //driver.FindElement(By.XPath("//input[@type='search']")).SendKeys("Cox");
            Thread.Sleep(2000);
            IWebElement searchBox = driver.FindElement(By.XPath("//input[@type='search']"));
            searchBox.SendKeys("Wagner");
            Thread.Sleep(2000);
            IWebElement searchMessage = driver.FindElement(By.Id("example_info"));
            string actualText = searchMessage.Text;
            string expectedText = "Showing 1 to 1 of 1 entries (filtered from 32 total entries)";
            Assert.AreEqual(expectedText, actualText);

            IWebElement actualName = driver.FindElement(By.XPath("//tbody/descendant::tr/descendant::td[1]"));
            IWebElement actualPosition = driver.FindElement(By.XPath("//tbody/descendant::tr/descendant::td[2]"));
            IWebElement actualOffice = driver.FindElement(By.XPath("//tbody/descendant::tr/descendant::td[3]"));
            IWebElement actualAge = driver.FindElement(By.XPath("//tbody/descendant::tr/descendant::td[4]"));
            IWebElement actualStartDate = driver.FindElement(By.XPath("//tbody/descendant::tr/descendant::td[5]"));
            IWebElement actualSalary = driver.FindElement(By.XPath("//tbody/descendant::tr/descendant::td[6]"));

            string abc = actualAge.Text;
            
            string pqr = "28";
            Assert.AreEqual(pqr, abc);

            Assert.AreEqual("B. Wagner", actualName.Text);

            string expectedName = "B. Wagner";
            string actualNameValue = actualName.Text;
            Assert.AreEqual(expectedName, actualNameValue);

            Assert.AreEqual("B. Wagner", driver.FindElement(By.XPath("//tbody/descendant::tr/descendant::td[1]")).Text);

        }

        [Test]
        public void AngularHTMLWebTableTest()
        {
            driver.Url = "http://demo.automationtesting.in/WebTable.html";

            List<string> expectedEmail = new List<string>
            { 
                "luzhongkui@hotmail.com",
                "raitvishnu@gmail.com",
                "akbarshaik911@gmail.com",
                "akbarshaik911@gmail.com",
                "3102318750@proba1.com",
                "rajatsharma@gmail.com",
                "tyagi.shailja03@gmail.com",
                "tyagi.shailja53@gmail.com",
                "tyagi.shailja07@gmail.com",
                "tyagi.shailja10@gmail.com"
            };

            List<string> actualEmail = new List<string>();
            List<string> actualFirstName = new List<string>();
            List<string> actualGender = new List<string>();

            ReadOnlyCollection<IWebElement> tableRows = driver.FindElements(By.XPath("//*[@class='ui-grid-canvas']/descendant::div[@role='row']"));

            for (int i = 1; i <= tableRows.Count; i++)
            {
                actualEmail.Add(driver.FindElement(By.XPath("//*[@class='ui-grid-canvas']/descendant::div[@role='row'][" + i + "]/descendant::*[contains(@class, '0005')]")).Text);
                actualFirstName.Add(driver.FindElement(By.XPath("//*[@class='ui-grid-canvas']/descendant::div[@role='row'][" + i + "]/descendant::*[contains(@class, '0006')]")).Text);
                actualGender.Add(driver.FindElement(By.XPath("//*[@class='ui-grid-canvas']/descendant::div[@role='row'][" + i + "]/descendant::*[contains(@class, '0007')]")).Text);
            }

            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [Test]
        public void ComplexHTMLWebTableTest()
        {
            //Expected First Name List of Strings
            List<string> expectedFirstName = new List<string>()
            {
                "Cierra",
                "Alden",
                "Kierra"
            };

            //Actual First Name Declaration
            List<string> actualFirstName = new List<string>();

            //Navigating to URL
            driver.Url = "https://demoqa.com/webtables";

            //Getting total number of rows of table
            ReadOnlyCollection<IWebElement> totalRows = driver.FindElements(By.XPath("//*[@role='rowgroup']"));

            //Using for loop to iterate over each row
            for (int i = 1; i <= totalRows.Count; i++)
            {
                //Passing index i as parameter to Xpath for iterating over each row
                //Column index is fixed to 1
                IWebElement firstName = driver.FindElement(By.XPath("//*[@role='rowgroup']["+i+"]/descendant::*[@role='gridcell'][1]"));

                //If the firstName.Text is not Null or White space then go in the if block and add it to actual first name collection
                if(!string.IsNullOrWhiteSpace(firstName.Text))
                {
                    actualFirstName.Add(firstName.Text);
                }
            }
            //Assertion with expected and actual First names
            Assert.AreEqual(expectedFirstName, actualFirstName);
        }

        [Test]
        public void EditHTMLWebTableUsingForLoopTest()
        {
            //Expected row to edit
            string editRowFirstName = "Kierra";

            //Navigating to URL
            driver.Url = "https://demoqa.com/webtables";
            Thread.Sleep(3000);

            //Getting total number of rows of table
            ReadOnlyCollection<IWebElement> totalRows = driver.FindElements(By.XPath("//*[@role='rowgroup']"));

            //Using for loop to iterate over each row
            for (int i = 1; i <= totalRows.Count; i++)
            {
                //Passing index i as parameter to Xpath for iterating over each row
                //Column index is fixed to 1
                IWebElement firstName = driver.FindElement(By.XPath("//*[@role='rowgroup'][" + i + "]/descendant::*[@role='gridcell'][1]"));

                //If the firstName.Text is equals with the row which we want to edit then go inside the if block
                if (firstName.Text.Equals(editRowFirstName))
                {
                    //Finding the Edit icon for row of the same index i for which the first name is matched
                    IWebElement editIcon = driver.FindElement(By.XPath("//*[@role='rowgroup'][" + i + "]/descendant::*[@role='gridcell'][7]/descendant::span[contains(@id, 'edit')]"));
                    editIcon.Click();
                    Thread.Sleep(3000);
                    break;
                }
            }

            //Editing the LastName in Pop-up 
            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Updated");
            Thread.Sleep(3000);

            //Clicking on Submit button in Pop-up
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();

            Thread.Sleep(3000);

            //Using for loop to iterate over each row for verifying the last name is updated
            for (int i = 1; i < totalRows.Count; i++)
            {
                //Passing index i as parameter to Xpath for iterating over each row
                //Column index is fixed to 1
                IWebElement firstName = driver.FindElement(By.XPath("//*[@role='rowgroup'][" + i + "]/descendant::*[@role='gridcell'][1]"));

                //If the firstName.Text is equals with the row which we want to edit then go inside the if block
                string actualFirstNameText = firstName.Text;
                if (actualFirstNameText.Equals(editRowFirstName))
                {
                    //Finding the last name for row of the same index i for which the first name is matched
                    IWebElement actualLastName = driver.FindElement(By.XPath("//*[@role='rowgroup'][" + i + "]/descendant::*[@role='gridcell'][2]"));
                    Assert.AreEqual("GentryUpdated", actualLastName.Text);
                    break;
                }
            }
        }

        [Test]
        public void EditHTMLWebTableTest()
        {
            string editRowFirstName = "Kierra";
            driver.Url = "https://demoqa.com/webtables";
            Thread.Sleep(3000);

            //Finding the edit icon element with respect to first name
            IWebElement editIcon = driver.FindElement(By.XPath("//*[text()='"+ editRowFirstName + "']/following-sibling::*/descendant::span[contains(@id, 'edit')]"));
            editIcon.Click();

            //Editing the LastName in Pop-up
            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Updated");
            Thread.Sleep(3000);

            //Clicking submit in Pop-up
            IWebElement submitButton = driver.FindElement(By.Id("submit"));
            submitButton.Click();
            Thread.Sleep(3000);

            //Finding last name element with respect to first name
            IWebElement actualLastName = driver.FindElement(By.XPath("//*[text()='"+ editRowFirstName + "']/following-sibling::*[1]"));
            Assert.AreEqual("GentryUpdated", actualLastName.Text);
        }

        [Test]
        public void ImplicitWaitExample()
        {
            driver.Url = "https://demo.tutorialzine.com/2009/09/simple-ajax-website-jquery/demo.html#page1";
            IWebElement page3Button = driver.FindElement(By.XPath("//a[@href='#page3']"));
            page3Button.Click();
            
            IWebElement kittenImg = driver.FindElement(By.XPath("//div[@id='pageContent']/descendant::img"));
            string kittenSrc = kittenImg.GetAttribute("src");
            string actualImgWidth = kittenImg.GetAttribute("width");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}