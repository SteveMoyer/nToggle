namespace nToggle
{
    public interface IFeatureToggleFactory
    {
        IFeatureToggle GetFeatureToggle(string featureName, bool reversed);
        IFeatureToggle GetFeatureToggle(string featureName);
        IConditionFeatureToggle GetConditionFeatureToggle(string featureName, bool reversed);
        IConditionFeatureToggle GetConditionFeatureToggle(string featureName);
    }
}