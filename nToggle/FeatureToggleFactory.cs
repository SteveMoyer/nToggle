using System;

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
           _ToggleRepository = new AppSettingsFeatureToggleRepository();
       }


       public IFeatureToggle GetFeatureToggle(string featureName, bool reversed)
       {
           var toggleRepositoryGetToggleStatus = _ToggleRepository.GetToggleStatus(featureName);
           return new FeatureToggle(reversed ? !toggleRepositoryGetToggleStatus : toggleRepositoryGetToggleStatus);
       }
       public IFeatureToggle GetFeatureToggle(string FeatureName)
       {
           return new FeatureToggle(_ToggleRepository.GetToggleStatus(FeatureName));
       }
    }
}
