using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace nToggleWebTests
{
    [TestFixture]
    public class WebFeatureToggleWebTest
    {
        private const string BaseAddress = "http://localhost:1194/";
        IWebDriver driver;
        [SetUp]
        public void setup() 
        {
            driver = new FirefoxDriver();
        }

        [TearDown]
        public void teardown()
        {
            driver.Close();
        }

        [Test]
        public void ShouldShowEnabledAndHideremoved()
        {
            
            driver.Url = BaseAddress + "ToggledOn.aspx";
            var enabledelement =driver.FindElement(By.Id("enabledby"));
            Assert.IsTrue(enabledelement != null,"enabled control was removed");

            try
            {
                driver.FindElement(By.Id("removedby"));
                Assert.Fail("removed control was not removed");
            }
            catch (NoSuchElementException)
            {
            }
        }

        [Test]
        public void ShouldHidEnabledAndShowRemovedWhenFeatureIsOff()
        {
            driver.Url = BaseAddress + "ToggledOff.aspx";
            var enabledelement = driver.FindElement(By.Id("removedby"));
            Assert.IsTrue(enabledelement != null, "enabled control was removed");

            try
            {
                driver.FindElement(By.Id("enabledby"));
                Assert.Fail("removed control was not removed");
            }
            catch (NoSuchElementException)
            {
            }


        }
    }
}
                        