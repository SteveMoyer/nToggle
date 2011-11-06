using System;
using System.Configuration;

namespace nToggle.Configuration
{
    public class ToggleElement: ConfigurationElement
    {
        private const string ValueProperty = "value";
        private const string FactoryProperty = "factory";
        private const string NameProperty = "name";
        private const string DefaultFactoryClass = null;

        public ToggleElement(String name,
                              String factory)
        {
            Name = name;
            Factory = factory;
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

        [ConfigurationProperty(FactoryProperty,
            DefaultValue = DefaultFactoryClass,
            IsRequired = false)]
        public string Factory
        {
            get
            {
                return (string)this[FactoryProperty];
            }
            set
            {
                this[FactoryProperty] = value;
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