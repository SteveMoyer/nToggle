using System;
using System.Collections.Generic;
using System.Configuration;
using nToggle.Configuration;

namespace nToggle
{
    public class FeatureToggleFactory : IFeatureToggleFactory
    {
        private readonly IFeatureToggleRepository _staticToggleRepository;
        private readonly Dictionary<string, IFeatureToggleRepository> _toggleRepositoryDictionary;
        private static FeatureToggleFactory _currentFactory;

        public static FeatureToggleFactory CurrentFactory
        {
            get
            {
                if (_currentFactory == null)
                {
                    _currentFactory = LoadFactory();
                }
                return _currentFactory;
            }
            set { _currentFactory = value; }
        }

        private static FeatureToggleFactory LoadFactory()
        {
            var config = (ToggleConfigurationSection) ConfigurationManager.GetSection(
                "nToggle");
            var toggleRepositoryDictionary = new Dictionary<String, IFeatureToggleRepository>();
            var toggleValueDictionary = new Dictionary<String, bool>();
            var staticToggleRepository = new StaticToggleRepository(toggleValueDictionary);
            foreach (ToggleElement toggle in config.Toggles)
            {
                if (!toggle.Value || String.IsNullOrEmpty(toggle.Repository))
                {
                    toggleRepositoryDictionary.Add(toggle.Name, staticToggleRepository);
                    toggleValueDictionary.Add(toggle.Name, toggle.Value);
                }
                else
                {
                    var strings = toggle.Repository.Split(',');

                    var dynamicRepo =
                        (IFeatureToggleRepository) Activator.CreateInstance(strings[0], strings[1]).Unwrap();
                    toggleRepositoryDictionary.Add(toggle.Name,dynamicRepo);
                }
            }

            return new FeatureToggleFactory(toggleRepositoryDictionary);
        }


        public FeatureToggleFactory(Dictionary<string, IFeatureToggleRepository> toggleRepositoryDictionary)
        {
            _toggleRepositoryDictionary = toggleRepositoryDictionary;
        }


        public IFeatureToggle GetFeatureToggle(string featureName, bool reversed)
        {
            bool statusFromRepository = false;
            try
            {
                statusFromRepository = _toggleRepositoryDictionary[featureName].GetToggleStatus(featureName);
             
            }
            catch (KeyNotFoundException ex)
            {
             
            }
            return new FeatureToggle(reversed ? !statusFromRepository : statusFromRepository);
        }

        public IFeatureToggle GetFeatureToggle(string featureName)
        {
            return GetFeatureToggle(featureName, false);
        }

    }

    internal class StaticToggleRepository : IFeatureToggleRepository
    {
        private Dictionary<string, bool> _toggleValues;

        public StaticToggleRepository(Dictionary<string, bool> values)
        {
            _toggleValues = values;
        }

        public bool GetToggleStatus(string toggleName)
        {
            return _toggleValues[toggleName];
        }
    }
}