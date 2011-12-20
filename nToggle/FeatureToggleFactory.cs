using System;
using System.Collections.Generic;
using System.Configuration;
using nToggle.Configuration;

namespace nToggle
{
    public class FeatureToggleFactory : IFeatureToggleFactory
    {
        private static FeatureToggleFactory _currentFactory;
        private readonly Dictionary<string, bool> _toggleGlobalSettingDictionary;
        private readonly Dictionary<string, IFeatureToggleRepository> _toggleRepositoryDictionary;


        public FeatureToggleFactory(Dictionary<string, IFeatureToggleRepository> toggleRepositoryDictionary,
                                    Dictionary<string, bool> toggleGlobalSettingDictionary)
        {
            _toggleRepositoryDictionary = toggleRepositoryDictionary;
            _toggleGlobalSettingDictionary = toggleGlobalSettingDictionary;
        }

        public static FeatureToggleFactory CurrentFactory
        {
            get { return _currentFactory ?? (_currentFactory = LoadFactory()); }
            set { _currentFactory = value; }
        }

        #region IFeatureToggleFactory Members

        public IFeatureToggle GetFeatureToggle(string featureName, bool reversed)
        {
            bool statusFromRepository = false;
            try
            {
                statusFromRepository = _toggleRepositoryDictionary[featureName].GetToggleStatus(featureName);
            }
            catch (KeyNotFoundException)
            {
            }
            return new FeatureToggle(reversed ? !statusFromRepository : statusFromRepository);
        }

        public IConditionalFeatureToggle GetConditionalFeatureToggle(string featureName, bool reversed)
        {
            IFeatureToggle featureToggle = GetFeatureToggle(featureName, reversed);

            bool globalSetting = false;
            if (_toggleGlobalSettingDictionary.ContainsKey(featureName))
            {
                globalSetting = _toggleGlobalSettingDictionary[featureName];
            }

            return !reversed
                       ? new ConditionalFeatureToggle(featureToggle, globalSetting)
                       : new ConditionalFeatureToggle(featureToggle, !globalSetting);
        }

        public IFeatureToggle GetFeatureToggle(string featureName)
        {
            return GetFeatureToggle(featureName, false);
        }

        public IConditionalFeatureToggle GetConditionalFeatureToggle(string featureName)
        {
            return GetConditionalFeatureToggle(featureName, false);
        }

        #endregion

        private static FeatureToggleFactory LoadFactory()
        {
            var config = (ToggleConfigurationSection) ConfigurationManager.GetSection("nToggle");
            var toggleRepositoryDictionary = new Dictionary<String, IFeatureToggleRepository>();
            var toggleGlobalSettingDictionary = new Dictionary<String, bool>();
            var toggleValueDictionary = new Dictionary<String, bool>();
            var staticToggleRepository = new StaticToggleRepository(toggleValueDictionary);
            foreach (ToggleElement toggle in config.Toggles)
            {
                toggleGlobalSettingDictionary.Add(toggle.Name, toggle.Value);
                if (!toggle.Value || String.IsNullOrEmpty(toggle.Repository))
                {
                    toggleRepositoryDictionary.Add(toggle.Name, staticToggleRepository);
                    toggleValueDictionary.Add(toggle.Name, toggle.Value);
                }
                else
                {
                    string[] strings = toggle.Repository.Split(',');
                    var dynamicRepo =
                        (IFeatureToggleRepository) Activator.CreateInstance(strings[0], strings[1]).Unwrap();
                    toggleRepositoryDictionary.Add(toggle.Name, dynamicRepo);
                }
            }

            return new FeatureToggleFactory(toggleRepositoryDictionary, toggleGlobalSettingDictionary);
        }
    }

    internal class StaticToggleRepository : IFeatureToggleRepository
    {
        private readonly Dictionary<string, bool> _toggleValues;

        public StaticToggleRepository(Dictionary<string, bool> values)
        {
            _toggleValues = values;
        }

        #region IFeatureToggleRepository Members

        public bool GetToggleStatus(string toggleName)
        {
            return _toggleValues[toggleName];
        }

        #endregion
    }
}