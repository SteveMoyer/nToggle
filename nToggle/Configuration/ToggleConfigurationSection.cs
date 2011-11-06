using System.Configuration;

namespace nToggle.Configuration
{
    public class ToggleConfigurationSection : ConfigurationSection
    {
        private const string ToggleProperty = "toggles";


        [ConfigurationProperty(ToggleProperty,
            IsDefaultCollection = false)]
        public ToggleElementCollection Toggles
        {
            get
            {
                var urlsCollection =
                    (ToggleElementCollection) base[ToggleProperty];
                return urlsCollection;
            }
        }


        protected override string SerializeSection(
            ConfigurationElement parentElement,
            string name, ConfigurationSaveMode saveMode)
        {
            var s =
                base.SerializeSection(parentElement,
                                      name, saveMode);
            return s;
        }
    }
}