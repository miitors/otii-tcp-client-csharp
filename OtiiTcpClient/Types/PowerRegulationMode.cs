using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace OtiiTcpClient.Types {

    /// <summary>
    /// Defines the available power regulation modes.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PowerRegulationMode {

        /// <summary>
        /// Constant voltage.
        /// </summary>
        [EnumMember(Value = "voltage")]
        Voltage,

        /// <summary>
        /// Constant current.
        /// </summary>
        [EnumMember(Value = "current")]
        Current,

        /// <summary>
        /// Off.
        /// </summary>
        [EnumMember(Value = "off")]
        Off,
    }
}