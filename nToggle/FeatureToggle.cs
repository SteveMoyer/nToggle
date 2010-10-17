using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace nToggle
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:FeatureToggle runat=server></{0}:FeatureToggle>")]
    public class FeatureToggle : PlaceHolder
    {
        private IFeatureStatusFactory _FeatureFactory;
        private IFeatureStatus _FeatureStatus;
        string _removedBy = "";
        string _enabledBy = "";
        public FeatureToggle(IFeatureStatusFactory featureFactory)
        {
            _FeatureFactory = featureFactory;
        }
        public FeatureToggle()
        {
            _FeatureFactory = new FeatureStatusFactory();
        }
        [Bindable(true)]
        
        [DefaultValue("")]
        [Localizable(true)]
        public string EnabledBy
        {
            get
            {
                return _enabledBy;
            }

            set
            {
                _enabledBy = value;
            }
        }
        [Bindable(true)]
       
        [DefaultValue("false")]
        [Localizable(true)]
        public string RemovedBy
        {
            get
            {
                return _removedBy;
            }

            set
            {
                _removedBy = value;
            }
        }

        public void RunActionWhenDisabled(Action disabledAction)
        {
            _FeatureStatus.RunActionIfOff(disabledAction);
            
            
        }
        public void RunActionWhenEnabled(Action enabledAction)
        {
            _FeatureStatus.RunActionIfOn(enabledAction);
            
        }
        private void ValidateProperties()
        {
            if (!String.IsNullOrWhiteSpace(RemovedBy) && !string.IsNullOrWhiteSpace(EnabledBy))
                throw new InvalidMarkupException("You must set RemovedBy or EnabledBy but not both");

            if (string.IsNullOrWhiteSpace(RemovedBy) && string.IsNullOrWhiteSpace(EnabledBy))
                throw new InvalidMarkupException("You must set RemovedBy or EnabledBy");
        }
        public void ApplyToggle()
        {
            ValidateProperties();
            Boolean reversed = string.IsNullOrWhiteSpace(EnabledBy);
            string featureName = reversed ? RemovedBy : EnabledBy;

            _FeatureStatus = _FeatureFactory.GetFeatureStatus(featureName, reversed);
            if (!_FeatureStatus.IsOn)
            {
                Controls.Clear();
            }
        }
        protected override void OnInit(EventArgs e)
        {
            ApplyToggle();
        }
    }
}
