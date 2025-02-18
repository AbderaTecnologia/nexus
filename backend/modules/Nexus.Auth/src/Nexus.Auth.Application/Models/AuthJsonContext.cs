using System.Text.Json.Serialization;

namespace Nexus.Auth.Application.Models
{
    [JsonSerializable(typeof(LoginResponse))]
    public partial class AuthJsonContext : JsonSerializerContext
    {
    }
}