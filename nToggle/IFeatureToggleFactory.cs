using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nToggle
{
   public interface IFeatureToggleFactory
    {
       FeatureStatus GetFeatureStatus(string featureName, bool reversed);
       FeatureStatus GetFeatureStatus(string featureName);
    }
}
