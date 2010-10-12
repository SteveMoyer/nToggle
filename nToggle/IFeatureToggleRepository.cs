using System;

namespace nToggle
{
    public interface IFeatureStatusRepository
    {
         bool GetToggleStatus(string toggleName);
      
    }
}
