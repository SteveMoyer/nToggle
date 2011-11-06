using System;
using System.Web.UI;
using Moq;
using nToggle;
using NUnit.Framework;

namespace nToggleTest
{
    [TestFixture]
    public class WebFeatureToggleTest
    {
       
        [SetUp]
        public void Setup()
        {
            _mockFeatureToggleFactory = new Mock<IFeatureToggleFactory>();
            _featureToggle = new WebFeatureToggle(_mockFeatureToggleFactory.Object);
            _featureToggle.Controls.Add(new LiteralControl());
            _mockFeatureToggle = new Mock<IFeatureToggle>();
        }

       
        private Mock<IFeatureToggle> _mockFeatureToggle;
        private Mock<IFeatureToggleFactory> _mockFeatureToggleFactory;
        private WebFeatureToggle _featureToggle;

        [Test]
        public void RunActionWhenDisabledShouldPassThroughToFeatureToggle()
        {
            _featureToggle.RemovedBy = "fake";
            _mockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", true)).Returns(
                _mockFeatureToggle.Object);
            Action action = () => { };

            _featureToggle.ApplyToggle();
            _featureToggle.RunActionWhenDisabled(action);
            _mockFeatureToggle.Verify(status => status.RunActionIfOff(action));
        }

        [Test]
        public void RunActionWhenEnabledShouldPassThroughToFeatureToggle()
        {
            _featureToggle.RemovedBy = "fake";
            _mockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", true)).Returns(
                _mockFeatureToggle.Object);
            Action action = () => { };

            _featureToggle.ApplyToggle();
            _featureToggle.RunActionWhenEnabled(action);
            _mockFeatureToggle.Verify(status => status.RunActionIfOn(action));
        }

        [Test]
        public void ShouldClearControlsWhenFeatureNotEnabled()
        {
            _featureToggle.EnabledBy = "fake";
            _mockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", false)).Returns(
                new FeatureToggle(false));
            _featureToggle.ApplyToggle();

            Assert.AreEqual(0, _featureToggle.Controls.Count);
        }

        [Test]
        public void ShouldClearControlsWhenFeatureRemoved()
        {
            _featureToggle.RemovedBy = "fake";
            _mockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", true)).Returns(new FeatureToggle(false));
            _featureToggle.ApplyToggle();

            Assert.AreEqual(0, _featureToggle.Controls.Count);
        }

        [Test]
        public void ShouldNotClearControlsWhenFeatureEnabled()
        {
            _featureToggle.EnabledBy = "fake";
            _mockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", false)).Returns(new FeatureToggle(true));
            _featureToggle.ApplyToggle();

            Assert.AreEqual(1, _featureToggle.Controls.Count);
        }

        [Test]
        public void ShouldNotClearControlsWhenFeatureNotRemoved()
        {
            _featureToggle.RemovedBy = "fake";
            _mockFeatureToggleFactory.Setup(fact => fact.GetFeatureToggle("fake", true)).Returns(new FeatureToggle(true));
            _featureToggle.ApplyToggle();

            Assert.AreEqual(1, _featureToggle.Controls.Count);
        }

        [Test, ExpectedException(typeof (InvalidMarkupException))]
        public void ShouldThrowExceptionWhenBothEnabledAndRemovedByUsed()
        {
            _featureToggle.RemovedBy = "fake";
            _featureToggle.EnabledBy = "fake";
            _featureToggle.ApplyToggle();
        }

        [Test, ExpectedException(typeof (InvalidMarkupException))]
        public void ShouldThrowExceptionWhenNeitherEnabledOrRemovedByUsed()
        {
            _featureToggle.ApplyToggle();
        }
    }
}