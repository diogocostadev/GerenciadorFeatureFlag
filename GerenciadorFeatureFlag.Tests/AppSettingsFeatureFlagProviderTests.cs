using GerenciadorFeatureFlags;
using Microsoft.Extensions.Configuration;

namespace GerenciadorFeatureFlag.Tests;

public class AppSettingsFeatureFlagProviderTests
{
    private IConfiguration BuildConfiguration()
    {
        var configurationData = new Dictionary<string, string>
        {
            { "FeatureFlags:NovaFuncionalidade", "true" },
            { "FeatureFlags:FuncionalidadeBeta", "false" }
        };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(configurationData)
            .Build();
    }

    [Fact]
    public void IsFeatureEnabled_ReturnsTrue_WhenFeatureIsEnabledInAppSettings()
    {
        // Arrange
        var configuration = BuildConfiguration();
        var provider = new AppSettingsFeatureFlagProvider(configuration);

        // Act
        var result = provider.IsFeatureEnabled("NovaFuncionalidade");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsFeatureEnabled_ReturnsFalse_WhenFeatureIsDisabledInAppSettings()
    {
        // Arrange
        var configuration = BuildConfiguration();
        var provider = new AppSettingsFeatureFlagProvider(configuration);

        // Act
        var result = provider.IsFeatureEnabled("FuncionalidadeBeta");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsFeatureEnabled_WithCustomLogic_ReturnsTrue_WhenLogicPasses()
    {
        // Arrange
        var configuration = BuildConfiguration();
        var provider = new AppSettingsFeatureFlagProvider(configuration);

        // Act
        var result = provider.IsFeatureEnabled("NovaFuncionalidade", () =>
        {
            // Custom logic: habilitar apenas se o horário for antes das 12h
            return DateTime.Now.Hour < 12;
        });

        // Assert
        var expected = DateTime.Now.Hour < 12;
        Assert.Equal(expected, result);
    }
}