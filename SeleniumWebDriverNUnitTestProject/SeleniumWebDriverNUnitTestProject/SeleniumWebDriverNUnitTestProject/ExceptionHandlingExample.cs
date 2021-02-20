using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SeleniumWebDriverNUnitTestProject
{
    class ExceptionHandlingExample
    {
        //Class Member
        //Only declaration
        IWebDriver driver;

        //This method will get executed before each test
        [SetUp]
        public void BeforeTest()
        {
            //Local variable to method BeforeTest
            //scope of driver will be limited to BeforeTest method only
            IWebDriver driver = new ChromeDriver(@"E:\Drivers\chromedriver_win32");
        }

        [Test]
        public void NullReferenceExceptionTest()
        {
            //Below line of code will throw NullReferenceException
            //As driver class member is only declared but not initialized
            driver.Url = "https://www.google.com";
        }

        [Test]
        public void IndexOutOfRangeExceptionTest()
        {
            //String of Array having 3 members
            string[] numbers = { "One", "Two", "Three" };

            //Try block
            try
            {
                //Below line of code will throw IndexOutOfRangeException
                //As array has 3 members are we are trying of access 4th member
                //Index for array member to access starts from 0
                Console.WriteLine(numbers[3]);
            }
            //Catch Method having General Exception
            catch (Exception e)
            {
                //Printing of StackTrace
                Console.WriteLine(e.StackTrace);
                //Printing of Message
                Console.WriteLine(e.Message);
            }
        }

        [Test]
        public void DivideByZeroExceptionTest()
        {
            //Local variable Declaration and initialization
            int a = 1;
            int b = 0;
            int c = 2;
            
            //Check if b variable is having is non-zero value, only then perform division
            if (b != 0)
            {
                //Performing division and storing the output of division to variable c
                //This will override the pervious value of c variable
                c = a / b;
            }

            //Printing of c variable value
            Console.WriteLine("Value of c is : " + c);
            //Below line of code will throw DivideByZeroException, as b variable value is 0
            //DivideByZeroException is not catched as it's not wrapped in try catch block
            Console.WriteLine(a / b);
        }

        [Test]
        public void ArgumentOutOfRangeExceptionTest()
        {
            //Local variable
            //Creating object of ChromeDriver and storing it in IWebDriver interface reference container
            IWebDriver driver = new ChromeDriver(@"E:\Drivers\chromedriver_win32");
            //Navigation to URL
            driver.Url = "https://www.seleniumeasy.com/test/table-sort-search-demo.html";

            //Try block
            try
            {
                //FindingElements matching with specified identifier and storing it in collection
                ReadOnlyCollection<IWebElement> tableRows = driver.FindElements(By.XPath("//tbody/descendant::tr"));

                //Below line of code will throw ArgumentOutOfRangeException
                //As we are trying to access 12th member of collection, collection are 0 based index
                string tableRow = tableRows[11].Text;
                
                //This line of code will never be reached
                Console.WriteLine(tableRow);
            }
            //Catch Method having General Exception
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.Pass();
            }
        }

        [Test]
        public void TryCatchFinallyTest()
        {
            //Try block
            try
            {
                int x = 1;
                int y = 0;
                //Below line of code will throw DivideByZeroException
                Console.WriteLine(x / y);
            }
            //Catch Method having General Exception
            catch (Exception)
            {
                Console.WriteLine("In Exception Method");
            }
            //Finally block will always be executed
            //Irrespective of Exception is thrown or not
            finally
            {
                Console.WriteLine("In Finally Block");
            }
        }

        [Test]
        public void MultipleCatchTest()
        {
            try
            {
                int x = 1;
                int y = 0;
                //Below line of code will throw DivideByZeroException
                Console.WriteLine(x / y);
            }
            //Catch Method having Specialized Exception
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("In Index Out Of Range Exception Method");
            }
            //Catch Method having Specialized Exception
            catch (DivideByZeroException)
            {
                Console.WriteLine("In Divide By Zero Exception Method");
            }
            //Catch Method having Generalized Exception
            catch (Exception)
            {
                Console.WriteLine("In Exception Method");
            }
            //Finally block will always be executed
            //Irrespective of Exception is thrown or not
            finally
            {
                Console.WriteLine("In Finally Block");
            }
        }

        [Test]
        public void TryFinallyTest()
        {
            //Try block
            try
            {
                int x = 1;
                int y = 0;
                Console.WriteLine(x / y);
            }
            //Finally Block
            finally
            {
                Console.WriteLine("In Finally Block");
            }
        }

        [Test]
        public void ExceptionThrowKeywordTest()
        {
            try
            {
                int x = 1;
                int y = 0;
                //throw is keyword in C#
                //When we use throw keyword then that line of code will throw exception and below line of codes
                //Will never be executed
                throw new Exception();
                Console.WriteLine(x / y);
            }
            //This example has only Finally block
            finally
            {
                Console.WriteLine("In Finally Block");
            }
        }
    }
}
