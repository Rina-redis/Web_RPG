using System.Text.Json.Serialization;

namespace Web_RPG.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Mage, Knight, Healler
    }
}
