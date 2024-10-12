using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AMP.EMS.API.Core.Constants;

[JsonConverter(typeof(StringEnumConverter))]
public enum RSVPResponse
{
    DECLINE,
    ACCEPT
}
