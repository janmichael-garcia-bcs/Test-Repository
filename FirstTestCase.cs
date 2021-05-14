using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace Test_Repository
{
    public class FirstTestCase
    {
        public class Test
        {
            string testURL = "http://the-internet.herokuapp.com/windows";

            [Fact]
            public void TestNewWindow()
            {

                ChromeOptions chrome = new ChromeOptions();
                //chrome.AddArguments("headless");
                chrome.AddArguments("--window-size=1920,1080");

                IWebDriver driver = new ChromeDriver(chrome);
                driver.Url = testURL;

                IWebElement linkToNewWindow = driver.FindElement(By.XPath("//a[text()='Click Here']"));
                linkToNewWindow.Click();

                IWebElement newWindowText = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h3")));
                if (newWindowText.Text.Equals("New Window"))
                {
                    Console.WriteLine("Passed");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
                
                driver.Close();
                driver.Quit();
            }
        }
    }
}
