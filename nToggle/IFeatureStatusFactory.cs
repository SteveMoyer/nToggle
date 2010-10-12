using System;

namespace nToggle
{
   public interface IFeatureStatusFactory
    {
       FeatureStatus GetFeatureStatus(string featureName, bool reversed);
       FeatureStatus GetFeatureStatus(string featureName);
    }
}
