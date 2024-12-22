namespace C3i.GerenciadorFeatureFlags;

public class InMemoryFeatureFlagProvider : IFeatureFlagProvider
{
    private readonly Dictionary<string, bool> _featureFlags;

    public InMemoryFeatureFlagProvider(Dictionary<string, bool> featureFlags)
    {
        _featureFlags = featureFlags;
    }

    /// <summary>
    /// Verifica se uma feature está habilitada usando o dictionary.
    /// </summary>
    public bool IsFeatureEnabled(string featureName)
    {
        return _featureFlags.ContainsKey(featureName) && _featureFlags[featureName];
    }

    /// <summary>
    /// Verifica se uma feature está habilitada com base em lógica personalizada.
    /// </summary>
    public bool IsFeatureEnabled(string featureName, Func<bool> customLogic)
    {
        // Se a feature flag não existir ou não estiver habilitada no dicionário, retorna falso
        if (!IsFeatureEnabled(featureName))
        {
            return false;
        }

        // Aplica a lógica personalizada
        return customLogic();
    }
}