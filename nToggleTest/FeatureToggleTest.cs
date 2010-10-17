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
            FeatureToggle featureStatus = new FeatureToggle(true);

            bool actionWasRun = false;
            featureStatus.RunActionIfOn(() => { actionWasRun = true; });
            Assert.IsTrue(actionWasRun);

        }
        [Test]
        public void RunActionIfOnShouldNotRunActionWhenOff()
        {
            FeatureToggle featureStatus = new FeatureToggle(false);

            bool actionWasRun = false;
            featureStatus.RunActionIfOn(() => { actionWasRun = true; });
            Assert.IsFalse(actionWasRun);

        }
        [Test]
        public void RunActionIfOffShouldRunActionWhenOff()
        {
            FeatureToggle featureStatus = new FeatureToggle(false);

            bool actionWasRun = false;
            featureStatus.RunActionIfOff(() => { actionWasRun = true; });
            Assert.IsTrue(actionWasRun);

        }
        [Test]
        public void RunActionIfOffShouldNotRunActionWhenOn()
        {
            FeatureToggle featureStatus = new FeatureToggle(true);

            bool actionWasRun = false;
            featureStatus.RunActionIfOff(() => { actionWasRun = true; });
            Assert.IsFalse(actionWasRun);

        }


    }
    
}
