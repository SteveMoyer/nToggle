using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.UI.WebControls;
using nToggle;
using Moq;

namespace nToggleTest
{
    [TestClass]
    public class FeatureToggleTest
    {
        private Mock<IFeatureStatusFactory> _MockFeatureStatusFactory;
        private nToggle.FeatureToggle _FeatureToggle;
        public FeatureToggleTest()
        {
            _MockFeatureStatusFactory = new Mock<IFeatureStatusFactory>();
            _FeatureToggle = new FeatureToggle(_MockFeatureStatusFactory.Object);
        }
        [TestMethod]
        public void ShouldNotClearControlsWhenFeatureEnabled()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.EnabledBy = "fake";
            _MockFeatureStatusFactory.Setup(fact => fact.GetFeatureStatus("fake",false)).Returns(new FeatureStatus(true));
            _FeatureToggle.ApplyToggle();

            Assert.AreEqual(1, _FeatureToggle.Controls.Count);
            

        }
        [TestMethod]
        public void ShouldClearControlsWhenFeatureNotEnabled()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.EnabledBy = "fake";
            _MockFeatureStatusFactory.Setup(fact => fact.GetFeatureStatus("fake", false)).Returns(new FeatureStatus(false));
            _FeatureToggle.ApplyToggle();

            Assert.AreEqual(0, _FeatureToggle.Controls.Count);


        }
        [TestMethod]
        public void ShouldClearControlsWhenFeatureRemoved()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.RemovedBy = "fake";
            _MockFeatureStatusFactory.Setup(fact => fact.GetFeatureStatus("fake", true)).Returns(new FeatureStatus(false));
            _FeatureToggle.ApplyToggle();

            Assert.AreEqual(0, _FeatureToggle.Controls.Count);


        }
        [TestMethod]
        public void ShouldNotClearControlsWhenFeatureNotRemoved()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.RemovedBy = "fake";
            _MockFeatureStatusFactory.Setup(fact => fact.GetFeatureStatus("fake", true)).Returns(new FeatureStatus(true));
            _FeatureToggle.ApplyToggle();

            Assert.AreEqual(1, _FeatureToggle.Controls.Count);


        }
    }
}
