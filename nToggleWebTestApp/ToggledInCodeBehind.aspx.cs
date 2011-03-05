using System;

namespace nToggleWebTestApp
{
    public partial class ToggledInCodeBehind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebFeatureToggle.RunActionWhenDisabled(CodeToRunIfDisabled);
            WebFeatureToggle.RunActionWhenEnabled(CodeToRunIfEnabled);
        }
        protected void CodeToRunIfDisabled()
        {
        }
        protected void CodeToRunIfEnabled()
        {
        }
    }
}