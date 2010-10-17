using System;

namespace nToggle
{
   public class FeatureStatusFactory:IFeatureStatusFactory
    {

       IFeatureStatusRepository _ToggleRepository;
       public FeatureStatusFactory(IFeatureStatusRepository repository){
           _ToggleRepository = repository;
       }

       public FeatureStatusFactory()
       {
           _ToggleRepository = new AppSettingsFeatureStatusRepository();
       }


       public IFeatureStatus GetFeatureStatus(string featureName, bool reversed)
       {
           var toggleRepositoryGetToggleStatus = _ToggleRepository.GetToggleStatus(featureName);
           return new FeatureStatus(reversed ? !toggleRepositoryGetToggleStatus : toggleRepositoryGetToggleStatus);
       }
       public IFeatureStatus GetFeatureStatus(string FeatureName)
       {
           return new FeatureStatus(_ToggleRepository.GetToggleStatus(FeatureName));
       }
    }
}
