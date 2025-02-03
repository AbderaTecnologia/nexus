using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Nexus.Core.Api.Filters.Response;

namespace Nexus.Core.Api.Extensions;

public static class JsonConfigureExtension
{
    public static IServiceCollection AddConfigureJsonSerializable(this IServiceCollection services)
    {
        services.ConfigureHttpJsonOptions(o => o.SerializerOptions.TypeInfoResolver = JsonContext.Default);

        return services;
    }
}

[JsonSerializable(typeof(ResponseBase<object>))]
public partial class JsonContext : JsonSerializerContext;