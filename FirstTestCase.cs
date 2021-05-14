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
            string testURL = "https://www.seleniumeasy.com/test/window-popup-modal-demo.html";

            [Fact]
            public void TestPopupWindow()
            {

                ChromeOptions chrome = new ChromeOptions();
                chrome.AddArguments("headless");
                chrome.AddArguments("--window-size=1920,1080");

                IWebDriver driver = new ChromeDriver(chrome);
                driver.Url = testURL;

                IWebElement linkToNewWindow = driver.FindElement(By.XPath("//a[text()='  Follow On Twitter ']"));
                linkToNewWindow.Click();

                driver.SwitchTo().Window(driver.WindowHandles[1]);

                IWebElement newWindowText = new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                        .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[text()='Log in']")));
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
