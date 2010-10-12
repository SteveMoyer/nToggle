using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nToggle
{
    public interface IFeatureToggleRepository
    {
         bool GetToggleStatus(string toggleName);
      
    }
}
