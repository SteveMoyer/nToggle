using System;

using nToggle;
using NUnit.Framework;
namespace nToggleTest
{
   [TestFixture]
    public class AppSettingsToggleRepositoryTest
    {
        [Test]
        public void ShouldReturnFalseWhenFalseInConfig()
        {
            var repo = new AppSettingsFeatureToggleRepository();
            Assert.AreEqual(false, repo.GetToggleStatus("TestFeatureOff"));
        }
        [Test]
        public void ShouldReturnTrueWhenTrueInConfig()
        {
            var repo = new AppSettingsFeatureToggleRepository();
            Assert.AreEqual(true, repo.GetToggleStatus("TestFeatureOn"));
        }
        [Test]
        public void ShouldReturnFalseIfNotInConfig()
        {
            var repo = new AppSettingsFeatureToggleRepository();
            Assert.AreEqual(false, repo.GetToggleStatus("NotPresent"));
        }
    }
}
