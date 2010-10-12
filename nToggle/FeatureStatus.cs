using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nToggle
{
   public class FeatureStatus
    {
       public FeatureStatus(bool isOn)
       {
           _IsOn = isOn;
       }
       private readonly  bool _IsOn;
       public bool IsOn { get { return _IsOn; } }
    }
}
