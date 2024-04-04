using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace OtiiTcpClient {

    /// <summary>
    /// Defines the possible current measurement ranges.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MeasurementRange {

        /// <summary>
        /// Enables auto-range.
        /// </summary>
        [EnumMember(Value = "low")]
        Auto,

        /// <summary>
        /// Force high-range.
        /// </summary>
        [EnumMember(Value = "high")]
        High,
    }
}