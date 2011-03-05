namespace nToggle
{
    public class FeatureToggleFactory : IFeatureToggleFactory
    {
        private readonly IFeatureToggleRepository _toggleRepository;

        public FeatureToggleFactory(IFeatureToggleRepository repository)
        {
            _toggleRepository = repository;
        }

        public FeatureToggleFactory()
        {
            _toggleRepository = new AppSettingsFeatureToggleRepository();
        }

        #region IFeatureToggleFactory Members

        public IFeatureToggle GetFeatureToggle(string featureName, bool reversed)
        {
            bool toggleRepositoryGetToggleStatus = _toggleRepository.GetToggleStatus(featureName);
            return new FeatureToggle(reversed ? !toggleRepositoryGetToggleStatus : toggleRepositoryGetToggleStatus);
        }

        public IFeatureToggle GetFeatureToggle(string featureName)
        {
            return new FeatureToggle(_toggleRepository.GetToggleStatus(featureName));
        }

        #endregion
    }
}