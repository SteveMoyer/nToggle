namespace nToggle
{
    public interface IFeatureToggleFactory
    {
        IFeatureToggle GetFeatureToggle(string featureName, bool reversed);
        IFeatureToggle GetFeatureToggle(string featureName);
        IConditionalFeatureToggle GetConditionalFeatureToggle(string featureName, bool reversed);
        IConditionalFeatureToggle GetConditionalFeatureToggle(string featureName);
    }
}