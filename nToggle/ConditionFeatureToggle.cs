using System;

namespace nToggle
{
    public class ConditionFeatureToggle : FeatureToggle, IConditionFeatureToggle
    {
        private readonly bool isGlobalOn;

        public ConditionFeatureToggle(bool isOn, bool isGlobalOn) : base(isOn)
        {
            this.isGlobalOn = isGlobalOn;
        }


        public bool IsGlobalOn
        {
            get { return isGlobalOn; }
        }

        public void RunActionIfGlobalOn(Action onAction)
        {
            if (IsGlobalOn) onAction();
        }
    }
}
