using System;

namespace nToggle
{
    public interface IConditionFeatureToggle : IFeatureToggle
    {
        bool IsGlobalOn { get; }
        void RunActionIfGlobalOn(Action onAction);
    }
}
