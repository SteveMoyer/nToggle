using System;
using NUnit.Framework;
using nToggle;

namespace nToggleTest
{
    [TestFixture]
    public class FeatureStatusTest
    {
        [Test]
        public void RunActionIfOnShouldRunActionWhenOn()
        {
            FeatureStatus featureStatus = new FeatureStatus(true);

            bool actionWasRun = false;
            featureStatus.RunActionIfOn(() => { actionWasRun = true; });
            Assert.IsTrue(actionWasRun);

        }
        [Test]
        public void RunActionIfOnShouldNotRunActionWhenOff()
        {
            FeatureStatus featureStatus = new FeatureStatus(false);

            bool actionWasRun = false;
            featureStatus.RunActionIfOn(() => { actionWasRun = true; });
            Assert.IsFalse(actionWasRun);

        }
        [Test]
        public void RunActionIfOffShouldRunActionWhenOff()
        {
            FeatureStatus featureStatus = new FeatureStatus(false);

            bool actionWasRun = false;
            featureStatus.RunActionIfOff(() => { actionWasRun = true; });
            Assert.IsTrue(actionWasRun);

        }
        [Test]
        public void RunActionIfOffShouldNotRunActionWhenOn()
        {
            FeatureStatus featureStatus = new FeatureStatus(true);

            bool actionWasRun = false;
            featureStatus.RunActionIfOff(() => { actionWasRun = true; });
            Assert.IsFalse(actionWasRun);

        }


    }
    
}
