namespace GerenciadorFeatureFlags;

public interface IFeatureFlagProvider
{
    
    /// <summary>
    /// Verifica se uma feature está habilitada, usando a lógica padrão.
    /// </summary>
    bool IsFeatureEnabled(string featureName);

    /// <summary>
    /// Verifica se uma feature está habilitada, com base em lógica personalizada.
    /// </summary>
    bool IsFeatureEnabled(string featureName, Func<bool> customLogic);
}
