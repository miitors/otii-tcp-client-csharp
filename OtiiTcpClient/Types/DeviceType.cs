using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace OtiiTcpClient.Types {

    /// <summary>
    /// Defines the possible Otii device types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DeviceType {

        /// <summary>
        /// Otii Arc.
        /// </summary>
        [EnumMember(Value = "Arc")]
        Arc,

        //"{\"data\":{\"timeout\":0},\"type\":\"request\",\"cmd\":\"otii_get_devices\",\"trans_id\":\"1\"}\n"
        //"{\"type\":\"response\",\"cmd\":\"otii_get_devices\",\"trans_id\":\"1\",\"data\":{\"devices\":[{\"device_id\":\"211101200078\",\"name\":\"Ace\",\"type\":\"Ace\"}]}}"
        /// <summary>
        /// Otii Arc.
        /// </summary>
        [EnumMember(Value = "Ace")]
        Ace,

        /// <summary>
        /// UART.
        /// </summary>
        [EnumMember(Value = "UART")]
        Uart,
    }
}