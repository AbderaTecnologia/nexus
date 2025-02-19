using System.Text.Json.Serialization;
using Nexus.Cadastro.Application.Handlers.Contador.Create;
using Nexus.Cadastro.Domain.Entities;

namespace Nexus.Cadastro.Api.Extensions;

public static class JsonConfigureExtension
{
    public static IServiceCollection AddCadastroConfigureJsonSerializable(this IServiceCollection services)
    {
        services.ConfigureHttpJsonOptions(o => { o.SerializerOptions.TypeInfoResolverChain.Insert(0, CadastroJsonContext.Default); });

        return services;
    }
}

[JsonSerializable(typeof(CreateContadorCommand))]
[JsonSerializable(typeof(Contabilidade))]
public partial class CadastroJsonContext : JsonSerializerContext;