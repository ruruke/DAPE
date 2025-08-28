using System.Text.Json;
using System.Text.Json.Serialization;

namespace KisaragiTech.Dape.Config;

public class RootConfig
{
    [JsonIgnore]
    private static JsonSerializerOptions options = new()
    {
        IgnoreReadOnlyFields = false, IgnoreReadOnlyProperties = false,
        UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
    };

    [JsonPropertyName("database")]
    public required DatabaseConfig Database { get; init; }

    public static RootConfig DeserializeFromJson(string json) => JsonSerializer.Deserialize<RootConfig>(json, options)!;
}
