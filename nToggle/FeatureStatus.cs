using System;

namespace nToggle
{
    public class FeatureStatus : IFeatureStatus
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
        public FeatureStatus(bool isOn)
        {
            _IsOn = isOn;
        }
        private readonly bool _IsOn;
        public bool IsOn { get { return _IsOn; } }
    }
}
