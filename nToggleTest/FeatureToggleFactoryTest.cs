using Moq;
using nToggle;
using NUnit.Framework;

namespace nToggleTest
{
    [TestFixture]
    public class FeatureToggleFactoryTest
    {
        #region Setup/Teardown

        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IFeatureToggleRepository>();
            _factory = new FeatureToggleFactory(_repo.Object);
        }

        #endregion

        private FeatureToggleFactory _factory;
        private Mock<IFeatureToggleRepository> _repo;

        [Test]
        public void ShouldReturnNotToggledOnWhenOff()
        {
            _repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(false);
            Assert.AreEqual(false, _factory.GetFeatureToggle("fake").IsOn);
        }

        [Test]
        public void ShouldReturnNotToggledOnWhenOnAndReversed()
        {
            _repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(true);

            Assert.AreEqual(false, _factory.GetFeatureToggle("fake", true).IsOn);
        }

        [Test]
        public void ShouldReturnToggledOnWhenOffAndReversed()
        {
            _repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(false);
            Assert.AreEqual(true, _factory.GetFeatureToggle("fake", true).IsOn);
        }

        [Test]
        public void ShouldReturnToggledOnWhenOn()
        {
            _repo.Setup(repos => repos.GetToggleStatus("fake")).Returns(true);
            Assert.AreEqual(true, _factory.GetFeatureToggle("fake").IsOn);
        }
    }
}