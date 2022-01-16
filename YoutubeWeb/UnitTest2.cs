using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System.Net;



namespace YoutubeWeb
{
    [TestClass]
    public class YoutubeSearch
    {
        [TestMethod]
        public void TestSearch()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.youtube.com/");
            IWebElement searchBar= driver.FindElement(By.XPath("//input[@id='search']"));
            searchBar.SendKeys("Volvi Bad Bunny");
            System.Threading.Thread.Sleep(100);
            IWebElement searchButton = driver.FindElement(By.Id("search-icon-legacy"));
            searchButton.Click();
            System.Threading.Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IEnumerable<IWebElement> videosDisplayed = driver.FindElements(By.CssSelector("div#dismissible"));
            Console.WriteLine(videosDisplayed.Count());
            driver.Close();
            
        }

        public void API()
        {
            string html;
            string url = "https://reqres.in/api/users/2";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            Console.WriteLine(response); 
        }
    }
}
