namespace nToggle
{
    public interface IFeatureToggleFactory
    {
        IFeatureToggle GetFeatureToggle(string featureName, bool reversed);
        IFeatureToggle GetFeatureToggle(string featureName);
        IConditionalFeatureToggle GetConditionFeatureToggle(string featureName, bool reversed);
        IConditionalFeatureToggle GetConditionFeatureToggle(string featureName);
    }
}