using System;

namespace nToggle
{
   public interface IFeatureStatusFactory
    {
       IFeatureStatus GetFeatureStatus(string featureName, bool reversed);
       IFeatureStatus GetFeatureStatus(string featureName);
    }
}
