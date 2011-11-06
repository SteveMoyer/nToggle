using System.Web;
using nToggle;

namespace nToggleDynamicFeatureTest
{
    public class TestDynamicRepository:IFeatureToggleRepository
    {
        public bool GetToggleStatus(string toggleName)
        {
            return (bool) HttpContext.Current.Request.Path.Contains("DynamicOn");
        }
    }
}