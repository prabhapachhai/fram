using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;

namespace spc1
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        IWebDriver driver = new ChromeDriver(@"C:\driver\chromedriver_win32");
        [Given(@"i am navigate to "" (.*)")]
        public void GivenIamNavigateTo(string p0)
        {
            driver.Url = p0;
                
        }
        
        [Given(@"i have click on sign in link"" (.*)")]
        public void GivenIhaveClickedOnSignInLink()
        {
            IWebElement accountandList = driver.FindElement(By.XPath("//*[text()='Account&Lists']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(accountandList).Perform();
            IWebElement signInLink = driver.FindElement(By.ClassName("nav-action-inner"));
            signInLink.Click();
        }
        
        [When(@"i entered email or phone number""(.*)")]
        public void WhenIenteredEamilOrPhoneNumber(Decimal p0)
        {
            string userName = Convert.ToString(p0);
            IWebElement emailorphoneNumber = driver.FindElement(By.Id("ap_email"));
            emailorphoneNumber.SendKeys(userName);
                
        }
        [When(@"i click on continue button ""(.*)")]
        public void WhenIclickOnContinueButton()
        {
            driver.FindElement(By.Id("continue")).Click();
        }
        [When(@"i enter password ""(.*)")]
        public void WhenIenterPassword()
        {
            IWebElement password = driver.FindElement(By.Id("ap_password"));
            password.SendKeys("xyz");
        }
        [When(@"i click on sign in button ""(.*)")]
        public void ClickOnSignInButton()
        {
            driver.FindElement(By.Id("signInSubmit")).Click();
        }

        [Then(@" i should get error message (.*)")]
        public void ThenIshouldGetErrorMessage(string p0)
        {
            IWebElement message = driver.FindElement(By.Id("auth-warning-message-box"));
            string actualMessage = message.Text;
            Assert.AreEqual(p0, actualMessage);
           
        }
    }
}
