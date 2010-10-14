using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace nToggle
{
   public  class AppSettingsFeatureStatusRepository:IFeatureStatusRepository
    {
       public bool GetToggleStatus(string toggleName)
       {
           var value = ConfigurationManager.AppSettings[toggleName];
          
           return value == null? false: Boolean.Parse(value);
       }
    }
}
