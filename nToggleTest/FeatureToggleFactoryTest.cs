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
        
        [SetUp]
        public void Setup()
        {
            toggleRepositoryDictionary = new Dictionary<string, IFeatureToggleRepository>();
            repo = new Mock<IFeatureToggleRepository>();
            factory = new FeatureToggleFactory(toggleRepositoryDictionary);
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
    }
}