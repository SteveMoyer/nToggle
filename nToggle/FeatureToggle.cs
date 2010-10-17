using System;

namespace nToggle
{
    public class FeatureToggle : IFeatureToggle
    {
        public void RunActionIfOff(Action offAction)
        {
            if (!IsOn)
                offAction();

        }
        public void RunActionIfOn(Action onAction)
        {
            if (IsOn)
                onAction();
        }
        public FeatureToggle(bool isOn)
        {
            _IsOn = isOn;
        }
        private readonly bool _IsOn;
        public bool IsOn { get { return _IsOn; } }
    }
}
