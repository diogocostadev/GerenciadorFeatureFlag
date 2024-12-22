using Microsoft.Extensions.Configuration;

namespace C3i.GerenciadorFeatureFlags;

public class AppSettingsFeatureFlagProvider : IFeatureFlagProvider
{
    private readonly IConfiguration _configuration;

    public AppSettingsFeatureFlagProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool IsFeatureEnabled(string featureName)
    {
        var value = _configuration[$"FeatureFlags:{featureName}"];
        return bool.TryParse(value, out var isEnabled) && isEnabled;
    }

    /// <summary>
    /// Verifica se uma feature está habilitada com base em lógica personalizada.
    /// </summary>
    public bool IsFeatureEnabled(string featureName, Func<bool> customLogic)
    {
        // Se a feature flag não estiver habilitada no appsettings.json, retorna falso
        if (!IsFeatureEnabled(featureName))
        {
            return false;
        }

        // Aplica a lógica personalizada
        return customLogic();
    }
}