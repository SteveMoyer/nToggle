using System;
using NUnit.Framework;
using nToggle;

namespace nToggleTest
{
    [TestFixture]
    public class FeatureToggleTest
    {
        [Test]
        public void RunActionIfOnShouldRunActionWhenOn()
        {
            FeatureToggle featureToggle = new FeatureToggle(true);

            bool actionWasRun = false;
            featureToggle.RunActionIfOn(() => { actionWasRun = true; });
            Assert.IsTrue(actionWasRun);

        }
        [Test]
        public void RunActionIfOnShouldNotRunActionWhenOff()
        {
            FeatureToggle featureToggle = new FeatureToggle(false);

            bool actionWasRun = false;
            featureToggle.RunActionIfOn(() => { actionWasRun = true; });
            Assert.IsFalse(actionWasRun);

        }
        [Test]
        public void RunActionIfOffShouldRunActionWhenOff()
        {
            FeatureToggle featureToggle = new FeatureToggle(false);

            bool actionWasRun = false;
            featureToggle.RunActionIfOff(() => { actionWasRun = true; });
            Assert.IsTrue(actionWasRun);

        }
        [Test]
        public void RunActionIfOffShouldNotRunActionWhenOn()
        {
            FeatureToggle featureToggle = new FeatureToggle(true);

            bool actionWasRun = false;
            featureToggle.RunActionIfOff(() => { actionWasRun = true; });
            Assert.IsFalse(actionWasRun);

        }


    }
    
}
