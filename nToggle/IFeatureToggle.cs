using System;

namespace nToggle
{
    public interface IFeatureToggle
    {
        void RunActionIfOff(Action offAction);
        void RunActionIfOn(Action onAction);
        bool IsOn { get; }
    }
}
