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
        private Mock<IFeatureStatus> _MockFeatureStatus;
        private Mock<IFeatureStatusFactory> _MockFeatureStatusFactory;
        private FeatureToggle _FeatureToggle;

        [SetUp]
        public void Setup()
        {
            _MockFeatureStatusFactory = new Mock<IFeatureStatusFactory>();
            _FeatureToggle = new FeatureToggle(_MockFeatureStatusFactory.Object);
            _MockFeatureStatus = new Mock<IFeatureStatus>();
        }

        [Test]
        public void ShouldNotClearControlsWhenFeatureEnabled()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.EnabledBy = "fake";
            _MockFeatureStatusFactory.Setup(fact => fact.GetFeatureStatus("fake", false)).Returns(new FeatureStatus(true));
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

        [Test]
        public void RunActionWhenEnabledShouldPassThroughToFeatureStatus()
        {
            _FeatureToggle.RemovedBy = "fake";
            _MockFeatureStatusFactory.Setup(fact => fact.GetFeatureStatus("fake", true)).Returns(_MockFeatureStatus.Object);
            Action action = () => { };
            
            _FeatureToggle.ApplyToggle();
            _FeatureToggle.RunActionWhenEnabled(action);
            _MockFeatureStatus.Verify(status => status.RunActionIfOn(action));

        }

        [Test]
        public void RunActionWhenDisabledShouldPassThroughToFeatureStatus()
        {
            _FeatureToggle.RemovedBy = "fake";
            _MockFeatureStatusFactory.Setup(fact => fact.GetFeatureStatus("fake", true)).Returns(_MockFeatureStatus.Object);
            Action action = () => { };
          
            _FeatureToggle.ApplyToggle();
            _FeatureToggle.RunActionWhenDisabled(action);
            _MockFeatureStatus.Verify(status => status.RunActionIfOff(action));

        }


    }
}
