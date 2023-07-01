using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpTutorial
{
    [TestFixture]
    public class SeleniumCSharpTutorial04
    {
        [Test]
        [Author("Jarończyk","krzysztof.jaronczyk@microsoft.wsei.edu.pl")]
        [Description("Facebook login verify")]
        [TestCaseSource("DataDrivenTesting")]
        public void Test1(string urlName)
        {
            IWebDriver driver = null;
            try
            {
                var options = new ChromeOptions();
                // Zmienic sciezke jesli nie dziala
                options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                driver = new ChromeDriver(options);
                driver.Manage().Window.Maximize();
                //driver.Url = "https://www.facebook.com/";
                driver.Url = urlName;
                IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
                //IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='abcd']"));
                emailTextField.SendKeys("Selenium C#");
                driver.Quit();
            }
            catch (Exception e)
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile("E:\\WSEI-resources\\SeleniumCSharp\\SeleniumCSharpTutorial\\Screenshots\\s1.jpg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }

            
        }

        static IList DataDrivenTesting()
        {
            ArrayList list = new ArrayList();
            list.Add("https://www.facebook.com/");
            //list.Add("https://www.youtube.com/");
            //list.Add("https://www.gmail.com/");
            return list;
        }

        //[Test]
        //[Author("Jarończyk","krzysztof.jaronczyk@microsoft.wsei.edu.pl")]
        //[Description("Facebook login verify")]
        //public void Test2()
        //{
        //    var options = new ChromeOptions();
        //    // Zmienic sciezke jesli nie dziala
        //    options.BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
        //    IWebDriver driver = new ChromeDriver(options);
        //    driver.Manage().Window.Maximize();
        //    driver.Url = "https://www.facebook.com/";
        //    IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
        //    emailTextField.SendKeys("Selenium C#");
        //}
    }
}
