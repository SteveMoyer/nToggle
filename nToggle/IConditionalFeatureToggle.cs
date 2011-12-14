using System;

namespace nToggle
{
    public interface IConditionalFeatureToggle : IFeatureToggle
    {
        bool IsGlobalOn { get; }
        void RunActionIfGlobalOn(Action onAction);
    }
}
