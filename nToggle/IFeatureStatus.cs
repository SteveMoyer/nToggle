using System;

namespace nToggle
{
    public interface IFeatureStatus
    {
        void RunActionIfOff(Action offAction);
        void RunActionIfOn(Action onAction);
        bool IsOn { get; }
    }
}
