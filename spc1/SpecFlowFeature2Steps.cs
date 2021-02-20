using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace spc1
{
    [Binding]
    public class SpecFlowFeature2Steps
    {
        IWebDriver driver = new ChromeDriver(@"C:\driver\chromedriver_win32");
        [Given(@"i am navigate to""(.*)""")]
        public void GivenIAmNavigateTo(string p0)
        {
            driver.Url = p0;
           
        }
        
        [Given(@"i enter the below information")]
        public void GivenIEnterTheBelowInformation(Table table)
        {

            var tableData = table.CreateDynamicSet();
            foreach (var item in tableData)
            {
                driver.FindElement(By.XPath("//input[@placeholder='First Name']")).SendKeys((string)item.FirstName);
                driver.FindElement(By.XPath("//input[@placeholder='Last Name']")).SendKeys((string)item.LastName);
                driver.FindElement(By.TagName("textarea")).SendKeys((string)item.Address);
            }
            {

            }
        }
    }
}
