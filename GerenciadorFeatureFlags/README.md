# Gerenciador de Feature Flags

[![NuGet](https://img.shields.io/nuget/v/GerenciadorFeatureFlags)](https://www.nuget.org/packages/GerenciadorFeatureFlags)
[![Build Status](https://img.shields.io/github/actions/workflow/status/SeuRepositorio/build.yml)](https://github.com/SeuRepositorio/actions)

Uma biblioteca simples e flexível para gerenciar **feature flags** em projetos .NET. Suporta configuração via `appsettings.json` ou diretamente em memória usando um `Dictionary`.

---

## 📦 Instalação

### Via NuGet
Instale o pacote via NuGet Package Manager:
```bash
dotnet add package GerenciadorFeatureFlags
```

Manualmente

Clone o repositório e adicione o projeto como referência.

🚀 Como Usar

A biblioteca oferece dois provedores principais para gerenciar feature flags:
	1.	AppSettingsFeatureFlagProvider: Gerencia feature flags configuradas no appsettings.json.
	2.	InMemoryFeatureFlagProvider: Gerencia feature flags configuradas em um Dictionary.

1. Usando o AppSettingsFeatureFlagProvider

Passo 1: Configurar o appsettings.json

Adicione as feature flags no arquivo appsettings.json:
```csharp
{
  "FeatureFlags": {
    "NovaFuncionalidade": true,
    "FuncionalidadeBeta": false
  }
}
```
Passo 2: Usar o provedor no código

Configure e use o provedor para verificar se as feature flags estão habilitadas:
```csharp
using FeatureFlags;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var featureFlagProvider = new AppSettingsFeatureFlagProvider(configuration);

// Verificar se uma feature está habilitada
bool isEnabled = featureFlagProvider.IsFeatureEnabled("NovaFuncionalidade");
Console.WriteLine($"NovaFuncionalidade está habilitada? {isEnabled}");
```
Passo 3: Usar lógica personalizada (opcional)
```csharp
bool isEnabledWithLogic = featureFlagProvider.IsFeatureEnabled("NovaFuncionalidade", () =>
{
    // Exemplo: habilitar somente antes das 12h
    return DateTime.Now.Hour < 12;
});
Console.WriteLine($"NovaFuncionalidade habilitada com lógica? {isEnabledWithLogic}");
```
2. Usando o InMemoryFeatureFlagProvider

Passo 1: Configurar o Dictionary

Crie um Dictionary com as feature flags:
```csharp
var featureFlags = new Dictionary<string, bool>
{
    { "NovaFuncionalidade", true },
    { "FuncionalidadeBeta", false }
};

var featureFlagProvider = new InMemoryFeatureFlagProvider(featureFlags);
```
Passo 2: Usar o provedor no código
```csharp
// Verificar se uma feature está habilitada
bool isEnabled = featureFlagProvider.IsFeatureEnabled("NovaFuncionalidade");
Console.WriteLine($"NovaFuncionalidade está habilitada? {isEnabled}");
```
Passo 3: Usar lógica personalizada (opcional)
```csharp
bool isEnabledWithLogic = featureFlagProvider.IsFeatureEnabled("NovaFuncionalidade", () =>
{
    // Exemplo: habilitar somente aos domingos
    return DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
});
Console.WriteLine($"NovaFuncionalidade habilitada com lógica? {isEnabledWithLogic}");
```
🛠 Funcionalidades Planejadas
	•	Suporte a persistência em banco de dados.
	•	Interface de gerenciamento via API.
	•	Rollouts progressivos (habilitar para porcentagem de usuários).

🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e enviar pull requests.
	1.	Faça o fork do repositório.
	2.	Crie uma branch para sua funcionalidade: git checkout -b minha-funcionalidade.
	3.	Envie suas alterações: git push origin minha-funcionalidade.

📜 Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo LICENSE para mais detalhes.
