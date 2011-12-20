using System.Collections.Generic;
using Moq;
using nToggle;
using NUnit.Framework;

namespace nToggleTest
{
    [TestFixture]
    public class FeatureToggleFactoryTest
    {
        private FeatureToggleFactory factory;
        private Mock<IFeatureToggleRepository> repo;
        private Dictionary<string, IFeatureToggleRepository> toggleRepositoryDictionary;
        private Dictionary<string, bool> toggleGlobalSettingDictionary;
        
        
        [SetUp]
        public void Setup()
        {
            toggleRepositoryDictionary = new Dictionary<string, IFeatureToggleRepository>();
            toggleGlobalSettingDictionary = new Dictionary<string, bool>();
            repo = new Mock<IFeatureToggleRepository>();
            factory = new FeatureToggleFactory(toggleRepositoryDictionary, toggleGlobalSettingDictionary);
        }

        [Test]
        public void ShouldReturnNotToggledOnWhenOff()
        {
            toggleRepositoryDictionary.Add("fake",repo.Object);
            repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(false);
            Assert.AreEqual(false, factory.GetFeatureToggle("fake").IsOn);
        }

        [Test]
        public void ShouldReturnFalseWhenToggleNotConfigured()
        {
            Assert.AreEqual(false, factory.GetFeatureToggle("fake").IsOn);
        }

        [Test]
        public void ShouldReturnNotToggledOnWhenOnAndReversed()
        {
            toggleRepositoryDictionary.Add("fake", repo.Object);
           
            repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(true);

            Assert.AreEqual(false, factory.GetFeatureToggle("fake", true).IsOn);
        }

        [Test]
        public void ShouldReturnToggledOnWhenOffAndReversed()
        {
            toggleRepositoryDictionary.Add("fake", repo.Object);
           
            repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(false);
            Assert.AreEqual(true, factory.GetFeatureToggle("fake", true).IsOn);
        }

        [Test]
        public void ShouldReturnToggledOnWhenOn()
        {
            toggleRepositoryDictionary.Add("fake", repo.Object);
           
            repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(true);
            Assert.AreEqual(true, factory.GetFeatureToggle("fake").IsOn);
        }

        [Test]
        public void IsGlobalOnShouldReturnTrueWhenSetToTrueInConfig()
        {
            var featureName = "condition";
            toggleGlobalSettingDictionary.Add(featureName, true);
            toggleRepositoryDictionary.Add(featureName, repo.Object);
            Assert.IsTrue(factory.GetConditionalFeatureToggle(featureName).IsGlobalOn);
        }

        [Test]
        public void IsGlobalOnShouldReturnTrueWhenSetToFalseInConfigAndNeedToBeReversed()
        {
            var featureName = "condition";
            toggleGlobalSettingDictionary.Add(featureName, false);
            toggleRepositoryDictionary.Add(featureName, repo.Object);
            Assert.IsTrue(factory.GetConditionalFeatureToggle(featureName, true).IsGlobalOn);
        }

        [Test]
        public void IsGlobalOnShouldReturnFalseWhenSetToTrueInConfigAndNeedToBeReversed()
        {
            var featureName = "condition";
            toggleGlobalSettingDictionary.Add(featureName, true);
            toggleRepositoryDictionary.Add(featureName, repo.Object);
            Assert.IsFalse(factory.GetConditionalFeatureToggle(featureName, true).IsGlobalOn);
        }

        [Test]
        public void IsGlobalOnShouldReturnFaleWhenSetToFalseInConfig()
        {
            var featureName = "condition";
            toggleGlobalSettingDictionary.Add(featureName, false);
            toggleRepositoryDictionary.Add(featureName, repo.Object);
            Assert.IsFalse(factory.GetConditionalFeatureToggle(featureName).IsGlobalOn);
        }

        [Test]
        public void IsGlobalOnShouldReturnFaleWhenItIsNotSetInConfig()
        {
            Assert.IsFalse(factory.GetConditionalFeatureToggle("NotExist").IsGlobalOn);
        }

        [Test]
        public void IsGlobalOnShouldReturnTrueWhenItIsNotSetInConfigAndNeedToBeReversed()
        {
            Assert.IsTrue(factory.GetConditionalFeatureToggle("NotExist", true).IsGlobalOn);
        }
    }
}