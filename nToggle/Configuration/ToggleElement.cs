using System;
using System.Configuration;

namespace nToggle.Configuration
{
    public class ToggleElement: ConfigurationElement
    {
        private const string ValueProperty = "value";
        private const string RepositoryProperty = "repository";
        private const string NameProperty = "name";
        private const string DefaultFactoryClass = null;

        public ToggleElement(String name,
                              String repository)
        {
            Name = name;
            Repository = repository;
        }

        public ToggleElement()
        {
        }

        public ToggleElement(string elementName)
        {
            Name = elementName;
        }

        [ConfigurationProperty(NameProperty, 
            IsRequired = true, 
            IsKey = true)]
        public string Name
        {
            get
            {
                return (string)this[NameProperty];
            }
            set
            {
                this[NameProperty] = value;
            }
        }

        [ConfigurationProperty(RepositoryProperty,
            DefaultValue = DefaultFactoryClass,
            IsRequired = false)]
        public string Repository
        {
            get
            {
                return (string)this[RepositoryProperty];
            }
            set
            {
                this[RepositoryProperty] = value;
            }
        }

        [ConfigurationProperty(ValueProperty,
            DefaultValue = false,
            IsRequired = true)]
        public bool Value
        {
            get
            {
                return (bool)this[ValueProperty];
            }
            set
            {
                this[ValueProperty] = value;
            }
        }
    }
}