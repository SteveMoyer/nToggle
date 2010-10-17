using System;

namespace nToggle
{
   public interface IFeatureToggleFactory
    {
       IFeatureToggle GetFeatureStatus(string featureName, bool reversed);
       IFeatureToggle GetFeatureStatus(string featureName);
    }
}
