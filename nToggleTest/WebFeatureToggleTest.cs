using System;
using System.Web.UI.WebControls;
using nToggle;
using Moq;
using NUnit.Framework;

namespace nToggleTest
{
    [TestFixture]
    public class WebFeatureToggleTest
    {
        private Mock<IFeatureToggle> _MockFeatureToggle;
        private Mock<IFeatureToggleFactory> _MockFeatureToggleFactory;
        private WebFeatureToggle _FeatureToggle;

        [SetUp]
        public void Setup()
        {
            _MockFeatureToggleFactory = new Mock<IFeatureToggleFactory>();
            _FeatureToggle = new WebFeatureToggle(_MockFeatureToggleFactory.Object);
            _MockFeatureToggle = new Mock<IFeatureToggle>();
        }

        [Test]
        public void ShouldNotClearControlsWhenFeatureEnabled()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.EnabledBy = "fake";
            _MockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", false)).Returns(new FeatureToggle(true));
            _FeatureToggle.ApplyToggle();

            Assert.AreEqual(1, _FeatureToggle.Controls.Count);
        }

        [Test]
        public void ShouldClearControlsWhenFeatureNotEnabled()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.EnabledBy = "fake";
            _MockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", false)).Returns(new FeatureToggle(false));
            _FeatureToggle.ApplyToggle();

            Assert.AreEqual(0, _FeatureToggle.Controls.Count);
        }

        [Test]
        public void ShouldClearControlsWhenFeatureRemoved()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.RemovedBy = "fake";
            _MockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", true)).Returns(new FeatureToggle(false));
            _FeatureToggle.ApplyToggle();

            Assert.AreEqual(0, _FeatureToggle.Controls.Count);

        }

        [Test]
        public void ShouldNotClearControlsWhenFeatureNotRemoved()
        {
            _FeatureToggle.Controls.Add(new Literal());
            _FeatureToggle.RemovedBy = "fake";
            _MockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", true)).Returns(new FeatureToggle(true));
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
        public void RunActionWhenEnabledShouldPassThroughToFeatureToggle()
        {
            _FeatureToggle.RemovedBy = "fake";
            _MockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", true)).Returns(_MockFeatureToggle.Object);
            Action action = () => { };
            
            _FeatureToggle.ApplyToggle();
            _FeatureToggle.RunActionWhenEnabled(action);
            _MockFeatureToggle.Verify(status => status.RunActionIfOn(action));

        }

        [Test]
        public void RunActionWhenDisabledShouldPassThroughToFeatureToggle()
        {
            _FeatureToggle.RemovedBy = "fake";
            _MockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", true)).Returns(_MockFeatureToggle.Object);
            Action action = () => { };
          
            _FeatureToggle.ApplyToggle();
            _FeatureToggle.RunActionWhenDisabled(action);
            _MockFeatureToggle.Verify(status => status.RunActionIfOff(action));

        }


    }
}
