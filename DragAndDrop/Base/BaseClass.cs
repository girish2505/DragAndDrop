using NLog.Fluent;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragAndDrop.Base
{
    public class BaseClass
    {
        public static IWebDriver driver;
        [SetUp]
        public void setup()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("http://demo.guru99.com/test/drag_drop.html");
                System.Threading.Thread.Sleep(2000);

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                string title = (string)js.ExecuteScript("return document.title");
                Console.WriteLine(title);

                ((IJavaScriptExecutor)driver).ExecuteScript("scroll(0,16000)");
                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
        public static void Takescreenshot()
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\girish.v\source\repos\DragAndDrop\DragAndDrop\Screenshot\test.png");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
