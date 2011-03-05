using nToggle;
using NUnit.Framework;

namespace nToggleTest
{
    [TestFixture]
    public class FeatureToggleTest
    {
        [Test]
        public void RunActionIfOffShouldNotRunActionWhenOn()
        {
            var featureToggle = new FeatureToggle(true);

            bool actionWasRun = false;
            featureToggle.RunActionIfOff(() => { actionWasRun = true; });
            Assert.IsFalse(actionWasRun);
        }

        [Test]
        public void RunActionIfOffShouldRunActionWhenOff()
        {
            var featureToggle = new FeatureToggle(false);

            bool actionWasRun = false;
            featureToggle.RunActionIfOff(() => { actionWasRun = true; });
            Assert.IsTrue(actionWasRun);
        }

        [Test]
        public void RunActionIfOnShouldNotRunActionWhenOff()
        {
            var featureToggle = new FeatureToggle(false);

            bool actionWasRun = false;
            featureToggle.RunActionIfOn(() => { actionWasRun = true; });
            Assert.IsFalse(actionWasRun);
        }

        [Test]
        public void RunActionIfOnShouldRunActionWhenOn()
        {
            var featureToggle = new FeatureToggle(true);

            bool actionWasRun = false;
            featureToggle.RunActionIfOn(() => { actionWasRun = true; });
            Assert.IsTrue(actionWasRun);
        }
    }
}