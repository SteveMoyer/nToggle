using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace nToggle
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:FeatureToggle runat=server></{0}:FeatureToggle>")]
    public class FeatureToggle : Panel
    {
        bool _Reversed = false;
        string _FeatureName = "";

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string FeatureName
        {
            get
            {

                return _FeatureName;
            }

            set
            {
                _FeatureName = value;
            }
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("false")]
        [Localizable(true)]
        public bool Reversed
        {
            get
            {
                return _Reversed;
            }

            set
            {
                _Reversed = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            IFeatureToggleFactory featureFactory = new FeatureToggleFactory();
            var  featureToggle=featureFactory.GetFeatureStatus(FeatureName,Reversed);
            if (!featureToggle.IsOn)
            {
                Controls.Clear();
            }
        }
    }
}
