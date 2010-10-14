using System;
using System.Web.UI.WebControls;
using nToggle;
using Moq;
using NUnit.Framework;

namespace nToggleTest
{
    [TestFixture]
    public class FeatureToggleTest
    {
        private Mock<IFeatureStatusFactory> _MockFeatureStatusFactory;
        private FeatureToggle _FeatureToggle;
        
        [SetUp]
        public void Setup()
        {
            _MockFeatureStatusFactory = new Mock<IFeatureStatusFactory>();
            _FeatureToggle = new FeatureToggle(_MockFeatureStatusFactory.Object);
        }
        
        [Test]
        public void ShouldNotClearControlsWhenFeatureEnabled()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.EnabledBy = "fake";
            _MockFeatureStatusFactory.Setup(fact => fact.GetFeatureStatus("fake",false)).Returns(new FeatureStatus(true));
            _FeatureToggle.ApplyToggle();

            Assert.AreEqual(1, _FeatureToggle.Controls.Count);
        }

        [Test]
        public void ShouldClearControlsWhenFeatureNotEnabled()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.EnabledBy = "fake";
            _MockFeatureStatusFactory.Setup(fact => fact.GetFeatureStatus("fake", false)).Returns(new FeatureStatus(false));
            _FeatureToggle.ApplyToggle();

            Assert.AreEqual(0, _FeatureToggle.Controls.Count);
        }

        [Test]
        public void ShouldClearControlsWhenFeatureRemoved()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.RemovedBy = "fake";
            _MockFeatureStatusFactory.Setup(fact => fact.GetFeatureStatus("fake", true)).Returns(new FeatureStatus(false));
            _FeatureToggle.ApplyToggle();

            Assert.AreEqual(0, _FeatureToggle.Controls.Count);
            
        }
        [Test]
        public void ShouldNotClearControlsWhenFeatureNotRemoved()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.RemovedBy = "fake";
            _MockFeatureStatusFactory.Setup(fact => fact.GetFeatureStatus("fake", true)).Returns(new FeatureStatus(true));
            _FeatureToggle.ApplyToggle();

            Assert.AreEqual(1, _FeatureToggle.Controls.Count);
        }
        
        [Test, ExpectedException(typeof(InvalidMarkupException))]
        public void ShouldThrowExceptionWhenBothEnabledAndRemovedByUsed()
        {
            _FeatureToggle.RemovedBy = "fake";
            _FeatureToggle.EnabledBy = "fake";
            _FeatureToggle.ApplyToggle();
        }
        [Test, ExpectedException(typeof(InvalidMarkupException))]
        public void ShouldThrowExceptionWhenNeitherEnabledOrRemovedByUsed()
        {
            _FeatureToggle.ApplyToggle();
        }

    }
}
