using System;

using nToggle;
using Moq;
using NUnit.Framework;
namespace nToggleTest
{
    [TestFixture]
    public class FeatureToggleFactoryTest
    {

        private FeatureToggleFactory _Factory;
        private Mock<IFeatureToggleRepository> _repo ;
        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IFeatureToggleRepository>();
            _Factory = new FeatureToggleFactory(_repo.Object);

        }

        [Test]
        public void ShouldReturnToggledOnWhenOn()
        {

            _repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(true);
            Assert.AreEqual(true, _Factory.GetFeatureStatus("fake").IsOn);
        }
        [Test]
        public void ShouldReturnNotToggledOnWhenOff()
        {
            _repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(false);
            Assert.AreEqual(false, _Factory.GetFeatureStatus("fake").IsOn);
        }
        [Test]
        public void ShouldReturnToggledOnWhenOffAndReversed()
        {
            _repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(false);
            Assert.AreEqual(true, _Factory.GetFeatureStatus("fake", true).IsOn);
        }
        [Test]
        public void ShouldReturnNotToggledOnWhenOnAndReversed()
        {
            _repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(true);

            Assert.AreEqual(false, _Factory.GetFeatureStatus("fake", true).IsOn);
        }
    }
}
