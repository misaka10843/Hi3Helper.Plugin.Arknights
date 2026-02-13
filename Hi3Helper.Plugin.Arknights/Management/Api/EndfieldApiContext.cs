using System.Text.Json.Serialization;

namespace Hi3Helper.Plugin.Arknights.Management.Api;

[JsonSourceGenerationOptions(
    WriteIndented = false,
    PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower)]
[JsonSerializable(typeof(ArknightsBatchRequest))]
[JsonSerializable(typeof(ArknightsBatchResponse))]
public partial class ArknightsApiContext : JsonSerializerContext
{
}