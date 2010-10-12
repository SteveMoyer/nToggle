using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using nToggle;
namespace nToggleTest
{
   [TestClass]
    public class AppSettingsToggleRepositoryTest
    {
        [TestMethod]
        public void ShouldReturnFalseWhenFalseInConfig()
        {
            var repo = new AppSettingsToggleRepository();
            Assert.AreEqual(false, repo.GetToggleStatus("TestFeatureOff"));
        }
        [TestMethod]
        public void ShouldReturnTrueWhenTrueInConfig()
        {
            var repo = new AppSettingsToggleRepository();
            Assert.AreEqual(true, repo.GetToggleStatus("TestFeatureOn"));
        }
        [TestMethod]
        public void ShouldReturnFalseIfNotInConfig()
        {
            var repo = new AppSettingsToggleRepository();
            Assert.AreEqual(false, repo.GetToggleStatus("NotPresent"));
        }
    }
}
