using System.Collections.Generic;
using Moq;
using nToggle;
using NUnit.Framework;

namespace nToggleTest
{
    [TestFixture]
    public class FeatureToggleFactoryTest
    {
       
        [SetUp]
        public void Setup()
        {
            _toggleRepositoryDictionary = new Dictionary<string, IFeatureToggleRepository>();
            _repo = new Mock<IFeatureToggleRepository>();
            _factory = new FeatureToggleFactory(_toggleRepositoryDictionary);
        }

       
        private FeatureToggleFactory _factory;
        private Mock<IFeatureToggleRepository> _repo;
        private Dictionary<string, IFeatureToggleRepository> _toggleRepositoryDictionary;
        
        [Test]
        public void ShouldReturnNotToggledOnWhenOff()
        {
            _toggleRepositoryDictionary.Add("fake",_repo.Object);
            _repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(false);
            Assert.AreEqual(false, _factory.GetFeatureToggle("fake").IsOn);
        }


        [Test]
        public void ShouldReturnFalseWhenToggleNotConfigured()
        {
            Assert.AreEqual(false, _factory.GetFeatureToggle("fake").IsOn);
        }

        [Test]
        public void ShouldReturnNotToggledOnWhenOnAndReversed()
        {
            _toggleRepositoryDictionary.Add("fake", _repo.Object);
           
            _repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(true);

            Assert.AreEqual(false, _factory.GetFeatureToggle("fake", true).IsOn);
        }

        [Test]
        public void ShouldReturnToggledOnWhenOffAndReversed()
        {
            _toggleRepositoryDictionary.Add("fake", _repo.Object);
           
            _repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(false);
            Assert.AreEqual(true, _factory.GetFeatureToggle("fake", true).IsOn);
        }

        [Test]
        public void ShouldReturnToggledOnWhenOn()
        {
            _toggleRepositoryDictionary.Add("fake", _repo.Object);
           
            _repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(true);
            Assert.AreEqual(true, _factory.GetFeatureToggle("fake").IsOn);
        }
    }
}