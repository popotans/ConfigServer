﻿using ConfigServer.Server;
using System;
using System.Linq;
using Xunit;

namespace ConfigServer.Core.Tests
{
    public class ConfigurationSetDefinitionTests
    {
        private readonly Type defaultType = typeof(DefaultConfigSet);

        [Fact]
        public void NewConfiguarationSetDefinition_ContainsNoDefinitions()
        {
            var result = new ConfigurationSetModel(defaultType);

            Assert.Equal(0, result.Configs.Count());
        }

        [Fact]
        public void CanGetOrInitializeByType()
        {
            var result = new ConfigurationSetModel(defaultType);
            var gotValue = result.GetOrInitialize(nameof(SimpleConfig), typeof(SimpleConfig));
            Assert.Equal(1, result.Configs.Count());
            Assert.Equal(result.Configs.Single(), gotValue);
        }

        [Fact]
        public void CanGetOrInitializeByTypeDoesNotDuplicateInitialization()
        {
            var result = new ConfigurationSetModel(defaultType);
            var gotValue = result.GetOrInitialize(nameof(SimpleConfig), typeof(SimpleConfig));
            var gotValue2 = result.GetOrInitialize(nameof(SimpleConfig), typeof(SimpleConfig));

            Assert.Equal(1, result.Configs.Count());
            Assert.True(ReferenceEquals(gotValue, gotValue2));
        }

        [Fact]
        public void CanGetOrInitializeByGenericType()
        {
            var result = new ConfigurationSetModel(defaultType);
            var gotValue = result.GetOrInitialize<SimpleConfig>(nameof(SimpleConfig));
            Assert.Equal(1, result.Configs.Count());
            Assert.Equal(result.Configs.Single(), gotValue);
        }

        [Fact]
        public void CanGetExistingType()
        {
            var result = new ConfigurationSetModel(defaultType);
            var gotValue = result.GetOrInitialize(nameof(SimpleConfig), typeof(SimpleConfig));
            var gotValue2 = result.Get(typeof(SimpleConfig));

            Assert.True(ReferenceEquals(gotValue, gotValue2));
        }

        [Fact]
        public void CanGetExistingType_Generic()
        {
            var result = new ConfigurationSetModel(defaultType);
            var gotValue = result.GetOrInitialize<SimpleConfig>(nameof(SimpleConfig));
            var gotValue2 = result.Get<SimpleConfig>();

            Assert.True(ReferenceEquals(gotValue, gotValue2));
        }

        [Fact]
        public void Throws_IfConfigTYpeNotFound()
        {
            var target = new ConfigurationSetModel(defaultType);
            Assert.Throws(typeof(ConfigurationModelNotFoundException),()=> target.Get<SimpleConfig>());
        }

        [Fact]
        public void GetOrInitializePopulatesModelProperties()
        {
            var result = new ConfigurationSetModel(defaultType);
            var gotValue = result.GetOrInitialize(nameof(SimpleConfig), typeof(SimpleConfig));

            Assert.Equal(1, result.Configs.Count());
            Assert.Equal(typeof(int), gotValue.ConfigurationProperties[nameof(SimpleConfig.IntProperty)].PropertyType);
            Assert.Equal("Int Property", gotValue.ConfigurationProperties[nameof(SimpleConfig.IntProperty)].PropertyDisplayName);
            Assert.Equal(nameof(SimpleConfig.IntProperty), gotValue.ConfigurationProperties[nameof(SimpleConfig.IntProperty)].ConfigurationPropertyName);

        }

        private class DefaultConfigSet : ConfigurationSet<DefaultConfigSet>
        {

        }
    }
}
