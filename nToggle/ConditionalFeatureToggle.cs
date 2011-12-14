using System;

namespace nToggle
{
    public class ConditionalFeatureToggle : FeatureToggle, IConditionalFeatureToggle
    {
        private readonly bool _isGlobalOn;

        public ConditionalFeatureToggle(bool isOn, bool isGlobalOn) : base(isOn)
        {
            _isGlobalOn = isGlobalOn;
        }

        public ConditionalFeatureToggle(IFeatureToggle featureToggle, bool isGlobalOn) : base(featureToggle.IsOn)
        {
            _isGlobalOn = isGlobalOn;
        }

        public bool IsGlobalOn
        {
            get { return _isGlobalOn; }
        }

        public void RunActionIfGlobalOn(Action onAction)
        {
            if (IsGlobalOn) onAction();
        }     
    }
}