using System;

namespace nToggle
{
    public interface IFeatureToggleRepository
    {
         bool GetToggleStatus(string toggleName);
      
    }
}
