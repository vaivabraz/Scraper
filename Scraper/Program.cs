using OpenQA.Selenium.Firefox;
using System;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium;

namespace Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.gismeteo.lt/";
            Scraper myScraper = new Scraper();
            myScraper.DoAllJob(url);
        }
    }

    public class Scraper
    {
        private string url { get; set; }
        private string firefoxDriver= @"C:\Users\Vaiva\Documents\MyDrivers";
        private string firefoxExe = @"C:\Program Files\Mozilla Firefox\firefox.exe";
        IWebDriver _driver;

        public void DoAllJob(string url)
        {
            this.url = url;

            Do();
        }

        public void Do()
        {

            _driver = new PhantomJSDriver();
            _driver.Navigate().GoToUrl(url);
            IWebElement searchField = _driver.FindElement(By.ClassName("search_input"));
            searchField.SendKeys("Vilnius");
            searchField.SendKeys(Keys.Enter);
            string newUrl = _driver.Url;
            string endingReal = "-PR";
            
            string ending = "-4230/";

            if (newUrl.EndsWith(ending))
            {
                newUrl = newUrl.Substring(0, newUrl.LastIndexOf(ending));
                    //inputText.Substring(0, inputText.LastIndexOf(item));
            }

            //IWebElement coverage = _driver.FindElement(By.ClassName(""));
            //coverage.GetText()
        }

        public void OpenUrl()
        {
            

        }

    }
}
