using System;
using System.Collections.Generic;
using System.Configuration;
using nToggle.Configuration;

namespace nToggle
{
    public class FeatureToggleFactory : IFeatureToggleFactory
    {
        private readonly Dictionary<string, IFeatureToggleRepository> toggleRepositoryDictionary;
        private static readonly Dictionary<string, bool> toggleGlobalSettingDictionary = new Dictionary<string, bool>();
        private static FeatureToggleFactory currentFactory;

        public static FeatureToggleFactory CurrentFactory
        {
            get { return currentFactory ?? (currentFactory = LoadFactory()); }
            set { currentFactory = value; }
        }

        private static FeatureToggleFactory LoadFactory()
        {
            var config = (ToggleConfigurationSection) ConfigurationManager.GetSection("nToggle");
            var toggleRepositoryDictionary = new Dictionary<String, IFeatureToggleRepository>();
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
                    var strings = toggle.Repository.Split(',');
                    var dynamicRepo = (IFeatureToggleRepository) Activator.CreateInstance(strings[0], strings[1]).Unwrap();
                    toggleRepositoryDictionary.Add(toggle.Name,dynamicRepo);
                }
            }

            return new FeatureToggleFactory(toggleRepositoryDictionary);
        }


        public FeatureToggleFactory(Dictionary<string, IFeatureToggleRepository> toggleRepositoryDictionary)
        {
            this.toggleRepositoryDictionary = toggleRepositoryDictionary;
        }


        public IFeatureToggle GetFeatureToggle(string featureName, bool reversed)
        {
            bool statusFromRepository = false;
            try
            {
                statusFromRepository = toggleRepositoryDictionary[featureName].GetToggleStatus(featureName);
             
            }
            catch (KeyNotFoundException ex)
            {
             
            }
            return new FeatureToggle(reversed ? !statusFromRepository : statusFromRepository);
        }

        public IConditionFeatureToggle GetConditionFeatureToggle(string featureName, bool reversed)
        {
            var statusFromRepository = false;
            try
            {
                statusFromRepository = toggleRepositoryDictionary[featureName].GetToggleStatus(featureName);

            }
            catch (KeyNotFoundException ex)
            {

            }
            if(!reversed)
            {
                return new ConditionFeatureToggle(statusFromRepository, toggleGlobalSettingDictionary[featureName]);
            }
            return new ConditionFeatureToggle(!statusFromRepository, !toggleGlobalSettingDictionary[featureName]);
        }

        public IFeatureToggle GetFeatureToggle(string featureName)
        {
            return GetFeatureToggle(featureName, false);
        }

        public IConditionFeatureToggle GetConditionFeatureToggle(string featureName)
        {
            return GetConditionFeatureToggle(featureName, false);
        }
    }

    internal class StaticToggleRepository : IFeatureToggleRepository
    {
        private readonly Dictionary<string, bool> toggleValues;

        public StaticToggleRepository(Dictionary<string, bool> values)
        {
            toggleValues = values;
        }

        public bool GetToggleStatus(string toggleName)
        {
            return toggleValues[toggleName];
        }
    }
}