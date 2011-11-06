using System.Configuration;

namespace nToggle.Configuration
{
    public class ToggleElementCollection:ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ToggleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ToggleElement) element).Name;
        }
    }
}