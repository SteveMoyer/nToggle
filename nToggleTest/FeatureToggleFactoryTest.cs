using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nToggle;
namespace nToggleTest
{
    [TestClass]
    public class FeatureToggleFactoryTest
    {
        
        [TestMethod]
        public void ShouldReturnToggledOnWhenOn()
        {
            var repo = new Moq.Mock<IFeatureToggleRepository>();
            repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(true);
            var factory =new FeatureToggleFactory(repo.Object);
            Assert.AreEqual(true, factory.GetFeatureStatus("fake").IsOn);
        }
        [TestMethod]
        public void ShouldReturnNotToggledOnWhenOff()
        {
            var repo = new Moq.Mock<IFeatureToggleRepository>();
            repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(false);
            var factory = new FeatureToggleFactory(repo.Object);
            Assert.AreEqual(false, factory.GetFeatureStatus("fake").IsOn);
        }
        [TestMethod]
        public void ShouldReturnToggledOnWhenOffAndReversed()
        {
            var repo = new Moq.Mock<IFeatureToggleRepository>();
            repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(false);
            var factory = new FeatureToggleFactory(repo.Object);
            Assert.AreEqual(true, factory.GetFeatureStatus("fake",true).IsOn);
        }
        [TestMethod]
        public void ShouldReturnNotToggledOnWhenOnAndReversed()
        {
            var repo = new Moq.Mock<IFeatureToggleRepository>();
            repo.Setup<bool>(repos => repos.GetToggleStatus("fake")).Returns(true);
            var factory = new FeatureToggleFactory(repo.Object);
            Assert.AreEqual(false, factory.GetFeatureStatus("fake",true).IsOn);
        }
    }
}
