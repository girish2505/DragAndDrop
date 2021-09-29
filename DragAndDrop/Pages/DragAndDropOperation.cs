using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragAndDrop.Pages
{
    public class DragOperation:Base.BaseClass
    {
        public static void DragandDrop()
        {   		
            IWebElement element1 = driver.FindElement(By.XPath("//*[@id='credit2']/a"));
		
            IWebElement element2 = driver.FindElement(By.XPath("//*[@id='bank']/li"));

            Actions action = new Actions(driver);
            action.DragAndDrop(element1, element2).Build().Perform();
            System.Threading.Thread.Sleep(2000);

            IWebElement dropElement = driver.FindElement(By.XPath("//*[@id='bank']/li"));
            string textTo = dropElement.Text;

            Console.WriteLine(textTo);
            if (textTo.Equals(" BANK"))
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            System.Threading.Thread.Sleep(200);

            action.MoveToElement(element1);
            System.Threading.Thread.Sleep(200);
        }
    }
}
