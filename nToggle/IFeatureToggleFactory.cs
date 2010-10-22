using System;

namespace nToggle
{
   public interface IFeatureToggleFactory
    {
       IFeatureToggle GetFeatureToggle(string featureName, bool reversed);
       IFeatureToggle GetFeatureToggle(string featureName);
    }
}
