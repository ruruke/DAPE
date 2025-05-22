using System.Text.Json.Serialization;

namespace KisaragiTech.Dape.Config;

public class DatabaseConfig
{
    [JsonPropertyName("host")]
    public string Host { get; set; }
    [JsonPropertyName("port")]
    public ushort Port { get; set; }
    [JsonPropertyName("user")]
    public string User { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
    
    [JsonConstructor]
    public DatabaseConfig(string host, ushort port, string user, string password)
    {
        Host = host;
        Port = port;
        User = user;
        Password = password;
    }
}

