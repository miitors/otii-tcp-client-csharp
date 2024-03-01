using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace OtiiTcpClient {

    /// <summary>
    /// Defines the possible Otii message types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MessageType {

        /// <summary>
        /// Request.
        /// </summary>
        [EnumMember(Value = "request")]
        Request,

        /// <summary>
        /// Response.
        /// </summary>
        [EnumMember(Value = "response")]
        Response,

        /// <summary>
        /// Progress notification.
        /// </summary>
        [EnumMember(Value = "progress")]
        Progress,

        /// <summary>
        /// Information notification.
        /// </summary>
        [EnumMember(Value = "information")]
        Information,

        /// <summary>
        /// Error.
        /// </summary>
        [EnumMember(Value = "error")]
        Error,
    }
}