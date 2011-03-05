using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace nToggleWebTests
{
    [TestFixture]
    public class WebFeatureToggleWebTest
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }

        #endregion

        private const string BaseAddress = "http://localhost:1194/";
        private IWebDriver _driver;

        [Test]
        public void ShouldHidEnabledAndShowRemovedWhenFeatureIsOff()
        {
            _driver.Url = BaseAddress + "ToggledOff.aspx";
            IWebElement enabledelement = _driver.FindElement(By.Id("removedby"));
            Assert.IsTrue(enabledelement != null, "enabled control was removed");

            try
            {
                _driver.FindElement(By.Id("enabledby"));
                Assert.Fail("removed control was not removed");
            }
            catch (NoSuchElementException)
            {
            }
        }

        [Test]
        public void ShouldShowEnabledAndHideremoved()
        {
            _driver.Url = BaseAddress + "ToggledOn.aspx";
            IWebElement enabledelement = _driver.FindElement(By.Id("enabledby"));
            Assert.IsTrue(enabledelement != null, "enabled control was removed");

            try
            {
                _driver.FindElement(By.Id("removedby"));
                Assert.Fail("removed control was not removed");
            }
            catch (NoSuchElementException)
            {
            }
        }
    }
}