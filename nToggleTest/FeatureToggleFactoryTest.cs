using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nToggle;
using Moq;
namespace nToggleTest
{
    [TestClass]
    public class FeatureToggleFactoryTest
    {

        private FeatureStatusFactory _Factory;
        private Mock<IFeatureStatusRepository> _repo ;
        public FeatureToggleFactoryTest() 
        {
            _repo = new Moq.Mock<IFeatureStatusRepository>();
            _Factory = new FeatureStatusFactory(_repo.Object);
            
        }

        [TestMethod]
        public void ShouldReturnToggledOnWhenOn()
        {

            _repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(true);
            Assert.AreEqual(true, _Factory.GetFeatureStatus("fake").IsOn);
        }
        [TestMethod]
        public void ShouldReturnNotToggledOnWhenOff()
        {
            _repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(false);
            Assert.AreEqual(false, _Factory.GetFeatureStatus("fake").IsOn);
        }
        [TestMethod]
        public void ShouldReturnToggledOnWhenOffAndReversed()
        {
            _repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(false);
            Assert.AreEqual(true, _Factory.GetFeatureStatus("fake", true).IsOn);
        }
        [TestMethod]
        public void ShouldReturnNotToggledOnWhenOnAndReversed()
        {
            _repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(true);

            Assert.AreEqual(false, _Factory.GetFeatureStatus("fake", true).IsOn);
        }
    }
}
