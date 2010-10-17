using System;
using System.Configuration;
namespace nToggle
{
   public  class AppSettingsFeatureToggleRepository:IFeatureToggleRepository
    {
       public bool GetToggleStatus(string toggleName)
       {
           var value = ConfigurationManager.AppSettings[toggleName];
          
           return value == null? false: Boolean.Parse(value);
       }
    }
}
