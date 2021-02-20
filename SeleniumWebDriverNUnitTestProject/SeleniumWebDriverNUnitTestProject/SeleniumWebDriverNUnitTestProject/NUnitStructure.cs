using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriverNUnitTestProject
{
    class NUnitStructure
    {
        //By Adding OneTimeSetUp attribute to a method, this method will get executed only once
        //If you run single or multiple tests, OneTimeSetUp method would get executed only once
        [OneTimeSetUp]
        public void OTSU()
        {
            //For Actual Application Under test, One time setup will consists of things depending upon the business requirement
            //Use of One time set up would be having things
            //For eg. Hosting of application before running tests
            //Creation of fresh Database and pointing it to hosted application
            Console.WriteLine("You are in One time setup");
        }

        //By Adding Setup attribute to a method, this method will get executed before each Test Method
        [SetUp]
        public void Setup()
        {
            //Pre-Conditions which needs to be executed before each test
            //For eg. Creation of browser instance
            //Navigating to URL
            Console.WriteLine("This method would be executed before each test");
        }

        //From the requirements phase of software developement life cycle, QA derives manual test cases against the requirments
        //Automation testing is automating of manual test case
        //By Adding Test attribute to a method, this method will be considered as Automated Test Method
        //By adding a Test attribute to a method, it will be listed in Test explorer
        [Test]
        public void Test1()
        {   
            //Manual test can be equivalent to automated Test method
            //All the manual test steps can be covered in this method
            //For verification different assertions would be added
            Console.WriteLine("You are in Test 1");
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine("You are in Test 2");
        }

        //By Adding TearDown attribute to a method, this method will get executed after each Test Method
        [TearDown]
        public void Teardown()
        {
            //Post-Conditions which needs to be executed after each test
            //For eg. closing of browser
            Console.WriteLine("This method would be executed after each test");
        }

        //By Adding OneTimeTearDown attribute to a method, this method will get executed only once
        //If you run single or multiple tests, OneTimeTearDown method would get executed only once
        [OneTimeTearDown]
        public void OTTD()
        {
            //For eg.Removing the Hosted site
            //Droping Database
            Console.WriteLine("You are in One time tear down");
        }
    }
}
