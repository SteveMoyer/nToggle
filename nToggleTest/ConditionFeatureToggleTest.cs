using Microsoft.VisualStudio.TestTools.UnitTesting;
using nToggle;

namespace nToggleTest
{
    [TestClass]
    public class ConditionFeatureToggleTest
    {
        [TestMethod]
        public void RunActionIfGlobalOnShouldRunActionWhenGlobalIsOn()
        {
            var featureToggle = new ConditionFeatureToggle(true, true);

            bool actionWasRun = false;
            featureToggle.RunActionIfGlobalOn(() => { actionWasRun = true; });
            Assert.IsTrue(actionWasRun);
        }

        [TestMethod]
        public void RunActionIfGlobalOnShouldNotRunActionWhenGlobalIsOff()
        {
            var featureToggle = new ConditionFeatureToggle(true, false);

            bool actionWasRun = false;
            featureToggle.RunActionIfGlobalOn(() => { actionWasRun = true; });
            Assert.IsFalse(actionWasRun);
        }
    }
}
