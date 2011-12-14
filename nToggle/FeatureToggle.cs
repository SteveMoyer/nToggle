using System;

namespace nToggle
{
    public class FeatureToggle : IFeatureToggle
    {
        private readonly bool _isOn;

        public FeatureToggle(bool isOn)
        {
            _isOn = isOn;
        }

        #region IFeatureToggle Members

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

        public bool IsOn
        {
            get { return _isOn; }
        }

        #endregion
    }
}