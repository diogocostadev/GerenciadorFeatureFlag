using C3i.GerenciadorFeatureFlags;

namespace GerenciadorFeatureFlag.Tests;

public class InMemoryFeatureFlagProviderTests
{
    [Fact]
    public void IsFeatureEnabled_ReturnsTrue_WhenFeatureIsEnabled()
    {
        // Arrange
        var featureFlags = new Dictionary<string, bool>
        {
            { "NovaFuncionalidade", true }
        };
        var provider = new InMemoryFeatureFlagProvider(featureFlags);

        // Act
        var result = provider.IsFeatureEnabled("NovaFuncionalidade");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsFeatureEnabled_ReturnsFalse_WhenFeatureIsDisabled()
    {
        // Arrange
        var featureFlags = new Dictionary<string, bool>
        {
            { "NovaFuncionalidade", false }
        };
        var provider = new InMemoryFeatureFlagProvider(featureFlags);

        // Act
        var result = provider.IsFeatureEnabled("NovaFuncionalidade");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsFeatureEnabled_WithCustomLogic_ReturnsTrue_WhenLogicPasses()
    {
        // Arrange
        var featureFlags = new Dictionary<string, bool>
        {
            { "NovaFuncionalidade", true }
        };
        var provider = new InMemoryFeatureFlagProvider(featureFlags);

        // Act
        var result = provider.IsFeatureEnabled("NovaFuncionalidade", () =>
        {
            // Custom logic: habilitar apenas se o dia for domingo
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
        });

        // Assert
        var expected = DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
        Assert.Equal(expected, result);
    }
}