using System.Text.Json.Serialization;

namespace Faruk_NET_6_WEB_API_MVC_Projekat.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight=1,
        Mage=2,
        Cleric=3
    }
}