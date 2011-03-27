using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nToggle
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:FeatureToggle runat=server></{0}:FeatureToggle>")]
    public class WebFeatureToggle : PlaceHolder
    {
        private readonly IFeatureToggleFactory _featureFactory;
        private IFeatureToggle _featureToggle;
        private string _enabledBy = "";
        private string _removedBy = "";

        public WebFeatureToggle(IFeatureToggleFactory featureFactory)
        {
            _featureFactory = featureFactory;
        }

        public WebFeatureToggle()
        {
            _featureFactory = new FeatureToggleFactory();
        }

        [Bindable(true)]
        [DefaultValue("")]
        [Localizable(true)]
        public string EnabledBy
        {
            get { return _enabledBy; }

            set { _enabledBy = value; }
        }

        [Bindable(true)]
        [DefaultValue("false")]
        [Localizable(true)]
        public string RemovedBy
        {
            get { return _removedBy; }

            set { _removedBy = value; }
        }

        public void RunActionWhenDisabled(Action disabledAction)
        {
            _featureToggle.RunActionIfOff(disabledAction);
        }

        public void RunActionWhenEnabled(Action enabledAction)
        {
            _featureToggle.RunActionIfOn(enabledAction);
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

            _featureToggle = _featureFactory.GetFeatureToggle(featureName, reversed);
            if (!_featureToggle.IsOn)
            {
                if (Controls.Count == 0)
                    throw new InvalidMarkupException(
                        "There are no controls to remove. Controls will not be present if you have inline script within your markup.  A possible workaround it to move script to code behind.");

                Controls.Clear();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            ApplyToggle();
        }
    }
}