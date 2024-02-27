using System.Runtime.Serialization;

namespace OtiiTcpClient.Types {

    /// <summary>
    /// Defines the possible Otii device types.
    /// </summary>
    public enum DeviceType {

        /// <summary>
        /// Otii Arc.
        /// </summary>
        [EnumMember(Value = "Arc")]
        Arc,

        /// <summary>
        /// UART.
        /// </summary>
        [EnumMember(Value = "UART")]
        Uart,
    }
}