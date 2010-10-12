using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nToggle
{
   public class FeatureToggleFactory:IFeatureToggleFactory
    {

       IFeatureToggleRepository _ToggleRepository;
       public FeatureToggleFactory(IFeatureToggleRepository repository){
           _ToggleRepository = repository;
       }

       public FeatureToggleFactory()
       {
           _ToggleRepository = new AppSettingsToggleRepository();
       }


       public FeatureStatus GetFeatureStatus(string featureName, bool reversed)
       {
           var toggleRepositoryGetToggleStatus = _ToggleRepository.GetToggleStatus(featureName);
           return new FeatureStatus(reversed ? !toggleRepositoryGetToggleStatus : toggleRepositoryGetToggleStatus);
       }
       public FeatureStatus GetFeatureStatus(string FeatureName)
       {
           return new FeatureStatus(_ToggleRepository.GetToggleStatus(FeatureName));
       }
    }
}
