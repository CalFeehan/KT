using System.Text.Json.Serialization;

namespace KT.Common.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContactPreference
{
    [JsonPropertyName("Email")]
    Email,
    [JsonPropertyName("Phone")]
    Phone
}
